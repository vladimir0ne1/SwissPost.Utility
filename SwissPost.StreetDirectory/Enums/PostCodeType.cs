namespace SwissPost.StreetDirectory.Enums;

public enum PostCodeType
{
    /// <summary>
    /// Domicile and specialist addresses.
    /// </summary>
    DomicileAndSpec = 10,

    /// <summary>
    /// Domicile addresses only.
    /// </summary>
    DomicileOnly = 20,

    /// <summary>
    /// P.O. Box postcodes only.
    /// </summary>
    PoBoxOnly = 30,

    /// <summary>
    /// Company postcodes.
    /// </summary>
    Company = 40,

    /// <summary>
    /// In-house Swiss Post postcodes (delivery post office information on bundle labels or bag addresses).
    /// </summary>
    InHouse = 80,
}