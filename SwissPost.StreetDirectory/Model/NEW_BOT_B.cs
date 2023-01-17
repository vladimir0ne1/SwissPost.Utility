using SwissPost.StreetDirectory.Enums;

namespace SwissPost.StreetDirectory.Model;

/// <summary>
/// Contains mail carrier information at house number level (letter delivery).
/// </summary>
public class NEW_BOT_B
{
    /// <summary>
    /// Designates the record type.
    /// </summary>
    public RecordType REC_ART { get; set; }

    /// <summary>
    /// Foreign address key (house, house entrance). Refers to NEW_GEB.
    /// </summary>
    public int HAUSKEY { get; set; }

    /// <summary>
    /// Address postcode.
    /// </summary>
    public int APLZ { get; set; }

    /// <summary>
    /// Postcode of the mail carrier district for letter delivery, for complete address, postcode of the P.O. Box office.
    /// </summary>
    public int BBZPLZ { get; set; }

    /// <summary>
    /// The mail carrier district number is allocated by the delivery point.
    /// </summary>
    public int BOTENBEZ { get; set; }

    /// <summary>
    /// Sequence in district. Always 0 for complete addresses.
    /// </summary>
    public int ETAPPENNR { get; set; }

    /// <summary>
    /// Sequence at stage. Always 0 for complete addresses.
    /// </summary>
    public int LAUFNR { get; set; }

    /// <summary>
    /// Reloading depot.
    /// </summary>
    public string NDEPOT { get; set; }
}