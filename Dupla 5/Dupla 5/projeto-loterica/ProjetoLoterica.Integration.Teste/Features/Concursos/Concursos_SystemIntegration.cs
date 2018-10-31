using FluentAssertions;
using NUnit.Framework;
using ProjetoLoterica.Aplicação.Features.Concursos;
using ProjetoLoterica.Common.Teste.Base;
using ProjetoLoterica.Common.Teste.Features.Concusos;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Concursos;
using ProjetoLoterica.Infra.Data.Features.Concursos;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjetoLoterica.Integration.Teste.Features.Concursos
{
    [TestFixture]
    public class Concursos_SystemIntegration
    {
        ConcursoRepository _concursoRepository;
        ConcursoService _concursoService;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _concursoRepository = new ConcursoRepository();
            _concursoService = new ConcursoService(_concursoRepository);
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_Insert_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();
            concurso = _concursoService.Add(concurso);
            concurso.Id.Should().Be(2);
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_Get_ShouldBeOk()
        {
            long id = 1;
            var concurso = _concursoService.Get(id);
            concurso.Id.Should().Be(1);
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_Delete_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();
            _concursoService.Delete(concurso);

            var concursoDeletado = _concursoService.Get(concurso.Id);
            concursoDeletado.Should().BeNull();
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_Update_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();
            concurso.Premio = 10;

            var concursoEditado = _concursoService.Update(concurso);
            concursoEditado.Premio.Should().Be(10);
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_UpdateSituacaoFalse_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            var concursoEditado = _concursoService.UpdateSituacao(concurso);
            concursoEditado.Situacao.Should().BeFalse();
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_UpdateSituacaoTrue_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();
            concurso.Situacao = false;

            var concursoEditado = _concursoService.UpdateSituacao(concurso);
            concursoEditado.Situacao.Should().BeFalse();
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_GetAll_ShouldBeOk()
        {
            IList<Concurso> concursos = _concursoService.GetAll();
            concursos.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_ComcursoComSeisDezenas_ShouldBeOk()
        {
            var concurso = _concursoService.Get(1);
            concurso.Dezenas.Count.Should().Be(6);
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_GerarCsv_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();
            concurso.Fechar();

            var concursos = _concursoService.GetAllConcursosFechados();
            concursos.Add(concurso);

            var desktop = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string caminho = System.IO.Path.Combine(desktop, "Test.csv");
            _concursoService.GerarCsv(concursos, caminho);

            File.Exists(caminho).Should().BeTrue();
        }

        [Test]
        public void Teste_ConcursoSystemIntegratio_GerarCsvSemConcurso_ShouldFail()
        {
            IList<Concurso> concursos = new List<Concurso>();

            string caminho = "integracao.csv";
            Action action = () => _concursoService.GerarCsv(concursos, caminho);
            action.Should().Throw<ListaConcursosVaziaException>();
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_AddDataInvalida_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoDataInvalida();

            Action action = () => _concursoService.Add(concurso);
            action.Should().Throw<ConcursoDataException>();
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_AddNumeroInvalido_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoNumeroInvalido();

            Action action = () => _concursoService.Add(concurso);
            action.Should().Throw<ConcursoNumeroException>();
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_AddPremioInvalido_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoPremioInvalido();

            Action action = () => _concursoService.Add(concurso);
            action.Should().Throw<ConcursoPremioException>();
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_AddDezenasInvalidas_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoQuantidadeDezenasInvalidas();

            Action action = () => _concursoService.Add(concurso);
            action.Should().Throw<ConcursoDezenaException>();
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_GetUndefinedId_ShouldFail()
        {
            long id = -1;

            Action action = () => _concursoService.Get(id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Teste_ConcursoSystemIntegration_DeleteConcursoComApostas_ShouldFail()
        {
            var concurso = _concursoService.Get(1);

            Action action = () => _concursoService.Delete(concurso);
            action.Should().Throw<ConcursoTemApostasException>();
        }
    }
}
