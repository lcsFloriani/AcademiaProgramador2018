using NDDResearch.Domain.Exceptions;
using NDDResearch.Domain.Features.Sites;
using NDDResearch.Infra.Data.Contexts;
using NDDResearch.Infra.Structs;
using System;
using System.Data.Entity;
using System.Linq;

namespace NDDResearch.Infra.Data.Features.Sites
{
    /// <summary>
    /// Repositório de sites
    /// </summary>
    public class SiteRepository : ISiteRepository
    {
        private NDDResearchDbContext _context;

        public SiteRepository(NDDResearchDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todas os sites de um derteminado cliente
        /// </summary>
        /// <param name="customerId">Id do cliente</param>
        /// <returns>IQueriable com sites.</returns>
        public IQueryable<Site> GetAll(int customerId)
        {
            return _context.Sites.Where(s => s.CustomerId == customerId);
        }

        /// <summary>
        /// Adiciona um Site
        /// </summary>
        /// <param name="site">Objetco Site com as suas propriedades preenchidas.</param>
        /// <returns>Site inserido atualizado com Id</returns>
        public Try<Exception, Site> Add(Site site)
        {
            var addedSite = _context.Sites.Add(site);
            SaveChanges();

            return addedSite;
        }

        /// <summary>
        /// Verifica se um determinado site é único em uma determinada empresa.
        /// </summary>
        /// <param name="customerId">Id da empresa</param>
        /// <param name="name">nome do site</param>
        /// <param name="siteId">id do site a ser ignorado. Utilizar com ao fazer update</param>
        /// <returns></returns>
        public Try<Exception, bool> IsUnique(int customerId, string name, int siteId = 0)
        {
            return !_context.Sites.Any(s => s.CustomerId == customerId && s.Name.ToLower().Equals(name.ToLower()) && (siteId == 0 || s.Id != siteId));
        }

        /// <summary>
        /// Atualiza as propriedades de um Site. (todas as propriedades, exceto IsDefault e Name)
        /// </summary>
        /// <param name="site">Site com suas propriedades preenchidas. </param>
        public Try<Exception, Result> Update(Site site)
        {
            _context.Entry(site).State = EntityState.Modified;
            _context.SaveChanges();
            return Result.Successful;
        }

        /// <summary>
        /// Retorna um determinado site 
        /// </summary>
        /// <param name="siteId">Id do site a ser retornado</param>
        /// <returns>Se encontrado Objeto Site preenchido.</returns>
        public Try<Exception, Site> GetById(int siteId)
        {
            var site = _context.Sites.FirstOrDefault(d => d.Id == siteId);
            if (site == null)
                return new NotFoundException();
            return site;
        }

        /// <summary>
        /// Remove um determinado site. 
        /// </summary>
        /// <param name="siteId">Id do site a ser removido</param>
        public Try<Exception, Result> Remove(int siteId)
        {
            var siteCallback = GetById(siteId);
            if (siteCallback.IsFailure)
                return siteCallback.Failure;

            var foundSite = siteCallback.Result;
            if (foundSite.IsDefault)
                return new NotAllowedException(); /* não pode remover site default */

            _context.Sites.Remove(foundSite);
            /* Remove o endereço também. */
            _context.Adresses.Remove(_context.Adresses.Find(foundSite.AddressId));
            _context.SaveChanges();

            return Result.Successful;
        }

        /// <summary>
        /// Retorna o site padrão de um determinado cliente.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Site padrão do cliente</returns>
        public Try<Exception, Site> GetDefaultSite(int customerId)
        {
            var site = _context.Sites.FirstOrDefault(s => s.CustomerId == customerId && s.IsDefault);
            if (site == null)
                return new NotFoundException();
            return site;
        }

        /// <summary>
        /// Executa o SaveChanges no DBContext.
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
