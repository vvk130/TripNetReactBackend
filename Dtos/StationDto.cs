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

    public class StationDtoValidator : AbstractValidator<StationDto>
    {
        public StationDtoValidator()
        {
            RuleFor(t => t.StationName).MaximumLength(100);
            RuleFor(t => t.StationAddress).MaximumLength(100);
            RuleFor(s => s.CoordinateX)
                .Matches(@"^-?(?:[0-9]{1,2}|1[0-7][0-9]|180)(\.[0-9]{1,16})?$")
                .WithMessage("X coordinate needs to be between -180 and 180, and can have up to 16 decimal places.");

            RuleFor(s => s.CoordinateY)
                .Matches(@"^-?(?:[0-8]?[0-9]|90)(\.[0-9]{1,16})?$")
                .WithMessage("Y coordinate needs to be between -90 and 90, and can have up to 16 decimal places.");
        }

    }


}

