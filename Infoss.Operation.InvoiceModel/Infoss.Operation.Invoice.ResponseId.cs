namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceResponseId
    {
        public InvoiceResponse Invoice { get; set; } = new InvoiceResponse();
        public List<InvoiceDetailResponse> InvoiceDetails { get; set; } = new List<InvoiceDetailResponse>();
        public List<InvoiceReqDelResponse> InvoiceReqDels { get; set; } = new List<InvoiceReqDelResponse>();
        public List<InvoiceExportEJKPResponse> InvoiceExportEJKPs { get; set; } = new List<InvoiceExportEJKPResponse>();
        public List<InvoiceExportFakturResponse> InvoiceExportFakturs { get; set; } = new List<InvoiceExportFakturResponse>();
        public List<InvoiceColumn> Columns { get; set; } = new List<InvoiceColumn>();
    }
}