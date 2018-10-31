using NDDResearch.API.Controllers.Common;
using NDDResearch.Application.Features.Sites;
using NDDResearch.Application.Features.Sites.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NDDResearch.API.Controllers.Sites
{
    /// <summary>
    /// Controlador de sites
    /// 
    /// Essa classe é responsável por prover os dados relacionados a entidade Site.
    /// 
    /// Perceba que não há obrigatóriedade de que os seus metódos precisem retornar sempre o tipo Site 
    /// assim, todos os métodos aqui presente que estão relcionados a essa entidade,
    /// </summary>
    [RoutePrefix("api/sites")]
    public class SitesController : ApiControllerBase
    {
        private readonly ISitesService _sitesService;


        public SitesController(ISitesService sitesService) : base()
        {
            _sitesService = sitesService;
        }

        #region HttpGet
        /// <summary>
        /// Interface para obter um site específico pelo id
        /// </summary>
        /// <param name="id">É o id do site para realizar a pesquisa. Provém diretamente da url pela configuração do Route</param>
        /// <returns>Retorna o site com id correspondente ao paramêtro id</returns>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(_sitesService.GetById(id));
        }

        #endregion HttpGet

        #region HttpPost
        /// <summary>
        /// Interface para cadastro de sites
        /// </summary>
        /// <param name="command">É o customer que será cadastrado no banco de dados. Provém do corpo da requisição (body)</param>
        /// <returns>Retorna um objeto com os erros acontecidos na operação. Em caso de sucesso, não há propriedades. </returns>
        [HttpPost]
        public IHttpActionResult RegisterSite(SiteRegisterCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_sitesService.Add(command));
        }

        #endregion HttpPost

        #region HttpPut
        /// <summary>
        /// Interface para editar um site
        /// </summary>
        /// <param name="siteId">É o id do site para realizar a pesquisa. Provém diretamente da url pela configuração do Route</param>
        /// <param name="command">É o customer que será atualizado no banco de dados. Provém do corpo da requisição (body)</param>
        /// <returns>Retorna um objeto com os erros acontecidos na operação. Em caso de sucesso, não há propriedades. </returns>
        [HttpPut]
        [Route("{siteId:int}")]
        public IHttpActionResult UpdateSite(int siteId, SiteUpdateCommand command)
        {
            var validator = command.Validate(siteId);
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_sitesService.Update(command));
        }

        #endregion HttpPut

        #region HttpDelete
        /// <summary>
        /// Interface para remover um site
        /// </summary>
        /// <param name="command">É o site que será removido no banco de dados. Provém do corpo da requisição (body)</param>
        /// <returns>Retorna um objeto com os erros acontecidos na operação. Em caso de sucesso, não há propriedades. </returns>
        [HttpDelete]
        public IHttpActionResult RemoveSite(SiteDeleteCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_sitesService.Remove(command));
        }
        #endregion HttpDelete
    }
}