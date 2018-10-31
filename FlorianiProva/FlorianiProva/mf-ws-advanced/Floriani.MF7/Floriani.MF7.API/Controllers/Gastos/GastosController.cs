using System.Web.Http;
using AutoMapper;
using Floriani.MF7.API.Controllers.Comum;
using Floriani.MF7.API.Filters;
using Floriani.MF7.API.Models.Gastos.ViewModel;
using Floriani.MF7.Aplicacao.Funcionalidades.Gastos;
using Floriani.MF7.Aplicacao.Funcionalidades.Gastos.Comandos;
using Floriani.MF7.Dominio.Funcionalidades.Gastos;

using Microsoft.AspNet.OData.Query;

namespace Floriani.MF7.API.Controllers.Gastos
{
	[Authorize]
	[RoutePrefix( "api/gastos" )]
	public class GastosController : ApiControllerBase
	{
		public IGastoServico _gastoServico;

		public GastosController(IGastoServico gastoServico) : base() =>
			_gastoServico = gastoServico;

		#region GET
		[HttpGet]
		[ODataQueryOptionsValidate]
		public IHttpActionResult Get(ODataQueryOptions<Gasto> queryOptions)
		{
			var query = _gastoServico.PegarTodos();
			return HandleQuery<Gasto, GastoViewModel>( query, queryOptions );
		}

		[HttpGet]
		[Route( "{id:int}" )]
		public IHttpActionResult GetById(int id)
		{
			var gasto = _gastoServico.PegarPorId( id );

			return HandleCallback( () => Mapper.Map<Gasto, GastoViewModel>( gasto ) );
		}
		#endregion
		#region POST
		[HttpPost]
		public IHttpActionResult Post(ComandoRegistrarGasto gastoCmd)
		{
			var validador = gastoCmd.Validate();
			if (!validador.IsValid)
				return HandleValidationFailure( validador.Errors );

			return HandleCallback( () => _gastoServico.Inserir( gastoCmd ) );
		}
		#endregion
		#region DELETE
		[HttpDelete]
		public IHttpActionResult Deletar(ComandoDeletarGasto gastoCmd)
			=> HandleCallback( () => _gastoServico.Deletar( gastoCmd ) );
		#endregion
	}
}
