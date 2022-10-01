namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDetailDemurrageRequest : InvoiceDetailDemurrage
    {
        public string User { get; set; } = string.Empty;
        public List<InvoiceDetailDemurrageContainerRequest> InvoiceDetailDemurrageContainers { get; set; } = new List<InvoiceDetailDemurrageContainerRequest>();

    }
}