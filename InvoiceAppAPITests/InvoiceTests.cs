using InvoiceWebAPI.Controllers;

namespace InvoiceAppAPITests;

public class InvoiceTests
{
    private Invoice getTestInvoice()
    {
        return new Invoice 
        {
            Id = "RT3080",
            CreatedAt = "2021-08-18",
            Description = "Re-branding",
            ClientName = "Jensen Huang",
            ClientEmail = "jensenh@mail.com",
            Status = "paid",
            PaymentTerms = 1,
            Total = 1800.90,
            SenderAddress = new Address
            {
                Street = "19 Union Terrace",
                City = "London",
                PostCode = "E1 3EZ",
                Country = "United Kingdom"
            },
            ClientAddress = new Address
            {
                Street = "106 Kendell Street",
                City = "Sharrington",
                PostCode = "NR24 5WQ",
                Country = "United Kingdom"
            },
            Items = new List<Item>
            {
                new()
                {
                    Name = "Brand Guidelines",
                    Quantity = 1,
                    Price = 1800.90,
                    Total = 1800.90
                },
                new ()
                {
                    Name ="Email Design",
                    Quantity = 2,
                    Price = 200.00,
                    Total = 400.00
                }
            }
        };
    }
    
    [Theory]
    [InlineData("RT3080","2021-08-18", "Re-branding", "Jensen Huang", "jensenh@mail.com",
        "paid", 1, 1800.90)]
    public void TestCreateInvoice(string expectedId, string expectedCreatedAt, string expectedDescription, 
        string expectedClientName, string expectedClientEmail, string expectedStatus,int expectedPaymentTerms, double expectedTotal)
    {
        var invoice = getTestInvoice();
        
        Assert.Equal(expectedId, invoice.Id);
        Assert.Equal(expectedCreatedAt, invoice.CreatedAt);
        Assert.Equal(expectedDescription, invoice.Description);
        Assert.Equal(expectedClientName, invoice.ClientName);
        Assert.Equal(expectedClientEmail, invoice.ClientEmail);
        Assert.Equal(expectedStatus, invoice.Status);
        Assert.Equal(expectedPaymentTerms, invoice.PaymentTerms);
        Assert.Equal(expectedTotal, invoice.Total);
    }
    [Fact]
    public void InvoiceSenderAddressCreationTest()
    {
        var invoice = getTestInvoice();
        Assert.Equal("19 Union Terrace", invoice.SenderAddress.Street);
        Assert.Equal("London", invoice.SenderAddress.City);
        Assert.Equal("E1 3EZ", invoice.SenderAddress.PostCode);
        Assert.Equal("United Kingdom", invoice.SenderAddress.Country);
    }
    [Fact]
    public void InvoiceClientAddressCreationTest()
    {
        var invoice = getTestInvoice();
        Assert.Equal("106 Kendell Street", invoice.ClientAddress.Street);
        Assert.Equal("Sharrington", invoice.ClientAddress.City);
        Assert.Equal("NR24 5WQ", invoice.ClientAddress.PostCode);
        Assert.Equal("United Kingdom", invoice.ClientAddress.Country);
    }

    [Theory]
    [InlineData("Brand Guidelines", 1, 1800.90, 1800.90, 0)]
    [InlineData("Email Design", 2, 200.00, 400.00, 1)]
    public void ItemCreationTest(string expectedName, int expectedQuntity, double expectedPrice, double expectedTotal, int arrayPointer)
    {
        var invoice = getTestInvoice();
        Assert.Equal(expectedName, invoice.Items[arrayPointer].Name);
        Assert.Equal(expectedQuntity, invoice.Items[arrayPointer].Quantity);
        Assert.Equal(expectedPrice, invoice.Items[arrayPointer].Price);
        Assert.Equal(expectedTotal,invoice.Items[arrayPointer].Total);
    }
    [Fact]
    public void testbla()
    {
    

    }
}