namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDetail
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int InvoiceId { get; set; } = 0;
        public int Sequence { get; set; } = 0;
        public string DebetCredit { get; set; } = string.Empty;
        public int AccountId { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int Type { get; set; } = 0;
        public bool CodingQuantity { get; set; }
        public decimal Quantity { get; set; } = 0;
        public decimal PerQty { get; set; } = 0;
        public bool Sign { get; set; }
        public int AmountCrr { get; set; } = 0;
        public decimal Amount { get; set; } = 0;
        public decimal PercentVat { get; set; } = 0;
        public decimal AmountVat { get; set; } = 0;
        public int EPLDetailId { get; set; } = 0;
        public int VatId { get; set; } = 0;
        public int IdLama { get; set; } = 0;
        public bool IsCostToCost { get; set; }
        public decimal OriginalUsd { get; set; } = 0;
        public decimal OriginalRate { get; set; } = 0;
    }
}