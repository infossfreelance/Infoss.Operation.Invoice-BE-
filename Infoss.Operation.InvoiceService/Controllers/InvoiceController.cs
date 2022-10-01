using Infoss.Operation.InvoiceService.Repositories;
using Infoss.Reg.UserAccessModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infoss.Operation.InvoiceService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository invoiceRepository;
        public IConfigurationRoot Configuration { get; }

        public InvoiceController()
        {
            IConfiguration Configuration = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").
                Build();

            invoiceRepository = new InvoiceRepository(Configuration);
        }

        [Route("PostByPageAll")]
        [HttpPost]
        public async Task<ResponsePage<InvoiceResponsePage>> GetPost(int pageNumber, int pageSize, [FromBody] UserLogin userLogin)
        {
            var route = Request.Path.Value;

            var requestPage = new RequestPage();
            requestPage.RowStatus = "ACT";
            requestPage.UserLogin = userLogin;
            requestPage.PageNumber = pageNumber;
            requestPage.PageSize = pageSize;

            var responsePage = await invoiceRepository.ReadAll(requestPage);
            return responsePage;

        }
        [Route("UpdateStatusPrint")]
        [HttpPut]
        public async Task<ResponsePage<InvoiceResponse>> PutStatusPrint([FromBody] InvoicePrintingRequest invoicePrintRequest)
        {
            return await invoiceRepository.UpdateStatusPrint(invoicePrintRequest);
        }

        [Route("UpdateStatusRePrint")]
        [HttpPut]
        public async Task<ResponsePage<InvoiceResponse>> PutStatusRePrint([FromBody] InvoiceRePrintingRequest invoiceRePrintRequest)
        {
            return await invoiceRepository.UpdateStatusRePrint(invoiceRePrintRequest);
        }

        [Route("PostByPage")]
        [HttpPost]
        public async Task<ResponsePage<InvoiceResponsePage>> Post(int pageNumber, int pageSize, [FromBody] UserLogin userLogin)
        {
            var route = Request.Path.Value;

            var requestPage = new RequestPage();
            requestPage.RowStatus = "ACT";
            requestPage.UserLogin = userLogin;
            requestPage.PageNumber = pageNumber;
            requestPage.PageSize = pageSize;

            var responsePage = await invoiceRepository.Read(requestPage);
            return responsePage;

        }

        [Route("PostById")]
        [HttpPost]
        public async Task<ResponsePage<InvoiceResponseId>> Post(int id, [FromBody] UserLogin userLogin)
        {
            var route = Request.Path.Value;

            var requestId = new RequestId();
            requestId.UserLogin = userLogin;
            requestId.Id = id;

            var responsePage = await invoiceRepository.Read(requestId);
            return responsePage;

        }

        [Route("Create")]
        [HttpPost]
        public async Task<ResponsePage<InvoiceResponse>> Post([FromBody] InvoiceRequestTransaction invoiceRequest)
        {
            return await invoiceRepository.Create(invoiceRequest);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ResponsePage<InvoiceResponse>> Put([FromBody] InvoiceRequestTransaction invoiceRequest)
        {
            return await invoiceRepository.Update(invoiceRequest);
        }

        [Route("Delete")]
        [HttpPut]
        public async Task<ResponsePage<InvoiceResponse>> Delete(int id, [FromBody] UserLogin userLogin)
        {
            var route = Request.Path.Value;

            var requestId = new RequestId();
            requestId.UserLogin = userLogin;
            requestId.Id = id;

            var responsePage = await invoiceRepository.Delete(requestId);
            return responsePage;
        }


    }
}
