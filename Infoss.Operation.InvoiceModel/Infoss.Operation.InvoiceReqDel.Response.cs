namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceReqDelResponse : InvoiceReqDel
    {
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}