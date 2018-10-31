using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoterica.Aplicação.Features.Concursos;
using ProjetoLoterica.Common.Teste.Features.Concusos;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjetoLoterica.Aplicação.Teste.Features.Concursos
{
    [TestFixture]
    public class ConcursoServiceTeste
    {
        private IConcursoService _concursoService;
        private Mock<IConcursoRepository> _mockRepository;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IConcursoRepository>();
            _concursoService = new ConcursoService(_mockRepository.Object);
        }

        [Test]
        public void Test_ConcursoService_Insert_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            _mockRepository
                .Setup(cr => cr.Add(concurso))
                .Returns(new Concurso { Id = 1 });

            var c = _concursoService.Add(concurso);

            _mockRepository.Verify(cr => cr.Add(concurso));
            c.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ConcursoService_Get_ShouldBeOk()
        {
            long ConcursoId = 1;

            _mockRepository
                .Setup(cr => cr.Get(ConcursoId))
                .Returns(new Concurso { Id = 1 });

            var concurso = _concursoService.Get(ConcursoId);
            _mockRepository.Verify(cr => cr.Get(ConcursoId));
            concurso.Should().NotBeNull();
        }

        [Test]
        public void Test_ConcursoService_Update_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();
            concurso.Numero = 2000;

            _mockRepository
                .Setup(cr => cr.Update(concurso))
                .Returns(new Concurso { Numero = 2000 });

            var c = _concursoService.Update(concurso);

            _mockRepository.Verify(cr => cr.Update(concurso));
            c.Numero.Should().Be(2000);
        }

        [Test]
        public void Test_ConcursoService_UpdateSituacao_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            _mockRepository
                .Setup(cr => cr.UpdateSituacao(concurso))
                .Returns(new Concurso { Situacao = false });

            var c = _concursoService.UpdateSituacao(concurso);

            _mockRepository.Verify(cr => cr.UpdateSituacao(concurso));
            c.Situacao.Should().BeFalse();
        }

        [Test]
        public void Test_ConcursoService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(cr => cr.GetAll())
                .Returns(new List<Concurso> { new Concurso { Id = 1 }, new Concurso { Id = 2 } });

            IList<Concurso> concurso = _concursoService.GetAll();

            _mockRepository.Verify(cr => cr.GetAll());
            concurso.Count.Should().Be(2);
            concurso[0].Id.Should().Be(1);
        }

        [Test]
        public void Test_ConcursoService_Delete_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            _concursoService.Delete(concurso);

            _mockRepository.Verify(cr => cr.Delete(concurso));
        }

        [Test]
        public void Test_ConcursoService_GerarCsv_ShouldBeOk()
        {
            _mockRepository
                .Setup(cr => cr.GetAllConcursosFechados())
                .Returns(new List<Concurso> { new Concurso { Id = 1 }, new Concurso { Id = 2 } });

            var concursos = _concursoService.GetAllConcursosFechados();
            var desktop = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string caminho = System.IO.Path.Combine(desktop,"Test.csv");
            _concursoService.GerarCsv(concursos, caminho);

            File.Exists(caminho).Should().BeTrue();
        }

        [Test]
        public void Test_ConcursoService_GerarCsvSemConcurso_ShouldFail()
        {
            _mockRepository
                .Setup(ar => ar.GetAllConcursosFechados())
                .Returns(new List<Concurso> { });

            var concursos = _concursoService.GetAllConcursosFechados();
            string caminho = "testeCSV.csv";

            Action action = () => _concursoService.GerarCsv(concursos, caminho);
            action.Should().Throw<ListaConcursosVaziaException>();
        }

        [Test]
        public void Test_ConcursoService_ValidarNumero_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoNumeroInvalido();

            Action action = () => concurso.Validar();
            action.Should().Throw<ConcursoNumeroException>();
        }

        [Test]
        public void Test_ConcursoService_ValidarData_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoDataInvalida();

            Action action = () => concurso.Validar();
            action.Should().Throw<ConcursoDataException>();
        }

        [Test]
        public void Test_ConcursoService_ValidarDezenas_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoQuantidadeDezenasInvalidas();

            Action action = () => concurso.Validar();
            action.Should().Throw<ConcursoDezenaException>();
        }

        [Test]
        public void Test_ConcursoService_ValidarPremio_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoPremioInvalido();

            Action action = () => concurso.Validar();
            action.Should().Throw<ConcursoPremioException>();
        }

        [Test]
        public void Test_ConcursoService_GetUndefinedId_ShouldFail()
        {
            long Id = 0;

            Action action = () => _concursoService.Get(Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
