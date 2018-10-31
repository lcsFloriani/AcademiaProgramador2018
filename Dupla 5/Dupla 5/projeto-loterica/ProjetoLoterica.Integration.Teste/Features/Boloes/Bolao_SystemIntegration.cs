using FluentAssertions;
using NUnit.Framework;
using ProjetoLoterica.Aplicação.Features.Boloes;
using ProjetoLoterica.Common.Teste.Base;
using ProjetoLoterica.Common.Teste.Features.Bolões;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Boloes;
using ProjetoLoterica.Infra.Data.Features.Apostas;
using ProjetoLoterica.Infra.Data.Features.Boloes;
using System;
using System.Collections.Generic;

namespace ProjetoLoterica.Integration.Teste.Features.Boloes
{
    [TestFixture]
    public class Bolao_SystemIntegration
    {
        ApostaRepository _apostaRepository;
        BolaoRepository _bolaoRepository;
        BolaoService _bolaoService;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _apostaRepository = new ApostaRepository();
            _bolaoRepository = new BolaoRepository();
            _bolaoService = new BolaoService(_bolaoRepository, _apostaRepository);
        }

        [Test]
        public void Teste_BolaoSystemIntegration_Add_ShouldBeOk()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            bolao = _bolaoRepository.Add(bolao);
            bolao.Id.Should().Be(2);
        }

        [Test]
        public void Teste_BolaoSystemIntegration_Delete_ShouldBeOk()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            _bolaoRepository.Delete(bolao);

            bolao = _bolaoRepository.Get(bolao.Id);
            bolao.Should().BeNull();
        }

        [Test]
        public void Teste_BolaoSystemIntegration_Get_ShouldBeOk()
        {
            long Id = 1;

            var bolao = _bolaoRepository.Get(Id);
            bolao.Should().NotBeNull();
            bolao.Id.Should().Be(Id);
        }

        [Test]
        public void Teste_BolaoSystemIntegration_GetAll_ShouldBeOk()
        {
            IList<Bolao> boloes = _bolaoRepository.GetAll();

            boloes.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_BolaoSystemIntegration_Update_ShouldFail()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            Action action = () => _bolaoRepository.Update(bolao);
            action.Should().Throw<BolaoUpdateException>();
        }

        [Test]
        public void Teste_BolaoSystemIntegration_GetUndefinedId_ShouldFail()
        {
            long id = 0;

            Action action = () => _bolaoRepository.Get(id);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
