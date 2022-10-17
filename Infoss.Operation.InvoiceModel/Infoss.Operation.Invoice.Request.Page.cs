namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceRequestPage : RequestInvoice
    {
        public InvoiceGetPageRequest UserLogin = new InvoiceGetPageRequest();

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}