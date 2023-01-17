using System.Text;
using SwissPost.StreetDirectory.Model;

namespace SwissPost.StreetDirectory;

/// <summary>
/// Represents Street Directory database.
/// </summary>
public class StreetDirectoryModel
{
    private static readonly Encoding SrcEncoding = Encoding.GetEncoding(Constants.Iso88591);

    public NEW_HEA FileInfo { get; set; }

    /// <summary>
    /// Dictionary of Postcodes (NEW_PLZ1).
    /// Key is Postcode primary key: NEW_PLZ1.ONRP.
    /// </summary>
    public Dictionary<int, NEW_PLZ1> PostCodes { get; } = new();

    /// <summary>
    /// Dictionary of Postcodes (NEW_PLZ2).
    /// Key is Postcode primary key:  NEW_PLZ2.ONRP.
    /// </summary>
    public Dictionary<int, NEW_PLZ2> PostCodesAlt { get; } = new();

    /// <summary>
    /// Dictionary of Political Municipalities (NEW_COM).
    /// Key is NEW_COM.BFSNR.
    /// </summary>
    public Dictionary<int, NEW_COM> PoliticalMunicipalities { get; } = new();

    /// <summary>
    /// Dictionary of Streets (NEW_STR).
    /// Key is NEW_STR.STRID.
    /// </summary>
    public Dictionary<int, NEW_STR> Streets { get; } = new();

    /// <summary>
    /// Dictionary of Streets alternative names (NEW_STRA).
    /// Key is NEW_STRA.STRID_ALT.
    /// </summary>
    public Dictionary<int, NEW_STRA> StreetsAlt { get; } = new();

    /// <summary>
    /// Dictionary of houses (NEW_GEB).
    /// Key is NEW_GEB.HOUSEKEY.
    /// </summary>
    public Dictionary<int, NEW_GEB> Houses { get; } = new();

    /// <summary>
    /// Dictionary of alternative houses (NEW_GEBA).
    /// Key is NEW_GEBA.HAUSKEY_ALT.
    /// </summary>
    public Dictionary<int, NEW_GEBA> HousesAlt { get; } = new();

    /// <summary>
    /// Dictionary of Mail Carriers (NEW_BOT_B).
    /// Key is NEW_BOT_B.HAUSKEY.
    /// </summary>
    public Dictionary<int, NEW_BOT_B> MailCarriers { get; } = new();

    /// <summary>
    /// Enumeration of all available addresses in FLAT format, eg. house JOIN street JOIN postcode
    /// </summary>
    /// <value>Enumeration of <see cref="FlatAddressModel"/>.</value>
    public IEnumerable<FlatAddressModel> FlatAddresses
    {
        get
        {
            foreach (var house in Houses.Values)
            {
                var street = Streets[house.STRID];
                var postInfo = PostCodes[street.ONRP];

                yield return new FlatAddressModel
                {
                    Key = $"{postInfo.ONRP}-{street.STRID}-{house.HOUSEKEY}",
                    Locality = GetUtf8FriendlyText(postInfo.ORTBEZ27),
                    Street = GetUtf8FriendlyText(street.STRBEZL),
                    HouseNumber = house.HNR,
                    HouseLetter = house.HNRA,
                    Zip = postInfo.POSTCODE,
                };
            }
        }
    }

    /// <summary>
    /// Source data is in ISO-8859-1 encoding.
    /// This method converts it to UTF-8.
    /// </summary>
    /// <param name="source">ISO-8859-1 encoded string.</param>
    /// <returns>UTF-8 encoded string.</returns>
    private static string GetUtf8FriendlyText(string source)
    {
        return Encoding.UTF8.GetString(Encoding.Convert(SrcEncoding, Encoding.UTF8, SrcEncoding.GetBytes(source)));
    }
}
