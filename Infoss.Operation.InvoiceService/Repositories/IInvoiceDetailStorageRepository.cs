namespace Infoss.Operation.InvoiceService.Repositories
{
    public interface IInvoiceDetailStorageRepository
    {
        // public Task<ResponsePage<InvoiceResponsePage>> Read(RequestPage requestPage);
        // public Task<ResponsePage<InvoiceResponseId>> Read(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailStorageResponse>> Create(InvoiceDetailStorageTransaction invoiceDetailStorage);
        // public Task<ResponsePage<InvoiceDetailStorageResponse>> Update(InvoiceRequestTransaction invoiceDetailStorage);
        public Task<ResponsePage<InvoiceDetailStorageResponse>> Deleted(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailStorageResponse>> Delete(RequestId requestId);
    }
}
