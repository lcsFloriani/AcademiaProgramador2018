using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Floriani.MF7.Dominio.Funcionalidades.Gastos;

namespace Floriani.MF7.Infra.ORM.Funcionalidades.Gastos
{
	[ExcludeFromCodeCoverage]
	public class GastoConfiguracao : EntityTypeConfiguration<Gasto>
	{
		public GastoConfiguracao()
		{
			ToTable( "TBGastos" );

			Property( f => f.Descricao ).
				HasColumnType( "nvarchar" )
				.HasMaxLength( 250 )
				.IsRequired();
			Property( f => f.Preco )
				.IsRequired();
			Property( f => f.Tipo )
				.IsRequired();

			HasKey( f => f.Id );
		}
	}
}
