using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace Floriani.MF7.Infra.ORM.Contexto
{
	[ExcludeFromCodeCoverage]
	public class DbContextFactory : IDbContextFactory<FlorianiMF7Contexto>
	{
		public FlorianiMF7Contexto Create()
		{
			return new FlorianiMF7Contexto();
		}
	}
}
