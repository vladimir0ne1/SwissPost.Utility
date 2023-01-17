using CsvHelper;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory.Reader.RecordReaders;

public class PoliticalMunicipalityReader : IStreetDirectoryRecordReader
{
    public virtual void Read(IReaderRow csvReader, StreetDirectoryModel model)
    {
        var politicalMunicipality = csvReader.GetRecord<NEW_COM>();
        model.PoliticalMunicipalities[politicalMunicipality.BFSNR] = politicalMunicipality;
    }
}