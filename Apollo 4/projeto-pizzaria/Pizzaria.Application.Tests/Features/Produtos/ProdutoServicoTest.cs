using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Application.Features.Produtos;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Produtos;
using System;
using System.Collections.Generic;

namespace Pizzaria.Application.Tests.Features.Produtos
{
    [TestFixture]
    public class ProdutoServicoTest
    {
        private Mock<IProdutoRepositorio> _produtoRepositorioMock;
        private IProdutoServico _produtoServico;
        private Produto _produtoPadrao;
        private Produto _produtoPadraoComId;

        [SetUp]
        public void Inicializacao()
        {
            _produtoRepositorioMock = new Mock<IProdutoRepositorio>();
            _produtoServico = new ProdutoServico(_produtoRepositorioMock.Object);

            _produtoPadrao = ObjectMother.ObterPizzaPequenaDeCalabresa();
            _produtoPadraoComId = ObjectMother.ObterPizzaPequenaDeCalabresaComId();
        }

        [Test]
        public void Produtos_Application_Deve_adicionar_um_novo_produto()
        {
            //Arrange
            _produtoRepositorioMock.Setup(p => p.Salvar(It.IsAny<Produto>()))
                .Returns(_produtoPadraoComId);

            int maiorQue = 0;

            //Action
            Produto resultadoProduto = _produtoServico.Adicionar(_produtoPadrao);

            //Assert
            resultadoProduto.Should().NotBeNull();
            resultadoProduto.Id.Should().BeGreaterThan(maiorQue);
            _produtoRepositorioMock.Verify(p => p.Salvar(It.IsAny<Produto>()));
        }

        [Test]
        public void Produtos_Application_Nao_Deve_adicionar_um_novo_produto_com_descricao_vazia_ou_nula()
        {
            //Arrange
            Produto produtoDescVazia = ObjectMother.ObterProdutoSemDescricao();

            //Action
            Action actionAdicionar = () => _produtoServico.Adicionar(produtoDescVazia);

            //Assert
            actionAdicionar.Should().Throw<ProdutoDescricaoNulaOuVaziaExcecao>();
            _produtoRepositorioMock.VerifyNoOtherCalls();
        }

        [Test]
        public void Produtos_Application_Deve_atualizar_um_produto()
        {
            //Arrange
            Produto produtoAtualizadoComId = ObjectMother.ObterPizzaPequenaDeCalabresaAtualizadoComId();

            _produtoRepositorioMock.Setup(p => p.Atualizar(It.IsAny<Produto>()))
               .Returns(produtoAtualizadoComId);

            int maiorQue = 0;

            //Action
            Produto resultado = _produtoServico.Atualizar(_produtoPadraoComId);

            //Assert
            resultado.Id.Should().BeGreaterThan(maiorQue);
            resultado.Id.Should().Be(_produtoPadraoComId.Id);
            resultado.Descricao.Should().Be(produtoAtualizadoComId.Descricao);
            _produtoRepositorioMock.Verify(p => p.Atualizar(It.IsAny<Produto>()));
        }

        [Test]
        public void Produtos_Application_Nao_Deve_atualizar_um_produto_com_id_invalido()
        {
            //Arrange-Action
            Action resultado = () => _produtoServico.Atualizar(_produtoPadrao);

            //Assert
            resultado.Should().Throw<IdentificadorIndefinidoExcecao>();
            _produtoRepositorioMock.VerifyNoOtherCalls();
        }

        [Test]
        public void Produtos_Application_Deve_buscar_um_produto_pelo_id()
        {
            //Arrange
            _produtoRepositorioMock.Setup(p => p.BuscarPorId(It.IsAny<long>())).Returns(_produtoPadraoComId);

            int maiorQue = 0;

            //Action
            Produto resultado = _produtoServico.BuscarPorId(_produtoPadraoComId.Id);

            //Assert
            resultado.Id.Should().BeGreaterThan(maiorQue);
            resultado.Id.Should().Be(_produtoPadraoComId.Id);
            _produtoRepositorioMock.Verify(p => p.BuscarPorId(It.IsAny<long>()));
        }

        [Test]
        public void Produtos_Application_Nao_Deve_buscar_um_produto_com_id_invalido()
        {
            //Arrange-Action
            Action resultado = () => _produtoServico.BuscarPorId(_produtoPadrao.Id);

            //Assert
            resultado.Should().Throw<IdentificadorIndefinidoExcecao>();
            _produtoRepositorioMock.VerifyNoOtherCalls();
        }

        [Test]
        public void Produtos_Application_Deve_buscar_todos_os_produtos()
        {
            //Arrange
            List<Produto> listaProdutos = new List<Produto>() {
                _produtoPadraoComId
            };

            _produtoRepositorioMock.Setup(p => p.Listagem()).Returns(listaProdutos);

            int tamanhoLista = 1;

            //Action
            var resultados = _produtoServico.Listagem();

            //Assert
            resultados.Should().HaveCount(tamanhoLista);
            resultados.Should().NotBeNullOrEmpty();
            _produtoRepositorioMock.Verify(p => p.Listagem());
        }

        [Test]
        public void Produtos_Application_Deve_buscar_um_produto_pelo_tamanho_e_tipo()
        {
            //Arrange
            List<Produto> listaProdutos = new List<Produto>() {
                _produtoPadraoComId
            };

            _produtoRepositorioMock.Setup(p => p.BuscarProdutoPorTamanhoETipo(It.IsAny<TamanhoProdutoEnum>(),It.IsAny<TipoProdutoEnum>())).Returns(listaProdutos);

            int tamanhoLista = 1;

            //Action
            var resultados = _produtoServico.BuscarProdutoPorTamanhoETipo(_produtoPadraoComId.Tamanho,_produtoPadraoComId.Tipo);

            //Assert
            resultados.Should().HaveCount(tamanhoLista);
            _produtoRepositorioMock.Verify(p => p.BuscarProdutoPorTamanhoETipo(It.IsAny<TamanhoProdutoEnum>(), It.IsAny<TipoProdutoEnum>()));
        }

        [Test]
        public void Produtos_Application_Deve_excluir_um_produto()
        {
            //Arrange
            _produtoRepositorioMock.Setup(p => p.Excluir(It.IsAny<Produto>()));
            _produtoRepositorioMock.Setup(p => p.TemDependencias(It.IsAny<Produto>())).Returns(false);


            //Action
            Action actionExcluir = () => _produtoServico.Excluir(_produtoPadraoComId);

            //Assert
            actionExcluir.Should().NotThrow<Exception>();
            _produtoRepositorioMock.Verify(p => p.Excluir(It.IsAny<Produto>()));
            _produtoRepositorioMock.Verify(p => p.TemDependencias(It.IsAny<Produto>()));
        }

        [Test]
        public void Produtos_Application_Nao_Deve_excluir_um_produto_com_id_invalido()
        {
            //Arrange-Action
            Action resultado = () => _produtoServico.Excluir(_produtoPadrao);

            //Assert
            resultado.Should().Throw<IdentificadorIndefinidoExcecao>();
            _produtoRepositorioMock.VerifyNoOtherCalls();
        }

        [Test]
        public void Produtos_Servico_Nao_Deveria_excluir_um_produto_com_dependencias()
        {
            //Arrange
            _produtoRepositorioMock.Setup(p => p.Excluir(It.IsAny<Produto>()));
            _produtoRepositorioMock.Setup(p => p.TemDependencias(It.IsAny<Produto>())).Returns(true);


            //Action
            Action actionExcluir = () => _produtoServico.Excluir(_produtoPadraoComId);

            //Assert
            actionExcluir.Should().Throw<ProdutoComDependenciasExcecao>();
            _produtoRepositorioMock.Verify(p => p.TemDependencias(It.IsAny<Produto>()));
            _produtoRepositorioMock.Verify(p => p.Excluir(It.IsAny<Produto>()), Times.Never);
        }
    }
}
