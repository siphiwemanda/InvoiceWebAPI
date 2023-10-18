using MongoDB.Bson.Serialization.Attributes;

namespace InvoiceWebAPI.Models;

public class Item
{
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("quantity")]
    public int Quantity { get; set; }
    [BsonElement("price")]
    public double Price { get; set; }
    [BsonElement("total")]
    public double Total { get; set; }
}