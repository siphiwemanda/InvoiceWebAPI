namespace InvoiceWebAPI.Controllers;

public class Invoice
{
    public string Id { get; set; }
    public string CreatedAt { get; set; }
    public string Description { get; set; }
    public string ClientName { get; set; }
    public string ClientEmail { get; set; }
    public string Status { get; set; }
    public int PaymentTerms { get; set; }
    public double Total { get; set; }
    public Address SenderAddress { get; set; }
    public Address ClientAddress { get; set; }
    public List<Item> Items { get; set; }
}