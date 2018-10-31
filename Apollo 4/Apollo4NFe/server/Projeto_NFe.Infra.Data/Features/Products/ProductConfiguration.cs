using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Products;

namespace Projeto_NFe.Infra.ORM.Features.Products
{
	public class ProductConfiguration: EntityTypeConfiguration<Product>
	{
		public ProductConfiguration()
		{
			ToTable( "TBProduct" );
			Property( e => e.Id ).HasColumnName( "IdProduct" );
			Property( p => p.Code ).IsRequired();
			Property( p => p.Description ).IsRequired();
			Property( p => p.UnitaryValue ).IsRequired();
		}
	}
}
