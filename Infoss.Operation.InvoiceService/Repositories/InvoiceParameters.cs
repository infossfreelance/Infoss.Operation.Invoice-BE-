using System.Data;
using Dapper;
using Infoss.Operation.InvoiceModel;

namespace Infoss.Operation.InvoiceService.Repositories
{
    public class InvoiceParameters : InvoiceParametersBase
    {

        public InvoiceParameters()
        {

        }
        public InvoiceParameters(InvoiceHeaderTransaction invoiceHeader)
        {
            InvoiceParameter(invoiceHeader);
        }
        public DynamicParameters Create()
        {
            invoiceHeader.InvoiceHeader.Id = 0;

            parameters.Add("@CreatedBy", invoiceHeader.InvoiceHeader.User);
            parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


            return parameters;
        }

        public DynamicParameters Update()
        {
            parameters.Add("@ModifiedBy", invoiceHeader.InvoiceHeader.User);
            parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


            return parameters;
        }

    }
}
