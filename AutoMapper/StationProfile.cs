using AutoMapper;
using TripNetReactBackend.Models;

public class StationProfile : Profile
{
    public StationProfile()
    {
        CreateMap<Station, StationDto>().ReverseMap();
        CreateMap<Station, StationDetailsDto>().ReverseMap();
    }
}