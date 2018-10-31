using FluentAssertions;
using NUnit.Framework;
using ORM01.Comum.Testes.Features;
using ORM01.Dominio.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Dominio.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoTeste
    {
        Endereco _endereco;
        [SetUp]
        public void SetUpAlunoDominio()
        {
            _endereco = ObjectMother.endereco;
        }

        [Test]
        public void Dominio_Endereco_DeveSerValido_OK()
        {
            Action validarCampos = () => _endereco.Validar();

            validarCampos.Should().NotThrow<Exception>();
        }

        [Test]
        public void Dominio_Endereco_DeveTerUmBairroValido_DeveRetornarExcessao()
        {
            _endereco.Bairro = "";

            Action validarNome = () => _endereco.Validar();

            validarNome.Should().Throw<BairroVazioEnderecoException>();
        }
        [Test]
        public void Dominio_Endereco_DeveTerUmComplementoValido_DeveRetornarExcessao()
        {
            _endereco.Complemento = "";

            Action validarNome = () => _endereco.Validar();

            validarNome.Should().Throw<ComplementoVazioEnderecoException>();
        }


        [Test]
        public void Dominio_Endereco_DeveTerUmaCidadeValida_DeveRetornarExcessao()
        {
            _endereco.Cidade = "";

            Action validarIdade = () => _endereco.Validar();

            validarIdade.Should().Throw<CidadeVazioEnderecoException>();
        }

        [Test]
        public void Dominio_Endereco_DeveTerUmBairroValida_DeveRetornarExcessao()
        {
            _endereco.Bairro = "";

            Action validarTurma = () => _endereco.Validar();

            validarTurma.Should().Throw<BairroVazioEnderecoException>();
        }

        [Test]
        public void Dominio_Endereco_DeveTerUmLougradouroValido_DeveRetornarExcessao()
        {
            _endereco.Logradouro = "";

            Action validarEndereco = () => _endereco.Validar();

            validarEndereco.Should().Throw<LougradouroVazioEnderecoException>();
        }
        [Test]
        public void Dominio_Endereco_DeveTerUmUFValido_DeveRetornarExcessao()
        {
            _endereco.UF = "";

            Action validarEndereco = () => _endereco.Validar();

            validarEndereco.Should().Throw<UFVazioEnderecoException>();
        }
        [Test]
        public void Dominio_Endereco_DeveTerUmNumeroValido_DeveRetornarExcessao()
        {
            _endereco.Numero = -2;

            Action validarEndereco = () => _endereco.Validar();

            validarEndereco.Should().Throw<NumeroEnderecoInvalidoException>();
        }
    }
}
