using SwissPost.StreetDirectory.Enums;

namespace SwissPost.StreetDirectory.Model;

/// <summary>
/// Contains the political municipalities in Switzerland and the Principality of Liechtenstein.
/// These data are taken from the official list of the Swiss Federal Statistical Office (BFS).
/// </summary>
public class NEW_COM
{
    /// <summary>
    /// Designates the record type.
    /// </summary>
    public RecordType REC_ART { get; set; }

    /// <summary>
    /// BFS number.
    /// </summary>
    public int BFSNR { get; set; }

    /// <summary>
    /// Municipality name.
    /// </summary>
    public string GEMEINDENAME { get; set; }

    /// <summary>
    /// Canton.
    /// </summary>
    public string KANTON { get; set; }

    /// <summary>
    /// Conurbation number.
    /// </summary>
    public int? AGGLONR { get; set; }
}
