using System.Text.Json;
using InvoiceWebAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InvoiceWebAPI.Domain;

public class CreateInvoice
{
    public static List<Invoice> GetInvoices()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), @"Domain\InvoiceData.json");
        var file = File.ReadAllText(path);
        var invoice = JsonConvert.DeserializeObject<List<Invoice>>(file);
        return invoice;
    }

    public static Invoice? GetInvoice(string id)
    {
        var invoices = GetInvoices();

        var invoice = invoices.Where(invoice => invoice.Id == id);
        if(invoice.Count() > 1)
            throw new MultipleInvoicesExpcetion();
        

        return invoice;
    }
}