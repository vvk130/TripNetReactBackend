using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using TripNetReactBackend.Models;

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
        models = _sieveprosessor.Apply(sieveModel, models);
        return Ok(models);
    }
}
