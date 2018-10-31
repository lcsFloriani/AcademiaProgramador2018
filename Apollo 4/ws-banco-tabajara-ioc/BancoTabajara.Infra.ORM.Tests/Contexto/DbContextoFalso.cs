using BancoTabajara.Infra.ORM.Contexto;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace BancoTabajara.Infra.ORM.Tests.Contexto
{

    public class DbContextoFalso : BancoTabajaraDbContexto
    {
        public DbContextoFalso(DbConnection conexao) : base(conexao)
        {
        }
    }
}
