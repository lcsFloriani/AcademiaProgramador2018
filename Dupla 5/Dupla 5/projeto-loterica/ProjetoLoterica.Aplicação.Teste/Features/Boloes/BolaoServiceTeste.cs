using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoterica.Aplicação.Features.Boloes;
using ProjetoLoterica.Common.Teste.Features.Bolões;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Apostas;
using ProjetoLoterica.Dominio.Features.Boloes;
using ProjetoLoterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;

namespace ProjetoLoterica.Aplicação.Teste.Features.Boloes
{
    [TestFixture]
    public class BolaoServiceTeste
    {
        private IBolaoService _bolaoService;
        private Mock<IBolaoRepository> _mockRepository;
        private Mock<IApostaRepository> _mockApostaRepository;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IBolaoRepository>();
            _mockApostaRepository = new Mock<IApostaRepository>();
            _bolaoService = new BolaoService(_mockRepository.Object, _mockApostaRepository.Object);
        }

        [Test]
        public void Test_BolaoService_Add_ShouldBeOk()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            _mockRepository
                .Setup(ar => ar.Add(bolao))
                .Returns(new Bolao { Id = 1 });

            var b = _bolaoService.Add(bolao);

            _mockRepository.Verify(ar => ar.Add(bolao));
            b.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_BolaoService_Update_ShouldBeOk()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            Action action = () => _bolaoService.Update(bolao);
            action.Should().Throw<BolaoUpdateException>();
        }

        [Test]
        public void Test_BolaoService_Get_ShouldBeOk()
        {
            _mockRepository
                  .Setup(br => br.Get(1))
                  .Returns(new Bolao { Id = 1 });

            var bolao = _bolaoService.Get(1);

            _mockRepository.Verify(ar => ar.Get(bolao.Id));
            bolao.Should().NotBeNull();
            bolao.Id.Should().Be(1);
        }

        [Test]
        public void Test_BolaoService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(ar => ar.GetAll())
                .Returns(new List<Bolao> { new Bolao { Id = 1 }, new Bolao { Id = 2 } });

            IList<Bolao> boloes = _bolaoService.GetAll();

            _mockRepository.Verify(ar => ar.GetAll());
            boloes.Count.Should().Be(2);
            boloes[0].Id.Should().Be(1);
        }

        [Test]
        public void Test_BolaoService_Delete_ShouldBeOk()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            _mockApostaRepository
                .Setup(ar => ar.GetApostasComBolao(bolao.Id))
                .Returns(new List<Aposta> { });

            _mockRepository
                .Setup(br => br.Delete(bolao));

            _bolaoService.Delete(bolao);
            _mockRepository.Verify(br => br.Delete(bolao));
        }

        [Test]
        public void Test_BolaoService_GerarBolao_ShouldBeOk()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            Mock<Concurso> concurso = new Mock<Concurso>();

            int numApostas = 10;

            _bolaoService.GerarBolao(bolao, concurso.Object, numApostas);
        }

        [Test]
        public void Test_BolaoService_AddInvalidNumber_ShouldBeFail()
        {
            var bolao = BolaoObjectMother.CriaBolaoInvalidoNumeroInvalido();

            Action action = () => _bolaoService.Add(bolao);
            action.Should().Throw<BolaoNumeroExeption>();
        }

        [Test]
        public void Test_BolaoService_Delete_ShouldBeFail()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            _mockApostaRepository
                .Setup(ar => ar.GetApostasComBolao(bolao.Id))
                .Returns(new List<Aposta> { new Aposta { Id = 1 } });

            Action action = () => _bolaoService.Delete(bolao);

            action.Should().Throw<BolaoComApostasException>();
        }

        [Test]
        public void Test_BolaoService_DeleteUndefinedId_ShouldFail()
        {
            var bolao = BolaoObjectMother.CriaBolaoInvalidoIdInvalido();

            _mockApostaRepository
                .Setup(ar => ar.GetApostasComBolao(bolao.Id))
                .Returns(new List<Aposta> { });

            Action action = () => _bolaoService.Delete(bolao);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_BolaoService_GetUndefinedId_ShouldFail()
        {
            _mockRepository
                  .Setup(br => br.Get(-1))
                  .Throws<IdentifierUndefinedException>();

            Action action = () => _bolaoService.Get(-1);

            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
