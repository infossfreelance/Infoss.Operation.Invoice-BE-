namespace Infoss.Operation.InvoiceService.Repositories
{
    public interface IInvoiceDetailHandlingRepository
    {
        // public Task<ResponsePage<InvoiceResponsePage>> Read(RequestPage requestPage);
        // public Task<ResponsePage<InvoiceResponseId>> Read(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailHandlingResponse>> Create(InvoiceDetailHandlingTransaction invoiceDetailHandling);
        // public Task<ResponsePage<InvoiceDetailHandlingResponse>> Update(InvoiceRequestTransaction invoiceDetailHandling);
        public Task<ResponsePage<InvoiceDetailHandlingResponse>> Deleted(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailHandlingResponse>> Delete(RequestId requestId);
    }
}
