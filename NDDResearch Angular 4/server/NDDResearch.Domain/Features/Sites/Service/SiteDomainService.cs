using NDDResearch.Domain.Features.Customers;

namespace NDDResearch.Domain.Features.Sites.Service
{
    /// <summary>
    /// 
    /// Serviço de domínio de sites, 
    /// responsável por executar regras de negócio relacionadas com o site.
    /// 
    /// </summary>
    public class SiteDomainService : ISiteDomainService
    {
        private readonly ISiteRepository _siteRepository;

        public SiteDomainService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        /// <summary>
        /// 
        /// Método para criar um novo site como default para um customer específico.
        /// 
        /// </summary>
        /// <param name="customer">É o customer que recebe o novo site como default</param>
        public Site CreateDefaultSite(Customer customer)
        {
            var site = new Site
            {
                CustomerId = customer.Id,
                IsDefault = true,
                Name = "Default Site",
                Address = customer.Address.Clone(),
            };

            return site;
        }
    }
}
