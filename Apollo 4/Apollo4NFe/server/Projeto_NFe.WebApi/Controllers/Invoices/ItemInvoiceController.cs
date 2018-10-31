using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Application.Features.Invoices.Items_invoice.Commands;
using Projeto_NFe.Application.Features.Invoices.Items_Invoice.Commands;
using Projeto_NFe.WebApi.Controllers.Common;
using System.Web.Http;

namespace Projeto_NFe.WebApi.Controllers.Invoices
{
    public class ItemInvoiceController : ApiControllerBase
    {
        private readonly IInvoiceInProcessService _invoiceInProcessService;
        public ItemInvoiceController(IInvoiceInProcessService invoiceInProcessService) : base() 
            => _invoiceInProcessService = invoiceInProcessService;
        
        [HttpPost]
        public IHttpActionResult AddItem(ItemInvoiceRegisterCommand cmd) 
            => HandleCallback(_invoiceInProcessService.AddItem(cmd));
        
        [HttpDelete]
        public IHttpActionResult DeleteItems(ItemInvoiceDeleteCommand cmd) 
            => HandleCallback(_invoiceInProcessService.RemoveItem(cmd));
        
    }
}
