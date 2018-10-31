using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Features.Produtos;
using System;

namespace Pizzaria.Domain.Tests.Features.Produtos
{
    [TestFixture]
    public class ProdutoTest
    {
        private Produto _produtoPadrao;

        [SetUp]
        public void Inicializacao()
        {
            _produtoPadrao = ObjectMother.ObterPizzaPequenaDeCalabresa();
        }

        [Test]
        public void Produtos_Domain_Deve_possuir_todos_os_atributos_validados()
        {
            //Arrange-Action
            Action validarProduto = () => _produtoPadrao.Validar();

            //Assert
            validarProduto.Should().NotThrow<ProdutoDescricaoNulaOuVaziaExcecao>();
            validarProduto.Should().NotThrow<ProdutoValorNegativoOuZeradoExcecao>();
        }

        [Test]
        public void Produtos_Domain_Nao_deve_possuir_uma_descricao_vazia()
        {
            //Arrange
            Produto produtoDescVazia = ObjectMother.ObterProdutoSemDescricao();

            //Action
            Action validarProduto = () => produtoDescVazia.Validar();

            //Assert
            validarProduto.Should().Throw<ProdutoDescricaoNulaOuVaziaExcecao>();
        }

        [Test]
        public void Produtos_Domain_Nao_deve_possuir_um_valor_negativo()
        {
            //Arrange
            Produto produtoValorNeg = ObjectMother.ObterProdutoComValorNegativo();

            //Action
            Action validarProduto = () => produtoValorNeg.Validar();

            //Assert
            validarProduto.Should().Throw<ProdutoValorNegativoOuZeradoExcecao>();
        }

        [Test]
        public void Produtos_Domain_Nao_deve_possuir_um_valor_zerado()
        {
            //Arrange
            Produto produtoValorZerado = ObjectMother.ObterProdutoComValorZerado();

            //Action
            Action validarProduto = () => produtoValorZerado.Validar();

            //Assert
            validarProduto.Should().Throw<ProdutoValorNegativoOuZeradoExcecao>();
        }
    }
}
