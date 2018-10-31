using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.Produtos
{
    public class ProdutoValorNegativoOuZeradoExcecao : NegocioExcecao
    {
        public ProdutoValorNegativoOuZeradoExcecao() : base("O valor do produto não pode ser negativo!")
        {
        }
    }
}
