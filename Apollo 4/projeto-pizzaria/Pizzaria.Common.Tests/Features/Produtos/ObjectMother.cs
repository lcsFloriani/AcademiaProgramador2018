using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Produtos;

namespace Pizzaria.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Produto ObterPizzaPequenaDeCalabresa()
        {
            return new Produto
            {
                Descricao = "Calabresa",
                Valor = 60,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Pizza
            };
        }

        public static Produto ObterPizzaPequenaDeCalabresaComId()
        {
            return new Produto
            {
                Id = 1,
                Descricao = "Calabresa",
                Valor = 60,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Pizza
            };
        }

        public static Produto ObterPizzaPequenaDeCalabresaAtualizadoComId()
        {
            return new Produto
            {
                Id = 1,
                Descricao = "Calabresa Atualizado",
                Valor = 60,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Pizza
            };
        }

        public static Produto ObterProdutoSemDescricao()
        {
            return new Produto
            {
                Descricao = "",
                Valor = 69.80,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Pizza
            };
        }

        public static Produto ObterProdutoComValorNegativo()
        {
            return new Produto
            {
                Descricao = "Teste",
                Valor = -10,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Pizza
            };
        }

        public static Produto ObterProdutoComValorZerado()
        {
            return new Produto
            {
                Descricao = "Teste",
                Valor = 0,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Pizza
            };
        }

        public static Produto ObterPizzaMediaDeCalabresa()
        {
            return new Produto
            {
                Descricao = "Calabresa",
                Valor = 69.80,
                Tamanho = TamanhoProdutoEnum.Media,
                Tipo = TipoProdutoEnum.Pizza
            };
        }

        public static Produto ObterPizzaPequenaDeCoracao()
        {
            return new Produto
            {
                Descricao = "Coração",
                Valor = 70,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Pizza
            };
        }

        public static Produto ObterPizzaMediaDeMussarela()
        {
            return new Produto
            {
                Descricao = "Mussarela",
                Valor = 75,
                Tamanho = TamanhoProdutoEnum.Media,
                Tipo = TipoProdutoEnum.Pizza
            };
        }

        public static Produto ObterBordaPequenaCatupiry()
        {
            return new Produto
            {
                Descricao = "Borda de Catupiry",
                Valor = 1.25,
                Tamanho = TamanhoProdutoEnum.Pequena,
                Tipo = TipoProdutoEnum.Adicional
            };
        }

        public static Produto ObterBordaMediaCheddar()
        {
            return new Produto
            {
                Descricao = "Borda de Cheddar",
                Valor = 1.50,
                Tamanho = TamanhoProdutoEnum.Media,
                Tipo = TipoProdutoEnum.Adicional
            };
        }

        public static Produto ObterCalzone()
        {
            return new Produto
            {
                Descricao = "Frango",
                Valor = 15.00,
                Tamanho = TamanhoProdutoEnum.Padrao,
                Tipo = TipoProdutoEnum.Calzone
            };
        }

        public static Produto ObterBebida()
        {
            return new Produto
            {
                Descricao = "Coca Cola 2L",
                Valor = 8.00,
                Tamanho = TamanhoProdutoEnum.Litro,
                Tipo = TipoProdutoEnum.Bebida
            };
        }
    }
}
