namespace InvoiceWebAPI.Controllers;

public class Item
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double Total { get; set; }
}