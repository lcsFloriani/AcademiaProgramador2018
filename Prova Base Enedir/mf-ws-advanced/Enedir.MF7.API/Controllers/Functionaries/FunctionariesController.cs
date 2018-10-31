using Enedir.MF7.API.Controllers.Common;
using Enedir.MF7.Application.Features.Functionaries;
using Enedir.MF7.Application.Features.Functionaries.Commands;
using Enedir.MF7.Application.Features.Functionaries.Querys;
using Enedir.MF7.Application.Features.Functionaries.ViewModels;
using Enedir.MF7.Domain.Features.Functionaries;
using FluentValidation.Results;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Enedir.MF7.API.Controllers.Functionaries
{
    [Authorize]
    [RoutePrefix("api/functionaries")]
    public class FunctionariesController : ApiControllerBase
    {

        private IFunctionaryService _service;

        public FunctionariesController(IFunctionaryService service)
        {
            _service = service;
        }

        #region POST

        [HttpPost]
        public IHttpActionResult PostAdd(FunctionaryRegisterCommand command)
        {
            ValidationResult resultadoValidacao = command.Validate();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);

            return HandleCallback(() => _service.Add(command));
        }
        #endregion

        #region PUT

        [HttpPut]
        public IHttpActionResult PutUpdate(FunctionaryUpdateCommand command)
        {
            ValidationResult resultadoValidacao = command.Validate();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);

            return HandleCallback(() => _service.Update(command));
        }

        #endregion

        #region PATCH

        [HttpPatch]
        [Route("status")]
        public IHttpActionResult PatchChangeStatus(FunctionaryChangeStatusCommand command)
        {
            ValidationResult resultadoValidacao = command.Validate();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);

            return HandleCallback(() => _service.ChangeStatus(command));
        }

        #endregion

        #region GET

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var keyValuePairs = this.Request.GetQueryNameValuePairs();
            KeyValuePair<string, string> quantidadePares = keyValuePairs.First(x => x.Key.Equals("quantity"));
            int quantidade = int.Parse(quantidadePares.Value);

            FunctionaryQuery clienteQuery = new FunctionaryQuery(quantidade);

            var query = _service.GetAll(clienteQuery);

            return HandleQueryable<Functionary, FunctionaryViewModel>(query); ;
        }

        [HttpGet]
        [Route("{id:long}")]
        public IHttpActionResult GetById(long id)
        {
            return HandleQuery<Functionary, FunctionaryViewModel>(_service.GetById(id));
        }

        #endregion

        #region DELETE

        [HttpDelete]
        public IHttpActionResult Remove(FunctionaryDeleteCommand command)
        {
            ValidationResult resultadoValidacao = command.Validate();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);

            return HandleCallback(() => _service.Remove(command));
        }

        #endregion
    }
}
