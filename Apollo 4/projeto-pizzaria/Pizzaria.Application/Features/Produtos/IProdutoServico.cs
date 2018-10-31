using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Produtos;
using System.Collections.Generic;

namespace Pizzaria.Application.Features.Produtos
{
    public interface IProdutoServico : IServico<Produto>
    {
        List<Produto> BuscarProdutoPorTamanhoETipo(TamanhoProdutoEnum tamanho, TipoProdutoEnum tipo);
    }
}
