using System.Data.Common;
using Projeto_NFe.Infra.ORM.Context;

namespace Projeto_NFe.Infra.ORM.Tests.Context
{
	public class DBContextFake : ProjetoNFeContext
	{		
		public DBContextFake(DbConnection conexao) : base(conexao)
		{

		}
	}
}
