namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceReqDelRequest : InvoiceReqDel
    {
        public string User { get; set; } = string.Empty;
        public List<InvoiceDetailDemurrageRequest> InvoiceDetailDemurrages { get; set; } = new List<InvoiceDetailDemurrageRequest>();
        public List<InvoiceDetailHandlingRequest> InvoiceDetailHandlings { get; set; } = new List<InvoiceDetailHandlingRequest>();
        public List<InvoiceDetailProfitShareRequest> InvoiceDetailProfitShares { get; set; } = new List<InvoiceDetailProfitShareRequest>();
        public List<InvoiceDetailStorageRequest> InvoiceDetailStorages { get; set; } = new List<InvoiceDetailStorageRequest>();

    }
}