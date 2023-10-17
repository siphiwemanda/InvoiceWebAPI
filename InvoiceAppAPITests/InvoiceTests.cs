using InvoiceWebAPI.Controllers;

namespace InvoiceAppAPITests;

public class InvoiceTests
{
    [Fact]
    public void InvoiceHasId()
    {
        var firstInvoice = new Invoice
        {
            Id = "RT3080"
        };
        Assert.Equal("RT3080", firstInvoice.Id);
    }
    
    [Fact]
    public void InvoiceHasCreatedAt()
    {
        var firstInvoice = new Invoice
        {
            CreatedAt = "2021-08-18"
        };
        Assert.Equal("2021-08-18", firstInvoice.CreatedAt);
    }
    [Fact]
    public void InvoiceHasOtherStringValues()
    {
        var firstInvoice = new Invoice
        {
            Description = "Re-branding",
            ClientName = "Jensen Huang",
            ClientEmail = "jensenh@mail.com",
            Status = "paid"
        };
        Assert.Equal("Re-branding", firstInvoice.Description);
        Assert.Equal("Jensen Huang", firstInvoice.ClientName);
        Assert.Equal("jensenh@mail.com", firstInvoice.ClientEmail);
        Assert.Equal("paid", firstInvoice.Status);
    }
    [Fact]
    public void InvoiceHasPaymentTerms()
    {
        var firstInvoice = new Invoice
        {
            PaymentTerms = 1
        };
        Assert.Equal(1, firstInvoice.PaymentTerms);
    }
    [Fact]
    public void InvoiceHasTotal()
    {
        var firstInvoice = new Invoice
        {
            Total = 1800.90
        };
        Assert.Equal(1800.90, firstInvoice.Total);
    }
    
    [Fact]
    public void InvoiceHasAllTopLevelValues()
    {
        var firstInvoice = new Invoice
        {
            Description = "Re-branding",
            ClientName = "Jensen Huang",
            ClientEmail = "jensenh@mail.com",
            Status = "paid",
            Total = 1800.90,
            PaymentTerms = 1,
            CreatedAt = "2021-08-18",
            Id = "RT3080"
        };
        Assert.Equal("Re-branding", firstInvoice.Description);
        Assert.Equal("Jensen Huang", firstInvoice.ClientName);
        Assert.Equal("jensenh@mail.com", firstInvoice.ClientEmail);
        Assert.Equal("paid", firstInvoice.Status);
        Assert.Equal(1800.90, firstInvoice.Total);
        Assert.Equal(1, firstInvoice.PaymentTerms);
        Assert.Equal("2021-08-18", firstInvoice.CreatedAt);
        Assert.Equal("RT3080", firstInvoice.Id);
    }
    
    [Fact]
    public void SenderAddressCreationTest()
    {
        var senderAddress = new Address
        {
            Street = "19 Union Terrace",
            City = "London",
            PostCode = "E1 3EZ",
            Country = "United Kingdom"
        };
        Assert.Equal("19 Union Terrace", senderAddress.Street);
        Assert.Equal("London", senderAddress.City);
        Assert.Equal("E1 3EZ", senderAddress.PostCode);
        Assert.Equal("United Kingdom", senderAddress.Country);
    }
    [Fact]
    public void InvoiceSenderAddressCreationTest()
    {
        var firstInvoice = new Invoice
        {
            SenderAddress = new Address{
                Street = "19 Union Terrace",
                City = "London",
                PostCode = "E1 3EZ",
                Country = "United Kingdom"}
        };
        Assert.Equal("19 Union Terrace", firstInvoice.SenderAddress.Street);
        Assert.Equal("London", firstInvoice.SenderAddress.City);
        Assert.Equal("E1 3EZ", firstInvoice.SenderAddress.PostCode);
        Assert.Equal("United Kingdom", firstInvoice.SenderAddress.Country);
    }
    [Fact]
    public void InvoiceClientAddressCreationTest()
    {
        var firstInvoice = new Invoice
        {
            ClientAddress = new Address{
                Street = "106 Kendell Street",
                City = "Sharrington",
                PostCode = "NR24 5WQ",
                Country = "United Kingdom"}
        };
        Assert.Equal("106 Kendell Street", firstInvoice.ClientAddress.Street);
        Assert.Equal("Sharrington", firstInvoice.ClientAddress.City);
        Assert.Equal("NR24 5WQ", firstInvoice.ClientAddress.PostCode);
        Assert.Equal("United Kingdom", firstInvoice.ClientAddress.Country);
    }
    [Fact]
    public void ItemCreationTest()
    {
        var item = new Item()
        {
            Name = "Brand Guidelines",
            Quantity = 1,
            Price = 1800.90,
            Total = 1800.90
        };
        Assert.Equal("Brand Guidelines", item.Name);
        Assert.Equal(1, item.Quantity);
        Assert.Equal(1800.90, item.Price);
        Assert.Equal(1800.90,item.Total);
    }
    [Fact]
    public void InvoiceItemCreationTest()
    {
        var invoice = new Invoice
        {
            Items = new List<Item>
            {
                new()
                {
                    Name = "Brand Guidelines",
                    Quantity = 1,
                    Price = 1800.90,
                    Total = 1800.90
                }
            }
        };
        Assert.Equal("Brand Guidelines", invoice.Items[0].Name);
        Assert.Equal(1, invoice.Items[0].Quantity);
        Assert.Equal(1800.90, invoice.Items[0].Price);
        Assert.Equal(1800.90,invoice.Items[0].Total);
    }
}