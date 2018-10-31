using MF6.API.Controllers.Common;
using MF6.Application.Funcionalidades.Impressoras;
using MF6.Application.Funcionalidades.Toners;
using MF6.Domain.Funcionalidades.Toners;
using MF6.Infra.ORM.Contexts;
using MF6.Infra.ORM.Funcionalidades.Toners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MF6.API.Controllers.Toners
{

    [RoutePrefix("api/toners")]
    public class TonersController : ApiControllerBase
    {
        public ITonerServico _tonerServico;

        public TonersController() : base()
        {
            var contexto = new MF6Context();
            var repositorioToner = new TonerRepositorio(contexto);
            _tonerServico = new TonerServico(repositorioToner);
        }

        #region Http Get

        [HttpGet]
        public IHttpActionResult PegarTodos()
        {
            var query = _tonerServico.PegarTodos();
            return HandleQueryable<Toner>(query);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id) => HandleCallback(() => _tonerServico.PegarPorId(id));
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(Toner toner) => HandleCallback(() => _tonerServico.Inserir(toner));

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(Toner toner) => HandleCallback(() => _tonerServico.Atualizar(toner));

        #endregion HttpPut
        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(Toner toner) => HandleCallback(() => _tonerServico.Deletar(toner));        

        #endregion HttpDelete
    }
}
