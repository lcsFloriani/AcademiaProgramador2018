using FluentAssertions;
using NUnit.Framework;
using Projeto_loterica.Common.Tests.Base;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Concursos;
using Projeto_loterica.Domain.Features.Resultados;
using System;
using System.Linq;

namespace Projeto_loterica.Infra.Data.Features.Concursos
{
    [TestFixture]
    public class ConcursoSqlRepositoryTest
    {
        ConcursoSQLRepository _concursoRepository;
        Concurso _concurso;

        [SetUp]
        public void BolaoRepositorySet()
        {
            _concursoRepository = new ConcursoSQLRepository();
            _concurso = new Concurso(new Estatisticas(new Vencedor(), new Vencedor(), new Vencedor()));
            _concurso = ObjectMother.ConcursoValido;
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void ConcursoRepository_Save_Should_BeOk()
        {
            _concurso.Apostas.Add(ObjectMother.apostaValida);
            _concurso.Boloes.Add(ObjectMother.BolãoValido);
            _concursoRepository.Add(_concurso);

            _concurso.Id.Should().BeGreaterThan(0);
        }


        [Test]
        public void ConcursoRepository_Update_Should_BeOk()
        {
            _concurso.Id = 1;
            _concurso.resultado = (Resultado)"2,3,4,5,6,7";
            _concursoRepository.Update(_concurso);
            var concursoUpdated = _concursoRepository.GetById(_concurso.Id);
            var numerosString = (string)concursoUpdated.resultado;
            numerosString.Should().Be((string)_concurso.resultado);
        }

        [Test]
        public void ConcursoRepository_GetAll_ShouldBeOk()
        {
            var teste = _concursoRepository.GetAll();
            teste.Count().Should().BeGreaterThan(0);
        }
        [Test]
        public void ConcursoRepository_GetById_ShouldBeOk()
        {
            _concurso.Id = 1;
            var teste = _concursoRepository.GetById(_concurso.Id);
            teste.Id.Should().Be(_concurso.Id);
        }
        [Test]
        public void ConcursoRepository_Delete_ShouldBeOk()
        {

            Action comparison = () => _concursoRepository.Delete(_concurso); 
            comparison.Should().Throw<UnsupportedOperationException>();
        }
    }
}
