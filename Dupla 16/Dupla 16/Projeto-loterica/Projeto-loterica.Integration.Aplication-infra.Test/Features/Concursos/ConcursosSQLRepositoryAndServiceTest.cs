using NUnit.Framework;
using System;
using System.Linq;
using FluentAssertions;
using Projeto_loterica.Common.Tests.Base;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Infra.Data.Features.Concursos;
using Projeto_loterica.Application.Features.Concursos;
using Projeto_loterica.Domain.Features.Concursos;

namespace Projeto_loterica.Integration.Test.Features.Concursos
{
    [TestFixture]
    class ConcursosSQLRepositoryAndServiceTest
    {
        ConcursoSQLRepository _concursoSqlRepository;
        Concurso _concurso;
        ConcursoService _service;

        [SetUp]
        public void ConcursoRepository_Set()
        {
            _concursoSqlRepository = new ConcursoSQLRepository();
            BaseSqlTest.SeedDatabase();
            _service = new ConcursoService(_concursoSqlRepository);
            _concurso = ObjectMother.ConcursoValido;

        }
        [Test]
        public void ConcursoServiceIntegradeWithSqlRepository_add_Should_BeOk()
        {
            _service.Add(_concurso);
            _concurso.Id.Should().BeGreaterThan(0);
            var post = _service.GetById(_concurso.Id);
            post.Id.Should().Be(_concurso.Id);
            var posts = _service.GetAll();
            posts.Last().Id.Should().Be(_concurso.Id);
        }

        [Test]
        public void ConcursoServiceIntegradeWithSqlRepository_Update_Should_BeOk()
        {
            _concurso.Id = 1;
            var cont = _concurso.Apostas.Count;
            _concurso.Apostas.Add(ObjectMother.apostaValida);
            _service.Update(_concurso);
            var concurso = _service.GetById(_concurso.Id);
            concurso.Apostas.Count.Should().BeGreaterThan(cont);
        }
        [Test]
        public void ConcursoServiceIntegradeWithSqlRepository_GerarResultado_Should_BeOk()
        {
            _concurso.Id = 1;
            var cont = _concurso.Apostas.Count;
            _concurso.Apostas.Add(ObjectMother.apostaValida);
            var concurso =  _service.GerarResultado(_concurso);
            concurso.Apostas.Count.Should().BeGreaterThan(cont);
        }

        [Test]
        public void ConcursoServiceIntegradeWithSqlRepository_GetAll_ShouldBeOk()
        {
            var teste = _service.GetAll();
            teste.Count().Should().BeGreaterThan(0);
        }
        [Test]
        public void ConcursoServiceIntegradeWithSqlRepository_GetById_ShouldBeOk()
        {
            _concurso.Id = 1;
            var teste = _service.GetById(_concurso.Id);
            teste.Apostas.Count.Should().BeGreaterThan(0);
        }
        [Test]
        public void ConcursoServiceIntegradeWithSqlRepository_Delete_ShouldBeOk()
        {
            Action alvo = () => _service.Delete(_concurso);
            alvo.Should().Throw<UnsupportedOperationException>();
        }
    }
}
