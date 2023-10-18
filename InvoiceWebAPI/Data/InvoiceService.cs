using MongoDB.Driver;using MongoDB.Bson;
using InvoiceWebAPI.Models;
using Microsoft.Extensions.Options;

namespace InvoiceWebAPI.Data
{
    public class InvoicesService
    {
        private readonly IMongoCollection<Invoice> _invoiceCollection;

        public InvoicesService(
            IOptions<InvoiceDatabaseSettings> invoiceDatabaseSettings)
        {
            var mongoClient = new MongoClient(invoiceDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(invoiceDatabaseSettings.Value.DatabaseName);
            _invoiceCollection = mongoDatabase.GetCollection<Invoice>(invoiceDatabaseSettings.Value.InvoiceCollectionName);
        }

        public async Task<List<Invoice>> GetAsync() =>
            await _invoiceCollection.Find(_ => true).ToListAsync();

        public async Task<Invoice?> GetAsync(string id) =>
            await _invoiceCollection.Find(x => x.Reference == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Invoice newInvoice) =>
            await _invoiceCollection.InsertOneAsync(newInvoice);

        public async Task UpdateAsync(string id, Invoice updatedInvoice) =>
            await _invoiceCollection.ReplaceOneAsync(x => x.Reference == id, updatedInvoice);

        public async Task RemoveAsync(string id) =>
            await _invoiceCollection.DeleteOneAsync(x => x.Reference == id);
    }

}


