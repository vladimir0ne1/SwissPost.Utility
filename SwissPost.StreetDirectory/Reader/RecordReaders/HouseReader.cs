using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader.RecordReaders;

public class HouseReader : IStreetDirectoryRecordReader
{
    public virtual void Read(IReaderRow csvReader, StreetDirectoryModel model)
    {
        var house = csvReader.GetRecord<NEW_GEB>();
        model.Houses[house.HOUSEKEY] = house;
    }
}
