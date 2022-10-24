namespace Infoss.Operation.InvoiceModel
{
    public class Invoice
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int Id { get; set; } = 0;
        public int TicketId { get; set; } = 0;
        public int InvoiceNo { get; set; } = 0;
        public string DebetCredit { get; set; } = string.Empty;
        public int ShipmentId { get; set; } = 0;
        public string ShipmentNo { get; set; } = 0;
        public int CustomerTypeId { get; set; } = 0;
        public int CustomerId { get; set; } = 0;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public int BillId { get; set; } = 0;
        public string BillName { get; set; } = string.Empty;
        public string BillAddress { get; set; } = string.Empty;
        public string InvoicesTo { get; set; } = string.Empty;
        public int InvoiceStatus { get; set; } = 0;
        public decimal PaymentUSD { get; set; } = 0;
        public decimal PaymentIDR { get; set; } = 0;
        public decimal TotalVatUSD { get; set; } = 0;
        public decimal TotalVatIDR { get; set; } = 0;
        public decimal Rate { get; set; } = 0;
        public DateTime ExRateDate { get; set; }
        public int Period { get; set; } = 0;
        public int YearPeriod { get; set; } = 0;
        public string InvoicesAgent { get; set; } = string.Empty;
        public string InvoicesEdit { get; set; } = string.Empty;
        public string JenisInvoices { get; set; } = string.Empty;
        public string LinkTo { get; set; } = string.Empty;
        public int DueDate { get; set; } = 0;
        public bool Paid { get; set; }
        public DateTime PaidOn { get; set; }
        public bool SaveOR { get; set; }
        public bool BadDebt { get; set; }
        public DateTime BadDebtOn { get; set; }
        public bool ReBadDebt { get; set; }
        public DateTime DateReBadDebt { get; set; }
        public int Printing { get; set; } = 0;
        public DateTime PrintedOn { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedOn { get; set; }
        public string InvoiceNo2 { get; set; } = string.Empty;
        public int InvHeader { get; set; } = 0;
        public int ExRateId { get; set; } = 0;
        public bool RePrintApproved { get; set; }
        public DateTime RePrintApprovedOn { get; set; }
        public string RePrintApprovedBy { get; set; } = string.Empty;
        public string DeletedRemarks { get; set; } = string.Empty;
        public int IdLama { get; set; } = 0;
        public bool IsCostToCost { get; set; }
        public int SFPId { get; set; } = 0;
        public string SFPNoFormat { get; set; } = string.Empty;
        public int SFPDetailId { get; set; } = 0;
        public string UniqueKeySFP { get; set; } = string.Empty;
        public string UniqueKeyInvoice { get; set; } = string.Empty;
        public int DeleteType { get; set; } = 0;
        public int DeleteTypeRefInvId { get; set; } = 0;
        public decimal KursKMK { get; set; } = 0;
        public int KursKMKId { get; set; } = 0;
        public bool IsDelivered { get; set; }
        public DateTime DeliveredOn { get; set; }
        public string DeliveredRemarks { get; set; } = string.Empty;
        public string SFPReference { get; set; } = string.Empty;
        public bool ApprovedCredit { get; set; }
        public int ApprovedCreditBy { get; set; } = 0;
        public DateTime ApprovedCreditOn { get; set; }
        public string ApprovedCreditRemarks { get; set; } = string.Empty;
        public string PackingListNo { get; set; } = string.Empty;
        public string SICustomerNo { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public bool IsStampDuty { get; set; }
        public decimal StampDutyAmount { get; set; } = 0;
        public int PEJKPNumber { get; set; } = 0;
        public string PEJKPReference { get; set; } = string.Empty;
    }
}