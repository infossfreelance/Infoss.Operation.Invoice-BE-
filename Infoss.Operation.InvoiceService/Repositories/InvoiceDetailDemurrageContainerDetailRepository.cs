    
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Infoss.Operation.InvoiceModel;

namespace Infoss.Operation.InvoiceService.Repositories
{
    public class InvoiceDetailDemurrageContainerDetailRepository : IInvoiceDetailDemurrageContainerDetailRepository
    {
        private SqlConnection connection;
        public int InvoiceDetailDemurrageContainerId;

        public InvoiceDetailDemurrageContainerDetailRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public async Task<ResponsePage<InvoiceDetailDemurrageContainerDetailResponse>> Create(InvoiceDetailDemurrageContainerDetailTransaction invDetDemuContainerDetails)
        {
            var responsePage = new ResponsePage<InvoiceDetailDemurrageContainerDetailResponse>();

            var parameters = new DynamicParameters();

            int index = 1;
            foreach (InvoiceDetailDemurrageContainerDetailRequest invDetDemuContainerDetail in invDetDemuContainerDetails.InvoiceDetailDemurrageContainerDetail)
            {
                parameters.Add("@RowStatus", invDetDemuContainerDetail.RowStatus == "" ? "ACT" : invDetDemuContainerDetail.RowStatus);
                parameters.Add("@CountryId", invDetDemuContainerDetail.CountryId);
                parameters.Add("@CompanyId", invDetDemuContainerDetail.CompanyId);
                parameters.Add("@BranchId", invDetDemuContainerDetail.BranchId);
                parameters.Add("@InvoiceDetailDemurrageContainerId", InvoiceDetailDemurrageContainerId);
                parameters.Add("@Sequence", index);
                parameters.Add("@DayContainer", invDetDemuContainerDetail.DayContainer);
                parameters.Add("@Description", invDetDemuContainerDetail.Description);
                parameters.Add("@AmountContainer20", invDetDemuContainerDetail.AmountContainer20);
                parameters.Add("@AmountContainer40", invDetDemuContainerDetail.AmountContainer40);
                parameters.Add("@IdLama", invDetDemuContainerDetail.IdLama);
                parameters.Add("@CreatedBy", invDetDemuContainerDetail.User);
                parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                try
                {
                    var affectedRows = await connection.ExecuteAsync("operation.SP_InvoiceDetailDemurrageContainerDetail_Create", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<ResponsePage<InvoiceDetailDemurrageContainerDetailResponse>> Deleted(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailDemurrageContainerDetailResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetailDemurrageContainerDetail_Deleted", parameters, commandType: CommandType.StoredProcedure);

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

        public async Task<ResponsePage<InvoiceDetailDemurrageContainerDetailResponse>> Delete(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailDemurrageContainerDetailResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetailDemurrageContainerDetail_Delete", parameters, commandType: CommandType.StoredProcedure);

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
