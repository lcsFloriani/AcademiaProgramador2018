using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Application.Features.Produtos;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.Infra.Data;
using Pizzaria.Infra.Data.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Pizzaria.Integration.Tests.Features.Produtos
{
    [TestFixture]
    public class ProdutoIntegracaoTest
    {
        private DataContext _contexto;
        private IProdutoRepositorio _repositorio;

        private ProdutoServico _servico;
        private Produto _produtoPadrao;
       
        [SetUp]
        public void Inicializacao()
        {
            Database.SetInitializer(new CriarBaseDeDadosParaTeste());
            _contexto = new DataContext();
            _contexto.Database.Initialize(true);

            _repositorio = new ProdutoSQLRepository(_contexto);
            _servico = new ProdutoServico(_repositorio);

            _produtoPadrao = ObjectMother.ObterPizzaPequenaDeCalabresa();
        }

        [Test]
        public void Produtos_Integration_Deve_adicionar_um_novo_produto()
        {
            //Cenário-Ação
            var resultado = _servico.Adicionar(_produtoPadrao);

            //Verifica
            resultado.Descricao.Should().Be(_produtoPadrao.Descricao);
            var resultadoBusca = _repositorio.BuscarPorId(resultado.Id);
            resultadoBusca.Should().NotBeNull();
            resultadoBusca.Descricao.Should().Be(_produtoPadrao.Descricao);
        }

        [Test]
        public void Produtos_Integration_Nao_deve_adicionar_um_novo_produto_com_descricao_nula_ou_vazia()
        {
            //Cenário
            var produtoSemDesc = ObjectMother.ObterProdutoSemDescricao();

            //Ação
            Action ActionAdicionar = () => _servico.Adicionar(produtoSemDesc);

            //Verifica
            ActionAdicionar.Should().Throw<ProdutoDescricaoNulaOuVaziaExcecao>();
        }

        [Test]
        public void Produtos_Integration_Nao_deve_adicionar_um_novo_produto_com_valor_zerado()
        {
            //Cenário
            var produtoValorZerado = ObjectMother.ObterProdutoComValorZerado();

            //Ação
            Action ActionAdicionar = () => _servico.Adicionar(produtoValorZerado);

            //Verifica
            ActionAdicionar.Should().Throw<ProdutoValorNegativoOuZeradoExcecao>();
        }

        [Test]
        public void Produtos_Integration_Nao_deve_adicionar_um_novo_produto_com_valor_negativo()
        {
            //Cenário
            var produtoValorNeg = ObjectMother.ObterProdutoComValorNegativo();

            //Ação
            Action ActionAdicionar = () => _servico.Adicionar(produtoValorNeg);

            //Verifica
            ActionAdicionar.Should().Throw<ProdutoValorNegativoOuZeradoExcecao>();
        }

        [Test]
        public void Produtos_Integration_Deve_atualizar_um_produto()
        {
            //Cenário
            var produtoAdicionado = _servico.Adicionar(_produtoPadrao);
            produtoAdicionado.Descricao = "Descrição Atualizada";

            //Ação
            var produtoAtualizado = _servico.Atualizar(produtoAdicionado);

            //Verificar
            produtoAtualizado.Should().NotBeNull();
            produtoAtualizado.Id.Should().Be(produtoAdicionado.Id);
            produtoAtualizado.Descricao.Should().Be(produtoAdicionado.Descricao);
        }

        [Test]
        public void Produtos_Integration_Nao_deve_atualizar_um_produto_com_id_invalido()
        {
            //Cenário-Ação
            Action produtoAtualizado = () => _servico.Atualizar(_produtoPadrao);

            //Verificar
            produtoAtualizado.Should().Throw<IdentificadorIndefinidoExcecao>();
        }

        [Test]
        public void Produtos_Integration_Nao_deve_atualizar_um_produto_com_descricao_nula_ou_vazia()
        {
            //Cenário
            var produtoSemDesc = ObjectMother.ObterProdutoSemDescricao();
            produtoSemDesc.Id = 1;

            //Ação
            Action ActionAtualizar = () => _servico.Atualizar(produtoSemDesc);

            //Verifica
            ActionAtualizar.Should().Throw<ProdutoDescricaoNulaOuVaziaExcecao>();
        }

        [Test]
        public void Produtos_Integration_Nao_deve_atualizar_um_produto_com_valor_zerado()
        {
            //Cenário
            var produtoValorZerado = ObjectMother.ObterProdutoComValorZerado();
            produtoValorZerado.Id = 1;

            //Ação
            Action ActionAtualizar = () => _servico.Atualizar(produtoValorZerado);

            //Verifica
            ActionAtualizar.Should().Throw<ProdutoValorNegativoOuZeradoExcecao>();
        }

        [Test]
        public void Produtos_Integration_Nao_deve_atualizar_um_produto_com_valor_negativo()
        {
            //Cenário
            var produtoValorNeg = ObjectMother.ObterProdutoComValorNegativo();
            produtoValorNeg.Id = 1;

            //Ação
            Action ActionAtualizar = () => _servico.Atualizar(produtoValorNeg);

            //Verifica
            ActionAtualizar.Should().Throw<ProdutoValorNegativoOuZeradoExcecao>();
        }

        [Test]
        public void Produtos_Integration_Deve_buscar_um_produto_pelo_id()
        {
            //Cenario
            var resultado = _servico.Adicionar(_produtoPadrao);

            //Acao
            var resultadoBuscaId = _servico.BuscarPorId(resultado.Id);

            //Verifica
            resultadoBuscaId.Should().NotBeNull();
            resultadoBuscaId.Id.Should().Be(resultado.Id);
            resultadoBuscaId.Descricao.Should().Be(resultado.Descricao);
        }

        [Test]
        public void Produtos_Integration_Nao_deve_buscar_um_produto_pelo_id_com_id_invalido()
        {
            //Cenário-Ação
            Action actionBuscaId = () => _servico.BuscarPorId(_produtoPadrao.Id);

            //Verificar
            actionBuscaId.Should().Throw<IdentificadorIndefinidoExcecao>();
        }

        [Test]
        public void Produtos_Integration_deve_buscar_todos_os_produtos()
        {
            //Cenario
            _produtoPadrao.Descricao = "Produto 1";
            var produtoAdicionado1 = _servico.Adicionar(_produtoPadrao);
            _produtoPadrao.Descricao = "Produto 2";
            var produtoAdicionado2 = _servico.Adicionar(_produtoPadrao);

            int tamanhoEsperado = 4;

            //Acao
            var resultadosBusca = _servico.Listagem();

            //Verificar
            resultadosBusca.Should().NotBeNull();
            resultadosBusca.Should().HaveCount(tamanhoEsperado);
            resultadosBusca.Last().Descricao.Should().Be(_produtoPadrao.Descricao);
        }

        [Test]
        public void Produtos_Integration_Deve_buscar_produtos_por_tamanho()
        {
            //Cenário
            TamanhoProdutoEnum tamanho = TamanhoProdutoEnum.Media;
            TipoProdutoEnum pizza = TipoProdutoEnum.Pizza;

            int tamanhoEsperado = 1;

            //Ação
            List<Produto> produtos = _servico.BuscarProdutoPorTamanhoETipo(tamanho, pizza);

            //Verifica
            produtos.Should().NotBeNull();
            produtos.Should().HaveCount(tamanhoEsperado);
        }

        [Test]
        public void Produtos_Integration_Deve_excluir_um_produto_pelo_id()
        {
            //Cenario
            long idBusca = 2;
            Produto p = _servico.BuscarPorId(idBusca);
            
            //Acao
            Action actionExcluir = () => _servico.Excluir(p);

            //Verificar
            actionExcluir.Should().NotThrow<Exception>();
            var resultadoBuscaPorId = _servico.BuscarPorId(idBusca);
            resultadoBuscaPorId.Should().BeNull();
        }

        [Test]
        public void Produtos_Integration_Nao_deve_excluir_um_produto_com_id_invalido()
        {
            //Cenario-Acao
            Action actionExcluir = () => _servico.Excluir(_produtoPadrao);

            actionExcluir.Should().Throw<IdentificadorIndefinidoExcecao>();
        }

        [Test]
        public void Produtos_Integracao_Nao_Deve_excluir_um_produto_pelo_id_quando_possui_dependencias()
        {
            //Cenario
            long idBusca = 1;
            Produto p = _servico.BuscarPorId(idBusca);

            //Acao
            Action actionExcluir = () => _servico.Excluir(p);

            //Verificar
            actionExcluir.Should().Throw<ProdutoComDependenciasExcecao>();
            var resultadoBuscaPorId = _servico.BuscarPorId(idBusca);
            resultadoBuscaPorId.Should().NotBeNull();
        }
    }
}
