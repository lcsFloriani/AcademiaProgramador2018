using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.Produtos
{
    public class ProdutoDescricaoNulaOuVaziaExcecao : NegocioExcecao
    {
        public ProdutoDescricaoNulaOuVaziaExcecao() : base("A descrição não pode ser nula e nem vazia!")
        {
        }
    }
}
