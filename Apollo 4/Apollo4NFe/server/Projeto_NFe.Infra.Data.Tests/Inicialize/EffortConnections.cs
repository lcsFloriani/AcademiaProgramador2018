using System.Data.Common;
using System.Data.Entity.Infrastructure;
using Effort;

namespace Projeto_NFe.Infra.ORM.Tests.Inicialize
{
	public class EffortConnections : IDbConnectionFactory
	{
		private static DbConnection _conexao;
		private readonly static object _lock = new object();

		public static void ResetarDb()
		{
			lock (_lock) {
				_conexao = null;
			}

		}

		public DbConnection CreateConnection(string nomeOuConnectionString)
		{
			lock (_lock) {
				if (_conexao == null) {
					_conexao = DbConnectionFactory.CreateTransient();
				}

				return _conexao;
			}
		}
	}
}
