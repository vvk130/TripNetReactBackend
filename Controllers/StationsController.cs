using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Sieve.Services;
using TripNetReactBackend.Models;
using Sieve.Models;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class StationsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ISieveProcessor _sieveprosessor;
    private readonly IMapper _mapper;

    public StationsController(AppDbContext context, ISieveProcessor sieveprosessor, IMapper mapper)
    {
        _context = context;
        _sieveprosessor = sieveprosessor;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetSortedFilteredStations([FromQuery] SieveModel sieveModel)
    {
        var models = _context.Stations.ProjectTo<StationDto>(_mapper.ConfigurationProvider);
        if (models is null) { 
            return NotFound();
        }
        models = _sieveprosessor.Apply(sieveModel, models, applyPagination: false);
        var count = models.Count();
        var requestedPageSize = SetPageSizeMax10NotNull(sieveModel.PageSize);
        models = _sieveprosessor.Apply(sieveModel, models, applyFiltering: false, applySorting: false);
        var result = new
        {
            count,
            pagesTotal = Math.Ceiling((double)count / (double)requestedPageSize),
            data = models,
        };
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStation([FromBody] StationDto stationDto)
    {
        var station = _mapper.Map<Station>(stationDto);
        await _context.Stations.AddAsync(station);
        await _context.SaveChangesAsync();
        return Created();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<object>>> GetStationDetailsByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var station = await _context.Stations.FindAsync(id, cancellationToken);

        if (station == null)
        {
            return NotFound();
        }

        var stationDto = _mapper.Map<StationDto>(station);

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

        var result = new
        {
            stationDto,
            stationDetails
        };

        return Ok(result);
        }

        [HttpGet("next-available-id")]
        public async Task<ActionResult> GetNextFreeId()
        {
            var maxId = await _context.Stations.MaxAsync(station => station.Id);
            var nextFreeId = maxId + 1; 
            return Ok(nextFreeId);
        }
        private int SetPageSizeMax10NotNull(int? pageSize)
        {
            return pageSize switch
            {
                null => 10,        
                > 10 => 10,       
                _ => pageSize.Value
            };
        }
}
