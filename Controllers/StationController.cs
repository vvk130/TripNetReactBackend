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

    public StationController(AppDbContext context, ISieveProcessor sieveprosessor)
    {
        _context = context;
        _sieveprosessor = sieveprosessor;

}

// [HttpGet]
// public async Task<ActionResult<IEnumerable<Station>>> GetStations()
// {
//     var stations = await _context.Stations
//                                   .Take(10) 
//                                   .ToListAsync();

//     if (stations == null || stations.Count == 0)
//     {
//         return NotFound("No stations found.");
//     }

//     return Ok(stations);
// }

    [HttpGet]
    public IActionResult GetSortedFilteredModel([FromQuery] SieveModel sieveModel)
    {
        var models = _context.Stations.AsNoTracking();
        models = _sieveprosessor.Apply(sieveModel, models);
        return Ok(models);
    }


}
