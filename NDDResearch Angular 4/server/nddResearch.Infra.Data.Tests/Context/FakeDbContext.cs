using NDDResearch.Infra.Data.Contexts;
using System.Data.Common;

namespace nddResearch.Infra.Data.Tests.Context
{
    /// <summary>
    /// Esse contexto deve ser usado para testar o EF através do Framework Effort
    /// </summary>
    public class FakeDbContext : NDDResearchDbContext
    {
        public FakeDbContext(DbConnection connection)
            : base(connection)
        {
        }
    }
}
