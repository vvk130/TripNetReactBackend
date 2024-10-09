using Sieve.Attributes;
using Sieve.Models;

namespace TripNetReactBackend.Models;

public class StationDto : SieveModel
{
    public int Id { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string? StationName { get; set; }

    public string? CoordinateX { get; set; }

    public string? CoordinateY { get; set; }
}
