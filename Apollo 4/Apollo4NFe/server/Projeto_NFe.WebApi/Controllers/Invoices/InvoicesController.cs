using FluentValidation.Results;
using Microsoft.AspNet.OData.Query;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.Invoices.Items_Invoice.Commands;
using Projeto_NFe.Application.Features.Invoices.ViewModels;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.WebApi.Controllers.Common;
using Projeto_NFe.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_NFe.WebApi.Controllers.Invoices
{
    [RoutePrefix("api/invoices")]
    public class InvoicesController : ApiControllerBase
    {
        private readonly IInvoiceInProcessService _invoiceIssuedService;
        public InvoicesController(IInvoiceInProcessService invoiceInProcessService) : base() 
            => _invoiceIssuedService = invoiceInProcessService;
        
        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<InvoiceInProcess> queryOptions) 
            => HandleQueryable<InvoiceInProcess, InvoiceInProcessViewModel>(_invoiceIssuedService.GetAll(), queryOptions);
        

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id) 
            => HandleQuery<InvoiceInProcess, InvoiceInProcessViewModel>(_invoiceIssuedService.Get(id));
        
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(InvoiceProcessCommandRegister Cmd)
        {
            var validator = Cmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_invoiceIssuedService.Add(Cmd));
        }
        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(InvoiceProcessCommandUpdate command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_invoiceIssuedService.Update(command));
        }

        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(InvoiceInProcessCommandDelete command)
        {
            ValidationResult validationResult = command.Validate();

            if (!validationResult.IsValid)
                return HandleValidationFailure(validationResult.Errors);

            return HandleCallback(_invoiceIssuedService.Delete(command));
        }

        #endregion HttpDelete
    }
}
