using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader.RecordReaders;

public class HouseAltReader : IStreetDirectoryRecordReader
{
    public virtual void Read(IReaderRow csvReader, StreetDirectoryModel model)
    {
        var houseAlt = csvReader.GetRecord<NEW_GEBA>();
        model.HousesAlt[houseAlt.HAUSKEY_ALT] = houseAlt;
    }
}