
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Infoss.Master.MessageModel;
using Infoss.Operation.InvoiceModel;
using Infoss.Reg.UserAccessModel;

namespace Infoss.Operation.InvoiceService.Repositories
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        private SqlConnection connection;
        public int invoiceId;
        public int countryId;
        public int companyId;
        public int branchId;

        private InvoiceDetailDemurrageRepository invoiceDetailDemurrageRepo;
        private InvoiceDetailHandlingRepository invoiceDetailHandlingRepo;
        private InvoiceDetailProfitShareRepository invoiceDetailProfitShareRepo;
        private InvoiceDetailStorageRepository invoiceDetailStorageRepo;

        public InvoiceDetailRepository(SqlConnection connection)
        {
            this.connection = connection;
            invoiceDetailDemurrageRepo = new InvoiceDetailDemurrageRepository(connection);
            invoiceDetailHandlingRepo = new InvoiceDetailHandlingRepository(connection);
            invoiceDetailProfitShareRepo = new InvoiceDetailProfitShareRepository(connection);
            invoiceDetailStorageRepo = new InvoiceDetailStorageRepository(connection);
        }

        public async Task<ResponsePage<InvoiceDetailResponse>> Create(InvoiceDetailTransaction invoiceDetails)
        {
            var responsePage = new ResponsePage<InvoiceDetailResponse>();

            var parameters = new DynamicParameters();

            int index = 1;
            foreach (InvoiceDetailRequest invoiceDetail in invoiceDetails.InvoiceDetails)
            {
                parameters.Add("@RowStatus", invoiceDetail.RowStatus == "" ? "ACT" : invoiceDetail.RowStatus);
                parameters.Add("@CountryId", countryId);
                parameters.Add("@CompanyId", companyId);
                parameters.Add("@BranchId", branchId);
                parameters.Add("@InvoiceId", invoiceId);
                parameters.Add("@Sequence", index);
                parameters.Add("@DebetCredit", invoiceDetail.DebetCredit);
                parameters.Add("@AccountId", invoiceDetail.AccountId);
                parameters.Add("@Description", invoiceDetail.Description);
                parameters.Add("@Type", invoiceDetail.Type);
                parameters.Add("@CodingQuantity", invoiceDetail.CodingQuantity);
                parameters.Add("@Quantity", invoiceDetail.Quantity);
                parameters.Add("@PerQty", invoiceDetail.PerQty);
                parameters.Add("@Sign", invoiceDetail.Sign);
                parameters.Add("@AmountCrr", invoiceDetail.AmountCrr);
                parameters.Add("@Amount", invoiceDetail.Amount);
                parameters.Add("@PercentVat", invoiceDetail.PercentVat);
                parameters.Add("@AmountVat", invoiceDetail.AmountVat);
                parameters.Add("@EPLDetailId", invoiceDetail.EPLDetailId);
                parameters.Add("@VatId", invoiceDetail.VatId);
                parameters.Add("@IdLama", invoiceDetail.IdLama);
                parameters.Add("@IsCostToCost", invoiceDetail.IsCostToCost);
                parameters.Add("@OriginalUsd", invoiceDetail.OriginalUsd);
                parameters.Add("@OriginalRate", invoiceDetail.OriginalRate);
                parameters.Add("@CreatedBy", invoiceDetail.User);
                parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                try
                {
                    var affectedRows = await connection.ExecuteAsync("operation.SP_InvoiceDetail_Create", parameters, commandType: CommandType.StoredProcedure);
                    int id = parameters.Get<int>("@RETURNVALUE");

                    //// Invoice Demurrage Insert

                    //invoiceDetailDemurrageRepo.invoiceDetailId = id;
                    //invoiceDetailDemurrageRepo.accountId = invoiceDetail.AccountId;
                    //invoiceDetailDemurrageRepo.invoiceId = invoiceId;

                    //InvoiceDetailDemurrageTransaction invoiceDetailDemurrageTransaction = new InvoiceDetailDemurrageTransaction();
                    //invoiceDetailDemurrageTransaction.InvoiceDetailDemurrage = invoiceDetail.InvoiceDetailDemurrages;

                    //await invoiceDetailDemurrageRepo.Create(invoiceDetailDemurrageTransaction);


                    //// Invoice Handling Insert

                    //invoiceDetailHandlingRepo.invoiceDetailId = id;

                    //InvoiceDetailHandlingTransaction invoiceDetailHandlingTransaction = new InvoiceDetailHandlingTransaction();
                    //invoiceDetailHandlingTransaction.InvoiceDetailHandling = invoiceDetail.InvoiceDetailHandlings;

                    //await invoiceDetailHandlingRepo.Create(invoiceDetailHandlingTransaction);


                    //// Invoice ProfitShare Insert

                    //invoiceDetailProfitShareRepo.invoiceDetailId = id;

                    //InvoiceDetailProfitShareTransaction invoiceDetailProfitShareTransaction = new InvoiceDetailProfitShareTransaction();
                    //invoiceDetailProfitShareTransaction.InvoiceDetailProfitShare = invoiceDetail.InvoiceDetailProfitShares;

                    //await invoiceDetailProfitShareRepo.Create(invoiceDetailProfitShareTransaction);


                    // Invoice Storage Insert

                    invoiceDetailStorageRepo.invoiceDetailId = id;
                    invoiceDetailStorageRepo.invoiceId = invoiceId;
                    invoiceDetailStorageRepo.accountId = invoiceDetail.AccountId;
                    invoiceDetailStorageRepo.countryId = countryId;
                    invoiceDetailStorageRepo.companyId = companyId;
                    invoiceDetailStorageRepo.branchId = branchId;

                    InvoiceDetailStorageTransaction invoiceDetailStorageTransaction = new InvoiceDetailStorageTransaction();
                    invoiceDetailStorageTransaction.InvoiceDetailStorage = invoiceDetail.InvoiceDetailStorages;

                    await invoiceDetailStorageRepo.Create(invoiceDetailStorageTransaction);

                    index++;

                }
                catch (Exception ex)
                {
                    responsePage.Code = 500;
                    responsePage.Error = ex.Message;
                    responsePage.Message = "Failed to create";

                    return responsePage;
                }
            }

            responsePage.Code = 200;
            responsePage.Message = "Data created";

            return responsePage;
        }

        public async Task<ResponsePage<InvoiceDetailResponse>> Update(InvoiceDetailTransaction invoiceDetails)
        {
            var responsePage = new ResponsePage<InvoiceDetailResponse>();

            var parameters = new DynamicParameters();


            // Delete Invoice Detail

            var requestId = new RequestId();
            requestId.Id = invoiceId;
            requestId.UserLogin.CountryId = countryId;
            requestId.UserLogin.CompanyId = companyId;
            requestId.UserLogin.BranchId = branchId;

            await Deleted(requestId);


            // Insert All Invoice Detail After Delete

            await Create(invoiceDetails);


            responsePage.Code = 200;
            responsePage.Message = "Data updated";

            return responsePage;
        }

        public async Task<ResponsePage<InvoiceDetailResponse>> Deleted(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetail_Deleted", parameters, commandType: CommandType.StoredProcedure);

                //// Invoice Demurrage Deleted
                //await invoiceDetailDemurrageRepo.Deleted(requestId);

                //// Invoice Handling Deleted
                //await invoiceDetailHandlingRepo.Deleted(requestId);

                //// Invoice ProfitShare Deleted
                //await invoiceDetailProfitShareRepo.Deleted(requestId);

                // Invoice Storage Deleted
                await invoiceDetailStorageRepo.Deleted(requestId);

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

        public async Task<ResponsePage<InvoiceDetailResponse>> Delete(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetail_Delete", parameters, commandType: CommandType.StoredProcedure);

                // Invoice Demurrage Delete
                await invoiceDetailDemurrageRepo.Delete(requestId);

                // Invoice Handling Delete
                await invoiceDetailHandlingRepo.Delete(requestId);

                // Invoice ProfitShare Delete
                await invoiceDetailProfitShareRepo.Delete(requestId);

                // Invoice Storage Delete
                await invoiceDetailStorageRepo.Delete(requestId);

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
