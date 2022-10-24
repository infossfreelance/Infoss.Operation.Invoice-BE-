
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Infoss.Operation.InvoiceModel;

namespace Infoss.Operation.InvoiceService.Repositories
{
    public class InvoiceDetailDemurrageContainerRepository : IInvoiceDetailDemurrageContainerRepository
    {
        private SqlConnection connection;
        public int invoiceDetailDemurrageId;
        public int invoiceId;

        private InvoiceDetailDemurrageContainerDetailRepository invDetDemuContainerDetailRepo;

        public InvoiceDetailDemurrageContainerRepository(SqlConnection connection)
        {
            this.connection = connection;
            invDetDemuContainerDetailRepo = new InvoiceDetailDemurrageContainerDetailRepository(connection);
        }

        public async Task<ResponsePage<InvoiceDetailDemurrageContainerResponse>> Create(InvoiceDetailDemurrageContainerTransaction invDetailDemurrageContainers)
        {
            var responsePage = new ResponsePage<InvoiceDetailDemurrageContainerResponse>();

            var parameters = new DynamicParameters();

            int index = 1;
            foreach (InvoiceDetailDemurrageContainerRequest invDetailDemurrageContainer in invDetailDemurrageContainers.InvoiceDetailDemurrageContainer)
            {
                parameters.Add("@RowStatus", invDetailDemurrageContainer.RowStatus == "" ? "ACT" : invDetailDemurrageContainer.RowStatus);
                parameters.Add("@CountryId", invDetailDemurrageContainer.CountryId);
                parameters.Add("@CompanyId", invDetailDemurrageContainer.CompanyId);
                parameters.Add("@BranchId", invDetailDemurrageContainer.BranchId);
                parameters.Add("@InvoiceDetailDemurrageId", invoiceDetailDemurrageId);
                parameters.Add("@InvoiceId", invoiceId);
                parameters.Add("@Sequence", index);
                parameters.Add("@ContainerNo", invDetailDemurrageContainer.ContainerNo);
                parameters.Add("@IdLama", invDetailDemurrageContainer.IdLama);
                parameters.Add("@CreatedBy", invDetailDemurrageContainer.User);
                parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                try
                {
                    var affectedRows = await connection.ExecuteAsync("operation.SP_InvoiceDetailDemurrageContainer_Create", parameters, commandType: CommandType.StoredProcedure);
                    int id = parameters.Get<int>("@RETURNVALUE");

                    // Invoice Demurrage Container Detail Insert

                    invDetDemuContainerDetailRepo.InvoiceDetailDemurrageContainerId = id;

                    InvoiceDetailDemurrageContainerDetailTransaction invDetDemuContainerDetailTransaction = new InvoiceDetailDemurrageContainerDetailTransaction();
                    invDetDemuContainerDetailTransaction.InvoiceDetailDemurrageContainerDetail = invDetailDemurrageContainer.InvoiceDetailDemurrageContainerDetails;

                    await invDetDemuContainerDetailRepo.Create(invDetDemuContainerDetailTransaction);


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

        public async Task<ResponsePage<InvoiceDetailDemurrageContainerResponse>> Deleted(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailDemurrageContainerResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetailDemurrageContainer_Deleted", parameters, commandType: CommandType.StoredProcedure);

                // Invoice Demurrage Container Delete
                await invDetDemuContainerDetailRepo.Deleted(requestId);

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

        public async Task<ResponsePage<InvoiceDetailDemurrageContainerResponse>> Delete(RequestId requestId)
        {
            var responsePage = new ResponsePage<InvoiceDetailDemurrageContainerResponse>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_InvoiceDetailDemurrageContainer_Delete", parameters, commandType: CommandType.StoredProcedure);

                // Invoice Demurrage Container Delete
                await invDetDemuContainerDetailRepo.Delete(requestId);

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
