namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceHeaderResponsePage
    {
        public List<InvoiceHeaderResponse> Invoice { get; set; } = new List<InvoiceHeaderResponse>();
        public List<InvoiceHeaderColumn> Columns { get; set; } = new List<InvoiceHeaderColumn>();

    }
}