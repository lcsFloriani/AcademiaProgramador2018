using System;
using FluentAssertions;
using NDDTwitter.Infra.Cep;
using NUnit.Framework;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Infra.Cep;

namespace Pizzaria.infra.Cep.Tests
{
    [TestFixture]
    public class CepRepositorioTest
    {
        private CepRepositorio _repositorio;

        [SetUp]
        public void Inicializacao()
        {
            _repositorio = new CepRepositorio();
        }

        [Test]
        public void Ceps_InfraCep_Deve_buscar_endereco_por_cep()
        {
            //Cenario
            string cepProdura = "88526380";

            string logradouroEsperado = "Rua Inácio de Alvarenga Peixoto";
            string bairroEsperado = "Várzea";
            string cepEsperado = "88526-380";

            //Ação
            Endereco endereco = _repositorio.BuscarCep(cepProdura);

            //Verificação
            endereco.Should().NotBeNull();
            endereco.Logradouro.Should().Be(logradouroEsperado);
            endereco.Bairro.Should().Be(bairroEsperado);
            endereco.Cep.Should().Be(cepEsperado);
            endereco.Complemento.Should().BeEmpty();
        }
    }
}
