﻿using Infoss.Operation.InvoiceModel;

namespace Infoss.Operation.InvoiceService.Repositories
{
    public interface IInvoiceRepository
    {
        public Task<ResponsePage<InvoiceResponsePage>> ReadAll(RequestPage requestPage);
        public Task<ResponsePage<InvoiceResponse>> UpdateStatusPrint(InvoicePrintingRequest invoicePrintingRequest);
        public Task<ResponsePage<InvoiceResponse>> UpdateStatusRePrint(InvoiceRePrintingRequest invoicePrintingRequest);
        public Task<ResponsePage<InvoiceResponsePage>> Read(RequestPage requestPage);
        public Task<ResponsePage<InvoiceResponseId>> Read(RequestId requestId);
        public Task<ResponsePage<InvoiceResponse>> Create(InvoiceRequestTransaction invoiceRequest);
        public Task<ResponsePage<InvoiceResponse>> Update(InvoiceRequestTransaction invoiceRequest);
        public Task<ResponsePage<InvoiceResponse>> Delete(RequestId requestId);

    }
}