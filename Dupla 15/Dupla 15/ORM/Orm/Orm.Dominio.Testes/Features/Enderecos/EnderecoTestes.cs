using FluentAssertions;
using NUnit.Framework;
using Orm.Comum.Testes.Features;
using Orm.Dominio.Features.Enderecos;
using System;

namespace Orm.Dominio.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoTestes
    {
        private Endereco _endereco;

        [SetUp]
        public void SetUp()
        {
            _endereco = new Endereco();
        }
        [Test]
        public void Endereco_Dominio_Validar_LogradouroEmBranco_DeveFalhar()
        {
            _endereco = ObjectMother.EnderecoComLogradouroEmBranco();

            Action action = () => _endereco.Validar();

            action.Should().Throw<EnderecoLogradouroEmBrancoException>();
        }

        [Test]
        public void Endereco_Dominio_Validar_BairroEmBranco_DeveFalhar()
        {
            _endereco = ObjectMother.EnderecoComBairroEmBranco();

            Action action = () => _endereco.Validar();

            action.Should().Throw<EnderecoBairroEmBrancoException>();
        }

        [Test]
        public void Endereco_Dominio_Validar_CidadeEmBranco_DeveFalhar()
        {
            _endereco = ObjectMother.EnderecoComCidadeEmBranco();

            Action action = () => _endereco.Validar();

            action.Should().Throw<EnderecoCidadeEmBrancoException>();
        }

        [Test]
        public void Endereco_Dominio_Validar_EstadoEmBranco_DeveFalhar()
        {
            _endereco = ObjectMother.EnderecoComUFEmBranco();

            Action action = () => _endereco.Validar();

            action.Should().Throw<EnderecoUFEmBrancoException>();
        }

        [Test]
        public void Endereco_Dominio_Validar_NumeroEmBranco_DeveAcrescentarCaracteresSN()
        {
            _endereco = ObjectMother.EnderecoComNumeroEmBranco();

            _endereco.Validar();

            _endereco.Numero.Should().Be("S/N");
        }

        [Test]
        public void Endereco_Dominio_Validar_ComplementoEmBranco_DeveFalhar()
        {
            _endereco = ObjectMother.EnderecoComComplementoEmBranco();

            Action action = () => _endereco.Validar();

            action.Should().Throw<EnderecoComplementoVazioException>();
        }

        [Test]
        public void Endereco_Dominio_Validar_DeveFuncionar()
        {
            _endereco = ObjectMother.EnderecoValido();

            Action action = () => _endereco.Validar();

            action.Should().NotThrow();
        }
    }
}
