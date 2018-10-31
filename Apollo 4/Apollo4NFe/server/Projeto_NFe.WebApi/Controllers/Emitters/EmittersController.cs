using FluentValidation.Results;
using Microsoft.AspNet.OData.Query;
using Projeto_NFe.Application.Features.Emitters;
using Projeto_NFe.Application.Features.Emitters.Commands;
using Projeto_NFe.Application.Features.Emitters.Queries;
using Projeto_NFe.Application.Features.Emitters.ViewModels;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.WebApi.Controllers.Common;
using Projeto_NFe.WebApi.Filters;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_NFe.WebApi.Controllers.Emitters
{
	[RoutePrefix("api/emitters")]
	public class EmittersController : ApiControllerBase
	{
		public IEmitterService service;

        public EmittersController(IEmitterService service) : base() => this.service = service;

		#region POST

		[HttpPost]
		public IHttpActionResult Add(EmitterRegisterCommand command)
		{
			ValidationResult validationResult = command.Validate();

			if (!validationResult.IsValid)
				return HandleValidationFailure(validationResult.Errors);

			return HandleCallback(service.Add(command));
		}

		#endregion

		#region PUT

		[HttpPut]
		public IHttpActionResult Update(EmitterUpdateCommand command)
		{
			ValidationResult validationResult = command.Validate();

			if (!validationResult.IsValid)
				return HandleValidationFailure(validationResult.Errors);

			return HandleCallback(service.Update(command));
		}

		#endregion

		#region GET

		[HttpGet]
		[ODataQueryOptionsValidate]
		public IHttpActionResult Get(ODataQueryOptions<Emitter> queryOptions) => HandleQueryable<Emitter, EmitterViewModel>(service.GetAll(), queryOptions);

		[HttpGet]
		[Route("{id:int}")]
		public IHttpActionResult GetById(int id) => HandleQuery<Emitter, EmitterViewModel>(service.Get(id));

		#endregion

		#region DELETE

		[HttpDelete]
		public IHttpActionResult Delete(EmitterDeleteCommand command)
		{
			ValidationResult validationResult = command.Validate();

			if (!validationResult.IsValid)
				return HandleValidationFailure(validationResult.Errors);

			return HandleCallback(service.Delete(command));
		}

		#endregion
	}
}
