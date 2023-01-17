using System.Net;
using System.Text;
using System.Text.Json;

namespace SwissPost.GeoApiClient;

public class MockGeoApiClientHandler : HttpClientHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var data = new GeoApiResponse
        {
            Latitude = 47.959619773998682,
            Longitude = 8.5317748121599557,
        };

        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8)
        };

        return Task.FromResult(response);
    }
}
