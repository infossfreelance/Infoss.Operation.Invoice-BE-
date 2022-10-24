namespace Infoss.Operation.InvoiceService.Repositories
{
    public interface IInvoiceHeaderRepository
    {
        // public Task<ResponsePage<InvoiceResponsePage>> Read(RequestPage requestPage);
        // public Task<ResponsePage<InvoiceResponseId>> Read(RequestId requestId);
        public Task<ResponsePage<InvoiceHeaderResponse>> Create(InvoiceHeaderTransaction invoiceHeader);
        public Task<ResponsePage<InvoiceHeaderResponse>> Update(InvoiceHeaderTransaction invoiceHeader);
        public Task<ResponsePage<InvoiceHeaderResponse>> Delete(RequestId requestId);
    }
}
