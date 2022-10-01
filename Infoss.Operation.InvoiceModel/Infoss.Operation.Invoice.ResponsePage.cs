namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceResponsePage 
    {
        public List<InvoiceResponse> Invoices { get; set; } = new List<InvoiceResponse>();
        public List<InvoiceColumn> Columns { get; set; } = new List<InvoiceColumn>();

    }
}