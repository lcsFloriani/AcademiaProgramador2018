using MF6.Infra.ORM.Contexts;
using System.Data.Entity.Infrastructure;

namespace MF6.Infra.ORM.Contextos
{
    public class DbContextFactory : IDbContextFactory<MF6Context>
    {
        public MF6Context Create()
        {
            return new MF6Context();
        }
    }
}
