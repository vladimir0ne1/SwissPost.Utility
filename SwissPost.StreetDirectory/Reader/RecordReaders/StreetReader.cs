using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader.RecordReaders;

public class StreetReader : IStreetDirectoryRecordReader
{
    public virtual void Read(IReaderRow csvReader, StreetDirectoryModel model)
    {
        var street = csvReader.GetRecord<NEW_STR>();
        model.Streets[street.STRID] = street;
    }
}