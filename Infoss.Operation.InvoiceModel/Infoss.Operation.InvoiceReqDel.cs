namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceReqDel
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int Id { get; set; } = 0;
        public string Reference { get; set; } = string.Empty;
        public bool IsNonJob { get; set; }
        public int InvoiceId { get; set; } = 0;
        public int DeleteType { get; set; } = 0;
        public string Remarks { get; set; } = string.Empty;
        public int ApprovedStatus { get; set; } = 0;
        public string ApprovedRemarks { get; set; } = string.Empty;
        public string ApprovedBy { get; set; } = string.Empty;
        public DateTime ApprovedOn { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedOn { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}