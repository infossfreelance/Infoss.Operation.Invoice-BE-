using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Infoss.Operation.InvoiceService.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private string connectionString = string.Empty;

        public InvoiceRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("SqlConnection");
        }

        public async Task<ResponsePage<InvoiceResponsePage>> ReadAll(RequestPage requestPage)
        {
            var responsePage = new ResponsePage<InvoiceResponsePage>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RowStatus", requestPage.RowStatus);
                parameters.Add("@CountryId", requestPage.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestPage.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestPage.UserLogin.BranchId);
                parameters.Add("@User", requestPage.UserLogin.UserCode);
                parameters.Add("@Id", 0);
                parameters.Add("@PageNo", requestPage.PageNumber);
                parameters.Add("@PageSize", requestPage.PageSize);
                parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@PageCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var multi = (await connection.QueryMultipleAsync("operation.SP_Invoice_Read_All_Data", parameters, commandType: CommandType.StoredProcedure)))
                    {
                        InvoiceResponsePage invoiceResponsePage = new InvoiceResponsePage();

                        //var invoiceColumns = (await multi.ReadAsync<InvoiceColumn>()).ToList();
                        var invoiceResponses = (await multi.ReadAsync<InvoiceResponse>()).ToList();

                        //invoiceResponsePage.Columns = invoiceColumns;
                        invoiceResponsePage.Invoices = invoiceResponses;

                        responsePage.Data = invoiceResponsePage;

                        responsePage.TotalRowCount = parameters.Get<int>("@RowCount");
                        responsePage.TotalPage = parameters.Get<int>("@PageCount");

                        if (responsePage.Data != null)
                        {
                            responsePage.Code = 200;
                            responsePage.Message = "Successfully read";
                        }
                        else
                        {
                            responsePage.Code = 204;
                            responsePage.Message = "No content";
                        }

                        return responsePage;
                    }
                }

            }

            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to read";

                return responsePage;
            }
        }
        
        public async Task<ResponsePage<InvoiceResponse>> UpdateStatusPrint(InvoicePrintingRequest invoiceRequest)
        {
            var responsePage = new ResponsePage<InvoiceResponse>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RowStatus", invoiceRequest.RowStatus == "" ? "ACT" : invoiceRequest.RowStatus);
                parameters.Add("@CountryId", invoiceRequest.CountryId);
                parameters.Add("@CompanyId", invoiceRequest.CompanyId);
                parameters.Add("@BranchId", invoiceRequest.BranchId);
                parameters.Add("@Id", invoiceRequest.Id);
                //parameters.Add("@TicketId", invoiceRequest.TicketId);
                parameters.Add("@InvoiceNo", invoiceRequest.InvoiceNo);

                parameters.Add("@Printing", invoiceRequest.Printing);
                //parameters.Add("@PrintedOn", invoiceRequest.Invoice.PrintedOn);
                
                parameters.Add("@ModifiedBy", invoiceRequest.User);

                using (var connection = new SqlConnection(connectionString))
                {
                    //
                    // PaymentRequest Header
                    //
                    var affectedRows = await connection.ExecuteAsync("operation.SP_Invoice_Printing_Status_Update", parameters, commandType: CommandType.StoredProcedure);


                    responsePage.Code = 200;
                    responsePage.Message = "Data Updated";

                    return responsePage;
                }
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Faile to update";

                return responsePage;
            }
        }
        public async Task<ResponsePage<InvoiceResponse>> UpdateStatusRePrint(InvoiceRePrintingRequest invoiceRequest)
        {
            var responsePage = new ResponsePage<InvoiceResponse>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RowStatus", invoiceRequest.RowStatus == "" ? "ACT" : invoiceRequest.RowStatus);
                parameters.Add("@CountryId", invoiceRequest.CountryId);
                parameters.Add("@CompanyId", invoiceRequest.CompanyId);
                parameters.Add("@BranchId", invoiceRequest.BranchId);
                parameters.Add("@Id", invoiceRequest.Id);
                //parameters.Add("@TicketId", invoiceRequest.TicketId);
                parameters.Add("@InvoiceNo", invoiceRequest.InvoiceNo);

                parameters.Add("@RePrintApproved", invoiceRequest.RePrintApproved);
                parameters.Add("@RePrintApprovedBy", invoiceRequest.RePrintApprovedBy);

                parameters.Add("@ModifiedBy", invoiceRequest.User);

                using (var connection = new SqlConnection(connectionString))
                {
                    //
                    // PaymentRequest Header
                    //
                    var affectedRows = await connection.ExecuteAsync("operation.SP_Invoice_RePrinting_Status_Update", parameters, commandType: CommandType.StoredProcedure);


                    responsePage.Code = 200;
                    responsePage.Message = "Data Updated";

                    return responsePage;
                }
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Faile to update";

                return responsePage;
            }
        }

        public async Task<ResponsePage<InvoiceResponse>> UpdateStatusDelivered(InvoiceDeliveredRequest invoiceRequest)
        {
            var responsePage = new ResponsePage<InvoiceResponse>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RowStatus", invoiceRequest.RowStatus == "" ? "ACT" : invoiceRequest.RowStatus);
                parameters.Add("@CountryId", invoiceRequest.CountryId);
                parameters.Add("@CompanyId", invoiceRequest.CompanyId);
                parameters.Add("@BranchId", invoiceRequest.BranchId);
                parameters.Add("@Id", invoiceRequest.Id);
                //parameters.Add("@TicketId", invoiceRequest.TicketId);
                parameters.Add("@InvoiceNo", invoiceRequest.InvoiceNo);

                parameters.Add("@IsDelivered", invoiceRequest.IsDelivered);
                parameters.Add("@DeliveredOn", invoiceRequest.DeliveredOn);
                parameters.Add("@DeliveredRemarks", invoiceRequest.DeliveredRemarks);

                parameters.Add("@ModifiedBy", invoiceRequest.User);

                using (var connection = new SqlConnection(connectionString))
                {
                    //
                    // PaymentRequest Header
                    //
                    var affectedRows = await connection.ExecuteAsync("operation.SP_Invoice_Delivered_Status_Update", parameters, commandType: CommandType.StoredProcedure);


                    responsePage.Code = 200;
                    responsePage.Message = "Data Updated";

                    return responsePage;
                }
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Faile to update";

                return responsePage;
            }
        }

        public async Task<ResponsePage<InvoiceResponsePage>> Read(InvoiceRequestPage requestPage)
        {
            var responsePage = new ResponsePage<InvoiceResponsePage>();

            try
            {
                int a = requestPage.UserLogin.Filter.Length;
                string queryfilter = "";
                for (int i = 0; i < a; i++)
                {
                    string x = "";
                    string y = "";
                    y = requestPage.UserLogin.Filter[i].Field;
                    x = requestPage.UserLogin.Filter[i].Data;
                    queryfilter = queryfilter + " AND iv." + y + " LIKE '%" + x + "%' ";
                }
                string yu = queryfilter;

                var parameters = new DynamicParameters();

                parameters.Add("@RowStatus", requestPage.RowStatus);
                parameters.Add("@CountryId", requestPage.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestPage.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestPage.UserLogin.BranchId);
                parameters.Add("@User", requestPage.UserLogin.UserCode);
                parameters.Add("@Id", 0);
                parameters.Add("@PageNo", requestPage.PageNumber);
                parameters.Add("@PageSize", requestPage.PageSize);
                parameters.Add("@Filter", queryfilter);
                parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@PageCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(connectionString))
                {
                    //using (var multi = (await connection.QueryMultipleAsync("operation.SP_Invoice_Read", parameters, commandType: CommandType.StoredProcedure)))
                    using (var multi = (await connection.QueryMultipleAsync("operation.SP_Invoice_Read_Filter", parameters, commandType: CommandType.StoredProcedure)))
                    {
                        InvoiceResponsePage invoiceResponsePage = new InvoiceResponsePage();

                        var invoiceColumns = (await multi.ReadAsync<InvoiceColumn>()).ToList();
                        var invoiceResponses = (await multi.ReadAsync<InvoiceResponse>()).ToList();

                        invoiceResponsePage.Columns = invoiceColumns;
                        invoiceResponsePage.Invoices = invoiceResponses;

                        responsePage.Data = invoiceResponsePage;

                        responsePage.TotalRowCount = parameters.Get<int>("@RowCount");
                        responsePage.TotalPage = parameters.Get<int>("@PageCount");

                        if (responsePage.Data != null)
                        {
                            responsePage.Code = 200;
                            responsePage.Message = "Successfully read";
                        }
                        else
                        {
                            responsePage.Code = 204;
                            responsePage.Message = "No content";
                        }

                        return responsePage;
                    }
                }

            }

            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to read";

                return responsePage;
            }
        }

        public async Task<ResponsePage<InvoiceResponseId>> Read(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceResponseId>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RowStatus", requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@User", requestId.UserLogin.UserCode);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@PageNo", 0);
                parameters.Add("@PageSize", 0);
                parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@PageCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var multi = (await connection.QueryMultipleAsync("operation.SP_Invoice_Read", parameters, commandType: CommandType.StoredProcedure)))
                    {
                        InvoiceResponseId invoiceResponseId = new InvoiceResponseId();

                        var invoice = (await multi.ReadAsync<InvoiceResponse>()).First();
                        var invoiceDetails = (await multi.ReadAsync<InvoiceDetailResponse>()).ToList();
                        var invoiceDetailProfitShares = (await multi.ReadAsync<InvoiceDetailProfitShareResponse>()).ToList();
                        var invoiceDetailStorages = (await multi.ReadAsync<InvoiceDetailStorageResponse>()).ToList();
                        var invoiceReqDels = (await multi.ReadAsync<InvoiceReqDelResponse>()).ToList();
                        var invoiceExportEJKPs = (await multi.ReadAsync<InvoiceExportEJKPResponse>()).ToList();
                        var invoiceExportFakturs = (await multi.ReadAsync<InvoiceExportFakturResponse>()).ToList();

                        var invoiceColumns = (await multi.ReadAsync<InvoiceColumn>()).ToList();

                        invoiceResponseId.Columns = invoiceColumns;
                        invoiceResponseId.Invoice = invoice;
                        invoiceResponseId.InvoiceDetails = invoiceDetails;
                        if (invoiceResponseId.InvoiceDetails.Count > 0)
                        {
                            invoiceResponseId.InvoiceDetails[0].InvoiceDetailProfitShares = invoiceDetailProfitShares;
                            if (invoiceResponseId.InvoiceDetails[0].InvoiceDetailProfitShares.Count > 0)
                            {
                                invoiceResponseId.InvoiceDetails[0].InvoiceDetailStorages = invoiceDetailStorages;
                            }

                            invoiceResponseId.InvoiceReqDels = invoiceReqDels;
                            invoiceResponseId.InvoiceExportEJKPs = invoiceExportEJKPs;
                            invoiceResponseId.InvoiceExportFakturs = invoiceExportFakturs;

                        }

                        responsePage.Data = invoiceResponseId;

                        responsePage.TotalRowCount = parameters.Get<int>("@RowCount");
                        responsePage.TotalPage = parameters.Get<int>("@PageCount");


                        if (responsePage.Data != null)
                        {
                            responsePage.Code = 200;
                            responsePage.Message = "Successfully read";
                        }
                        else
                        {
                            responsePage.Code = 204;
                            responsePage.Message = "No content";
                        }

                        return responsePage;
                    }
                }

            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to read";

                return responsePage;
            }
        }

        public async Task<ResponsePage<InvoiceResponse>> Create(InvoiceRequestTransaction invoiceRequest)
        {
            var responsePage = new ResponsePage<InvoiceResponse>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RowStatus", invoiceRequest.Invoice.RowStatus == "" ? "ACT" : invoiceRequest.Invoice.RowStatus);
                parameters.Add("@CountryId", invoiceRequest.Invoice.CountryId);
                parameters.Add("@CompanyId", invoiceRequest.Invoice.CompanyId);
                parameters.Add("@BranchId", invoiceRequest.Invoice.BranchId);
                parameters.Add("@Id", invoiceRequest.Invoice.Id);
                parameters.Add("@TicketId", invoiceRequest.Invoice.TicketId);
                parameters.Add("@InvoiceNo", invoiceRequest.Invoice.InvoiceNo);
                parameters.Add("@DebetCredit", invoiceRequest.Invoice.DebetCredit);
                parameters.Add("@ShipmentId", invoiceRequest.Invoice.ShipmentId);
                parameters.Add("@CustomerTypeId", invoiceRequest.Invoice.CustomerTypeId);
                parameters.Add("@CustomerId", invoiceRequest.Invoice.CustomerId);
                parameters.Add("@CustomerName", invoiceRequest.Invoice.CustomerName);
                parameters.Add("@CustomerAddress", invoiceRequest.Invoice.CustomerAddress);
                parameters.Add("@BillId", invoiceRequest.Invoice.BillId);
                parameters.Add("@BillName", invoiceRequest.Invoice.BillName);
                parameters.Add("@BillAddress", invoiceRequest.Invoice.BillAddress);
                parameters.Add("@InvoicesTo", invoiceRequest.Invoice.InvoicesTo);
                parameters.Add("@InvoiceStatus", invoiceRequest.Invoice.InvoiceStatus);
                parameters.Add("@PaymentUSD", invoiceRequest.Invoice.PaymentUSD);
                parameters.Add("@PaymentIDR", invoiceRequest.Invoice.PaymentIDR);
                parameters.Add("@TotalVatUSD", invoiceRequest.Invoice.TotalVatUSD);
                parameters.Add("@TotalVatIDR", invoiceRequest.Invoice.TotalVatIDR);
                parameters.Add("@Rate", invoiceRequest.Invoice.Rate);
                parameters.Add("@ExRateDate", invoiceRequest.Invoice.ExRateDate);
                parameters.Add("@Period", invoiceRequest.Invoice.Period);
                parameters.Add("@YearPeriod", invoiceRequest.Invoice.YearPeriod);
                parameters.Add("@InvoicesAgent", invoiceRequest.Invoice.InvoicesAgent);
                parameters.Add("@InvoicesEdit", invoiceRequest.Invoice.InvoicesEdit);
                parameters.Add("@JenisInvoices", invoiceRequest.Invoice.JenisInvoices);
                parameters.Add("@LinkTo", invoiceRequest.Invoice.LinkTo);
                parameters.Add("@DueDate", invoiceRequest.Invoice.DueDate);
                parameters.Add("@Paid", invoiceRequest.Invoice.Paid);
                parameters.Add("@PaidOn", invoiceRequest.Invoice.PaidOn);
                parameters.Add("@SaveOR", invoiceRequest.Invoice.SaveOR);
                parameters.Add("@BadDebt", invoiceRequest.Invoice.BadDebt);
                parameters.Add("@BadDebtOn", invoiceRequest.Invoice.BadDebtOn);
                parameters.Add("@ReBadDebt", invoiceRequest.Invoice.ReBadDebt);
                parameters.Add("@DateReBadDebt", invoiceRequest.Invoice.DateReBadDebt);
                parameters.Add("@Printing", invoiceRequest.Invoice.Printing);
                parameters.Add("@PrintedOn", invoiceRequest.Invoice.PrintedOn);
                parameters.Add("@Deleted", invoiceRequest.Invoice.Deleted);
                parameters.Add("@DeletedOn", invoiceRequest.Invoice.DeletedOn);
                parameters.Add("@InvoiceNo2", invoiceRequest.Invoice.InvoiceNo2);
                parameters.Add("@InvHeader", invoiceRequest.Invoice.InvHeader);
                parameters.Add("@ExRateId", invoiceRequest.Invoice.ExRateId);
                parameters.Add("@RePrintApproved", invoiceRequest.Invoice.RePrintApproved);
                parameters.Add("@RePrintApprovedOn", invoiceRequest.Invoice.RePrintApprovedOn);
                parameters.Add("@RePrintApprovedBy", invoiceRequest.Invoice.RePrintApprovedBy);
                parameters.Add("@DeletedRemarks", invoiceRequest.Invoice.DeletedRemarks);
                parameters.Add("@IdLama", invoiceRequest.Invoice.IdLama);
                parameters.Add("@IsCostToCost", invoiceRequest.Invoice.IsCostToCost);
                parameters.Add("@SFPNoFormat", invoiceRequest.Invoice.SFPNoFormat);
                parameters.Add("@SFPDetailId", invoiceRequest.Invoice.SFPDetailId);
                parameters.Add("@UniqueKeySFP", invoiceRequest.Invoice.UniqueKeySFP);
                parameters.Add("@UniqueKeyInvoice", invoiceRequest.Invoice.UniqueKeyInvoice);
                parameters.Add("@DeleteType", invoiceRequest.Invoice.DeleteType);
                parameters.Add("@DeleteTypeRefInvId", invoiceRequest.Invoice.DeleteTypeRefInvId);
                parameters.Add("@KursKMK", invoiceRequest.Invoice.KursKMK);
                parameters.Add("@KursKMKId", invoiceRequest.Invoice.KursKMKId);
                parameters.Add("@IsDelivered", invoiceRequest.Invoice.IsDelivered);
                parameters.Add("@DeliveredOn", invoiceRequest.Invoice.DeliveredOn);
                parameters.Add("@DeliveredRemarks", invoiceRequest.Invoice.DeliveredRemarks);
                parameters.Add("@SFPReference", invoiceRequest.Invoice.SFPReference);
                parameters.Add("@ApprovedCredit", invoiceRequest.Invoice.ApprovedCredit);
                parameters.Add("@ApprovedCreditBy", invoiceRequest.Invoice.ApprovedCreditBy);
                parameters.Add("@ApprovedCreditOn", invoiceRequest.Invoice.ApprovedCreditOn);
                parameters.Add("@ApprovedCreditRemarks", invoiceRequest.Invoice.ApprovedCreditRemarks);
                parameters.Add("@PackingListNo", invoiceRequest.Invoice.PackingListNo);
                parameters.Add("@SICustomerNo", invoiceRequest.Invoice.SICustomerNo);
                parameters.Add("@Reference", invoiceRequest.Invoice.Reference);
                parameters.Add("@IsStampDuty", invoiceRequest.Invoice.IsStampDuty);
                parameters.Add("@StampDutyAmount", invoiceRequest.Invoice.StampDutyAmount);
                parameters.Add("@PEJKPNumber", invoiceRequest.Invoice.PEJKPNumber);
                parameters.Add("@PEJKPReference", invoiceRequest.Invoice.PEJKPReference);
                parameters.Add("@CreatedBy", invoiceRequest.Invoice.User);
                parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


                using (var connection = new SqlConnection(connectionString))
                {
                    //
                    // Invoice Header
                    //
                    var affectedRows = await connection.ExecuteAsync("operation.SP_Invoice_Create", parameters, commandType: CommandType.StoredProcedure);

                    int id = parameters.Get<int>("@RETURNVALUE");

                    //
                    // InvoiceDetail
                    //
                    for (int i = 0; i < invoiceRequest.InvoiceDetails.Count; i++)
                    {
                        var parameterDetails = new DynamicParameters();

                        parameterDetails.Add("@RowStatus", invoiceRequest.InvoiceDetails[i].RowStatus == "" ? "ACT" : invoiceRequest.InvoiceDetails[i].RowStatus);
                        parameterDetails.Add("@CountryId", invoiceRequest.Invoice.CountryId);
                        parameterDetails.Add("@CompanyId", invoiceRequest.Invoice.CompanyId);
                        parameterDetails.Add("@BranchId", invoiceRequest.Invoice.BranchId);
                        parameterDetails.Add("@InvoiceId", id);
                        parameterDetails.Add("@Sequence", i+1);
                        parameterDetails.Add("@DebetCredit", invoiceRequest.InvoiceDetails[i].DebetCredit);
                        parameterDetails.Add("@AccountId", invoiceRequest.InvoiceDetails[i].AccountId);
                        parameterDetails.Add("@Description", invoiceRequest.InvoiceDetails[i].Description);
                        parameterDetails.Add("@Type", invoiceRequest.InvoiceDetails[i].Type);
                        parameterDetails.Add("@CodingQuantity", invoiceRequest.InvoiceDetails[i].CodingQuantity);
                        parameterDetails.Add("@Quantity", invoiceRequest.InvoiceDetails[i].Quantity);
                        parameterDetails.Add("@PerQty", invoiceRequest.InvoiceDetails[i].PerQty);
                        parameterDetails.Add("@Sign", invoiceRequest.InvoiceDetails[i].Sign);
                        parameterDetails.Add("@AmountCrr", invoiceRequest.InvoiceDetails[i].AmountCrr);
                        parameterDetails.Add("@Amount", invoiceRequest.InvoiceDetails[i].Amount);
                        parameterDetails.Add("@PercentVat", invoiceRequest.InvoiceDetails[i].PercentVat);
                        parameterDetails.Add("@AmountVat", invoiceRequest.InvoiceDetails[i].AmountVat);
                        parameterDetails.Add("@EPLDetailId", invoiceRequest.InvoiceDetails[i].EPLDetailId);
                        parameterDetails.Add("@VatId", invoiceRequest.InvoiceDetails[i].VatId);
                        parameterDetails.Add("@IdLama", invoiceRequest.InvoiceDetails[i].IdLama);
                        parameterDetails.Add("@IsCostToCost", invoiceRequest.InvoiceDetails[i].IsCostToCost);
                        parameterDetails.Add("@OriginalUsd", invoiceRequest.InvoiceDetails[i].OriginalUsd);
                        parameterDetails.Add("@OriginalRate", invoiceRequest.InvoiceDetails[i].OriginalRate);
                        parameterDetails.Add("@CreatedBy", invoiceRequest.InvoiceDetails[i].User);

                        var affectedDetailRows = await connection.ExecuteAsync("operation.SP_InvoiceDetail_Create", parameterDetails, commandType: CommandType.StoredProcedure);

                        int detailid = parameterDetails.Get<int>("@RETURNVALUE");

                        if (invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares.Count != 0)
                        {
                            for (int j = 0; j < invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares.Count; j++)
                            {
                                var parameterDetailsProfitShares = new DynamicParameters();
                                parameterDetailsProfitShares.Add("@RowStatus", invoiceRequest.InvoiceDetails[i].RowStatus == "" ? "ACT" : invoiceRequest.InvoiceDetails[i].RowStatus);
                                parameterDetailsProfitShares.Add("@CountryId", invoiceRequest.Invoice.CountryId);
                                parameterDetailsProfitShares.Add("@CompanyId", invoiceRequest.Invoice.CompanyId);
                                parameterDetailsProfitShares.Add("@BranchId", invoiceRequest.Invoice.BranchId);
                                parameterDetailsProfitShares.Add("@InvoiceDetailId", detailid);
                                parameterDetailsProfitShares.Add("@InvoiceDetailSequence", i);
                                parameterDetailsProfitShares.Add("@Sequence", j+1);
                                parameterDetailsProfitShares.Add("@BFeet20", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].BFeet20);
                                parameterDetailsProfitShares.Add("@BFeet40", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].BFeet40);
                                parameterDetailsProfitShares.Add("@BFeetHQ", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].BFeetHQ);
                                parameterDetailsProfitShares.Add("@BFeetM3", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].BFeetM3);
                                parameterDetailsProfitShares.Add("@SFeet20", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].SFeet20);
                                parameterDetailsProfitShares.Add("@SFeet40", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].SFeet40);
                                parameterDetailsProfitShares.Add("@SFeetHQ", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].SFeetHQ);
                                parameterDetailsProfitShares.Add("@SFeetM3", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].SFeetM3);
                                parameterDetailsProfitShares.Add("@BRate20", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].BRate20);
                                parameterDetailsProfitShares.Add("@BRate40", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].BRate40);
                                parameterDetailsProfitShares.Add("@BRateHQ", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].BRateHQ);
                                parameterDetailsProfitShares.Add("@BRateM3", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].BRateM3);
                                parameterDetailsProfitShares.Add("@SRate20", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].SRate20);
                                parameterDetailsProfitShares.Add("@SRate40", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].SRate40);
                                parameterDetailsProfitShares.Add("@SRateHQ", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].SRateHQ);
                                parameterDetailsProfitShares.Add("@SRateM3", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].SRateM3);
                                parameterDetailsProfitShares.Add("@Percentage", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].Percentage);
                                parameterDetailsProfitShares.Add("@IdLama ", invoiceRequest.InvoiceDetails[i].InvoiceDetailProfitShares[j].IdLama);

                                var affectedDetailProfitSharesRows = await connection.ExecuteAsync("operation.SP_InvoiceDetailProfitShare_Create", parameterDetailsProfitShares, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (invoiceRequest.InvoiceDetails[i].InvoiceDetailStorages.Count != 0)
                        {
                            for (int j = 0; j < invoiceRequest.InvoiceDetails[i].InvoiceDetailStorages.Count; j++)
                            {
                                var parameterDetailsStorages = new DynamicParameters();
                                parameterDetailsStorages.Add("@RowStatus", invoiceRequest.InvoiceDetails[i].RowStatus == "" ? "ACT" : invoiceRequest.InvoiceDetails[i].RowStatus);
                                parameterDetailsStorages.Add("@CountryId", invoiceRequest.Invoice.CountryId);
                                parameterDetailsStorages.Add("@CompanyId", invoiceRequest.Invoice.CompanyId);
                                parameterDetailsStorages.Add("@BranchId", invoiceRequest.Invoice.BranchId);
                                parameterDetailsStorages.Add("@InvoiceDetailId", detailid);
                                parameterDetailsStorages.Add("@InvoiceDetailSequence", i);
                                parameterDetailsStorages.Add("@Sequence", j + 1);
                                parameterDetailsStorages.Add("@FromDate", invoiceRequest.InvoiceDetails[i].InvoiceDetailStorages[j].FromDate);
                                parameterDetailsStorages.Add("@ToDate", invoiceRequest.InvoiceDetails[i].InvoiceDetailStorages[j].ToDate);
                                parameterDetailsStorages.Add("@TotalDays", invoiceRequest.InvoiceDetails[i].InvoiceDetailStorages[j].TotalDays);
                                parameterDetailsStorages.Add("@StorageDetailId", invoiceRequest.InvoiceDetails[i].InvoiceDetailStorages[j].StorageDetailId);
                                parameterDetailsStorages.Add("@AmountIDR", invoiceRequest.InvoiceDetails[i].InvoiceDetailStorages[j].AmountIDR);
                                parameterDetailsStorages.Add("@AmountUSD", invoiceRequest.InvoiceDetails[i].InvoiceDetailStorages[j].AmountUSD);
                                parameterDetailsStorages.Add("@StorageId", invoiceRequest.InvoiceDetails[i].InvoiceDetailStorages[j].StorageId);

                                var affectedDetailStoragesRows = await connection.ExecuteAsync("operation.SP_InvoiceDetailStorage_Create", parameterDetailsStorages, commandType: CommandType.StoredProcedure);
                            }
                        }
                    }

                    //transaction.Commit();
                    //}

                    responsePage.Code = 200;
                    responsePage.Message = "Data created";

                    return responsePage;

                }
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Faile to create";

                return responsePage;
            }
        }

        public async Task<ResponsePage<InvoiceResponse>> Update(InvoiceRequestTransaction invoiceRequest)
        {
            var responsePage = new ResponsePage<InvoiceResponse>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RowStatus", invoiceRequest.Invoice.RowStatus == "" ? "ACT" : invoiceRequest.Invoice.RowStatus);
                parameters.Add("@CountryId", invoiceRequest.Invoice.CountryId);
                parameters.Add("@CompanyId", invoiceRequest.Invoice.CompanyId);
                parameters.Add("@BranchId", invoiceRequest.Invoice.BranchId);
                parameters.Add("@Id", invoiceRequest.Invoice.Id);
                parameters.Add("@TicketId", invoiceRequest.Invoice.TicketId);
                parameters.Add("@InvoiceNo", invoiceRequest.Invoice.InvoiceNo);
                parameters.Add("@DebetCredit", invoiceRequest.Invoice.DebetCredit);
                parameters.Add("@ShipmentId", invoiceRequest.Invoice.ShipmentId);
                parameters.Add("@CustomerTypeId", invoiceRequest.Invoice.CustomerTypeId);
                parameters.Add("@CustomerId", invoiceRequest.Invoice.CustomerId);
                parameters.Add("@CustomerName", invoiceRequest.Invoice.CustomerName);
                parameters.Add("@CustomerAddress", invoiceRequest.Invoice.CustomerAddress);
                parameters.Add("@BillId", invoiceRequest.Invoice.BillId);
                parameters.Add("@BillName", invoiceRequest.Invoice.BillName);
                parameters.Add("@BillAddress", invoiceRequest.Invoice.BillAddress);
                parameters.Add("@InvoicesTo", invoiceRequest.Invoice.InvoicesTo);
                parameters.Add("@InvoiceStatus", invoiceRequest.Invoice.InvoiceStatus);
                parameters.Add("@PaymentUSD", invoiceRequest.Invoice.PaymentUSD);
                parameters.Add("@PaymentIDR", invoiceRequest.Invoice.PaymentIDR);
                parameters.Add("@TotalVatUSD", invoiceRequest.Invoice.TotalVatUSD);
                parameters.Add("@TotalVatIDR", invoiceRequest.Invoice.TotalVatIDR);
                parameters.Add("@Rate", invoiceRequest.Invoice.Rate);
                parameters.Add("@ExRateDate", invoiceRequest.Invoice.ExRateDate);
                parameters.Add("@Period", invoiceRequest.Invoice.Period);
                parameters.Add("@YearPeriod", invoiceRequest.Invoice.YearPeriod);
                parameters.Add("@InvoicesAgent", invoiceRequest.Invoice.InvoicesAgent);
                parameters.Add("@InvoicesEdit", invoiceRequest.Invoice.InvoicesEdit);
                parameters.Add("@JenisInvoices", invoiceRequest.Invoice.JenisInvoices);
                parameters.Add("@LinkTo", invoiceRequest.Invoice.LinkTo);
                parameters.Add("@DueDate", invoiceRequest.Invoice.DueDate);
                parameters.Add("@Paid", invoiceRequest.Invoice.Paid);
                parameters.Add("@PaidOn", invoiceRequest.Invoice.PaidOn);
                parameters.Add("@SaveOR", invoiceRequest.Invoice.SaveOR);
                parameters.Add("@BadDebt", invoiceRequest.Invoice.BadDebt);
                parameters.Add("@BadDebtOn", invoiceRequest.Invoice.BadDebtOn);
                parameters.Add("@ReBadDebt", invoiceRequest.Invoice.ReBadDebt);
                parameters.Add("@DateReBadDebt", invoiceRequest.Invoice.DateReBadDebt);
                parameters.Add("@Printing", invoiceRequest.Invoice.Printing);
                parameters.Add("@PrintedOn", invoiceRequest.Invoice.PrintedOn);
                parameters.Add("@Deleted", invoiceRequest.Invoice.Deleted);
                parameters.Add("@DeletedOn", invoiceRequest.Invoice.DeletedOn);
                parameters.Add("@InvoiceNo2", invoiceRequest.Invoice.InvoiceNo2);
                parameters.Add("@InvHeader", invoiceRequest.Invoice.InvHeader);
                parameters.Add("@ExRateId", invoiceRequest.Invoice.ExRateId);
                parameters.Add("@RePrintApproved", invoiceRequest.Invoice.RePrintApproved);
                parameters.Add("@RePrintApprovedOn", invoiceRequest.Invoice.RePrintApprovedOn);
                parameters.Add("@RePrintApprovedBy", invoiceRequest.Invoice.RePrintApprovedBy);
                parameters.Add("@DeletedRemarks", invoiceRequest.Invoice.DeletedRemarks);
                parameters.Add("@IdLama", invoiceRequest.Invoice.IdLama);
                parameters.Add("@IsCostToCost", invoiceRequest.Invoice.IsCostToCost);
                parameters.Add("@SFPNoFormat", invoiceRequest.Invoice.SFPNoFormat);
                parameters.Add("@SFPDetailId", invoiceRequest.Invoice.SFPDetailId);
                parameters.Add("@UniqueKeySFP", invoiceRequest.Invoice.UniqueKeySFP);
                parameters.Add("@UniqueKeyInvoice", invoiceRequest.Invoice.UniqueKeyInvoice);
                parameters.Add("@DeleteType", invoiceRequest.Invoice.DeleteType);
                parameters.Add("@DeleteTypeRefInvId", invoiceRequest.Invoice.DeleteTypeRefInvId);
                parameters.Add("@KursKMK", invoiceRequest.Invoice.KursKMK);
                parameters.Add("@KursKMKId", invoiceRequest.Invoice.KursKMKId);
                parameters.Add("@IsDelivered", invoiceRequest.Invoice.IsDelivered);
                parameters.Add("@DeliveredOn", invoiceRequest.Invoice.DeliveredOn);
                parameters.Add("@DeliveredRemarks", invoiceRequest.Invoice.DeliveredRemarks);
                parameters.Add("@SFPReference", invoiceRequest.Invoice.SFPReference);
                parameters.Add("@ApprovedCredit", invoiceRequest.Invoice.ApprovedCredit);
                parameters.Add("@ApprovedCreditBy", invoiceRequest.Invoice.ApprovedCreditBy);
                parameters.Add("@ApprovedCreditOn", invoiceRequest.Invoice.ApprovedCreditOn);
                parameters.Add("@ApprovedCreditRemarks", invoiceRequest.Invoice.ApprovedCreditRemarks);
                parameters.Add("@PackingListNo", invoiceRequest.Invoice.PackingListNo);
                parameters.Add("@SICustomerNo", invoiceRequest.Invoice.SICustomerNo);
                parameters.Add("@Reference", invoiceRequest.Invoice.Reference);
                parameters.Add("@IsStampDuty", invoiceRequest.Invoice.IsStampDuty);
                parameters.Add("@StampDutyAmount", invoiceRequest.Invoice.StampDutyAmount);
                parameters.Add("@PEJKPNumber", invoiceRequest.Invoice.PEJKPNumber);
                parameters.Add("@PEJKPReference", invoiceRequest.Invoice.PEJKPReference);
                parameters.Add("@ModifiedBy", invoiceRequest.Invoice.User);

                using (var connection = new SqlConnection(connectionString))
                {
                    //
                    // PaymentRequest Header
                    //
                    var affectedRows = await connection.ExecuteAsync("operation.SP_Invoice_Update", parameters, commandType: CommandType.StoredProcedure);


                    //
                    // PaymentRequestDetail
                    //
                    for (int i = 0; i < invoiceRequest.InvoiceDetails.Count; i++)
                    {
                        var parameterDetails = new DynamicParameters();

                        parameterDetails.Add("@RowStatus", invoiceRequest.InvoiceDetails[i].RowStatus == "" ? "ACT" : invoiceRequest.InvoiceDetails[i].RowStatus);
                        parameterDetails.Add("@CountryId", invoiceRequest.Invoice.CountryId);
                        parameterDetails.Add("@CompanyId", invoiceRequest.Invoice.CompanyId);
                        parameterDetails.Add("@BranchId", invoiceRequest.Invoice.BranchId);
                        parameterDetails.Add("@InvoiceId", invoiceRequest.Invoice.Id);
                        parameterDetails.Add("@Sequence", i+1);
                        parameterDetails.Add("@DebetCredit", invoiceRequest.InvoiceDetails[i].DebetCredit);
                        parameterDetails.Add("@AccountId", invoiceRequest.InvoiceDetails[i].AccountId);
                        parameterDetails.Add("@Description", invoiceRequest.InvoiceDetails[i].Description);
                        parameterDetails.Add("@Type", invoiceRequest.InvoiceDetails[i].Type);
                        parameterDetails.Add("@CodingQuantity", invoiceRequest.InvoiceDetails[i].CodingQuantity);
                        parameterDetails.Add("@Quantity", invoiceRequest.InvoiceDetails[i].Quantity);
                        parameterDetails.Add("@PerQty", invoiceRequest.InvoiceDetails[i].PerQty);
                        parameterDetails.Add("@Sign", invoiceRequest.InvoiceDetails[i].Sign);
                        parameterDetails.Add("@AmountCrr", invoiceRequest.InvoiceDetails[i].AmountCrr);
                        parameterDetails.Add("@Amount", invoiceRequest.InvoiceDetails[i].Amount);
                        parameterDetails.Add("@PercentVat", invoiceRequest.InvoiceDetails[i].PercentVat);
                        parameterDetails.Add("@AmountVat", invoiceRequest.InvoiceDetails[i].AmountVat);
                        parameterDetails.Add("@EPLDetailId", invoiceRequest.InvoiceDetails[i].EPLDetailId);
                        parameterDetails.Add("@VatId", invoiceRequest.InvoiceDetails[i].VatId);
                        parameterDetails.Add("@IdLama", invoiceRequest.InvoiceDetails[i].IdLama);
                        parameterDetails.Add("@IsCostToCost", invoiceRequest.InvoiceDetails[i].IsCostToCost);
                        parameterDetails.Add("@OriginalUsd", invoiceRequest.InvoiceDetails[i].OriginalUsd);
                        parameterDetails.Add("@OriginalRate", invoiceRequest.InvoiceDetails[i].OriginalRate);
                        parameterDetails.Add("@ModifiedBy", invoiceRequest.InvoiceDetails[i].User);

                        var affectedDetailRows = await connection.ExecuteAsync("operation.SP_InvoiceDetail_Update", parameterDetails, commandType: CommandType.StoredProcedure);
                    }


                    //transaction.Commit();
                    //}

                    responsePage.Code = 200;
                    responsePage.Message = "Data Updated";

                    return responsePage;
                }
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Faile to update";

                return responsePage;
            }
        }

        public async Task<ResponsePage<InvoiceResponse>> Delete(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var parameterDetails = new DynamicParameters();
                parameterDetails.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameterDetails.Add("@CountryId", requestId.UserLogin.CountryId);
                parameterDetails.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameterDetails.Add("@BranchId", requestId.UserLogin.BranchId);
                parameterDetails.Add("@Id", requestId.Id);
                parameterDetails.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                using (var connection = new SqlConnection(connectionString))
                {
                    //
                    // Header
                    //
                    var affectedRows = await connection.ExecuteAsync("operation.SP_Invoice_Delete", parameters, commandType: CommandType.StoredProcedure);

                    //
                    //Detail
                    //
                    var affectedDetailRows = await connection.ExecuteAsync("operation.SP_InvoiceDetail_Delete", parameterDetails, commandType: CommandType.StoredProcedure);

                    responsePage.Code = 200;
                    responsePage.Message = "Data deleted";

                    return responsePage;
                }
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Faile to delete";

                return responsePage;
            }
        }

    }
}
