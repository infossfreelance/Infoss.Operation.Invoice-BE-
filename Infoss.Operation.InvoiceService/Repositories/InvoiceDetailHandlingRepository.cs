
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Infoss.Operation.InvoiceModel;

namespace Infoss.Operation.InvoiceService.Repositories
{
    public class InvoiceDetailHandlingRepository : IInvoiceDetailHandlingRepository
    {
        private SqlConnection connection;
        public int invoiceDetailId;
        public int accountId;

        private const int Cost_HandlingFee = 5;

        public InvoiceDetailHandlingRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public async Task<ResponsePage<InvoiceDetailHandlingResponse>> Create(InvoiceDetailHandlingTransaction invoiceDetailHandlings)
        {
            var responsePage = new ResponsePage<InvoiceDetailHandlingResponse>();

            if (accountId != Cost_HandlingFee)
            {
                responsePage.Code = 200;
                responsePage.Message = "Data is not handling fee";

                return responsePage;
            }

            var parameters = new DynamicParameters();

            int index = 1;
            foreach (InvoiceDetailHandlingRequest invoiceDetailHandling in invoiceDetailHandlings.InvoiceDetailHandling)
            {
                parameters.Add("@RowStatus", invoiceDetailHandling.RowStatus == "" ? "ACT" : invoiceDetailHandling.RowStatus);
                parameters.Add("@CountryId", invoiceDetailHandling.CountryId);
                parameters.Add("@CompanyId", invoiceDetailHandling.CompanyId);
                parameters.Add("@BranchId", invoiceDetailHandling.BranchId);
                parameters.Add("@InvoiceDetailId", invoiceDetailId);
                parameters.Add("@Sequence", index);
                parameters.Add("@Feet20", invoiceDetailHandling.Feet20);
                parameters.Add("@Feet40", invoiceDetailHandling.Feet40);
                parameters.Add("@FeetHQ", invoiceDetailHandling.FeetHQ);
                parameters.Add("@FeetM3", invoiceDetailHandling.FeetM3);
                parameters.Add("@Rate20", invoiceDetailHandling.Rate20);
                parameters.Add("@Rate40", invoiceDetailHandling.Rate40);
                parameters.Add("@RateHQ", invoiceDetailHandling.RateHQ);
                parameters.Add("@RateM3", invoiceDetailHandling.RateM3);
                parameters.Add("@IdLama", invoiceDetailHandling.IdLama);
                parameters.Add("@CreatedBy", invoiceDetailHandling.User);
                parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                try
                {
                    var affectedRows = await connection.ExecuteAsync("operation.SP_InvoiceDetailHandling_Create", parameters, commandType: CommandType.StoredProcedure);
                    int id = parameters.Get<int>("@RETURNVALUE");

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

        public async Task<ResponsePage<InvoiceDetailHandlingResponse>> Deleted(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailHandlingResponse>();

            if (accountId != Cost_HandlingFee)
            {
                responsePage.Code = 200;
                responsePage.Message = "Data is not handling fee";

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

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetailHandling_Deleted", parameters, commandType: CommandType.StoredProcedure);

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

        public async Task<ResponsePage<InvoiceDetailHandlingResponse>> Delete(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailHandlingResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetailHandling_Delete", parameters, commandType: CommandType.StoredProcedure);

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
