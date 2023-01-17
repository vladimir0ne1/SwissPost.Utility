using System.Text.Json;
using NUnit.Framework;
using SwissPost.GeoApiClient;

namespace SwissPost.Tests;

public class GeoApiClientTests
{
    [Test]
    public async Task CheckMockResponse()
    {
        using var mockHttpClient = new HttpClient(new MockGeoApiClientHandler());
        var client = new GeoApiClient.GeoApiClient("https://example.com/api/geo", mockHttpClient);
        var request = new GeoApiRequest
        {
            Locality = "abc",
            Street = "sdf",
            StreetNumber = "01",
            Zip = "202",
        };

        var data = await client.PostGeoApi(request);

        Assert.NotNull(data);
        Console.WriteLine(JsonSerializer.Serialize(data, options: new JsonSerializerOptions(){ WriteIndented = true }));
    }
}