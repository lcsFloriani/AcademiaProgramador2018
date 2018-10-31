using Enedir.MF7.Infra.ORM.Context;
using System.Data.Common;


namespace Enedir.MF7.ORM.Tests.Context
{
    public class DbContextFake : MF7DbContext
    {
        public DbContextFake(DbConnection connection) : base(connection)
        {

        }
    }
}
