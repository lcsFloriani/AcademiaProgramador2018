using Projeto_NFe.WebApi.Controllers.Common;
using Projeto_NFe.WebApi.Filters;
using Projeto_NFe.Application.Features.Conveyors;
using Projeto_NFe.Application.Features.Conveyors.Commands;
using Projeto_NFe.Application.Features.Conveyors.Queries;
using Projeto_NFe.Application.Features.Conveyors.ViewModels;
using Projeto_NFe.Domain.Features.Conveyors;
using FluentValidation.Results;
using Microsoft.AspNet.OData.Query;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_NFe.WebApi.Controllers.Conveyors
{
    [RoutePrefix("api/conveyors")]
    public class ConveyorsController : ApiControllerBase
    {
        public IConveyorService _conveyorService;

        public ConveyorsController(IConveyorService conveyorService) : base() =>
            _conveyorService = conveyorService;
        #region POST

        [HttpPost]
        public IHttpActionResult Add(ConveyorRegisterCommand command)
        {
            ValidationResult validationResult = command.Validate();

            if (!validationResult.IsValid)
                return HandleValidationFailure(validationResult.Errors);

            return HandleCallback(_conveyorService.Add(command));
        }

        #endregion

        #region PUT

        [HttpPut]
        public IHttpActionResult Update(ConveyorUpdateCommand command)
        {
            ValidationResult validationResult = command.Validate();

            if (!validationResult.IsValid)
                return HandleValidationFailure(validationResult.Errors);

            return HandleCallback(_conveyorService.Update(command));
        }

        #endregion

        #region GET

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Conveyor> queryOptions) => HandleQueryable<Conveyor, ConveyorViewModel>(_conveyorService.GetAll(), queryOptions);

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id) => HandleQuery<Conveyor, ConveyorViewModel>(_conveyorService.Get(id));
        
        #endregion

        #region DELETE

        [HttpDelete]
        public IHttpActionResult Delete(ConveyorDeleteCommand command)
        {
            ValidationResult validationResult = command.Validate();

            if (!validationResult.IsValid)
                return HandleValidationFailure(validationResult.Errors);

            return HandleCallback(_conveyorService.Delete(command));
        }

        #endregion
    }
}
