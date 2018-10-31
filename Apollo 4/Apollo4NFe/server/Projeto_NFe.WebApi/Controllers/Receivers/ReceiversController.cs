
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using FluentValidation.Results;
using Microsoft.AspNet.OData.Query;
using Projeto_NFe.Application.Features.Receivers;
using Projeto_NFe.Application.Features.Receivers.Commands;
using Projeto_NFe.Application.Features.Receivers.Queries;
using Projeto_NFe.Application.Features.Receivers.ViewModels;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.WebApi.Controllers.Common;
using Projeto_NFe.WebApi.Filters;

namespace Projeto_NFe.WebApi.Controllers.Receivers
{
	[RoutePrefix( "api/receivers" )]
	public class ReceiversController : ApiControllerBase
	{
		public IReceiverService _service;

		public ReceiversController(IReceiverService service) : base() 
            => _service = service;
		
		#region POST

		[HttpPost]
		public IHttpActionResult Add(ReceiverRegisterCommand command)
		{
			ValidationResult validationResult = command.Validate();

			if (!validationResult.IsValid)
				return HandleValidationFailure( validationResult.Errors );

			return HandleCallback( _service.Add( command ) );
		}

		#endregion

		#region PUT

		[HttpPut]
		public IHttpActionResult Update(ReceiverUpdateCommand command)
		{
			ValidationResult validationResult = command.Validate();

			if (!validationResult.IsValid)
				return HandleValidationFailure( validationResult.Errors );

			return HandleCallback( _service.Update( command ) );
		}

		#endregion

		#region GET

		[HttpGet]
		[ODataQueryOptionsValidate]
		public IHttpActionResult GetAll(ODataQueryOptions<Receiver> queryOptions)
		{
			var queryString = Request.GetQueryNameValuePairs()
									.Where( x => x.Key.Equals( "size" ) )
									.FirstOrDefault();

			var query = default( IQueryable<Receiver> );
			int size = 0;
			if (queryString.Key != null && int.TryParse( queryString.Value, out size )) {
				query = _service.GetAll( new ReceiverQuery( size ) );
			} else
				query = _service.GetAll();

			return HandleQueryable<Receiver, ReceiverViewModel>( query, queryOptions );
		}

		[HttpGet]
		[Route( "{id:long}" )]
		public IHttpActionResult GetById(long id) 
            => HandleQuery<Receiver, ReceiverViewModel>( _service.Get( id ) );
	
		#endregion

		#region DELETE

		[HttpDelete]
		public IHttpActionResult Delete(ReceiverDeleteCommand command)
		{
			ValidationResult validationResult = command.Validate();

			if (!validationResult.IsValid)
				return HandleValidationFailure( validationResult.Errors );

			return HandleCallback( _service.Delete( command ) );
		}

		#endregion
	}
}
    
