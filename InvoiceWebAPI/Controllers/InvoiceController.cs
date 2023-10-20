using InvoiceWebAPI.Data;
using InvoiceWebAPI.Models;
using InvoiceWebAPI.Domain;
using Microsoft.AspNetCore.Mvc;
namespace InvoiceWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly InvoicesService _invoicesService;
    public InvoiceController(InvoicesService invoicesService) => _invoicesService = invoicesService;

    public async Task<ActionResult<List<Invoice>>> Get()
    {
        var invoices = await _invoicesService.GetAsync();
        return invoices;

    }
    [HttpGet("{reference}")]
    public async Task<ActionResult<Invoice>> GetById(string reference)
    {
        var invoices = await _invoicesService.GetAsync(reference);
        return invoices;
    }
    
    [HttpPatch("{reference}")]
    public async Task<ActionResult<Invoice>> UpdateInvoice(string reference, Invoice invoice)
    {
        await _invoicesService.UpdateAsync(reference, invoice);
        var invoices = await _invoicesService.GetAsync(reference);
        return invoices;
    }
    
    [HttpPost]
    public async Task<ActionResult<Invoice>> GenerateInvoice(object newInvoice)
    {
        var invoice = CreateInvoice.Create(newInvoice);
        //await _invoicesService.UpdateAsync(reference, invoice);
        var invoices = await _invoicesService.GetAsync("dsfgkkdsf");
        return invoices;
    }
}
