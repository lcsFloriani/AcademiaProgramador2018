using FluentAssertions;
using NUnit.Framework;
using Projeto_loterica.Common.Tests.Base;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Boloes;
using System;
using System.Linq;

namespace Projeto_loterica.Infra.Data.Features.Boloes
{
    [TestFixture]
    public class BolaoSqlRepositoryTest
    {

        BolaoSQLRepository _bolaoRepository;
        Bolao _bolao;

        [SetUp]
        public void BolaoRepositorySet()
        {
            _bolaoRepository = new BolaoSQLRepository();
            _bolao = new Bolao();
            _bolao = ObjectMother.BolãoValido;
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void BolaoRepository_Save_Should_BeOk()
        {
            _bolaoRepository.Add(_bolao);
            _bolao.Id.Should().BeGreaterThan(0);
        }

     

        [Test]
        public void BolaoRepository_Update_Should_BeOk()
        {
            Action comparison = () =>  _bolaoRepository.Update(_bolao);
            comparison.Should().Throw<UnsupportedOperationException>();
        }

        [Test]
        public void BolaoRepository_GetAll_ShouldBeOk()
        {
            var teste = _bolaoRepository.GetAll();
            teste.Count().Should().BeGreaterThan(0);
        }
        [Test]
        public void BolaoRepository_GetById_ShouldBeOk()
        {
            _bolao.Id = 1;
            var teste = _bolaoRepository.GetById(_bolao.Id);
            teste.Id.Should().Be(_bolao.Id);
        }
        [Test]
        public void BolaoRepository_Delete_ShouldBeOk()
        {

            Action comparison = () =>  _bolaoRepository.Delete(_bolao);
            comparison.Should().Throw<UnsupportedOperationException>();
        }
    }
}
