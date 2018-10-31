using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Produtos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Pizzaria.Infra.Data.Features.Produtos
{
    public class ProdutoSQLRepository : IProdutoRepositorio
    {
        DataContext _contexto;
        private int maiorQue = 0;

        public ProdutoSQLRepository(DataContext contexto)
        {
            _contexto = contexto;
        }
        
        public Produto Salvar(Produto produto)
        {
            var produtoRetorno = _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();
            return produtoRetorno;
        }

        public Produto Atualizar(Produto produto)
        {
            _contexto.Entry(produto).State = EntityState.Modified;
            _contexto.SaveChanges();

            return produto;
        }
        public Produto BuscarPorId(long id)
        {
            return _contexto.Produtos.Where(p => p.Id == id).FirstOrDefault();
        }

        public Produto Editar(Produto produto)
        {
            _contexto.Entry(produto).State = EntityState.Modified;
            _contexto.SaveChanges();

            return produto;
        }
        
        public void Excluir(Produto produto)
        {
            _contexto.Entry(produto).State = EntityState.Deleted;
            _contexto.SaveChanges();
        }

        public IList<Produto> Listagem()
        {
            return _contexto.Produtos.ToList();
        }

        public List<Produto> BuscarProdutoPorTamanhoETipo(TamanhoProdutoEnum tamanho, TipoProdutoEnum tipo)
        {
            return _contexto.Produtos.Where(p =>  p.Tamanho == tamanho && p.Tipo == tipo).ToList();
        }

        public bool TemDependencias(Produto produto)
        {
            int count1 = (from i in _contexto.ItensPedidos join p in _contexto.Produtos on i.PrimeiroProdutoId equals p.Id  where p.Id == produto.Id select i).Count();
            int count2 = (from i in _contexto.ItensPedidos join p in _contexto.Produtos on i.SegundoProdutoId equals p.Id  where p.Id == produto.Id select i).Count();
            int count3 = (from i in _contexto.ItensPedidos join p in _contexto.Produtos on i.AdicionalId equals p.Id where p.Id == produto.Id select i).Count();

            int sum = (count1 + count2 + count3);

            return sum > maiorQue;
        }
    }
}
