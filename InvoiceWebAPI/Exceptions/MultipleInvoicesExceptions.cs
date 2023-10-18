namespace InvoiceWebAPI.Exceptions;

[Serializable]
public class MultipleInvoicesExceptions : Exception
{
    public MultipleInvoiceExceptions() { }

    public MultipleInvoiceExceptions(string message)
        : base(message) { }

    public MultipleInvoiceExceptions(string message, Exception inner)
        : base(message, inner) { }
}