using NDDResearch.Domain.Features.Customers;

namespace NDDResearch.Domain.Features.Sites.Service
{
    /// <summary>
    /// 
    /// Representa o serviço de domínio de sites, 
    /// responsável por executar regras de negócio relacionadas com o site.
    /// 
    /// </summary>
    public interface ISiteDomainService
    {
        Site CreateDefaultSite(Customer customer);
    }
}
