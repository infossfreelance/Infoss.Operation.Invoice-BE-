
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Infoss.Operation.InvoiceModel;

namespace Infoss.Operation.InvoiceService.Repositories
{
    public class InvoiceDetailDemurrageRepository : IInvoiceDetailDemurrageRepository
    {
        private SqlConnection connection;
        public int invoiceDetailId;
        public int accountId;
        public int invoiceId;

        private const int Cost_Demurrage = 6;

        private InvoiceDetailDemurrageContainerRepository invoiceDetailDemurrageContainerRepo;

        public InvoiceDetailDemurrageRepository(SqlConnection connection)
        {
            this.connection = connection;
            invoiceDetailDemurrageContainerRepo = new InvoiceDetailDemurrageContainerRepository(connection);
        }

        //public async Task<ResponsePage<InvoiceDetailDemurrageResponse>> Create(InvoiceDetailTransaction invoiceDetail)
        //{
        //    var responsePage = new ResponsePage<InvoiceDetailDemurrageResponse>();

        //    if (accountId != Cost_Demurrage)
        //    {
        //        responsePage.Code = 200;
        //        responsePage.Message = "Data is not demurrage";

        //        return responsePage;
        //    }

        //    var parameters = new DynamicParameters();

        //    int index = 1;
        //    foreach (InvoiceDetailDemurrageRequest invoiceDetailDemurrage in invoiceDetailDemurrages.InvoiceDetailDemurrage)
        //    {
        //        parameters.Add("@RowStatus", invoiceDetailDemurrage.RowStatus == "" ? "ACT" : invoiceDetailDemurrage.RowStatus);
        //        parameters.Add("@CountryId", invoiceDetailDemurrage.CountryId);
        //        parameters.Add("@CompanyId", invoiceDetailDemurrage.CompanyId);
        //        parameters.Add("@BranchId", invoiceDetailDemurrage.BranchId);
        //        parameters.Add("@InvoiceDetailId", invoiceDetailId);
        //        parameters.Add("@InvoiceId", invoiceId);
        //        parameters.Add("@Sequence", index);
        //        parameters.Add("@BackContainerOn", invoiceDetailDemurrage.BackContainerOn);
        //        parameters.Add("@Freetime", invoiceDetailDemurrage.Freetime);
        //        parameters.Add("@Fase", invoiceDetailDemurrage.Fase);
        //        parameters.Add("@TotalContainer20", invoiceDetailDemurrage.TotalContainer20);
        //        parameters.Add("@TotalContainer40", invoiceDetailDemurrage.TotalContainer40);
        //        parameters.Add("@DiscType", invoiceDetailDemurrage.DiscType);
        //        parameters.Add("@DiscAmount", invoiceDetailDemurrage.DiscAmount);
        //        parameters.Add("@IdLama", invoiceDetailDemurrage.IdLama);
        //        parameters.Add("@CreatedBy", invoiceDetailDemurrage.User);
        //        parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

        //        try
        //        {
        //            var affectedRows = await connection.ExecuteAsync("operation.SP_InvoiceDetailDemurrage_Create", parameters, commandType: CommandType.StoredProcedure);
        //            int id = parameters.Get<int>("@RETURNVALUE");

        //            // Invoice Demurrage Container Insert

        //            invoiceDetailDemurrageContainerRepo.invoiceDetailDemurrageId = id;
        //            invoiceDetailDemurrageContainerRepo.invoiceId = invoiceId;

        //            InvoiceDetailDemurrageContainerTransaction invoiceDetailDemurrageContainerTransaction = new InvoiceDetailDemurrageContainerTransaction();
        //            invoiceDetailDemurrageContainerTransaction.InvoiceDetailDemurrageContainer = invoiceDetailDemurrage.InvoiceDetailDemurrageContainers;

        //            await invoiceDetailDemurrageContainerRepo.Create(invoiceDetailDemurrageContainerTransaction);

        //            index++;
        //        }
        //        catch (Exception ex)
        //        {
        //            responsePage.Code = 500;
        //            responsePage.Error = ex.Message;
        //            responsePage.Message = "Failed to create";

        //            return responsePage;
        //        }
        //    }

        //    responsePage.Code = 200;
        //    responsePage.Message = "Data created";

        //    return responsePage;
        //}

        public async Task<ResponsePage<InvoiceDetailDemurrageResponse>> Deleted(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailDemurrageResponse>();

            if (accountId != Cost_Demurrage)
            {
                responsePage.Code = 200;
                responsePage.Message = "Data is not demurrage";

                return responsePage;
            }

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetailDemurrage_Deleted", parameters, commandType: CommandType.StoredProcedure);

                // Invoice Demurrage Container Delete
                await invoiceDetailDemurrageContainerRepo.Deleted(requestId);

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

        public async Task<ResponsePage<InvoiceDetailDemurrageResponse>> Delete(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailDemurrageResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetailDemurrage_Delete", parameters, commandType: CommandType.StoredProcedure);

                // Invoice Demurrage Container Delete
                await invoiceDetailDemurrageContainerRepo.Delete(requestId);

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
