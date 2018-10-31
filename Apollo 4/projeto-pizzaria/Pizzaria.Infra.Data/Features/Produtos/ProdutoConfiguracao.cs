using Pizzaria.Domain.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Features.Produtos
{
    public class ProdutoConfiguracao : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguracao()
        {
            ToTable("TBProduto");

            Property(p => p.Id).HasColumnName("IdProduto");
            Property(p => p.Descricao).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(p => p.Tipo).HasColumnType("INT");
            Property(p => p.Tamanho).HasColumnType("INT");
        }

    }
}
