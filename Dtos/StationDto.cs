using Sieve.Attributes;

namespace TripNetReactBackend.Models;

public record StationDto
{
    [Sieve(CanFilter = true, CanSort = true)]
    public int Id { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string? StationName { get; set; }

    public string? CoordinateX { get; set; }

    public string? CoordinateY { get; set; }
}
