using BancoTabajara.API.Controllers.Comum;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Infra.ORM.Contexto;
using BancoTabajara.Infra.ORM.Funcionalidades.Clientes;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace BancoTabajara.API.Controllers.Clientes
{
    [RoutePrefix("api/clientes")]
    public class ClientesController : ApiControllerBase
    {
        public IClienteServico servico;

        public ClientesController() : base()
        {
            var contexto = new BancoTabajaraDbContexto();
            var repositorio = new ClienteRepositorio(contexto);
            servico = new ClienteServico(repositorio);
        }

        #region POST

        [HttpPost]
        public IHttpActionResult Adicionar(Cliente cliente)
        {
            return HandleCallback(() => servico.Adicionar(cliente));
        }

        #endregion

        #region PUT

        [HttpPut]
        public IHttpActionResult Atualizar(Cliente cliente)
        {
            return HandleCallback(() => servico.Atualizar(cliente));
        }

        #endregion

        #region GET

        [HttpGet]
        public IHttpActionResult Listagem()
        {
            var keyValuePairs = this.Request.GetQueryNameValuePairs();
            KeyValuePair<string, string> quantidadePares = keyValuePairs.First(x => x.Key.Equals("quantidade"));
            int quantidade = int.Parse(quantidadePares.Value);
            
            var query = servico.Listagem(quantidade);

            return HandleQueryable(query);
        }

        [HttpGet]
        [Route("{id:long}")]
        public IHttpActionResult BuscarPorId(long id)
        {
            return HandleCallback(() => servico.BuscarPorId(id));
        }

        #endregion

        #region DELETE

        [HttpDelete]
        [Route("{id:long}")]
        public IHttpActionResult Excluir(long id)
        {
            return HandleCallback(() => servico.Excluir(id));
        }

        #endregion
    }
}