namespace SwissPost.StreetDirectory.Enums;

public enum RecordType
{
    /// <summary>
    /// NEW_HEA.
    /// </summary>
    FileInfo = 00,

    /// <summary>
    /// NEW_PLZ1.
    /// </summary>
    PostCode = 01,

    /// <summary>
    /// NEW_PLZ2.
    /// </summary>
    PostCodeAlt = 02,

    /// <summary>
    /// NEW_COM.
    /// </summary>
    PoliticalMunicipalities = 03,

    /// <summary>
    /// NEW_STR.
    /// </summary>
    Street = 04,

    /// <summary>
    /// NEW_STRA.
    /// </summary>
    StreetAlt = 05,

    /// <summary>
    /// NEW_GEB.
    /// </summary>
    House = 06,

    /// <summary>
    /// NEW_GEBA.
    /// </summary>
    HouseAlt = 07,

    /// <summary>
    /// NEW_BOT_B.
    /// </summary>
    MailCarrierInfo = 08,

    /// <summary>
    /// NEW_GEB_COM.
    /// </summary>
    BuildingMunicipalityLink = 12,

    /// <summary>
    /// NEW_GEO.
    /// </summary>
    GeoRef = 10,

    /// <summary>
    /// NEW_HH.
    /// </summary>
    HouseHolds = 11,
}