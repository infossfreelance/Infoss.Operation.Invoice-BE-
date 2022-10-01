namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceRequestTransaction
    {
        public InvoiceRequest Invoice { get; set; } = new InvoiceRequest();
        public List<InvoiceDetailRequest> InvoiceDetails { get; set; } = new List<InvoiceDetailRequest>();
        public List<InvoiceReqDelResponse> InvoiceReqDels { get; set; } = new List<InvoiceReqDelResponse>();
        public List<InvoiceExportEJKPResponse> InvoiceExportEJKPs { get; set; } = new List<InvoiceExportEJKPResponse>();
        public List<InvoiceExportFakturResponse> InvoiceExportFakturs { get; set; } = new List<InvoiceExportFakturResponse>();

    }
}