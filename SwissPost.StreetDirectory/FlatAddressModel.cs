using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory;

/// <summary>
/// Represents flat address info: Locality/Zip, Street, House.
/// Locality and Street are UTF8-friendly strings.
/// </summary>
public class FlatAddressModel
{
    /// <summary>
    /// Flat address uniq key - surrogate key of NEW_PLZ1, NEW_STR, NEW_GEB
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// The locality line in the postal address.
    /// The <see cref="NEW_PLZ1.ORTBEZ27"/>
    /// </summary>
    public string Locality { get; set; }

    /// <summary>
    /// Post code.
    /// The <see cref="NEW_PLZ1.POSTCODE"/>.
    /// </summary>
    public int Zip { get; set; }

    /// <summary>
    /// Street name.
    /// The <see cref="NEW_STR.STRBEZL"/>.
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    /// Numerical part of the house number.
    /// </summary>
    public int? HouseNumber { get; set; }

    /// <summary>
    /// Alphanumerical part of the house number.
    /// </summary>
    public string HouseLetter { get; set; }

    /// <summary>
    /// Combined House Number and House Letter.
    /// </summary>
    public string StreetNumber => $"{HouseNumber}{HouseLetter}";
}