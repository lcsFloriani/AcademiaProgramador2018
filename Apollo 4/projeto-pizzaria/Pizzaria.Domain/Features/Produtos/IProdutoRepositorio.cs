using Pizzaria.Domain.Enums;
using System.Collections.Generic;

namespace Pizzaria.Domain.Features.Produtos
{
    public interface IProdutoRepositorio
    {
        Produto Salvar(Produto produto);
        Produto Atualizar(Produto produto);
        Produto Editar(Produto produto);
        Produto BuscarPorId(long Id);
        IList<Produto> Listagem();
        List<Produto> BuscarProdutoPorTamanhoETipo(TamanhoProdutoEnum tamanho, TipoProdutoEnum tipo);
        void Excluir(Produto produto);
        bool TemDependencias(Produto produto);
    }
}
