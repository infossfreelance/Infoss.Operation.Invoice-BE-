namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceGetPageRequest 
    {
        private string _defFilter = "";
        public string UserCode { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public fieldFilter[] Filter { get; set; }
    }
    public class fieldFilter 
    {
        public string Field { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
    }
}