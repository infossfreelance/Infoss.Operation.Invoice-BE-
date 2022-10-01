namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDetailDemurrageResponse : InvoiceDetailDemurrage
    {
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public List<InvoiceDetailDemurrageContainerResponse> InvoiceDetailDemurrageContainers { get; set; } = new List<InvoiceDetailDemurrageContainerResponse>();

    }
}