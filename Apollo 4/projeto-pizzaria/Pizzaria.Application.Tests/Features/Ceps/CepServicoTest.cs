using FluentAssertions;
using Moq;
using NDDTwitter.Infra.Cep;
using NUnit.Framework;
using Pizzaria.Application.Features.CEPs;
using Pizzaria.Application.Features.Clientes;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Infra.Cep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Application.Tests.Features.CEPs
{
    [TestFixture]
    public class CepServicoTest
    {
        private Mock<CepRepositorio> _mockRepositorio;
        private ICepServico _servico;

        [SetUp]
        public void Inicializacao()
        {
            _mockRepositorio = new Mock<CepRepositorio>();
            _servico = new CepServico(_mockRepositorio.Object);
        }

        [Test]
        public void Ceps_Application_Deve_buscar_endereco_por_cep()
        {
            //Cenário
            string cep = "88526380";

            _mockRepositorio.Setup(m => m.BuscarCep(cep)).Returns(ObjectMother.ObterEndereco);

            //Ação
            Endereco resultado = _servico.BuscarCep(cep);

            //Verifica
            resultado.Should().NotBeNull();
            _mockRepositorio.Verify(repository => repository.BuscarCep(cep));
        }

        [Test]
        public void Ceps_Application_Nao_deve_buscar_endereco_por_cep_vazio()
        {
            //Cenário
            string cep = "";
           
            //Ação
            Action acao = () => _servico.BuscarCep(cep);

            //Verifica
            acao.Should().Throw<CepNuloOuVazioExcecao>();
            _mockRepositorio.VerifyNoOtherCalls();
        }
    }
}
