using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Enedir.MF7.API.Controllers.Common;
using Enedir.MF7.Application.Features.Outgoing;
using Enedir.MF7.Application.Features.Outgoing.Commands;
using Enedir.MF7.Application.Features.Outgoing.Querys;
using Enedir.MF7.Application.Features.Outgoing.ViewModels;
using Enedir.MF7.Domain.Features.Outgoing;
using FluentValidation.Results;

namespace Enedir.MF7.API.Controllers.Outgoing
{
    [Authorize]
    [RoutePrefix("api/outgoing")]
    public class OutgoingController : ApiControllerBase
    {
        private IOutgoService _service;

        public OutgoingController(IOutgoService service)
        {
            _service = service;
        }

        #region POST

        [HttpPost]
        public IHttpActionResult PostAdd(OutgoRegisterCommand command)
        {
            ValidationResult resultadoValidacao = command.Validate();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);

            return HandleCallback(() => _service.Add(command));
        }
        #endregion

        #region GET

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var keyValuePairs = this.Request.GetQueryNameValuePairs();
            KeyValuePair<string, string> quantidadePares = keyValuePairs.First(x => x.Key.Equals("quantity"));
            int quantidade = int.Parse(quantidadePares.Value);

            OutgoQuery clienteQuery = new OutgoQuery(quantidade);

            var query = _service.GetAll(clienteQuery);

            return HandleQueryable<Outgo, OutgoViewModel>(query); ;
        }

        [HttpGet]
        [Route("{id:long}")]
        public IHttpActionResult GetById(long id)
        {
            return HandleQuery<Outgo, OutgoViewModel>(_service.GetById(id));
        }

        #endregion

        #region DELETE

        [HttpDelete]
        public IHttpActionResult Remove(OutgoDeleteCommand command)
        {
            ValidationResult resultadoValidacao = command.Validate();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);

            return HandleCallback(() => _service.Remove(command));
        }

        #endregion

    }
}
