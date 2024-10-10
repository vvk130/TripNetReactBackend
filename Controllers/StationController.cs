using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Sieve.Services;
using TripNetReactBackend.Models;
using Sieve.Models;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class StationController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ISieveProcessor _sieveprosessor;
    private readonly IMapper _mapper;

    public StationController(AppDbContext context, ISieveProcessor sieveprosessor, IMapper mapper)
    {
        _context = context;
        _sieveprosessor = sieveprosessor;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetSortedFilteredStations([FromQuery] SieveModel sieveModel)
    {
        var models = _context.Stations.ProjectTo<StationDto>(_mapper.ConfigurationProvider);
        models = _sieveprosessor.Apply(sieveModel, models, applyPagination: false);
        Request.HttpContext.Response.Headers.Append("X-Total-Count", models.Count().ToString());
        models = _sieveprosessor.Apply(sieveModel, models, applyFiltering: false, applySorting: false);
        return Ok(models);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<object>>> GetStationDetailsByIdAsync(int id, CancellationToken cancellationToken)
    {
        var stationDetails = await _context.Journeys
        .Where(j => j.DepartureStationId == id || j.ReturnStationId == id)  
        .GroupBy(j => 1)  
        .Select(g => new
        {
            DepartureTotalNum = g.Count(j => j.DepartureStationId == id), 
            ReturnTotalNum = g.Count(j => j.ReturnStationId == id),  
            AvgDepartureDistance = g.Where(j => j.DepartureStationId == id).Average(j => j.Distance), 
            AvgDepartureDuration = g.Where(j => j.DepartureStationId == id).Average(j => j.Duration),  
        })
        .ToListAsync(cancellationToken);

        return !stationDetails.Any() ? NotFound() : Ok(stationDetails);
    }
}
