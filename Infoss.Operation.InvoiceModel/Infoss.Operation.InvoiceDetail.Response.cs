namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceDetailResponse : InvoiceDetail
    {
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }

        //public List<InvoiceDetailDemurrageResponse> InvoiceDetailDemurrages { get; set; } = new List<InvoiceDetailDemurrageResponse>();
        //public List<InvoiceDetailHandlingResponse> InvoiceDetailHandlings { get; set; } = new List<InvoiceDetailHandlingResponse>();
        public List<InvoiceDetailProfitShareResponse> InvoiceDetailProfitShares { get; set; } = new List<InvoiceDetailProfitShareResponse>();
        public List<InvoiceDetailStorageResponse> InvoiceDetailStorages { get; set; } = new List<InvoiceDetailStorageResponse>();

    }
}