using System.Runtime.Serialization;

namespace InvoiceWebAPI.Domain
{
    [Serializable]
    public class MultipleInvoicesException : Exception
    {
        public MultipleInvoicesException()
        {
        }

        public MultipleInvoicesException(string? message) : base(message)
        {
        }

        public MultipleInvoicesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MultipleInvoicesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}