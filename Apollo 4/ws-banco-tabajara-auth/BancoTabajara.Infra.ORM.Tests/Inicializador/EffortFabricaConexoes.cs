using Effort;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace BancoTabajara.Infra.ORM.Tests.Inicializador
{

    public class EffortFabricaConexoes : IDbConnectionFactory
    {
        private static DbConnection _conexao;
        private readonly static object _lock = new object();

        public static void ResetarDb()
        {
            lock (_lock)
            {
                _conexao = null;
            }

        }

        public DbConnection CreateConnection(string nomeOuConnectionString)
        {
            lock (_lock)
            {
                if (_conexao == null)
                {
                    _conexao = DbConnectionFactory.CreateTransient();
                }

                return _conexao;
            }
        }
    }
}
