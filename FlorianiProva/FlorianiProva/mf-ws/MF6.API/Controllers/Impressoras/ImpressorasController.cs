using MF6.API.Controllers.Common;
using MF6.Application.Funcionalidades.Impressoras;
using MF6.Domain.Funcionalidades.Impressoras;
using MF6.Infra.ORM.Contexts;
using MF6.Infra.ORM.Funcionalidades.Impressoras;
using MF6.Infra.ORM.Funcionalidades.Toners;
using System.Web.Http;

namespace MF6.API.Controllers.Impressoras
{
    [RoutePrefix("api/impressoras")]
    public class ImpressorasController : ApiControllerBase
    {
        public IImpressoraServico _impressoraServico;

        public ImpressorasController() : base()
        {
            var contexto = new MF6Context();
            var repositorioImpressora = new ImpressoraRepositorio(contexto);
            var repositorioToner = new TonerRepositorio(contexto);
            _impressoraServico = new ImpressoraServico(repositorioImpressora, repositorioToner);
        }


        #region Http Get

        [HttpGet]
        public IHttpActionResult PegarTodos()
        { 
            var query = _impressoraServico.PegarTodos();
            return HandleQueryable<Impressora>(query);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id) => HandleCallback(() => _impressoraServico.PegarPorId(id));
        #endregion

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(Impressora impressora) => HandleCallback(() => _impressoraServico.Inserir(impressora));

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(Impressora impressora) => HandleCallback(() => _impressoraServico.Atualizar(impressora));

        #endregion HttpPut
        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(Impressora impressora) => HandleCallback(() => _impressoraServico.Deletar(impressora));

        #endregion HttpDelete
    }
}
