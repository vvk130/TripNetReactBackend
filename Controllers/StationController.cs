using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Sieve.Services;
using TripNetReactBackend.Models;
using Sieve.Models;

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
    public IActionResult GetSortedFilteredModel([FromQuery] SieveModel sieveModel)
    {
        var models = _context.Stations.ProjectTo<StationDto>(_mapper.ConfigurationProvider);
        models = _sieveprosessor.Apply(sieveModel, models, applyPagination: false);
        Request.HttpContext.Response.Headers.Append("X-Total-Count", models.Count().ToString());
        models = _sieveprosessor.Apply(sieveModel, models, applyFiltering: false, applySorting: false);
        return Ok(models);
    }

    // var stations = _context.Stations.ProjectTo<StationDto>(_mapper.ConfigurationProvider);
    // stations = _sieveprosessor.Apply(sieveModel, models, applyPagination: false);
    //     Request.HttpContext.Response.Headers.Append("X-Total-Count", models.Count().ToString());
    //     models = _sieveprosessor.Apply(sieveModel, models, applyFiltering: false, applySorting: false);
    //     return Ok(stations);

    // [HttpGet("{id}")]
    // public IActionResult GetStationById([FromQuery] int id)
    // {

    //     var stations = _context.Stations.ProjectTo<StationDto>(_mapper.ConfigurationProvider);
    //     stations = _sieveprosessor.Apply(sieveModel, stations);
    //     return Ok(pageTotal,stations);
    // }
}
