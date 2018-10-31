using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.ItensPedido
{
    public class ItemPedidoQuantidadeZeroExcecao : NegocioExcecao
    {
        public ItemPedidoQuantidadeZeroExcecao() : base("A quantidade do item de pedido não pode ser zero!")
        {
        }
    }
}
