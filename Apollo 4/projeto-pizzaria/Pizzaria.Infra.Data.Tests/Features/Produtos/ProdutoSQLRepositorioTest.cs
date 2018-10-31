using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.Infra.Data.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Tests.Features.Produtos
{
    [TestFixture]
    public class ProdutoSQLRepositorioTest
    {
        private IProdutoRepositorio _repositorio;
        private DataContext _contexto;

        [SetUp]
        public void Inicializacao()
        {
            _contexto = new DataContext();
            Database.SetInitializer(new CriarBaseDeDadosParaTeste());
            _contexto.Database.Initialize(true);

            _repositorio = new ProdutoSQLRepository(_contexto);
        }

        [Test]
        public void Produto_InfraData_Deve_salvar_pizza_de_calabresa()
        {
            //Cenário
            long idEsperado = 3;
            Produto produto = ObjectMother.ObterPizzaPequenaDeCalabresa();

            //Ação
            Produto resultado = _repositorio.Salvar(produto);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Produtos_InfraData_Deve_buscar_um_produto_por_tamanho_e_tipo()
        {
            //Cenário
            TamanhoProdutoEnum tamnho = TamanhoProdutoEnum.Media;
            TipoProdutoEnum pizza = TipoProdutoEnum.Pizza;

            int tamanhoEsperado = 1;
            //Ação
            List<Produto> produtos = _repositorio.BuscarProdutoPorTamanhoETipo(tamnho,pizza);

            //Verifica
            produtos.Should().NotBeNull();
            produtos.Should().HaveCount(tamanhoEsperado);
        }

        [Test]
        public void Produtos_InfraData_Deve_buscar_por_um_produto_por_id()
        {
            //Cenario
            long idProcura = 1;
            //Ação
            var produto = _repositorio.BuscarPorId(idProcura);

            //Verifica
            produto.Should().NotBeNull();
            produto.Id.Should().Equals(idProcura);
        }

        [Test]
        public void Produtos_InfraData_Deve_atualizar_produto()
        {
            //Cenário
            int idPesquisa = 1;
            Produto produto = _repositorio.BuscarPorId(idPesquisa);
            string descricaoAntiga = produto.Descricao;
            produto.Descricao = "DescricaoNova";

            //Ação
            Produto resultado = _repositorio.Editar(produto);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Descricao.Should().NotBe(descricaoAntiga);
        }

        [Test]
        public void Produtos_InfraData_Deve_buscar_todos_os_produtos()
        {
            //Ação
            var produtos = _repositorio.Listagem();

            //Verifica
            produtos.Should().NotBeNull();
            produtos.Should().HaveCount(_contexto.Produtos.Count());
        }

        [Test]
        public void Produtos_InfraData_Deve_excluir_um_produto()
        {
            //Cenário
            long idProduto = 1;
            var produto = _repositorio.BuscarPorId(idProduto);

            //Ação
            _repositorio.Excluir(produto);

            //Verifica
            var produtoDB = _repositorio.BuscarPorId(idProduto);
            produtoDB.Should().BeNull();

        }

        [Test]
        public void Produtos_InfraData_Deve_validar_um_produto_que_contenha_dependencias()
        {
            //Cenário
            long idProduto = 1;
            var produto = _repositorio.BuscarPorId(idProduto);

            //Ação
            bool dependencias = _repositorio.TemDependencias(produto);

            //Verifica
            dependencias.Should().BeTrue();
        }


        [Test]
        public void Produtos_InfraData_Deve_validar_um_produto_que_nao_contenha_dependencias()
        {
            //Cenário
            long idProduto = 2;
            var produto = _repositorio.BuscarPorId(idProduto);

            //Ação
            bool dependencias = _repositorio.TemDependencias(produto);

            //Verifica
            dependencias.Should().BeFalse();
        }
    }
}
