using TripNetReactBackend.Interfaces;
using TripNetReactBackend.Models;

namespace TripNetReactBackend.Repositories;

public class StationRepository : IStationRepository
{
    private readonly AppDbContext _context;

    public StationRepository(AppDbContext context)
    {
        _context = context;
    }

    public bool IsIdUnique(int id)
    {
        var station = _context.Stations.Find(id);
        return station == null;
    }
}