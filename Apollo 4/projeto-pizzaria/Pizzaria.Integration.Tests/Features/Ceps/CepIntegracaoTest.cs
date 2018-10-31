using FluentAssertions;
using NDDTwitter.Infra.Cep;
using NUnit.Framework;
using Pizzaria.Application.Features.CEPs;
using Pizzaria.Application.Features.Clientes;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Infra.Cep;
using Pizzaria.Infra.Data;
using Pizzaria.Infra.Data.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Integration.Tests.Features.Ceps
{
    [TestFixture]
    public class CepIntegracaoTest
    {
        private CepRepositorio _repositorio;
        private CepServico _servico;

        [SetUp]
        public void Inicializacao()
        {
            _repositorio = new CepRepositorio();
            _servico = new CepServico(_repositorio);
        }

        [Test]
        public void Ceps_Integration_Deve_buscar_endereco_por_cep()
        {
            //Cenário
            string cepProcura = "88526380";

            string logradouroEsperado = "Rua Inácio de Alvarenga Peixoto";
            string bairroEsperado = "Várzea";
            string cepEsperado = "88526-380";

            //Ação
            Endereco endereco = _servico.BuscarCep(cepProcura);

            //Verifica
            endereco.Should().NotBeNull();
            endereco.Logradouro.Should().Be(logradouroEsperado);
            endereco.Bairro.Should().Be(bairroEsperado);
            endereco.Cep.Should().Be(cepEsperado);
            endereco.Complemento.Should().BeEmpty();

        }

        [Test]
        public void Ceps_Integration_Nao_deve_buscar_endereco_por_cep_vazio()
        {
            //Cenário
            string cep = "";

            //Ação
            Action acao = () => _servico.BuscarCep(cep);

            //Verifica
            acao.Should().Throw<CepNuloOuVazioExcecao>();
        }

    }
}
