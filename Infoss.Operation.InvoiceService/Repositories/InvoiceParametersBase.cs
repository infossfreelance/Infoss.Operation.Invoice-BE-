using System.Data;
using Dapper;

namespace Infoss.Operation.InvoiceService.Repositories
{
    public class InvoiceParametersBase
    {
        public DynamicParameters parameters { get; set; } = new DynamicParameters();
        public InvoiceHeaderTransaction invoiceHeader { get; set; } = new InvoiceHeaderTransaction();

        public InvoiceParametersBase()
        {

        }

        public DynamicParameters InvoiceParameter(InvoiceHeaderTransaction invoiceHeader)
        {
            this.invoiceHeader = invoiceHeader;

            parameters.Add("@RowStatus", invoiceHeader.InvoiceHeader.RowStatus == "" ? "ACT" : invoiceHeader.InvoiceHeader.RowStatus);
            parameters.Add("@CountryId", invoiceHeader.InvoiceHeader.CountryId);
            parameters.Add("@CompanyId", invoiceHeader.InvoiceHeader.CompanyId);
            parameters.Add("@BranchId", invoiceHeader.InvoiceHeader.BranchId);
            parameters.Add("@Id", invoiceHeader.InvoiceHeader.Id);
            parameters.Add("@TicketId", invoiceHeader.InvoiceHeader.TicketId);
            parameters.Add("@InvoiceNo", invoiceHeader.InvoiceHeader.InvoiceNo);
            parameters.Add("@DebetCredit", invoiceHeader.InvoiceHeader.DebetCredit);
            parameters.Add("@ShipmentId", invoiceHeader.InvoiceHeader.ShipmentId);
            parameters.Add("@ShipmentNo", invoiceHeader.InvoiceHeader.ShipmentNo);
            parameters.Add("@CustomerTypeId", invoiceHeader.InvoiceHeader.CustomerTypeId);
            parameters.Add("@CustomerId", invoiceHeader.InvoiceHeader.CustomerId);
            parameters.Add("@CustomerName", invoiceHeader.InvoiceHeader.CustomerName);
            parameters.Add("@CustomerAddress", invoiceHeader.InvoiceHeader.CustomerAddress);
            parameters.Add("@BillId", invoiceHeader.InvoiceHeader.BillId);
            parameters.Add("@BillName", invoiceHeader.InvoiceHeader.BillName);
            parameters.Add("@BillAddress", invoiceHeader.InvoiceHeader.BillAddress);
            parameters.Add("@InvoicesTo", invoiceHeader.InvoiceHeader.InvoicesTo);
            parameters.Add("@InvoiceStatus", invoiceHeader.InvoiceHeader.InvoiceStatus);
            parameters.Add("@PaymentUSD", invoiceHeader.InvoiceHeader.PaymentUSD);
            parameters.Add("@PaymentIDR", invoiceHeader.InvoiceHeader.PaymentIDR);
            parameters.Add("@TotalVatUSD", invoiceHeader.InvoiceHeader.TotalVatUSD);
            parameters.Add("@TotalVatIDR", invoiceHeader.InvoiceHeader.TotalVatIDR);
            parameters.Add("@Rate", invoiceHeader.InvoiceHeader.Rate);
            parameters.Add("@ExRateDate", invoiceHeader.InvoiceHeader.ExRateDate);
            parameters.Add("@Period", invoiceHeader.InvoiceHeader.Period);
            parameters.Add("@YearPeriod", invoiceHeader.InvoiceHeader.YearPeriod);
            parameters.Add("@InvoicesAgent", invoiceHeader.InvoiceHeader.InvoicesAgent);
            parameters.Add("@InvoicesEdit", invoiceHeader.InvoiceHeader.InvoicesEdit);
            parameters.Add("@JenisInvoices", invoiceHeader.InvoiceHeader.JenisInvoices);
            parameters.Add("@LinkTo", invoiceHeader.InvoiceHeader.LinkTo);
            parameters.Add("@DueDate", invoiceHeader.InvoiceHeader.DueDate);
            parameters.Add("@Paid", invoiceHeader.InvoiceHeader.Paid);
            parameters.Add("@PaidOn", invoiceHeader.InvoiceHeader.PaidOn);
            parameters.Add("@SaveOR", invoiceHeader.InvoiceHeader.SaveOR);
            parameters.Add("@BadDebt", invoiceHeader.InvoiceHeader.BadDebt);
            parameters.Add("@BadDebtOn", invoiceHeader.InvoiceHeader.BadDebtOn);
            parameters.Add("@ReBadDebt", invoiceHeader.InvoiceHeader.ReBadDebt);
            parameters.Add("@DateReBadDebt", invoiceHeader.InvoiceHeader.DateReBadDebt);
            parameters.Add("@Printing", invoiceHeader.InvoiceHeader.Printing);
            parameters.Add("@PrintedOn", invoiceHeader.InvoiceHeader.PrintedOn);
            parameters.Add("@Deleted", invoiceHeader.InvoiceHeader.Deleted);
            parameters.Add("@DeletedOn", invoiceHeader.InvoiceHeader.DeletedOn);
            parameters.Add("@InvoiceNo2", invoiceHeader.InvoiceHeader.InvoiceNo2);
            parameters.Add("@InvHeader", invoiceHeader.InvoiceHeader.InvHeader);
            parameters.Add("@ExRateId", invoiceHeader.InvoiceHeader.ExRateId);
            parameters.Add("@RePrintApproved", invoiceHeader.InvoiceHeader.RePrintApproved);
            parameters.Add("@RePrintApprovedOn", invoiceHeader.InvoiceHeader.RePrintApprovedOn);
            parameters.Add("@RePrintApprovedBy", invoiceHeader.InvoiceHeader.RePrintApprovedBy);
            parameters.Add("@DeletedRemarks", invoiceHeader.InvoiceHeader.DeletedRemarks);
            parameters.Add("@IdLama", invoiceHeader.InvoiceHeader.IdLama);
            parameters.Add("@IsCostToCost", invoiceHeader.InvoiceHeader.IsCostToCost);
            parameters.Add("@SFPNoFormat", invoiceHeader.InvoiceHeader.SFPNoFormat);
            parameters.Add("@SFPDetailId", invoiceHeader.InvoiceHeader.SFPDetailId);
            parameters.Add("@UniqueKeySFP", invoiceHeader.InvoiceHeader.UniqueKeySFP);
            parameters.Add("@UniqueKeyInvoice", invoiceHeader.InvoiceHeader.UniqueKeyInvoice);
            parameters.Add("@DeleteType", invoiceHeader.InvoiceHeader.DeleteType);
            parameters.Add("@DeleteTypeRefInvId", invoiceHeader.InvoiceHeader.DeleteTypeRefInvId);
            parameters.Add("@KursKMK", invoiceHeader.InvoiceHeader.KursKMK);
            parameters.Add("@KursKMKId", invoiceHeader.InvoiceHeader.KursKMKId);
            parameters.Add("@IsDelivered", invoiceHeader.InvoiceHeader.IsDelivered);
            parameters.Add("@DeliveredOn", invoiceHeader.InvoiceHeader.DeliveredOn);
            parameters.Add("@DeliveredRemarks", invoiceHeader.InvoiceHeader.DeliveredRemarks);
            parameters.Add("@SFPReference", invoiceHeader.InvoiceHeader.SFPReference);
            parameters.Add("@ApprovedCredit", invoiceHeader.InvoiceHeader.ApprovedCredit);
            parameters.Add("@ApprovedCreditBy", invoiceHeader.InvoiceHeader.ApprovedCreditBy);
            parameters.Add("@ApprovedCreditOn", invoiceHeader.InvoiceHeader.ApprovedCreditOn);
            parameters.Add("@ApprovedCreditRemarks", invoiceHeader.InvoiceHeader.ApprovedCreditRemarks);
            parameters.Add("@PackingListNo", invoiceHeader.InvoiceHeader.PackingListNo);
            parameters.Add("@SICustomerNo", invoiceHeader.InvoiceHeader.SICustomerNo);
            parameters.Add("@Reference", invoiceHeader.InvoiceHeader.Reference);
            parameters.Add("@IsStampDuty", invoiceHeader.InvoiceHeader.IsStampDuty);
            parameters.Add("@StampDutyAmount", invoiceHeader.InvoiceHeader.StampDutyAmount);
            parameters.Add("@PEJKPNumber", invoiceHeader.InvoiceHeader.PEJKPNumber);
            parameters.Add("@PEJKPReference", invoiceHeader.InvoiceHeader.PEJKPReference);

            return parameters;
        }

    }
}
