using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Features.ItensPedido
{
    public class ItemPedidoConfiguracao : EntityTypeConfiguration<ItemPedido>
    {
        public ItemPedidoConfiguracao()
        {
            ToTable("TBItemPedido");

            Property(c => c.Id).HasColumnName("IdItemPedido");
            Property(c => c.Quantidade).HasColumnType("INT");

            // one to many Pedido - Item de Pedido
            HasRequired<Pedido>(i => i.Pedido).WithMany(p => p.ItensPedidos).HasForeignKey<long>(i => i.PedidoId).WillCascadeOnDelete(true);
            // one to many Produto - Item de Pedido
            HasRequired(it => it.PrimeiroProduto).WithMany().HasForeignKey(it => it.PrimeiroProdutoId);
            // one to many Produto - Item de Pedido
            HasOptional(it => it.SegundoProduto).WithMany().HasForeignKey(it => it.SegundoProdutoId);
            // one to many Produto - Item de Pedido
            HasOptional(it => it.Adicional).WithMany().HasForeignKey(it => it.AdicionalId);
        }
    }
}
