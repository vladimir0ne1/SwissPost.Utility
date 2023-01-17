using System.Net.Http.Json;

namespace SwissPost.GeoApiClient;

public interface IGeoApiClient
{
    Task<GeoApiResponse> PostGeoApi(GeoApiRequest request);
}

public class GeoApiClient : IGeoApiClient
{
    private readonly string baseUrl;
    private readonly HttpClient httpClient;

    public GeoApiClient(string baseUrl, HttpClient httpClient)
    {
        if (string.IsNullOrEmpty(baseUrl))
        {
            throw new ArgumentException("Base Url can not be null or empty", nameof(this.baseUrl));
        }

        this.baseUrl = baseUrl.TrimEnd('/');
        this.httpClient = httpClient;
    }

    public virtual async Task<GeoApiResponse> PostGeoApi(GeoApiRequest request)
    {
        var response = await httpClient.PostAsJsonAsync($"{baseUrl}/api/geo", request);

        var responseModel = await response.Content.ReadFromJsonAsync<GeoApiResponse>();

        return responseModel;
    }
}
