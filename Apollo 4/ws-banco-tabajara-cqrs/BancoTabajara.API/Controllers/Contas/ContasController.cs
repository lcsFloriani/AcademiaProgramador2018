using BancoTabajara.API.Controllers.Comum;
using BancoTabajara.Aplicacao.Funcionalidades.Contas;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.AlterarEstado;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Atualizar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Deletar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Depositar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Registrar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Sacar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Transferir;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Querys;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.ViewModels;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace BancoTabajara.API.Controllers.Contas
{
    [RoutePrefix("api/contas")]
    public class ContasController : ApiControllerBase
    {
        public IContaServico _contaServico;

        public ContasController(IContaServico contaServico)
        {
            _contaServico = contaServico;
        }

        #region GET

        [HttpGet]
        public IHttpActionResult Listagem()
        {
            var keyValuePairs = this.Request.GetQueryNameValuePairs();
            KeyValuePair<string, string> quantidadePares = keyValuePairs.First(x => x.Key.Equals("quantidade"));
            int quantidade = int.Parse(quantidadePares.Value);

            ContaQuery contaQuery = new ContaQuery(quantidade);

            var contas = _contaServico.Listagem(contaQuery);

            return HandleQueryable<Conta,ContaViewModel>(contas);
        }

        [HttpGet, Authorize]
        [Route("{id:long}")]
        public IHttpActionResult BuscarPorId(long id)
        {
            var conta = _contaServico.BuscarPorId(id);

            return HandleQuery<Conta, ContaViewModel>(conta);
        }

        [HttpGet, Authorize]
        [Route("{id:long}/extrato")]
        public IHttpActionResult GerarExtrato(long id)
        {
            var conta = _contaServico.GerarExtrato(id);

            return HandleQuery<Conta, ContaExtratoViewModel>(conta);
        }

        #endregion

        #region POST

        [HttpPost, Authorize]
        public IHttpActionResult Adicionar(ContaRegistroCommand command)
        {
            var resultadoValidacao = command.Validar();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);
            
            return HandleCallback(_contaServico.Adicionar(command));
        }
        #endregion

        #region PUT

        [HttpPut, Authorize]
        public IHttpActionResult Atualizar(ContaAtualizaCommand command)
        {
            var resultadoValidacao = command.Validar();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);
            
            return HandleCallback(_contaServico.Atualizar(command));
        }

        [HttpPut, Authorize]
        [Route("transferencia")]
        public IHttpActionResult RealizarTransferencia(ContaTransferenciaCommand command)
        {
            var resultadoValidacao = command.Validar();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);
            
            return HandleCallback(_contaServico.RealizarTransferencia(command));
        }

        #endregion

        #region DELETE

        [HttpDelete, Authorize]
        public IHttpActionResult Excluir(ContaDeletaCommand command)
        {
            var resultadoValidacao = command.Validar();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);
            
            return HandleCallback(_contaServico.Excluir(command));
        }

        #endregion

        #region PATCH

        [HttpPatch, Authorize]
        [Route("estadoconta")]
        public IHttpActionResult AlaterarEstado(ContaEstadoCommand command)
        {
            var resultadoValidacao = command.Validar();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);
            
            return HandleCallback(_contaServico.AlterarEstado(command));
        }

        [HttpPatch, Authorize]
        [Route("saque")]
        public IHttpActionResult Sacar(ContaSaqueCommand command)
        {
            var resultadoValidacao = command.Validar();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);
            
            return HandleCallback(_contaServico.Sacar(command));
        }

        [HttpPatch, Authorize]
        [Route("deposito")]
        public IHttpActionResult Depositar(ContaDepositoCommand command)
        {
            var resultadoValidacao = command.Validar();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);
            
            return HandleCallback(_contaServico.Depositar(command));
        }

        #endregion

    }
}
