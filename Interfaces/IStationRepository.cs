namespace TripNetReactBackend.Interfaces;

public interface IStationRepository
{
    bool IsIdUnique(int id);
}