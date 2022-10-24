namespace Infoss.Operation.InvoiceService.Repositories
{
    public interface IInvoiceDetailRepository
    {
        // public Task<ResponsePage<InvoiceResponsePage>> Read(RequestPage requestPage);
        // public Task<ResponsePage<InvoiceResponseId>> Read(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailResponse>> Create(InvoiceDetailTransaction invoiceDetail);
        public Task<ResponsePage<InvoiceDetailResponse>> Update(InvoiceDetailTransaction invoiceDetail);
        public Task<ResponsePage<InvoiceDetailResponse>> Deleted(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailResponse>> Delete(RequestId requestId);
    }
}
