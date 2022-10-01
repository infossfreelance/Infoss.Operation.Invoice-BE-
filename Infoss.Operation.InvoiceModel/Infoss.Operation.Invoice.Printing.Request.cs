namespace Infoss.Operation.InvoiceModel
{
    public class InvoicePrintingRequest 
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int Id { get; set; }
        //public int TicketId { get; set; }
        public int InvoiceNo { get; set; }
        public int Printing { get; set; }
        public string User { get; set; } = string.Empty;
    }
}