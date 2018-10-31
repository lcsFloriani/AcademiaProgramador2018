using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Pedidos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Features.Pedidos
{
    public class PedidoConfiguracao : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguracao()
        {
            ToTable("TBPedido");

            Property(c => c.Id).HasColumnName("IdPedido");
            Property(c => c.Setor).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(c => c.Responsavel).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(c => c.Documento).HasColumnType("VARCHAR").HasMaxLength(20);
            Property(c => c.FormaPagamento).HasColumnType("INT");
            Property(c => c.EmitirNFe).HasColumnType("BIT");
            Property(c => c.Observacao).HasColumnType("VARCHAR").HasMaxLength(200);
            Property(c => c.Data).HasColumnType("DATETIME");
            Property(c => c.StatusPedido).HasColumnType("INT");

            // one to many Pedido - Cliente
            HasRequired(p => p.Cliente).WithMany().HasForeignKey(p => p.ClienteId);
        }

    }
}
