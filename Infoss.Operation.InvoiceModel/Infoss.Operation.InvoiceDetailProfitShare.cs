namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDetailProfitShare
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int InvoiceDetilId { get; set; } = 0;
        public int Sequence { get; set; } = 0;
        public decimal SFeet20 { get; set; } = 0;
        public decimal SFeet40 { get; set; } = 0;
        public decimal SFeetHQ { get; set; } = 0;
        public decimal SFeetM3 { get; set; } = 0;
        public decimal SRate20 { get; set; } = 0;
        public decimal SRate40 { get; set; } = 0;
        public decimal SRateHQ { get; set; } = 0;
        public decimal SRateM3 { get; set; } = 0;
        public decimal BFeet20 { get; set; } = 0;
        public decimal BFeet40 { get; set; } = 0;
        public decimal BFeetHQ { get; set; } = 0;
        public decimal BFeetM3 { get; set; } = 0;
        public decimal BRate20 { get; set; } = 0;
        public decimal BRate40 { get; set; } = 0;
        public decimal BRateHQ { get; set; } = 0;
        public decimal BRateM3 { get; set; } = 0;
        public decimal Percentage { get; set; } = 0;
        public int IdLama { get; set; } = 0;
    }
}