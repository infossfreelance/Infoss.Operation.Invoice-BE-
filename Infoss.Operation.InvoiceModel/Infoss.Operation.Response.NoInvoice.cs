namespace Infoss.Operation.InvoiceModel
{
    public class ResponseNoInvoice
    {
        public int InvoiceNo { get; set; } = 0;
        public string InvoiceNo2 { get; set; } = string.Empty;
        public int SFPId { get; set; } = 0;
        public string SFPNoFormat { get; set; } = string.Empty;
        public int SFPDetailId { get; set; } = 0;
        public string UniqueKeySFP { get; set; } = string.Empty;
        public string UniqueKeyInvoice { get; set; } = string.Empty;
    }
}