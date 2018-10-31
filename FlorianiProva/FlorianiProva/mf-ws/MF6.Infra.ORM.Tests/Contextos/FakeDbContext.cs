using MF6.Infra.ORM.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF6.Infra.ORM.Tests.Contexts
{
    public class FakeDbContext : MF6Context
    {

        public FakeDbContext(DbConnection connection) : base(connection)
        {
        }

    }
}
