namespace Infoss.Operation.InvoiceModel
{
    public class InvoiceGetPageRequest 
    {
        private string _defFilter = "";
        public string UserCode { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public string Filter { get { return _defFilter; } set { _defFilter = value; } }
    }
}