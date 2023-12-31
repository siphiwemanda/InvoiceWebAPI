using InvoiceWebAPI.Controllers;
using InvoiceWebAPI.Domain;
using InvoiceWebAPI.Models;

namespace InvoiceAppAPITests;

public class InvoiceTests
{
    private Invoice getTestInvoice()
    {
        return new Invoice 
        {
            Reference = "RT3080",
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

    private Invoice getTestUpdateInvoice()
    {
        return new Invoice
        {
            Reference = "RT3080",
            CreatedAt = "2021-08-18",
            Description = "Jazz",
            ClientName = "Jensen Huang",
            ClientEmail = "jensenh@mail.com",
            Status = "paid",
            PaymentTerms = 1,
            Total = 1234.56,
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
        
        Assert.Equal(expectedId, invoice.Reference);
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
    public void TestReturnAllInvoices()
    {
        var expected = typeof(List<Invoice>);
        var invoice = CreateInvoice.GetInvoices();
        Assert.IsType<List<Invoice>>(invoice);
        Assert.IsType(expected, invoice);
    }
    
    [Theory]
    [InlineData("RT3080")]
    public void TestReturnInvoicesWithId(string id)
    {
        var invoice = CreateInvoice.GetInvoice(id);
        Assert.Equal(invoice.Id, id);
    }
    //Adam Brumby's Hack -- this was all his idea 
    //[Theory][InlineData("RT3080")]
    //public void TestReturnInvoicesWithSameId(string id)
    //{
    //Assert.Throws<MultipleInvoicesException>(() => CreateInvoice.GetInvoice(id));

    //}
    [Fact]
    public void UpdateInvoice()
    {
        var testUpdate = getTestUpdateInvoice();
        var invoices = CreateInvoice.UpdateInvoice("RT3080", testUpdate);


    }

}