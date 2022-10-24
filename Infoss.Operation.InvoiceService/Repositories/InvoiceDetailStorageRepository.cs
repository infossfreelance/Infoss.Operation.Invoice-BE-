
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Infoss.Operation.InvoiceModel;

namespace Infoss.Operation.InvoiceService.Repositories
{
    public class InvoiceDetailStorageRepository : IInvoiceDetailStorageRepository
    {
        private SqlConnection connection;

        public int invoiceDetailId;
        public int invoiceId;
        public int accountId;
        public int countryId;
        public int companyId;
        public int branchId;

        private const int Cost_Storage = 306;
        private const int Cost_ExtensionStorage = 307;

        public InvoiceDetailStorageRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public async Task<ResponsePage<InvoiceDetailStorageResponse>> Create(InvoiceDetailStorageTransaction invoiceDetailStorages)
        {
            var responsePage = new ResponsePage<InvoiceDetailStorageResponse>();

            if (accountId != Cost_Storage && accountId != Cost_ExtensionStorage)
            {
                responsePage.Code = 200;
                responsePage.Message = "Data is not storage";

                return responsePage;
            }

            var parameters = new DynamicParameters();

            int index = 1;
            foreach (InvoiceDetailStorageRequest invoiceDetailStorage in invoiceDetailStorages.InvoiceDetailStorage)
            {
                parameters.Add("@RowStatus", invoiceDetailStorage.RowStatus == "" ? "ACT" : invoiceDetailStorage.RowStatus);
                parameters.Add("@CountryId", countryId);
                parameters.Add("@CompanyId", companyId);
                parameters.Add("@BranchId", branchId);
                parameters.Add("@InvoiceDetailId", invoiceDetailId);
                parameters.Add("@InvoiceId", invoiceId);
                parameters.Add("@Sequence", index);
                parameters.Add("@FromDate", invoiceDetailStorage.FromDate);
                parameters.Add("@ToDate", invoiceDetailStorage.ToDate);
                parameters.Add("@TotalDays", invoiceDetailStorage.TotalDays);
                parameters.Add("@StorageDetailId", invoiceDetailStorage.StorageDetailId);
                parameters.Add("@AmountIDR", invoiceDetailStorage.AmountIDR);
                parameters.Add("@AmountUSD", invoiceDetailStorage.AmountUSD);
                parameters.Add("@StorageId", invoiceDetailStorage.StorageId);
                parameters.Add("@CreatedBy", invoiceDetailStorage.User);
                parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                try
                {
                    var affectedRows = await connection.ExecuteAsync("operation.SP_InvoiceDetailStorage_Create", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<ResponsePage<InvoiceDetailStorageResponse>> Deleted(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailStorageResponse>();

            //if (accountId != Cost_Storage && accountId != Cost_ExtensionStorage)
            //{
            //    responsePage.Code = 200;
            //    responsePage.Message = "Data is not storage";

            //    return responsePage;
            //}

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetailStorage_Deleted", parameters, commandType: CommandType.StoredProcedure);

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

        public async Task<ResponsePage<InvoiceDetailStorageResponse>> Delete(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailStorageResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetailStorage_Delete", parameters, commandType: CommandType.StoredProcedure);

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
