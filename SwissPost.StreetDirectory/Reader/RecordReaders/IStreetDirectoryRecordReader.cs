using CsvHelper;

namespace SwissPost.StreetDirectory.Reader.RecordReaders;

public interface IStreetDirectoryRecordReader
{
    void Read(IReaderRow csvReader, StreetDirectoryModel model);
}