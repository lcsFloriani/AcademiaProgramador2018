using FluentAssertions;
using NUnit.Framework;
using ProjetoLoterica.Common.Teste.Base;
using ProjetoLoterica.Common.Teste.Features.Bolões;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Boloes;
using ProjetoLoterica.Infra.Data.Features.Boloes;
using System;
using System.Collections.Generic;

namespace ProjetoLoterica.Infra.Data.Teste.Features.Boloes
{
    [TestFixture]
    public class BolaoRepositoryTest
    {
        private IBolaoRepository _bolaoRepository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _bolaoRepository = new BolaoRepository();
        }

        [Test]
        public void Test_IntegrationDataBaseBolao_Add_ShouldBeOk()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            bolao = _bolaoRepository.Add(bolao);
            bolao.Id.Should().Be(2);
        }

        [Test]
        public void Test_IntegrationDataBaseBolao_Delete_ShouldBeOk()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            _bolaoRepository.Delete(bolao);

            bolao = _bolaoRepository.Get(bolao.Id);
            bolao.Should().BeNull();
        }

        [Test]
        public void Test_IntegrationDataBaseBolao_Get_ShouldBeOk()
        {
            long Id = 1;

            var bolao = _bolaoRepository.Get(Id);
            bolao.Should().NotBeNull();
            bolao.Id.Should().Be(Id);
        }

        [Test]
        public void Test_IntegrationDataBaseBolao_GetAll_ShouldBeOk()
        {
            IList<Bolao> boloes = _bolaoRepository.GetAll();

            boloes.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_IntegrationDataBaseBolao_Update_ShouldFail()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            Action action = () => _bolaoRepository.Update(bolao);
            action.Should().Throw<BolaoUpdateException>();
        }

        [Test]
        public void Test_IntegrationDataBaseBolao_GetUndefinedId_ShouldFail()
        {
            long id = 0;

            Action action = () => _bolaoRepository.Get(id);
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
