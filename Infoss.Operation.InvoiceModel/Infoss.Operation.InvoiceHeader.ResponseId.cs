namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceHeaderResponseId
    {
        public InvoiceHeaderResponse Invoice { get; set; } = new InvoiceHeaderResponse();
        public List<InvoiceHeaderColumn> Columns { get; set; } = new List<InvoiceHeaderColumn>();

    }
}