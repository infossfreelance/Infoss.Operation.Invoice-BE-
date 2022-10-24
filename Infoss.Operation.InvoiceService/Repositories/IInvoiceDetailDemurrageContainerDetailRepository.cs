namespace Infoss.Operation.InvoiceService.Repositories
{
    public interface IInvoiceDetailDemurrageContainerDetailRepository
    {
        // public Task<ResponsePage<InvoiceResponsePage>> Read(RequestPage requestPage);
        // public Task<ResponsePage<InvoiceResponseId>> Read(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailDemurrageContainerDetailResponse>> Create(InvoiceDetailDemurrageContainerDetailTransaction invDetDemuContainerDetail);
        // public Task<ResponsePage<InvoiceDetailDemurrageResponse>> Update(InvoiceRequestTransaction invoiceDetailDemurrage);
        public Task<ResponsePage<InvoiceDetailDemurrageContainerDetailResponse>> Deleted(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailDemurrageContainerDetailResponse>> Delete(RequestId requestId);
    }
}
