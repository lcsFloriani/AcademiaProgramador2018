using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.ItensPedido
{
    public class ItemPedidoPrimeiroProdutoIgualSegundoProdutoInvalidoExcecao : NegocioExcecao
    {
        public ItemPedidoPrimeiroProdutoIgualSegundoProdutoInvalidoExcecao() : base("Uma pizza de dois sabores não pode ter o mesmo sabor!")
        {

        }
    }
}
