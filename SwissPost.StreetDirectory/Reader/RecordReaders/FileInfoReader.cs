using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader.RecordReaders;

public class FileInfoReader : IStreetDirectoryRecordReader
{
    public virtual void Read(IReaderRow csvReader, StreetDirectoryModel model)
    {
        model.FileInfo = csvReader.GetRecord<NEW_HEA>();
    }
}