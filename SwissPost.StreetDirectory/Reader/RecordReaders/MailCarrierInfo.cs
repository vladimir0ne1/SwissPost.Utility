using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader.RecordReaders;

public class MailCarrierInfo : IStreetDirectoryRecordReader
{
    public virtual void Read(IReaderRow csvReader, StreetDirectoryModel model)
    {
        var record = csvReader.GetRecord<NEW_BOT_B>();
        model.MailCarriers[record.HAUSKEY] = record;
    }
}