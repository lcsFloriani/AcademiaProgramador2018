using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.Produtos
{
    public class ProdutoComDependenciasExcecao : NegocioExcecao
    {
        public ProdutoComDependenciasExcecao() : base("Este produto tem dependência(s) e não pode ser excluído!")
        {
        }
    }
}
