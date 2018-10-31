using NUnit.Framework;
using ProjetoLoterica.Dominio.Features.Apostas;
using ProjetoLoterica.Common.Teste.Base;
using ProjetoLoterica.Infra.Data.Features.Apostas;
using ProjetoLoterica.Common.Teste.Features.Apostas;
using FluentAssertions;
using System.Collections.Generic;
using System;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Concursos;
using Moq;

namespace ProjetoLoterica.Infra.Data.Teste.Features.Apostas
{
    [TestFixture]
    public class ApostaRepositoryTest
    {
        private IApostaRepository _apostaRepository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _apostaRepository = new ApostaRepository();
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_Insert_ShouldBeOk()
        {
            var aposta = ApostaObjectMother.CriaApostaValida();
            aposta = _apostaRepository.Add(aposta);
            aposta.Id.Should().Be(2);
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_Update_ShouldBeOk()
        {
            var aposta = ApostaObjectMother.CriaApostaValida();
            aposta.Valor = 6;

            var apostaEditada = _apostaRepository.Update(aposta);
            apostaEditada.Valor.Should().Be(6);
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_Delete_ShouldBeOk()
        {
            Mock<Concurso> concurso = new Mock<Concurso>();

            var aposta = ApostaObjectMother.CriaApostaValida();
                
            aposta.Concurso = concurso.Object;
            _apostaRepository.Delete(aposta);

            aposta = _apostaRepository.Get(1);
            aposta.Should().BeNull();
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_Get_ShouldBeOk()
        {
            long id = 1;

            var aposta = _apostaRepository.Get(id);
            aposta.Should().NotBeNull();
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_GetConcurso_ShouldBeOk()
        {
            long id = 1;

            var aposta = ApostaObjectMother.CriaApostaValida();

            aposta.Concurso = _apostaRepository.GetConcurso(id);

            aposta.Concurso.Should().NotBeNull();
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_GetApostasComBolao_ShouldBeOk()
        {
            long id = 1;

            IList<Aposta> apostas = _apostaRepository.GetApostasComBolao(id);

            apostas.Count.Should().Be(0);
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_GetAll_ShouldBeOk()
        {
            IList<Aposta> apostas = _apostaRepository.GetAll();

            apostas.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_GetUndefinedId_ShouldFail()
        {
            long id = 0;

            Action action = () => _apostaRepository.Get(id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_GetConcursoUndefinedId_ShouldFail()
        {
            long id = -1;

            Action action = () => _apostaRepository.GetConcurso(id);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}