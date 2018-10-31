using FluentAssertions;
using NUnit.Framework;
using ProjetoLoterica.Aplicação.Features.Apostas;
using ProjetoLoterica.Common.Teste.Base;
using ProjetoLoterica.Common.Teste.Features.Apostas;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Apostas;
using ProjetoLoterica.Infra.Data.Features.Apostas;
using System;
using System.Collections.Generic;

namespace ProjetoLoterica.Integration.Teste.Features.Apostas
{
    [TestFixture]
    public class Apostas_SystemIntegration
    {
        ApostaRepository _apostaRepository;
        ApostaService _apostaService;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _apostaRepository = new ApostaRepository();
            _apostaService = new ApostaService(_apostaRepository);
        }

        [Test]
        public void Teste_ApostaSystemIntegration_Insert_ShouldBeOk()
        {
            var aposta = ApostaObjectMother.CriaApostaValida();
            aposta = _apostaService.Add(aposta);
            aposta.Id.Should().Be(2);
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_Update_ShouldBeOk()
        {
            var aposta = ApostaObjectMother.CriaApostaValida();
            aposta.Valor = 6;

            var apostaEditada = _apostaService.Update(aposta);
            apostaEditada.Valor.Should().Be(6);
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_Delete_ShouldBeOk()
        {
            var aposta = ApostaObjectMother.CriaApostaValida();

            _apostaService.Delete(aposta);

            aposta = _apostaService.Get(1);
            aposta.Should().BeNull();
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_Get_ShouldBeOk()
        {
            long id = 1;

            var aposta = _apostaService.Get(id);
            aposta.Should().NotBeNull();
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_GetConcurso_ShouldBeOk()
        {
            long id = 1;

            var aposta = ApostaObjectMother.CriaApostaValida();

            aposta.Concurso = _apostaService.GetConcurso(id);
            aposta.Concurso.Should().NotBeNull();
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_GetAll_ShouldBeOk()
        {
            IList<Aposta> apostas = _apostaService.GetAll();
            apostas.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_GetUndefinedId_ShouldFail()
        {
            long id = 0;

            Action action = () => _apostaService.Get(id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Teste_IntegrationDatabaseApostas_GetConcursoUndefinedId_ShouldFail()
        {
            long id = -1;

            Action action = () => _apostaService.GetConcurso(id);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
