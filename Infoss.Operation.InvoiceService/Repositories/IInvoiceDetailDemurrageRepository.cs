namespace Infoss.Operation.InvoiceService.Repositories
{
    public interface IInvoiceDetailDemurrageRepository
    {
        // public Task<ResponsePage<InvoiceResponsePage>> Read(RequestPage requestPage);
        // public Task<ResponsePage<InvoiceResponseId>> Read(RequestId requestId);
        //public Task<ResponsePage<InvoiceDetailDemurrageResponse>> Create(InvoiceDetailTransaction invoiceDetail);
        // public Task<ResponsePage<InvoiceDetailDemurrageResponse>> Update(InvoiceRequestTransaction invoiceDetailDemurrage);
        public Task<ResponsePage<InvoiceDetailDemurrageResponse>> Deleted(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailDemurrageResponse>> Delete(RequestId requestId);
    }
}
