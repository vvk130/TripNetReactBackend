using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using TripNetReactBackend.Models;

namespace SievePackage
{
    public class StationDtoSieveProsessor : SieveProcessor
    {
        public StationDtoSieveProsessor(
            IOptions<SieveOptions> options)
            : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<StationDto>(p => p.StationName)
                .CanSort()
                .CanFilter();

            return mapper;
        }
    }
}