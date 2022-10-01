namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDetailStorage
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int InvoiceDetailId { get; set; } = 0;
        public int Sequence { get; set; } = 0;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TotalDays { get; set; } = 0;
        public int StorageDetailId { get; set; } = 0;
        public decimal AmountIDR { get; set; } = 0;
        public decimal AmountUSD { get; set; } = 0;
        public int StorageId { get; set; } = 0;
    }
}