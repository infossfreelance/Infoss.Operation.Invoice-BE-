namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceExportFaktur
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int InvoiceId { get; set; } = 0;
        public int Sequence { get; set; } = 0;
        public bool IsInvoiceNonJob { get; set; }
        public bool IsExported { get; set; }
        public DateTime ExportedOn { get; set; }
        public string ExportedBy { get; set; } = string.Empty;
        public bool IsUploaded { get; set; }
        public DateTime UploadedOn { get; set; }
        public string UploadedBy { get; set; } = string.Empty;
    }
}