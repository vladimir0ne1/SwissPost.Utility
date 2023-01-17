namespace SwissPost.Utility;

public class AppOptions
{
    public bool UseMockGeoApi { get; set; } = true;
    public string GeoApiUrl { get; set; } = "https://example.com/";
    public int ParallelGeoApiRequests { get; set; } = 30;
    public string SourceFilePath { get; set; }
}