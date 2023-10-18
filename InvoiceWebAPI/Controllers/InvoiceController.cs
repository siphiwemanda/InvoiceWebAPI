using InvoiceWebAPI.Data;
using InvoiceWebAPI.Models;
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

    //[Route("/{id}")]
    // public Invoice GetById(int id)
    // {
    //     
    // }
}