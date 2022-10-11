namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDeliveredRequest 
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int Id { get; set; }
        public int InvoiceNo { get; set; }
        public int IsDelivered { get; set; }
        //public string DeliveredOn { get; set; }
        public string DeliveredRemarks { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
    }
}