using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;

namespace Floriani.MF7.Infra.ORM.Funcionalidades.Funcionarios
{
	[ExcludeFromCodeCoverage]
	public class FuncionarioConfiguracao : EntityTypeConfiguration<Funcionario>
	{
		public FuncionarioConfiguracao()
		{
			ToTable("TBFuncionarios");

			Property(f => f.PrimeiroNome).
				HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired();
			Property(f => f.Sobrenome).
				HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired();
			Property(f => f.Usuario)
				.HasColumnType("nvarchar")
				.HasMaxLength(100)
				.IsRequired();
			Property(f => f.Senha)
				.HasColumnType("nvarchar")
				.HasMaxLength(1000)
				.IsRequired();
			Property(f => f.Cargo)
				.IsRequired();

			HasKey(f => f.Id);
		}
	}
}
