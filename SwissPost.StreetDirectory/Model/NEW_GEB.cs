using SwissPost.StreetDirectory.Enums;

namespace SwissPost.StreetDirectory.Model;

/// <summary>
/// Contains house numbers and house keys.
/// </summary>
public class NEW_GEB
{
    /// <summary>
    /// Designates the record type.
    /// </summary>
    public RecordType REC_ART { get; set; } = RecordType.House;

    /// <summary>
    /// House key.
    /// </summary>
    public int HOUSEKEY { get; set; }

    /// <summary>
    /// Foreign key for street names (refers to NEW_STR).
    /// </summary>
    public int STRID { get; set; }

    /// <summary>
    /// House number.
    /// </summary>
    public int? HNR { get; set; }

    /// <summary>
    /// Alphanumerical part of the house number.
    /// </summary>
    public string HNRA { get; set; }

    /// <summary>
    /// House number status.
    /// </summary>
    public bool HNR_COFF { get; set; }

    /// <summary>
    /// Complete house number.
    /// </summary>
    public bool? GANZFACH { get; set; }

    /// <summary>
    /// ONRP of the P.O. Box office for complete addresses,
    /// </summary>
    public int? FACH_ONRP { get; set; }
}
