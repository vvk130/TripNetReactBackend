using Sieve.Attributes;

namespace TripNetReactBackend.Models;

public record StationDetailsDto
{
    public int Id { get; set; }

    public string? StationName { get; set; }

    public string? StationAddress { get; set; }

    public string? CoordinateX { get; set; }

    public string? CoordinateY { get; set; }

    public int JourneysStartingTotal { get; set; }

    public double JourneysStartingAvgDistance { get; set; }

    public double JourneysStartingAvgDuration { get; set; }

    public int JourneysEndingTotal { get; set; }

}