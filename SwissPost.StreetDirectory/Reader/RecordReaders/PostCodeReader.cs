using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader.RecordReaders;

public class PostCodeReader : IStreetDirectoryRecordReader
{
    public virtual void Read(IReaderRow csvReader, StreetDirectoryModel model)
    {
        var locality = csvReader.GetRecord<NEW_PLZ1>();
        model.PostCodes[locality.ONRP] = locality;
    }
}