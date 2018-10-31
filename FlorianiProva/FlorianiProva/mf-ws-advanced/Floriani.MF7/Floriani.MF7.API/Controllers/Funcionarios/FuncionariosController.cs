using System.Web.Http;
using AutoMapper;
using Floriani.MF7.API.Controllers.Comum;
using Floriani.MF7.API.Filters;
using Floriani.MF7.API.Models.Funcionarios.ViewModel;
using Floriani.MF7.Aplicacao.Funcionalidades.Funcionarios;
using Floriani.MF7.Aplicacao.Funcionalidades.Funcionarios.Comandos;
using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;
using Microsoft.AspNet.OData.Query;

namespace Floriani.MF7.API.Controllers.Funcionarios
{
	//[Authorize]
	[RoutePrefix( "api/funcionarios" )]
	public class FuncionariosController : ApiControllerBase
	{
		public IFuncionarioServico _funcionarioServico;

		public FuncionariosController(IFuncionarioServico funcionarioServico) : base() =>
			_funcionarioServico = funcionarioServico;

		#region GET
		[HttpGet]
		[ODataQueryOptionsValidate]
		public IHttpActionResult Get(ODataQueryOptions<Funcionario> queryOptions)
		{
			var query = _funcionarioServico.PegarTodos();
			return HandleQuery<Funcionario, FuncionarioViewModel>( query, queryOptions );
		}

		[HttpGet]
		[Route( "{id:int}" )]
		public IHttpActionResult GetById(int id)
		{
			var funcionario = _funcionarioServico.PegarPorId( id );

			return HandleCallback( () => Mapper.Map<Funcionario, FuncionarioViewModel>( funcionario ) );
		}
		#endregion

		#region POST
		public IHttpActionResult Post(ComandoRegistrarFuncionario funcionarioCmd)
		{
			var validador = funcionarioCmd.Validate();
			if (!validador.IsValid)
				return HandleValidationFailure( validador.Errors );

			return HandleCallback( () => _funcionarioServico.Inserir( funcionarioCmd ) );
		}
		#endregion
		#region PATCH(Status)
		[HttpPatch]
		[Route( "{id:int}" )]
		public IHttpActionResult AtualizarStatus(int id)
			=> HandleCallback( () => _funcionarioServico.AtualizarStatus( id ) );
		
		#endregion
		#region PUT
		[HttpPut]
		public IHttpActionResult Atualizar(ComandoAtualizarFuncionario funcionarioCmd)
		{
			var validador = funcionarioCmd.Validate();
			if (!validador.IsValid)
				return HandleValidationFailure( validador.Errors );

			return HandleCallback( () => _funcionarioServico.Atualizar( funcionarioCmd ) );
		}
		#endregion
		#region DELETE
		[HttpDelete]
		public IHttpActionResult Deletar(ComandoDeletarFuncionario funcionarioCmd)
			=> HandleCallback( () => _funcionarioServico.Deletar( funcionarioCmd ) );
		#endregion 
	}
}
