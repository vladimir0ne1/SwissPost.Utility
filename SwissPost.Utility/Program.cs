using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SwissPost.GeoApiClient;
using SwissPost.Utility;
using SwissPost.Utility.GeoJson;

// Read config, register services
var config = GetConfig();
Console.WriteLine($"Run Configuration:{Environment.NewLine}{JsonSerializer.Serialize(config, new JsonSerializerOptions{ WriteIndented = true, })}");
StreetDirectoryToGeoJsonConverter fileConverter;
RegisterServices();


// Convert source file to GeoJSON
var globalSw = Stopwatch.StartNew();
var resultFile = await fileConverter.ConvertAsync(config.SourceFilePath);
Console.WriteLine($"Output File: {resultFile}");
Console.WriteLine($"Full time: {globalSw.Elapsed:g}");

// Exit.
Console.WriteLine("Press any key to exit.");
Console.ReadKey();

void RegisterServices()
{
    // Move to DI configuration. Skip for console app.
    var httpClient = config.UseMockGeoApi ? new HttpClient(new MockGeoApiClientHandler()) : new HttpClient(); // Register as singleton
    var geoApiClient = new GeoApiClient(config.GeoApiUrl, httpClient); // Register per request / lifecycle
    var coordinatesProvider = new GeoCoordinatesProvider(geoApiClient); // Register per request / lifecycle
    var modelConverter = new GeoJsonConverter(coordinatesProvider, Options.Create(config)); // Register per request / lifecycle
    fileConverter = new StreetDirectoryToGeoJsonConverter(modelConverter);
}

AppOptions GetConfig()
{
    IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .Build();
    return configuration.GetSection(nameof(AppOptions)).Get<AppOptions>();
}
