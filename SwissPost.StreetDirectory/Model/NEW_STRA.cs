using SwissPost.StreetDirectory.Enums;

namespace SwissPost.StreetDirectory.Model;

/// <summary>
/// Logical alternative or foreign language street name for the official street name.
/// Building names without street/house number, area, plot or hamlet names are handled in the same way as street names.
/// </summary>
public class NEW_STRA
{
    /// <summary>
    /// Designates the record type.
    /// </summary>
    public RecordType REC_ART { get; set; } = RecordType.StreetAlt;

    /// <summary>
    /// Primary key for alternative street names.
    /// </summary>
    public int STRID_ALT { get; set; }

    /// <summary>
    /// Foreign key for street names.
    /// </summary>
    public int STRID { get; set; }

    /// <summary>
    /// Street type.
    /// </summary>
    public int STRTYP { get; set; }

    /// <summary>
    /// Alternative street name (abbreviated or foreign language).
    /// </summary>
    public string STRBEZAK { get; set; }

    /// <summary>
    /// Alternative street name.
    /// </summary>
    public string STRBEZAL { get; set; }

    /// <summary>
    /// Reorganized alternative street name (abbreviated or foreign language).
    /// </summary>
    public string STRBEZA2K { get; set; }

    /// <summary>
    /// Reorganized alternative street name.
    /// </summary>
    public string STRBEZA2L { get; set; }

    /// <summary>
    /// Street location type.
    /// </summary>
    public int STR_LOK_TYP { get; set; }

    /// <summary>
    /// Street language.
    /// </summary>
    public LanguageCode STRBEZ_SPC { get; set; }
}
