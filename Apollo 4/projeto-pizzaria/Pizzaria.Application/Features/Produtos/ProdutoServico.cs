using System.Collections.Generic;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Produtos;

namespace Pizzaria.Application.Features.Produtos
{
    public class ProdutoServico : IProdutoServico
    {
        private IProdutoRepositorio _produtoRepositorio;
        private int _menorQue = 1;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public Produto Adicionar(Produto produto)
        {
            produto.Validar();
            return _produtoRepositorio.Salvar(produto);
        }

        public Produto Atualizar(Produto produto)
        {
            if (produto.Id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            produto.Validar();
            return _produtoRepositorio.Atualizar(produto);
        }

        public Produto BuscarPorId(long id)
        {
            if (id < 1)
                throw new IdentificadorIndefinidoExcecao();

            return _produtoRepositorio.BuscarPorId(id);
        }

        public List<Produto> BuscarProdutoPorTamanhoETipo(TamanhoProdutoEnum tamanho, TipoProdutoEnum tipo)
        {
            return _produtoRepositorio.BuscarProdutoPorTamanhoETipo(tamanho,tipo);
        }

        public void Excluir(Produto produto)
        {
            if (produto.Id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            if (_produtoRepositorio.TemDependencias(produto))
                throw new ProdutoComDependenciasExcecao();

            _produtoRepositorio.Excluir(produto);
        }

        public List<Produto> Listagem()
        {
            return _produtoRepositorio.Listagem() as List<Produto>;
        }
    }
}
