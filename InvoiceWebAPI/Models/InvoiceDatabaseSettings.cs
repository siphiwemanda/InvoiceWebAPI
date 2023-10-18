namespace InvoiceWebAPI.Models
{
    public class InvoiceDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string InvoiceCollectionName { get; set; } = null!;
    }
}