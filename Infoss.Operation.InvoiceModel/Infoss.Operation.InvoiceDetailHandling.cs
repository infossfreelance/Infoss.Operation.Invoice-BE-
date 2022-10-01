namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDetailHandling
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int InvoiceDetailId { get; set; } = 0;
        public int Sequence { get; set; } = 0;
        public decimal Feet20 { get; set; } = 0;
        public decimal Feet40 { get; set; } = 0;
        public decimal FeetHQ { get; set; } = 0;
        public decimal FeetM3 { get; set; } = 0;
        public decimal Rate20 { get; set; } = 0;
        public decimal Rate40 { get; set; } = 0;
        public decimal RateHQ { get; set; } = 0;
        public decimal RateM3 { get; set; } = 0;
        public int IdLama { get; set; } = 0;
    }
}