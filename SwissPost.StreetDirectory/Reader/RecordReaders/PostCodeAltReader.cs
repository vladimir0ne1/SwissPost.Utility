using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader.RecordReaders;

public class PostCodeAltReader : IStreetDirectoryRecordReader
{
    public virtual void Read(IReaderRow csvReader, StreetDirectoryModel model)
    {
        var localityAlt = csvReader.GetRecord<NEW_PLZ2>();
        model.PostCodesAlt[localityAlt.ONRP] = localityAlt;
    }
}