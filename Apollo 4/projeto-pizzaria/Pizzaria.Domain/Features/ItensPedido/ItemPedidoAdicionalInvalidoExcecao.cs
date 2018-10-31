using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.ItensPedido
{
    public class ItemPedidoAdicionalInvalidoExcecao : NegocioExcecao
    {
        public ItemPedidoAdicionalInvalidoExcecao() : base("Adicional inválido!")
        {

        }
    }
}
