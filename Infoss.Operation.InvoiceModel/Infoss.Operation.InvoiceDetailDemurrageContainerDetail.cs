namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDetailDemurrageContainerDetail
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int InvoiceDetailDemurrageContainerId { get; set; } = 0;
        public int Sequence { get; set; } = 0;
        public int DayContainer { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public decimal AmountContainer20 { get; set; } = 0;
        public decimal AmountContainer40 { get; set; } = 0;
        public int IdLama { get; set; } = 0;
    }
}