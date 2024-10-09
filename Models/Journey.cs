using System.ComponentModel.DataAnnotations;

namespace JourneyApp1.Server.Models;

public class Journey
{
    [Key]
    public int Id { get; set; }

    public DateTime? DepartTime { get; set; }

    public DateTime? ReturnTime { get; set; }

    public int DepartStationId { get; set; }

    public int ReturnStationId { get; set; }

    public int? Distance { get; set; }

    public int? Duration { get; set; }
}