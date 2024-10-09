using System.ComponentModel.DataAnnotations;
using Sieve.Attributes;
using Sieve.Models;

namespace JourneyApp1.Server.Models;

public class Station : SieveModel
{
    [Key]
    public int Id { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? CoordinateX { get; set; }

    public string? CoordinateY { get; set; }
}