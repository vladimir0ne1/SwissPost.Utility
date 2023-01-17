using SwissPost.StreetDirectory.Enums;

namespace SwissPost.StreetDirectory.Model;

/// <summary>
/// Contains alternative locality and area names for each postcode.
/// </summary>
public class NEW_PLZ2
{
    /// <summary>
    /// Designates the record type.
    /// </summary>
    public RecordType REC_ART { get; set; } = RecordType.PostCodeAlt;

    /// <summary>
    /// Swiss Post classification number (PK).
    /// </summary>
    public int ONRP { get; set; }

    /// <summary>
    /// Sequence number within an ONRP
    /// </summary>
    public int LAUFNUMMER { get; set; }

    /// <summary>
    /// Designation types.
    /// </summary>
    public int BEZTYP { get; set; }

    /// <summary>
    /// Language code
    /// </summary>
    public LanguageCode SPRACHCODE { get; set; }

    /// <summary>
    /// 18-character locality name.
    /// </summary>
    public string ORTBEZ18 { get; set; }

    /// <summary>
    /// 27-character locality name.
    /// </summary>
    public string ORTBEZ27 { get; set; }
}
