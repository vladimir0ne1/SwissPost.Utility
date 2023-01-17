using System.Diagnostics;
using System.Text;
using System.Text.Json;
using GeoJSON.Text.Feature;
using GeoJSON.Text.Geometry;
using NUnit.Framework;
using SwissPost.StreetDirectory;
using SwissPost.StreetDirectory.Enums;
using SwissPost.StreetDirectory.Reader;

namespace SwissPost.Tests;

public class DevTests
{
    [Test]
    public async Task ReadFromMemory()
    {
        var byteArray = Encoding.UTF8.GetBytes("01;104;5586;20;1000;00;1000;\"Lausanne;Lausanne;VD;2;;130;19880301;100060;N");
        var stream = new MemoryStream(byteArray);

        var reader = new StreetDirectoryFileReader();
        var model = await reader.ReadAsync(stream);

        Assert.AreEqual("Lausanne", model.PostCodes[0].ORTBEZ27);
    }

    [TestCase("04;76101726;4312;PB zweihundert;BK Anlage \"200er\";PB zweihundert;BK Anlage \"200er\";2;1;J;N;")]
    [TestCase("04;76101726;4312;PB zweihundert;BK Anlage 200er;PB zweihundert;BK Anlage 200er;2;1;J;N;")]
    public async Task ReadFromMemory04(string row)
    {
        var byteArray = Encoding.UTF8.GetBytes(row);
        var stream = new MemoryStream(byteArray);

        var reader = new StreetDirectoryFileReader();
        var model = await reader.ReadAsync(stream);

        Assert.AreEqual("PB zweihundert", model.Streets[0].STRBEZK);
    }

    [Test]
    public async Task ReadFromFile()
    {
        const string file = @"TestData\Sample.csv";
        var srcEncoding = Encoding.GetEncoding(Constants.Iso88591);

        var reader = new StreetDirectoryFileReader();
        var model = await reader.ReadAsync(file);

        await File.WriteAllLinesAsync("WriteLines.txt", new []{model.PostCodes[105].ORTBEZ27 }, Encoding.GetEncoding(Constants.Iso88591));

        // play with encoding's. UTF8 <-> ISO-8859-1
        var expectedText = "Lausanne 1 Dépôt";
        var expectedInSourceEncoding = Encoding.UTF8.GetString(
            Encoding.Convert(srcEncoding, Encoding.UTF8, srcEncoding.GetBytes(expectedText)));
        Assert.AreEqual(expectedInSourceEncoding, model.PostCodes[105].ORTBEZ27);
    }

    [Test]
    public async Task E2EReadWriteRead_CheckEncodingPersists()
    {
        var srcEncoding = Encoding.GetEncoding(Constants.Iso88591);

        // read source model
        const string file = @"TestData\Sample.csv";
        var reader = new StreetDirectoryFileReader();
        var model = await reader.ReadAsync(file);

        // write line with special symbol(s)
        await File.WriteAllLinesAsync("test_out.txt", new []{model.PostCodes[105].ORTBEZ27 }, Encoding.GetEncoding(Constants.Iso88591));

        // read again and check encoding persists.
        await using var testResultFile = File.OpenRead("test_out.txt");
        using var sr = new StreamReader(testResultFile, srcEncoding);

        Assert.AreEqual(model.PostCodes[105].ORTBEZ27, await sr.ReadLineAsync());
    }

    [Test]
    public async Task ReadReal()
    {
        const string file = @"C:\Projects\Aterise\TestTasks\SwissPostToGeoJsonConverter\Docs\Backend Task\Post_Adressdaten20170425.csv";

        var sw = Stopwatch.StartNew();
        var reader = new StreetDirectoryFileReader();
        var model = await reader.ReadAsync(file);

        sw.Stop();
        Console.WriteLine(sw.Elapsed.TotalSeconds);

        Assert.AreEqual("Lausanne", model.PostCodes[0].ORTBEZ27);
    }

    [TestCase("00")]
    [TestCase("01")]
    [TestCase("02")]
    [TestCase("03")]
    [TestCase("04")]
    [TestCase("05")]
    public void TestPaddedEnumParser(string code)
    {
        var isOk = Enum.TryParse<LanguageCode>(code, true, out var result);

        Console.WriteLine($"{code} - {isOk}/{Enum.IsDefined(result)} - {result}");
    }

    [Test]
    public void TestGeoJson()
    {
        var position = new Position(51.899523, -2.124156);
        var point = new Point(position);

        var featureCollection = new FeatureCollection();
        var feature = new Feature
        {
            Geometry = point,
            Properties = new Dictionary<string, object>()
            {
                { "street", "Somewhere" },
                { "street number", "12" },
                { "zip", "22278" },
                { "locality", "locality 1" },
            },
        };
        featureCollection.Features.Add(feature);

        var json = JsonSerializer.Serialize(featureCollection);
        Console.WriteLine(json);
    }
}
