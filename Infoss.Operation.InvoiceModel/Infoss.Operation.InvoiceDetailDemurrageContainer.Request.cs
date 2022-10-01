namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDetailDemurrageContainerRequest : InvoiceDetailDemurrageContainer
    {
        public string User { get; set; } = string.Empty;
        public List<InvoiceDetailDemurrageContainerDetailRequest> InvoiceDetailDemurrageContainerDetails { get; set; } = new List<InvoiceDetailDemurrageContainerDetailRequest>();

    }
}