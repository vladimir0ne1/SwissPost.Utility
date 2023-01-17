using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using GeoJSON.Text.Feature;
using SwissPost.StreetDirectory;
using SwissPost.StreetDirectory.Reader;
using SwissPost.Utility.GeoJson;

namespace SwissPost.Utility;

/// <summary>
/// Contains logic that converts <see cref="StreetDirectoryModel"/> text file into GeoJSON text file.
/// </summary>
public class StreetDirectoryToGeoJsonConverter
{
    private readonly IGeoJsonConverter geoJsonConverter;

    public StreetDirectoryToGeoJsonConverter(IGeoJsonConverter geoJsonConverter)
    {
        this.geoJsonConverter = geoJsonConverter;
    }

    /// <summary>
    /// Converts StreetDirectory file into GeoJSON file.
    /// </summary>
    /// <param name="sourceFilePath">File path with StreetDirectory database.</param>
    /// <returns>Output file path.</returns>
    /// <exception cref="FileNotFoundException">Thrown if source file not found.</exception>
    public async Task<string> ConvertAsync(string sourceFilePath)
    {
        if (!File.Exists(sourceFilePath))
        {
            throw new FileNotFoundException("Source file not found", sourceFilePath);
        }

        var streetDirectoryModel = await ReadModel(sourceFilePath);
        var geoJsonModel = await ConvertToGeoJson(streetDirectoryModel);
        var outFilePath = FileHelper.GenerateOutputFilePath(sourceFilePath);
        await WriteOutputGeoJsonFile(geoJsonModel, outFilePath);

        return outFilePath;
    }

    private async Task<StreetDirectoryModel> ReadModel(string sourceFilePath)
    {
        var sw = Stopwatch.StartNew();

        Console.WriteLine("Reading StreetDirectory model...");

        var reader = new StreetDirectoryFileReader();
        var model = await reader.ReadAsync(sourceFilePath);

        Console.WriteLine($"Model read from file time: {sw.Elapsed:g}");
        Console.WriteLine($"NEW_HEA: {model.FileInfo.VDAT} / {model.FileInfo.ZCODE}");
        Console.WriteLine($"NEW_PLZ1: {model.PostCodes.Count}");
        Console.WriteLine($"NEW_PLZ21: {model.PostCodesAlt.Count}");
        Console.WriteLine($"NEW_STR: {model.Streets.Count}");
        Console.WriteLine($"NEW_STRA: {model.StreetsAlt.Count}");
        Console.WriteLine($"NEW_GEB: {model.Houses.Count}");
        Console.WriteLine($"NEW_GEBA: {model.HousesAlt.Count}");
        Console.WriteLine($"NEW_COM: {model.PoliticalMunicipalities.Count}");
        Console.WriteLine($"NEW_BOT_B: {model.MailCarriers.Count}");
        Console.WriteLine();

        return model;
    }

    private async Task<FeatureCollection> ConvertToGeoJson(StreetDirectoryModel model)
    {
        Console.WriteLine("Convert StreetDirectory model into GeoJSON model...");

        var sw = Stopwatch.StartNew();

        var geoJson = await geoJsonConverter.ConvertAsync(model);

        Console.WriteLine($"GeoJson build time: {sw.Elapsed:g}");
        Console.WriteLine($"Features Count: {geoJson.Features.Count}");
        Console.WriteLine();

        return geoJson;
    }

    private async Task WriteOutputGeoJsonFile(FeatureCollection geoJson, string outFilePath)
    {
        Console.WriteLine("Write Output GeoJSON File...");

        var sw = Stopwatch.StartNew();

        await using var outFile = File.Create(outFilePath);
        await JsonSerializer.SerializeAsync(outFile, geoJson, new JsonSerializerOptions(){Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)});
        await outFile.DisposeAsync();

        Console.WriteLine($"GeoJson file write time: {sw.Elapsed:g}");
        Console.WriteLine();
    }
}
