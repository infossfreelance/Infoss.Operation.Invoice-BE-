
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Infoss.Operation.InvoiceModel;

namespace Infoss.Operation.InvoiceService.Repositories
{
    public class InvoiceDetailProfitShareRepository : IInvoiceDetailProfitShareRepository
    {
        private SqlConnection connection;
        public int invoiceDetailId;
        public int accountId;

        private const int Cost_BuyingRate = 3;
        private const int Cost_SellingRate = 4;

        public InvoiceDetailProfitShareRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public async Task<ResponsePage<InvoiceDetailProfitShareResponse>> Create(InvoiceDetailProfitShareTransaction invoiceDetailProfitShares)
        {
            var responsePage = new ResponsePage<InvoiceDetailProfitShareResponse>();

            if (accountId != Cost_BuyingRate && accountId != Cost_SellingRate)
            {
                responsePage.Code = 200;
                responsePage.Message = "Data is not handling fee";

                return responsePage;
            }

            var parameters = new DynamicParameters();

            int index = 1;
            foreach (InvoiceDetailProfitShareRequest invoiceDetailProfitShare in invoiceDetailProfitShares.InvoiceDetailProfitShare)
            {
                parameters.Add("@RowStatus", invoiceDetailProfitShare.RowStatus == "" ? "ACT" : invoiceDetailProfitShare.RowStatus);
                parameters.Add("@CountryId", invoiceDetailProfitShare.CountryId);
                parameters.Add("@CompanyId", invoiceDetailProfitShare.CompanyId);
                parameters.Add("@BranchId", invoiceDetailProfitShare.BranchId);
                parameters.Add("@InvoiceDetailId", invoiceDetailId);
                parameters.Add("@Sequence", index);
                parameters.Add("@SFeet20", invoiceDetailProfitShare.SFeet20);
                parameters.Add("@SFeet40", invoiceDetailProfitShare.SFeet40);
                parameters.Add("@SFeetHQ", invoiceDetailProfitShare.SFeetHQ);
                parameters.Add("@SFeetM3", invoiceDetailProfitShare.SFeetM3);
                parameters.Add("@SRate20", invoiceDetailProfitShare.SRate20);
                parameters.Add("@SRate40", invoiceDetailProfitShare.SRate40);
                parameters.Add("@SRateHQ", invoiceDetailProfitShare.SRateHQ);
                parameters.Add("@SRateM3", invoiceDetailProfitShare.SRateM3);
                parameters.Add("@BFeet20", invoiceDetailProfitShare.BFeet20);
                parameters.Add("@BFeet40", invoiceDetailProfitShare.BFeet40);
                parameters.Add("@BFeetHQ", invoiceDetailProfitShare.BFeetHQ);
                parameters.Add("@BFeetM3", invoiceDetailProfitShare.BFeetM3);
                parameters.Add("@BRate20", invoiceDetailProfitShare.BRate20);
                parameters.Add("@BRate40", invoiceDetailProfitShare.BRate40);
                parameters.Add("@BRateHQ", invoiceDetailProfitShare.BRateHQ);
                parameters.Add("@BRateM3", invoiceDetailProfitShare.BRateM3);
                parameters.Add("@Percentage", invoiceDetailProfitShare.Percentage);
                parameters.Add("@IdLama", invoiceDetailProfitShare.IdLama);
                parameters.Add("@CreatedBy", invoiceDetailProfitShare.User);
                parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                try
                {
                    var affectedRows = await connection.ExecuteAsync("operation.SP_InvoiceDetailProfitShare_Create", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<ResponsePage<InvoiceDetailProfitShareResponse>> Deleted(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailProfitShareResponse>();

            if (accountId != Cost_BuyingRate && accountId != Cost_SellingRate)
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

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetailProfitShare_Deleted", parameters, commandType: CommandType.StoredProcedure);

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

        public async Task<ResponsePage<InvoiceDetailProfitShareResponse>> Delete(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailProfitShareResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetailProfitShare_Delete", parameters, commandType: CommandType.StoredProcedure);

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
