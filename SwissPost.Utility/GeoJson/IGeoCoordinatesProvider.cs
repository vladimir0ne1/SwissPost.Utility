using SwissPost.StreetDirectory;

namespace SwissPost.Utility.GeoJson;

public interface IGeoCoordinatesProvider
{
    Task<Coordinates> GetCoordinatesAsync(FlatAddressModel address);
}
