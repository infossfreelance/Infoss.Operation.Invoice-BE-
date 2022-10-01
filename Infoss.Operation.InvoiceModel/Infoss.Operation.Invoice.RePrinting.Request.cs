namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceRePrintingRequest 
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int Id { get; set; }
        //public int TicketId { get; set; }
        public int InvoiceNo { get; set; }
        public int RePrintApproved { get; set; }
        //public int RePrintApprovedOn { get; set; }
        public int RePrintApprovedBy { get; set; }
        public string User { get; set; } = string.Empty;
    }
}