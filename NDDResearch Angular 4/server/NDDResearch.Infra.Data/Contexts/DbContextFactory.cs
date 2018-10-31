using System.Data.Entity.Infrastructure;

namespace NDDResearch.Infra.Data.Contexts
{
    /// <summary>
    /// Essa classe resolve o problema do Migration que apresentava erro ao iniciar o NDDResearchDbContext 
    /// quando havia construtor COM parâmetros.
    /// 
    /// Não existe um ponto de chamada para essa classe. 
    /// 
    /// O próprio Migrations procura no Assembly uma classe que implementa IDbContextFactory
    /// 
    /// </summary>
    public class DbContextFactory : IDbContextFactory<NDDResearchDbContext>
    {
        public NDDResearchDbContext Create()
        {
            return new NDDResearchDbContext();
        }
    }
}
