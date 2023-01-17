using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader.RecordReaders;

public class StreetAltReader : IStreetDirectoryRecordReader
{
    public virtual void Read(IReaderRow csvReader, StreetDirectoryModel model)
    {
        var streetAlt = csvReader.GetRecord<NEW_STRA>();
        model.StreetsAlt[streetAlt.STRID_ALT] = streetAlt;
    }
}