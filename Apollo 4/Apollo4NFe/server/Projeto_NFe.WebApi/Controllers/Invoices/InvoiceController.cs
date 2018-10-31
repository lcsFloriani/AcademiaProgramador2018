using FluentValidation.Results;
using Microsoft.AspNet.OData.Query;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.Invoices.ViewModels;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.WebApi.Controllers.Common;
using Projeto_NFe.WebApi.Filters;
using System.Web.Http;

namespace Projeto_NFe.WebApi.Controllers.Features.Invoices
{
    [RoutePrefix("api/invoice")]
    public class InvoiceController : ApiControllerBase
    {
        private readonly IInvoiceIssuedService _invoiceIssuedService;
        public InvoiceController(IInvoiceIssuedService invoiceIssuedService) : base()
        {
            _invoiceIssuedService = invoiceIssuedService;
        }

        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<InvoiceIssued> queryOptions)
        {
            return HandleQueryable<InvoiceIssued, InvoiceIssuedViewModel>(_invoiceIssuedService.GetAll(), queryOptions);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleQuery<InvoiceIssued, InvoiceIssuedViewModel>(_invoiceIssuedService.Get(id));
        }
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(InvoiceIssuedCommandRegister Cmd)
        {
            var validator = Cmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_invoiceIssuedService.Add(Cmd));
        }

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(InvoiceIssuedCommandUpdate command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_invoiceIssuedService.Update(command));
        }

        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(InvoiceIssuedCommandDelete command)
        {
            ValidationResult validationResult = command.Validate();

            if (!validationResult.IsValid)
                return HandleValidationFailure(validationResult.Errors);

            return HandleCallback(_invoiceIssuedService.Delete(command));
        }

        #endregion HttpDelete
    }
}