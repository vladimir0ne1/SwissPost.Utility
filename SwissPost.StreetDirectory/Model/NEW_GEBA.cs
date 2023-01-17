using SwissPost.StreetDirectory.Enums;

namespace SwissPost.StreetDirectory.Model;

/// <summary>
/// Contains alternative house names and alternative house keys
/// </summary>
public class NEW_GEBA
{
    /// <summary>
    /// Designates the record type.
    /// </summary>
    public RecordType REC_ART { get; set; }

    /// <summary>
    /// House key (PK).
    /// </summary>
    public int HAUSKEY_ALT { get; set; }

    /// <summary>
    /// Foreign address key (house, house entrance). Refers to <see cref="NEW_GEB"/>.
    /// </summary>
    public int HAUSKEY { get; set; }

    /// <summary>
    /// Additional building name.
    /// </summary>
    public string GEB_BEZ_ALT { get; set; }

    /// <summary>
    /// Address with alternative building name.
    /// </summary>
    public int GEBTYP { get; set; }
}