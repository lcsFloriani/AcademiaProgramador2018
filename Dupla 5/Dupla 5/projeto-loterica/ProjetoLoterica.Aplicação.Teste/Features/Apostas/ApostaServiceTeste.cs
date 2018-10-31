using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoterica.Aplicação.Features.Apostas;
using ProjetoLoterica.Common.Teste.Features.Apostas;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Apostas;
using ProjetoLoterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;

namespace ProjetoLoterica.Aplicação.Teste.Features
{
    [TestFixture]
    public class ApostaServiceTeste
    {
        private IApostaService _service;
        private Mock<IApostaRepository> _mockRepository;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IApostaRepository>();
            _service = new ApostaService(_mockRepository.Object);
        }

        [Test]
        public void Test_ApostaService_Add_ShouldBeOk()
        {
            Aposta aposta = ApostaObjectMother.CriaApostaValida();

            _mockRepository
                .Setup(ar => ar.Add(aposta))
                .Returns(new Aposta { Id = 1 });

            Aposta p = _service.Add(aposta);

            _mockRepository.Verify(ar => ar.Add(aposta));
            p.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ApostaService_Update_ShouldBeOk()
        {
            Aposta aposta = ApostaObjectMother.CriaApostaValida();
            aposta.Valor = 6;

            _mockRepository
                .Setup(ar => ar.Update(aposta))
                .Returns(new Aposta { Valor = 6 });

            Aposta p = _service.Update(aposta);

            _mockRepository.Verify(ar => ar.Update(aposta));
            p.Valor.Should().Be(6);
        }

        [Test]
        public void Test_ApostaService_Delete_ShouldBeOk()
        {
            Aposta aposta = ApostaObjectMother.CriaApostaValida();

            _service.Delete(aposta);

            _mockRepository.Verify(ar => ar.Delete(aposta));
        }

        [Test]
        public void Test_ApostaService_Get_ShouldBeOk()
        {
            long id = 1;

            _mockRepository
                .Setup(ar => ar.Get(id))
                .Returns(new Aposta { Id = 1 });

            Aposta aposta = _service.Get(id);

            _mockRepository.Verify(ar => ar.Get(id));
            aposta.Id.Should().Be(1);
            aposta.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ApostaService_GetConcurso_ShouldBeOk()
        {
            Aposta aposta = ApostaObjectMother.CriaApostaValida();

            long id = 1;

            _mockRepository
                .Setup(ar => ar.GetConcurso(id))
                .Returns(new Concurso { Id = 1 });

            aposta.Concurso = _service.GetConcurso(id);

            _mockRepository.Verify(ar => ar.GetConcurso(id));
            aposta.Concurso.Id.Should().Be(1);
            aposta.Concurso.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ApostaService_GetApostasComBolao_ShouldBeOk()
        {
            long id = 1;

            _mockRepository
                .Setup(ar => ar.GetApostasComBolao(id))
                .Returns(new List<Aposta> { new Aposta { Id = 1 } });

            IList<Aposta> apostas = _service.GetApostasComBolao(id);

            _mockRepository.Verify(ar => ar.GetApostasComBolao(id));
            apostas.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ApostaService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(ar => ar.GetAll())
                .Returns(new List<Aposta> { new Aposta { Id = 1 }, new Aposta { Id = 2 } });

            IList<Aposta> apostas = _service.GetAll();

            _mockRepository.Verify(ar => ar.GetAll());
            apostas.Count.Should().Be(2);
            apostas[0].Id.Should().Be(1);
        }

        [Test]
        public void Test_ApostaService_GetConcursoUndefinedId_ShouldFail()
        {
            Aposta aposta = ApostaObjectMother.CriaApostaValida();

            long id = -1;

            _mockRepository
                .Setup(ar => ar.GetConcurso(id))
                .Throws<IdentifierUndefinedException>();

            Action action = () => _service.GetConcurso(id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_ApostaService_AddUndefinedId_ShouldFail()
        {
            Aposta aposta = ApostaObjectMother.CriaApostaInvalidaIdInvalido();

            Action action = () => _service.Add(aposta);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_ApostaService_AddInvalidDate_ShouldFail()
        {
            Aposta aposta = ApostaObjectMother.CriaApostaInvalidaDataInvalida();

            Action action = () => _service.Add(aposta);
            action.Should().Throw<ApostaDataException>();
        }

        [Test]
        public void Test_ApostaService_AddInvalidValue_ShouldFail()
        {
            Aposta aposta = ApostaObjectMother.CriaApostaInvalidaValorInvalido();

            Action action = () => _service.Add(aposta);
            action.Should().Throw<ApostaValorException>();
        }

        [Test]
        public void Test_ApostaService_AddInvalidDozens_ShouldFail()
        {
            Aposta aposta = ApostaObjectMother.CriaApostaInvalidaDezenaInvalida();

            Action action = () => _service.Add(aposta);
            action.Should().Throw<ApostaDezenasException>();
        }

        [Test]
        public void Test_ApostaService_UpdateUndefinedId_ShouldFail()
        {
            Aposta aposta = ApostaObjectMother.CriaApostaInvalidaIdInvalido();

            _mockRepository
                .Setup(ar => ar.Update(aposta))
                .Throws<IdentifierUndefinedException>();

            Action acrion = () => _service.Update(aposta);
            acrion.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_ApostaService_DeleteUndefinedId_ShouldFail()
        {
            Aposta aposta = ApostaObjectMother.CriaApostaInvalidaIdInvalido();

            _mockRepository
                .Setup(ar => ar.Delete(aposta))
                .Throws<IdentifierUndefinedException>();

            Action action = () => _service.Delete(aposta);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_ApostaService_GetUndefinedId_ShouldFail()
        {
            long id = -1;

            _mockRepository
                .Setup(ar => ar.Get(id))
                .Throws<IdentifierUndefinedException>();

            Action action = () => _service.Get(id);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}