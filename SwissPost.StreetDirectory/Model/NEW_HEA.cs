using SwissPost.StreetDirectory.Enums;

namespace SwissPost.StreetDirectory.Model;

/// <summary>
/// Contains the version date and a unique random code.
/// </summary>
public class NEW_HEA
{
    /// <summary>
    /// Designates the record type.
    /// </summary>
    public RecordType REC_ART { get; set; }

    /// <summary>
    /// Date of implementation.
    /// </summary>
    public DateTime VDAT { get; set; }

    /// <summary>
    /// Randomly generated code.
    /// </summary>
    public string ZCODE { get; set; }
}
