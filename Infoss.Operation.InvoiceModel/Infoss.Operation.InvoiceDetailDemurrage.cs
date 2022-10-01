namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDetailDemurrage
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int InvoiceDetailId { get; set; } = 0;
        public int Sequence { get; set; } = 0;
        public DateTime BackContainerOn { get; set; }
        public int Freetime { get; set; } = 0;
        public int Fase { get; set; } = 0;
        public int TotalContainer20 { get; set; } = 0;
        public int TotalContainer40 { get; set; } = 0;
        public string DiscType { get; set; } = string.Empty;
        public decimal DiscAmount { get; set; } = 0;
        public int IdLama { get; set; } = 0;
    }
}