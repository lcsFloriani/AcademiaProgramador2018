using NDDResearch.Infra.Structs;
using System;
using System.Linq;

namespace NDDResearch.Domain.Features.Sites
{
    /// <summary>
    /// Representa o repositório de sites
    /// </summary>
    public interface ISiteRepository
    {
        /// <summary>
        /// Retorna todas os sites de um derteminado cliente
        /// </summary>
        /// <param name="customerId">Id do cliente</param>
        /// <returns>IQueriable com sites.</returns>
        IQueryable<Site> GetAll(int customerId);

        /// <summary>
        /// Adiciona um Site
        /// </summary>
        /// <param name="site">Objetco Site com as suas propriedades preenchidas.</param>
        /// <returns>Site inserido atualizado com Id</returns>
        Try<Exception, Site> Add(Site site);

        /// <summary>
        /// Verifica se um determinado site é único em uma determinada empresa.
        /// </summary>
        /// <param name="customerId">Id da empresa</param>
        /// <param name="name">nome do site</param>
        /// <param name="siteId">id do site a ser ignorado. Utilizar com ao fazer update</param>
        /// <returns></returns>
        Try<Exception, bool> IsUnique(int customerId, string name, int siteId = 0);

        /// <summary>
        /// Atualiza as propriedades de um Site. (todas as propriedades, exceto IsDefault e Name)
        /// </summary>
        /// <param name="site">Site com suas propriedades preenchidas. </param>
        Try<Exception, Result> Update(Site site);

        /// <summary>
        /// Retorna um determinado site 
        /// </summary>
        /// <param name="siteId">Id do site a ser retornado</param>
        /// <returns>Se encontrado Objeto Site preenchido.</returns>
        Try<Exception, Site> GetById(int siteId);

        /// <summary>
        /// Remove um determinado site. 
        /// </summary>
        /// <param name="siteId">Id do site a ser removido</param>
        Try<Exception, Result> Remove(int siteId);

        /// <summary>
        /// Retorna o site padrão de um determinado cliente.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Site padrão</returns>
        Try<Exception, Site> GetDefaultSite(int customerId);

        /// <summary>
        /// Executa o SaveChanges no DBContext, 
        /// salvando efetivamente as modificações realizadas no banco;
        /// </summary>
        void SaveChanges();
    }
}
