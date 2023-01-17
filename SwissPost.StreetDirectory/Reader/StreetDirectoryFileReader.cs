using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using SwissPost.StreetDirectory.Enums;
using SwissPost.StreetDirectory.Reader.Converters;
using SwissPost.StreetDirectory.Reader.RecordReaders;

namespace SwissPost.StreetDirectory.Reader;

public class StreetDirectoryFileReader
{
    private readonly StreetDirectoryModel model;
    private int readLine;

    private readonly IDictionary<RecordType, IStreetDirectoryRecordReader> rowReaders =
        new Dictionary<RecordType, IStreetDirectoryRecordReader>
        {
            { RecordType.FileInfo, new FileInfoReader() },
            { RecordType.PostCode, new PostCodeReader() },
            { RecordType.PostCodeAlt, new PostCodeAltReader() },
            { RecordType.PoliticalMunicipalities, new PoliticalMunicipalityReader() },
            { RecordType.Street, new StreetReader() },
            { RecordType.StreetAlt, new StreetAltReader() },
            { RecordType.House, new HouseReader() },
            { RecordType.HouseAlt, new HouseAltReader() },
            { RecordType.MailCarrierInfo, new MailCarrierInfo() },
        };

    public StreetDirectoryFileReader()
    {
        model = new StreetDirectoryModel();
    }

    public async Task<StreetDirectoryModel> ReadAsync(string filePath)
    {
        await using var fs = File.OpenRead(filePath);
        return await ReadAsync(fs);
    }
    public async Task<StreetDirectoryModel> ReadAsync(Stream sourceStream)
    {
        var encoding = Encoding.GetEncoding(Constants.Iso88591);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            Delimiter = ";",
            Mode = CsvMode.NoEscape, // double quote is not escaped in source.
            Encoding = encoding
        };

        using var streamReader = new StreamReader(sourceStream, encoding);
        using var csvReader = new CsvReader(streamReader, config);
        csvReader.Context.TypeConverterCache.AddConverter<DateTime>(new DateConverter());
        csvReader.Context.TypeConverterCache.AddConverter<bool>(new BooleanConverter());

        while (await csvReader.ReadAsync())
        {
            ReadRow(csvReader);
            readLine++;
        }

        return model;
    }

    private void ReadRow(IReaderRow csvReader)
    {
        var firstCell = csvReader.GetField(0);

        if (!Enum.TryParse<RecordType>(firstCell, out var recordType) || !rowReaders.ContainsKey(recordType))
        {
            throw new InvalidOperationException($"Line {readLine}: Unknown or unsupported record type '{firstCell}'");
        }

        rowReaders[recordType].Read(csvReader, model);
    }
}
