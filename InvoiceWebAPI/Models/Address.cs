using MongoDB.Bson.Serialization.Attributes;

namespace InvoiceWebAPI.Models;

public class Address
{
    [BsonElement("street")]
    public string Street { get; set; }
    [BsonElement("city")]
    public string City { get; set; }
    [BsonElement("postCode")]
    public string PostCode { get; set; }
    [BsonElement("country")]
    public string Country { get; set; }
}