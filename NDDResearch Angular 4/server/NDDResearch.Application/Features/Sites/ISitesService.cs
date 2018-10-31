using NDDResearch.Application.Features.Sites.Commands;
using NDDResearch.Application.Features.Sites.Queries;
using NDDResearch.Domain.Features.Sites;
using NDDResearch.Infra.Structs;
using System;
using System.Linq;

namespace NDDResearch.Application.Features.Sites
{
    /// <summary>
    /// Representa um serviço de sites
    /// </summary>
    public interface ISitesService
    {
        /// <summary>
        /// Obtém todos os sites de um determinado customer
        /// </summary>
        /// <param name="customerId">É o id do customer que será buscado os sites que pertencem à ele</param>
        IQueryable<Site> GetAll(int customerId);

        /// <summary>
        /// Adiciona um site na base de dados
        /// </summary>
        /// <param name="site">É o command para o site que será adicionado</param>
        Try<Exception, int> Add(SiteRegisterCommand site);

        /// <summary>
        /// Obtém um site pelo identificador "id"
        /// </summary>
        /// <param name="siteId">É o id que será pesquisado para buscar um site</param>
        Try<Exception, SiteQuery> GetById(int siteId);

        /// <summary>
        /// Atualiza as propriedades de um site. 
        /// </summary>
        /// <param name="site">É o command para o site que será atualizado</param>
        Try<Exception, Result> Update(SiteUpdateCommand site);

        /// <summary>
        /// Remove um site da base de dados
        /// </summary>
        /// <param name="site">É o command para o site que será atualizado</param>
        Try<Exception, Result> Remove(SiteDeleteCommand site);
    }
}
