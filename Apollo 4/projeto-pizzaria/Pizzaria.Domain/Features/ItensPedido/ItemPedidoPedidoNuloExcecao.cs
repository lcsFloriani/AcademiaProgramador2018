using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.ItensPedido
{
    public class ItemPedidoPedidoNuloExcecao : NegocioExcecao
    {
        public ItemPedidoPedidoNuloExcecao() : base("O pedido não pode ser nulo!")
        {
        }
    }
}
