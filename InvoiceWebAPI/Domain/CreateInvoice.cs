using System.Reflection;
using System.Text.Json;
using InvoiceWebAPI.Models;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InvoiceWebAPI.Domain;

public class CreateInvoice
{
    public static Invoice Create(object newInvoice)
    {
        var invoice = JsonConvert.DeserializeObject<Invoice>(newInvoice.ToString());
        invoice.Id = "sdfsdfsdf";
        invoice.CreatedAt = DateTime.Now.ToString();
        return invoice;
    }
    //public static List<Invoice> GetInvoices()
    //{
    //    var path = Path.Combine(Directory.GetCurrentDirectory(), @$"Domain\InvoiceData.json");
    //    var file = File.ReadAllText(path);
    //    var invoice = JsonConvert.DeserializeObject<List<Invoice>>(file);
    //    return invoice;
    //}

    //public static Invoice? GetInvoice(string id)
    //{
    //    var invoices = GetInvoices();

    //    var invoice = invoices.Where(invoice => invoice.Id == id);
    //    if(invoice.Count() > 1)
    //        throw new MultipleInvoicesException();

    //    return invoice.FirstOrDefault();
    //}

    //public static Invoice? GetInvoiceFromList(string id, List<Invoice> invoiceList)
    //{
    //    var invoice = invoiceList.Where(invoice => invoice.Id == id);
    //    if (invoice.Count() > 1)
    //        throw new MultipleInvoicesException();

    //    return invoice.FirstOrDefault();
    //}

    //public static List<Invoice> UpdateInvoice(string id, Invoice invoice)
    //{

    //   var invoices = GetInvoices();
    //   var invoiceToBeUpdated = GetInvoiceFromList(id, invoices);
    //   invoices.Remove(invoiceToBeUpdated);
    //   invoices.Add(invoice);      
    //   return invoices;
    //}
}