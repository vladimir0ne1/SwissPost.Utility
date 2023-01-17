using SwissPost.GeoApiClient;
using SwissPost.StreetDirectory;

namespace SwissPost.Utility.GeoJson;

public class GeoCoordinatesProvider : IGeoCoordinatesProvider
{
    private readonly IGeoApiClient geoApiClient;

    public GeoCoordinatesProvider(IGeoApiClient geoApiClient)
    {
        this.geoApiClient = geoApiClient;
    }

    public async Task<Coordinates> GetCoordinatesAsync(FlatAddressModel address)
    {
        var request = new GeoApiRequest
        {
            Locality = address.Locality,
            Street = address.Street,
            StreetNumber = address.StreetNumber,
            Zip = address.Zip.ToString(),
        };

        var result = await geoApiClient.PostGeoApi(request);

        return new Coordinates
        {
            Latitude = result.Latitude,
            Longitude = result.Longitude,
        };
    }
}
