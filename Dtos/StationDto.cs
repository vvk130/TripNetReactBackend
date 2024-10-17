using FluentValidation;
using Sieve.Attributes;

namespace TripNetReactBackend.Models;

public record StationDto
{
    [Sieve(CanFilter = true, CanSort = true)]
    public int Id { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string? StationName { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string? StationAddress { get; set; }

    public string? CoordinateX { get; set; }

    public string? CoordinateY { get; set; }

    public class StationValidator : AbstractValidator<Station>
    {
        public StationValidator()
        {
            RuleFor(t => t.StationName).MaximumLength(100);
            RuleFor(t => t.StationAddress).MaximumLength(100);
            RuleFor(s => s.CoordinateY).Matches(@"^-? ([0 - 9]{1,2}| 1[0 - 7][0 - 9] | 180)(\.[0 - 9]{ 1,16})$");
            RuleFor(s => s.CoordinateX).Matches(@"^-?([0-8]?[0-9]|90)(\.[0-9]{1,16})$");
        }
    }
}
