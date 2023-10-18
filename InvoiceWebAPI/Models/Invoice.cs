using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace InvoiceWebAPI.Models;

public class Invoice
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("reference")]
    public string Reference { get; set; }
    [BsonElement("createdAt")]
    public string CreatedAt { get; set; }
    [BsonElement("paymentDue")]
    public string PaymentDue { get; set; }
    [BsonElement("description")]
    public string Description { get; set; }
    [BsonElement("clientName")]
    public string ClientName { get; set; }
    [BsonElement("clientEmail")]
    public string ClientEmail { get; set; }
    [BsonElement("status")]
    public string Status { get; set; }
    [BsonElement("paymentTerms")]
    public int PaymentTerms { get; set; }
    [BsonElement("total")]
    public double Total { get; set; }
    [BsonElement("senderAddress")]
    public Address SenderAddress { get; set; }
    [BsonElement("clientAddress")]
    public Address ClientAddress { get; set; }
    [BsonElement("items")]
    public List<Item> Items { get; set; }
}