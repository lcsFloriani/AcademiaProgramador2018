using BancoTabajara.API.Controllers.Comum;
using BancoTabajara.Aplicacao.Funcionalidades.Contas;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using BancoTabajara.Infra.ORM.Contexto;
using BancoTabajara.Infra.ORM.Funcionalidades.Contas;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace BancoTabajara.API.Controllers.Contas
{
    [RoutePrefix("api/contas")]
    public class ContasController : ApiControllerBase
    {
        private ContaRepositorio _reposistorio;
        public IContaServico _contaServico;

        public ContasController()
        {
            var contexto = new BancoTabajaraDbContexto();
            _reposistorio = new ContaRepositorio(contexto);
            _contaServico = new ContaServico(_reposistorio);
        }

        #region GET

        [HttpGet]
        public IHttpActionResult Listagem()
        {
            var keyValuePairs = this.Request.GetQueryNameValuePairs();
            KeyValuePair<string, string> quantidadePares = keyValuePairs.First(x => x.Key.Equals("quantidade"));
            int quantidade = int.Parse(quantidadePares.Value);

            var lista = _contaServico.Listagem(quantidade);
            return HandleQueryable(lista);
        }

        [HttpGet]
        [Route("{id:long}")]
        public IHttpActionResult BuscarPorId(long id)
        {
            return HandleCallback(() => _contaServico.BuscarPorId(id));
        }

        [HttpGet]
        [Route("{id:long}/gerarExtrato")]
        public IHttpActionResult GerarExtrato(long id)
        {
            return HandleCallback(() => _contaServico.GerarExtrato(id));
        }

        #endregion

        #region POST

        [HttpPost]
        public IHttpActionResult Adicionar(Conta conta)
        {
            return HandleCallback(() => _contaServico.Adicionar(conta));
        }
        #endregion

        #region PUT

        [HttpPut]
        public IHttpActionResult Atualizar(Conta conta)
        {
            return HandleCallback(() => _contaServico.Atualizar(conta));
        }

        [HttpPut]
        [Route("{idContaOrigem:long}/realizar_transferencia/{idContaDestino:long}")]
        public IHttpActionResult RealizarTransferencia(long idContaOrigem, long idContaDestino, [FromBody]double valorTransferencia)
        {
            return HandleCallback(() => _contaServico.RealizarTransferencia(idContaOrigem, idContaDestino, valorTransferencia));
        }

        #endregion

        #region DELETE

        [HttpDelete]
        [Route("{id:long}")]
        public IHttpActionResult Excluir(long id)
        {
            return HandleCallback(() => _contaServico.Excluir(id));
        }

        #endregion

        #region PATCH

        [HttpPatch]
        [Route("{id:long}/alterarestado")]
        public IHttpActionResult AlaterarEstado(long id, [FromBody]bool estado)
        {
            return HandleCallback(() => _contaServico.AlterarEstado(id, estado));
        }

        [HttpPatch]
        [Route("{id:long}/sacar")]
        public IHttpActionResult Sacar(long id, [FromBody]double valorSaque)
        {
            return HandleCallback(() => _contaServico.Sacar(id, valorSaque));
        }

        [HttpPatch]
        [Route("{id:long}/depositar")]
        public IHttpActionResult Depositar(long id, [FromBody]double valorDeposito)
        {
            return HandleCallback(() => _contaServico.Depositar(id, valorDeposito));
        }

        #endregion

    }
}
