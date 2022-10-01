namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDetailDemurrageContainerResponse : InvoiceDetailDemurrageContainer
    {
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public List<InvoiceDetailDemurrageContainerDetailResponse> InvoiceDetailDemurrageContainerDetails { get; set; } = new List<InvoiceDetailDemurrageContainerDetailResponse>();

    }
}