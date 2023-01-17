using SwissPost.StreetDirectory.Enums;

namespace SwissPost.StreetDirectory.Model;

/// <summary>
/// Contains all postcodes valid for addresses in Switzerland and the Principality of Liechtenstein.
/// </summary>
public class NEW_PLZ1
{
    /// <summary>
    /// Designates the record type.
    /// </summary>
    public RecordType REC_ART { get; set; }

    /// <summary>
    /// Swiss Post classification number (PK).
    /// </summary>
    public int ONRP { get; set; }

    /// <summary>
    /// Foreign key for BFSNR (refers to <see cref="NEW_COM"/>)
    /// </summary>
    public int BFSNR { get; set; }

    /// <summary>
    /// Postcode type.
    /// </summary>
    public PostCodeType PLZ_TYP { get; set; }

    /// <summary>
    /// Address postcode.
    /// </summary>
    public int POSTCODE { get; set; }

    /// <summary>
    /// Additional postcode number.
    /// </summary>
    public string PLZ_ZZ { get; set; }

    /// <summary>
    /// Basic postcode.
    /// </summary>
    public int GPLZ { get; set; }

    /// <summary>
    /// 18-character locality name.
    /// </summary>
    /// <example>Neuhausen</example>
    public string ORTBEZ18 { get; set; }

    /// <summary>
    /// 27-character locality name.
    /// </summary>
    /// <example>Neuhausen am Rheinfall</example>
    public string ORTBEZ27 { get; set; }

    /// <summary>
    /// Canton.
    /// </summary>
    public string KANTON { get; set; }

    /// <summary>
    /// Language code
    /// </summary>
    public LanguageCode SPRACHCODE { get; set; }

    /// <summary>
    /// Different language code.
    /// </summary>
    public int? SPRACHCODE_ABW { get; set; }

    /// <summary>
    /// Delivery point.
    /// </summary>
    public int? BRIEFZ_DURCH { get; set; }

    /// <summary>
    /// Valid as of.
    /// </summary>
    public DateTime GILT_AB_DAT { get; set; }

    /// <summary>
    /// Delivery point postcode.
    /// </summary>
    public int PLZ_BRIEFZUST { get; set; }

    /// <summary>
    /// Shows whether a postcode (PLZ_TYP 10 and PLZ_TYP 20) contains exclusively official or unofficial addresses
    /// </summary>
    public bool? PLZ_COFF { get; set; }
}
