using SwissPost.StreetDirectory.Enums;

namespace SwissPost.StreetDirectory.Model;

/// <summary>
/// Contains all the street names of every locality in Switzerland and the Principality of Liechtenstein.
/// </summary>
public class NEW_STR
{
    /// <summary>
    /// Designates the record type.
    /// </summary>
    public RecordType REC_ART { get; set; } = RecordType.Street;

    /// <summary>
    /// Street name (PK).
    /// </summary>
    public int STRID { get; set; }

    /// <summary>
    /// Swiss Post classification number (FK). <see cref="NEW_PLZ1"/>.
    /// </summary>
    public int ONRP { get; set; }

    /// <summary>
    /// Abbreviated street name.
    /// </summary>
    public string STRBEZK { get; set; }

    /// <summary>
    /// Full street name.
    /// </summary>
    public string STRBEZL { get; set; }

    /// <summary>
    /// Abbreviated reorganized street name.
    /// </summary>
    public string STRBEZ2K { get; set; }

    /// <summary>
    /// Reorganized street name.
    /// </summary>
    public string STRBEZ2L { get; set; }

    /// <summary>
    /// Street location type.
    /// </summary>
    public int STR_LOK_TYP { get; set; }

    /// <summary>
    /// Street language.
    /// </summary>
    public LanguageCode STRBEZ_SPC { get; set; }

    /// <summary>
    /// Shows whether a name is officially recognized, i.e. by the political municipality.
    /// </summary>
    public bool STRBEZ_COFF { get; set; }

    /// <summary>
    /// Complete address.
    /// </summary>
    public bool? STR_GANZFACH { get; set; }

    /// <summary>
    /// ONRP of the P.O. Box office.
    /// </summary>
    public int? STR_FACH_ONRP { get; set; }
}
