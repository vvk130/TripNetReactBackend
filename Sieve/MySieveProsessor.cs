using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using TripNetReactBackend.Models;

namespace SievePackage
{
    public class MySieveProcessor : SieveProcessor
    {
        public MySieveProcessor(
            IOptions<SieveOptions> options)
            : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<Station>(p => p.StationName)
                .CanSort()
                .CanFilter();

            return mapper;
        }
    }
}