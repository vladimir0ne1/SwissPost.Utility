using System.Collections.Concurrent;
using GeoJSON.Text.Feature;
using GeoJSON.Text.Geometry;
using Microsoft.Extensions.Options;
using SwissPost.StreetDirectory;

namespace SwissPost.Utility.GeoJson;

public interface IGeoJsonConverter
{
    Task<FeatureCollection> ConvertAsync(StreetDirectoryModel model);
}

/// <summary>
/// Provides method(s) to convert <see cref="StreetDirectoryModel"/> to GeoJSON FeatureCollection model.
/// </summary>
public class GeoJsonConverter : IGeoJsonConverter
{
    private readonly IGeoCoordinatesProvider coordinatesProvider;
    private readonly AppOptions config;

    public GeoJsonConverter(IGeoCoordinatesProvider coordinatesProvider, IOptions<AppOptions> options)
    {
        this.coordinatesProvider = coordinatesProvider;
        config = options.Value;
    }

    public async Task<FeatureCollection> ConvertAsync(StreetDirectoryModel model)
    {
        var coordinates = await FetchCoordinatesAsync(model);
        var featureCollection = new FeatureCollection();

        foreach (var address in model.FlatAddresses)
        {
            var feature = MapFeature(address, coordinates[address.Key]);
            featureCollection.Features.Add(feature);
        }

        return featureCollection;
    }

    private Feature MapFeature(FlatAddressModel address, Coordinates coordinates)
    {
        var position = new Position(coordinates.Latitude, coordinates.Longitude);
        var feature = new Feature
        {
            Properties = new Dictionary<string, object>
            {
                { "steet", address.Street },
                { "street number", address.StreetNumber },
                { "zip", address.Zip },
                { "locality", address.Locality },
                { "latitude", coordinates.Latitude },
                { "longitude", coordinates.Longitude },
            },
            Geometry = new Point(position)
        };

        return feature;
    }

    private async Task<IReadOnlyDictionary<string, Coordinates>> FetchCoordinatesAsync(StreetDirectoryModel model)
    {
        ParallelOptions parallelOptions = new() { MaxDegreeOfParallelism = config.ParallelGeoApiRequests };

        var coordinates = new ConcurrentDictionary<string, Coordinates>();

        await Parallel.ForEachAsync(
            model.FlatAddresses,
            parallelOptions,
            async (address, token) =>
            {
                // todo: add error handling
                var addressCoordinates = await coordinatesProvider.GetCoordinatesAsync(address);
                coordinates[address.Key] = addressCoordinates;
            });

        return coordinates;
    }
}
