namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDetailDemurrageContainer
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int InvoiceDetailDemurrageId { get; set; } = 0;
        public int Sequence { get; set; } = 0;
        public string ContainerNo { get; set; } = string.Empty;
        public int IdLama { get; set; } = 0;
    }
}