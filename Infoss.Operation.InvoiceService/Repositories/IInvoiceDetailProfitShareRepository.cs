namespace Infoss.Operation.InvoiceService.Repositories
{
    public interface IInvoiceDetailProfitShareRepository
    {
        // public Task<ResponsePage<InvoiceResponsePage>> Read(RequestPage requestPage);
        // public Task<ResponsePage<InvoiceResponseId>> Read(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailProfitShareResponse>> Create(InvoiceDetailProfitShareTransaction invoiceDetailProfitShare);
        // public Task<ResponsePage<InvoiceDetailProfitShareResponse>> Update(InvoiceRequestTransaction invoiceDetailProfitShare);
        public Task<ResponsePage<InvoiceDetailProfitShareResponse>> Deleted(RequestId requestId);
        public Task<ResponsePage<InvoiceDetailProfitShareResponse>> Delete(RequestId requestId);
    }
}
