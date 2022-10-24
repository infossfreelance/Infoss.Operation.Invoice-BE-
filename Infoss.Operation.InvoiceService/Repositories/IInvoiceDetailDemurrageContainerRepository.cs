namespace Infoss.Operation.InvoiceService.Repositories
{
    public interface IInvoiceDetailDemurrageContainerRepository
    {
        // public Task<ResponsePage<InvoiceResponsePage>> Read(RequestPage requestPage);
        // public Task<ResponsePage<InvoiceResponseId>> Read(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailDemurrageContainerResponse>> Create(InvoiceDetailDemurrageContainerTransaction invoiceDetailDemurrageContainer);
        // public Task<ResponsePage<InvoiceDetailDemurrageResponse>> Update(InvoiceRequestTransaction invoiceDetailDemurrage);
        public Task<ResponsePage<InvoiceDetailDemurrageContainerResponse>> Deleted(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailDemurrageContainerResponse>> Delete(RequestId requestId);
    }
}
