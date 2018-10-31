using FluentAssertions;
using NUnit.Framework;
using ProjetoLoterica.Common.Teste.Base;
using ProjetoLoterica.Common.Teste.Features.Concusos;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Concursos;
using ProjetoLoterica.Infra.Data.Features.Concursos;
using System;
using System.Collections.Generic;

namespace ProjetoLoterica.Infra.Data.Teste.Features.Concursos
{
    [TestFixture]
    public class ConcursoRepositoryTest
    {
        private IConcursoRepository _concursoRepository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _concursoRepository = new ConcursoRepository();
        }

        [Test]
        [Order(1)]
        public void Teste_ConcursoRepository_Add_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();
            concurso = _concursoRepository.Add(concurso);
            concurso.Id.Should().Be(2);
        }

        [Test]
        [Order(2)]
        public void Teste_ConcursoRepository_Get_ShouldBeOk()
        {
            long id = 1;
            var concurso = _concursoRepository.Get(id);
            concurso.Id.Should().Be(1);
        }

        [Test]
        [Order(3)]
        public void Teste_ConcursoRepository_Delete_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            concurso = _concursoRepository.Add(concurso);

            var concursoAdicionado = _concursoRepository.Get(2);

            _concursoRepository.Delete(concursoAdicionado);

            var concursoDeletado = _concursoRepository.GetAll();
            concursoDeletado.Count.Should().Be(1);
        }

        [Test]
        public void Teste_ConcursoRepository_Update_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();
            concurso.Premio = 10;

            var concursoEditado = _concursoRepository.Update(concurso);
            concursoEditado.Premio.Should().Be(10);
        }

        [Test]
        public void Teste_ConcursoRepository_UpdateSituacao_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            var concursoEditado = _concursoRepository.UpdateSituacao(concurso);
            concursoEditado.Situacao.Should().BeFalse();
        }

        [Test]
        public void Teste_ConcursoRepository_GetAll_ShouldBeOk()
        {
            IList<Concurso> concursos = _concursoRepository.GetAll();
            concursos.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ConcursoRepository_ConcursoComSeisDezenas_ShouldBeOk()
        {
            var concurso = _concursoRepository.Get(1);
            concurso.Dezenas.Count.Should().Be(6);
        }

        [Test]
        public void Teste_ConcursoRepository_AddDataInvalida_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoDataInvalida();

            Action action = () => _concursoRepository.Add(concurso);
            action.Should().Throw<ConcursoDataException>();
        }

        [Test]
        public void Teste_ConcursoRepository_AddNumeroInvalido_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoNumeroInvalido();

            Action action = () => _concursoRepository.Add(concurso);
            action.Should().Throw<ConcursoNumeroException>();
        }

        [Test]
        public void Teste_ConcursoRepository_AddPremioInvalido_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoPremioInvalido();

            Action action = () => _concursoRepository.Add(concurso);
            action.Should().Throw<ConcursoPremioException>();
        }

        [Test]
        public void Teste_ConcursoRepository_AddDezenasInvalidas_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoQuantidadeDezenasInvalidas();

            Action action = () => _concursoRepository.Add(concurso);
            action.Should().Throw<ConcursoDezenaException>();
        }

        [Test]
        public void Teste_ConcursoRepository_GetUndefinedId_ShouldFail()
        {
            long id = -1;

            Action action = () => _concursoRepository.Get(id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Teste_ConcursoRepository_DeleteConcursoComApostas_ShouldFail()
        {
            var concurso = _concursoRepository.Get(1);

            Action action = () => _concursoRepository.Delete(concurso);
            action.Should().Throw<ConcursoTemApostasException>();
        }
    }
}
