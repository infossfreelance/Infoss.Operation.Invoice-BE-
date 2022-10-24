
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Infoss.Operation.InvoiceModel;

namespace Infoss.Operation.InvoiceService.Repositories
{
    public class InvoiceHeaderRepository : IInvoiceHeaderRepository
    {
        private SqlConnection connection;

        public InvoiceHeaderRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public async Task<ResponsePage<InvoiceHeaderResponse>> Create(InvoiceHeaderTransaction invoiceHeader)
        {
            var responsePage = new ResponsePage<InvoiceHeaderResponse>();

            InvoiceParameters invoiceParameters = new InvoiceParameters(invoiceHeader);
            var parameters = invoiceParameters.Create();

            //var parameters = new DynamicParameters();

            //parameters.Add("@RowStatus", invoiceHeader.InvoiceHeader.RowStatus == "" ? "ACT" : invoiceHeader.InvoiceHeader.RowStatus);
            //parameters.Add("@CountryId", invoiceHeader.InvoiceHeader.CountryId);
            //parameters.Add("@CompanyId", invoiceHeader.InvoiceHeader.CompanyId);
            //parameters.Add("@BranchId", invoiceHeader.InvoiceHeader.BranchId);
            //parameters.Add("@Id", invoiceHeader.InvoiceHeader.Id);
            //parameters.Add("@TicketId", invoiceHeader.InvoiceHeader.TicketId);
            //parameters.Add("@InvoiceNo", invoiceHeader.InvoiceHeader.InvoiceNo);
            //parameters.Add("@DebetCredit", invoiceHeader.InvoiceHeader.DebetCredit);
            //parameters.Add("@ShipmentId", invoiceHeader.InvoiceHeader.ShipmentId);
            //parameters.Add("@CustomerTypeId", invoiceHeader.InvoiceHeader.CustomerTypeId);
            //parameters.Add("@CustomerId", invoiceHeader.InvoiceHeader.CustomerId);
            //parameters.Add("@CustomerName", invoiceHeader.InvoiceHeader.CustomerName);
            //parameters.Add("@CustomerAddress", invoiceHeader.InvoiceHeader.CustomerAddress);
            //parameters.Add("@BillId", invoiceHeader.InvoiceHeader.BillId);
            //parameters.Add("@BillName", invoiceHeader.InvoiceHeader.BillName);
            //parameters.Add("@BillAddress", invoiceHeader.InvoiceHeader.BillAddress);
            //parameters.Add("@InvoicesTo", invoiceHeader.InvoiceHeader.InvoicesTo);
            //parameters.Add("@InvoiceStatus", invoiceHeader.InvoiceHeader.InvoiceStatus);
            //parameters.Add("@PaymentUSD", invoiceHeader.InvoiceHeader.PaymentUSD);
            //parameters.Add("@PaymentIDR", invoiceHeader.InvoiceHeader.PaymentIDR);
            //parameters.Add("@TotalVatUSD", invoiceHeader.InvoiceHeader.TotalVatUSD);
            //parameters.Add("@TotalVatIDR", invoiceHeader.InvoiceHeader.TotalVatIDR);
            //parameters.Add("@Rate", invoiceHeader.InvoiceHeader.Rate);
            //parameters.Add("@ExRateDate", invoiceHeader.InvoiceHeader.ExRateDate);
            //parameters.Add("@Period", invoiceHeader.InvoiceHeader.Period);
            //parameters.Add("@YearPeriod", invoiceHeader.InvoiceHeader.YearPeriod);
            //parameters.Add("@InvoicesAgent", invoiceHeader.InvoiceHeader.InvoicesAgent);
            //parameters.Add("@InvoicesEdit", invoiceHeader.InvoiceHeader.InvoicesEdit);
            //parameters.Add("@JenisInvoices", invoiceHeader.InvoiceHeader.JenisInvoices);
            //parameters.Add("@LinkTo", invoiceHeader.InvoiceHeader.LinkTo);
            //parameters.Add("@DueDate", invoiceHeader.InvoiceHeader.DueDate);
            //parameters.Add("@Paid", invoiceHeader.InvoiceHeader.Paid);
            //parameters.Add("@PaidOn", invoiceHeader.InvoiceHeader.PaidOn);
            //parameters.Add("@SaveOR", invoiceHeader.InvoiceHeader.SaveOR);
            //parameters.Add("@BadDebt", invoiceHeader.InvoiceHeader.BadDebt);
            //parameters.Add("@BadDebtOn", invoiceHeader.InvoiceHeader.BadDebtOn);
            //parameters.Add("@ReBadDebt", invoiceHeader.InvoiceHeader.ReBadDebt);
            //parameters.Add("@DateReBadDebt", invoiceHeader.InvoiceHeader.DateReBadDebt);
            //parameters.Add("@Printing", invoiceHeader.InvoiceHeader.Printing);
            //parameters.Add("@PrintedOn", invoiceHeader.InvoiceHeader.PrintedOn);
            //parameters.Add("@Deleted", invoiceHeader.InvoiceHeader.Deleted);
            //parameters.Add("@DeletedOn", invoiceHeader.InvoiceHeader.DeletedOn);
            //parameters.Add("@InvoiceNo2", invoiceHeader.InvoiceHeader.InvoiceNo2);
            //parameters.Add("@InvHeader", invoiceHeader.InvoiceHeader.InvHeader);
            //parameters.Add("@ExRateId", invoiceHeader.InvoiceHeader.ExRateId);
            //parameters.Add("@RePrintApproved", invoiceHeader.InvoiceHeader.RePrintApproved);
            //parameters.Add("@RePrintApprovedOn", invoiceHeader.InvoiceHeader.RePrintApprovedOn);
            //parameters.Add("@RePrintApprovedBy", invoiceHeader.InvoiceHeader.RePrintApprovedBy);
            //parameters.Add("@DeletedRemarks", invoiceHeader.InvoiceHeader.DeletedRemarks);
            //parameters.Add("@IdLama", invoiceHeader.InvoiceHeader.IdLama);
            //parameters.Add("@IsCostToCost", invoiceHeader.InvoiceHeader.IsCostToCost);
            //parameters.Add("@SFPNoFormat", invoiceHeader.InvoiceHeader.SFPNoFormat);
            //parameters.Add("@SFPDetailId", invoiceHeader.InvoiceHeader.SFPDetailId);
            //parameters.Add("@UniqueKeySFP", invoiceHeader.InvoiceHeader.UniqueKeySFP);
            //parameters.Add("@UniqueKeyInvoice", invoiceHeader.InvoiceHeader.UniqueKeyInvoice);
            //parameters.Add("@DeleteType", invoiceHeader.InvoiceHeader.DeleteType);
            //parameters.Add("@DeleteTypeRefInvId", invoiceHeader.InvoiceHeader.DeleteTypeRefInvId);
            //parameters.Add("@KursKMK", invoiceHeader.InvoiceHeader.KursKMK);
            //parameters.Add("@KursKMKId", invoiceHeader.InvoiceHeader.KursKMKId);
            //parameters.Add("@IsDelivered", invoiceHeader.InvoiceHeader.IsDelivered);
            //parameters.Add("@DeliveredOn", invoiceHeader.InvoiceHeader.DeliveredOn);
            //parameters.Add("@DeliveredRemarks", invoiceHeader.InvoiceHeader.DeliveredRemarks);
            //parameters.Add("@SFPReference", invoiceHeader.InvoiceHeader.SFPReference);
            //parameters.Add("@ApprovedCredit", invoiceHeader.InvoiceHeader.ApprovedCredit);
            //parameters.Add("@ApprovedCreditBy", invoiceHeader.InvoiceHeader.ApprovedCreditBy);
            //parameters.Add("@ApprovedCreditOn", invoiceHeader.InvoiceHeader.ApprovedCreditOn);
            //parameters.Add("@ApprovedCreditRemarks", invoiceHeader.InvoiceHeader.ApprovedCreditRemarks);
            //parameters.Add("@PackingListNo", invoiceHeader.InvoiceHeader.PackingListNo);
            //parameters.Add("@SICustomerNo", invoiceHeader.InvoiceHeader.SICustomerNo);
            //parameters.Add("@Reference", invoiceHeader.InvoiceHeader.Reference);
            //parameters.Add("@IsStampDuty", invoiceHeader.InvoiceHeader.IsStampDuty);
            //parameters.Add("@StampDutyAmount", invoiceHeader.InvoiceHeader.StampDutyAmount);
            //parameters.Add("@PEJKPNumber", invoiceHeader.InvoiceHeader.PEJKPNumber);
            //parameters.Add("@PEJKPReference", invoiceHeader.InvoiceHeader.PEJKPReference);
            //parameters.Add("@CreatedBy", invoiceHeader.InvoiceHeader.User);
            //parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            try
            {
                var affectedRows = await connection.ExecuteAsync("operation.SP_Invoice_Create", parameters, commandType: CommandType.StoredProcedure);

                int id = parameters.Get<int>("@RETURNVALUE");
                invoiceHeader.InvoiceHeader.Id = id;

                responsePage.Code = 200;
                responsePage.Message = "Data created";

                return responsePage;

            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to create";

                return responsePage;
            }
        }

        public async Task<ResponsePage<InvoiceHeaderResponse>> Update(InvoiceHeaderTransaction invoiceHeader)
        {
            var responsePage = new ResponsePage<InvoiceHeaderResponse>();

            InvoiceParameters invoiceParameters = new InvoiceParameters(invoiceHeader);
            var parameters = invoiceParameters.Update();

            //var parameters = new DynamicParameters();

            //parameters.Add("@RowStatus", invoiceHeader.InvoiceHeader.RowStatus == "" ? "ACT" : invoiceHeader.InvoiceHeader.RowStatus);
            //parameters.Add("@CountryId", invoiceHeader.InvoiceHeader.CountryId);
            //parameters.Add("@CompanyId", invoiceHeader.InvoiceHeader.CompanyId);
            //parameters.Add("@BranchId", invoiceHeader.InvoiceHeader.BranchId);
            //parameters.Add("@Id", invoiceHeader.InvoiceHeader.Id);
            //parameters.Add("@TicketId", invoiceHeader.InvoiceHeader.TicketId);
            //parameters.Add("@InvoiceNo", invoiceHeader.InvoiceHeader.InvoiceNo);
            //parameters.Add("@DebetCredit", invoiceHeader.InvoiceHeader.DebetCredit);
            //parameters.Add("@ShipmentId", invoiceHeader.InvoiceHeader.ShipmentId);
            //parameters.Add("@CustomerTypeId", invoiceHeader.InvoiceHeader.CustomerTypeId);
            //parameters.Add("@CustomerId", invoiceHeader.InvoiceHeader.CustomerId);
            //parameters.Add("@CustomerName", invoiceHeader.InvoiceHeader.CustomerName);
            //parameters.Add("@CustomerAddress", invoiceHeader.InvoiceHeader.CustomerAddress);
            //parameters.Add("@BillId", invoiceHeader.InvoiceHeader.BillId);
            //parameters.Add("@BillName", invoiceHeader.InvoiceHeader.BillName);
            //parameters.Add("@BillAddress", invoiceHeader.InvoiceHeader.BillAddress);
            //parameters.Add("@InvoicesTo", invoiceHeader.InvoiceHeader.InvoicesTo);
            //parameters.Add("@InvoiceStatus", invoiceHeader.InvoiceHeader.InvoiceStatus);
            //parameters.Add("@PaymentUSD", invoiceHeader.InvoiceHeader.PaymentUSD);
            //parameters.Add("@PaymentIDR", invoiceHeader.InvoiceHeader.PaymentIDR);
            //parameters.Add("@TotalVatUSD", invoiceHeader.InvoiceHeader.TotalVatUSD);
            //parameters.Add("@TotalVatIDR", invoiceHeader.InvoiceHeader.TotalVatIDR);
            //parameters.Add("@Rate", invoiceHeader.InvoiceHeader.Rate);
            //parameters.Add("@ExRateDate", invoiceHeader.InvoiceHeader.ExRateDate);
            //parameters.Add("@Period", invoiceHeader.InvoiceHeader.Period);
            //parameters.Add("@YearPeriod", invoiceHeader.InvoiceHeader.YearPeriod);
            //parameters.Add("@InvoicesAgent", invoiceHeader.InvoiceHeader.InvoicesAgent);
            //parameters.Add("@InvoicesEdit", invoiceHeader.InvoiceHeader.InvoicesEdit);
            //parameters.Add("@JenisInvoices", invoiceHeader.InvoiceHeader.JenisInvoices);
            //parameters.Add("@LinkTo", invoiceHeader.InvoiceHeader.LinkTo);
            //parameters.Add("@DueDate", invoiceHeader.InvoiceHeader.DueDate);
            //parameters.Add("@Paid", invoiceHeader.InvoiceHeader.Paid);
            //parameters.Add("@PaidOn", invoiceHeader.InvoiceHeader.PaidOn);
            //parameters.Add("@SaveOR", invoiceHeader.InvoiceHeader.SaveOR);
            //parameters.Add("@BadDebt", invoiceHeader.InvoiceHeader.BadDebt);
            //parameters.Add("@BadDebtOn", invoiceHeader.InvoiceHeader.BadDebtOn);
            //parameters.Add("@ReBadDebt", invoiceHeader.InvoiceHeader.ReBadDebt);
            //parameters.Add("@DateReBadDebt", invoiceHeader.InvoiceHeader.DateReBadDebt);
            //parameters.Add("@Printing", invoiceHeader.InvoiceHeader.Printing);
            //parameters.Add("@PrintedOn", invoiceHeader.InvoiceHeader.PrintedOn);
            //parameters.Add("@Deleted", invoiceHeader.InvoiceHeader.Deleted);
            //parameters.Add("@DeletedOn", invoiceHeader.InvoiceHeader.DeletedOn);
            //parameters.Add("@InvoiceNo2", invoiceHeader.InvoiceHeader.InvoiceNo2);
            //parameters.Add("@InvHeader", invoiceHeader.InvoiceHeader.InvHeader);
            //parameters.Add("@ExRateId", invoiceHeader.InvoiceHeader.ExRateId);
            //parameters.Add("@RePrintApproved", invoiceHeader.InvoiceHeader.RePrintApproved);
            //parameters.Add("@RePrintApprovedOn", invoiceHeader.InvoiceHeader.RePrintApprovedOn);
            //parameters.Add("@RePrintApprovedBy", invoiceHeader.InvoiceHeader.RePrintApprovedBy);
            //parameters.Add("@DeletedRemarks", invoiceHeader.InvoiceHeader.DeletedRemarks);
            //parameters.Add("@IdLama", invoiceHeader.InvoiceHeader.IdLama);
            //parameters.Add("@IsCostToCost", invoiceHeader.InvoiceHeader.IsCostToCost);
            //parameters.Add("@SFPNoFormat", invoiceHeader.InvoiceHeader.SFPNoFormat);
            //parameters.Add("@SFPDetailId", invoiceHeader.InvoiceHeader.SFPDetailId);
            //parameters.Add("@UniqueKeySFP", invoiceHeader.InvoiceHeader.UniqueKeySFP);
            //parameters.Add("@UniqueKeyInvoice", invoiceHeader.InvoiceHeader.UniqueKeyInvoice);
            //parameters.Add("@DeleteType", invoiceHeader.InvoiceHeader.DeleteType);
            //parameters.Add("@DeleteTypeRefInvId", invoiceHeader.InvoiceHeader.DeleteTypeRefInvId);
            //parameters.Add("@KursKMK", invoiceHeader.InvoiceHeader.KursKMK);
            //parameters.Add("@KursKMKId", invoiceHeader.InvoiceHeader.KursKMKId);
            //parameters.Add("@IsDelivered", invoiceHeader.InvoiceHeader.IsDelivered);
            //parameters.Add("@DeliveredOn", invoiceHeader.InvoiceHeader.DeliveredOn);
            //parameters.Add("@DeliveredRemarks", invoiceHeader.InvoiceHeader.DeliveredRemarks);
            //parameters.Add("@SFPReference", invoiceHeader.InvoiceHeader.SFPReference);
            //parameters.Add("@ApprovedCredit", invoiceHeader.InvoiceHeader.ApprovedCredit);
            //parameters.Add("@ApprovedCreditBy", invoiceHeader.InvoiceHeader.ApprovedCreditBy);
            //parameters.Add("@ApprovedCreditOn", invoiceHeader.InvoiceHeader.ApprovedCreditOn);
            //parameters.Add("@ApprovedCreditRemarks", invoiceHeader.InvoiceHeader.ApprovedCreditRemarks);
            //parameters.Add("@PackingListNo", invoiceHeader.InvoiceHeader.PackingListNo);
            //parameters.Add("@SICustomerNo", invoiceHeader.InvoiceHeader.SICustomerNo);
            //parameters.Add("@Reference", invoiceHeader.InvoiceHeader.Reference);
            //parameters.Add("@IsStampDuty", invoiceHeader.InvoiceHeader.IsStampDuty);
            //parameters.Add("@StampDutyAmount", invoiceHeader.InvoiceHeader.StampDutyAmount);
            //parameters.Add("@PEJKPNumber", invoiceHeader.InvoiceHeader.PEJKPNumber);
            //parameters.Add("@PEJKPReference", invoiceHeader.InvoiceHeader.PEJKPReference);
            //parameters.Add("@CreatedBy", invoiceHeader.InvoiceHeader.User);
            //parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            try
            {
                var affectedRows = await connection.ExecuteAsync("operation.SP_Invoice_Update", parameters, commandType: CommandType.StoredProcedure);

                responsePage.Code = 200;
                responsePage.Message = "Data updated";

                return responsePage;

            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to update";

                return responsePage;
            }
        }

        public async Task<ResponsePage<InvoiceHeaderResponse>> Delete(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceHeaderResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_Invoice_Delete", parameters, commandType: CommandType.StoredProcedure);

                responsePage.Code = 200;
                responsePage.Message = "Data deleted";

                return responsePage;
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to delete";

                return responsePage;
            }
        }
    }
}
