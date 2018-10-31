using NUnit.Framework;
using System;
using System.Linq;
using FluentAssertions;
using Projeto_loterica.Infra.Data.Features.Boloes;
using Projeto_loterica.Application.Features.Boloes;
using Projeto_loterica.Domain.Features.Boloes;
using Projeto_loterica.Common.Tests.Base;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;

namespace Projeto_loterica.Integration.Test.Features.Boloes
{
    [TestFixture]
    public class BoloesSQLRepositoryAndServiceTest
    {
        BolaoSQLRepository _bolaoSqlRepository;
        Bolao _bolao;
        BolaoService _service;

        [SetUp]
        public void BolaoRepository_Set()
        {
            _bolaoSqlRepository = new BolaoSQLRepository();
            BaseSqlTest.SeedDatabase();
            _service = new BolaoService(_bolaoSqlRepository);
            _bolao = ObjectMother.BolãoValido;

        }
        [Test]
        public void BolaoServiceIntegradeWithSqlRepository_add_Should_BeOk()
        {
            _service.Add(_bolao);
            _bolao.Id.Should().BeGreaterThan(0);
            var post = _service.GetById(_bolao.Id);
            post.Id.Should().Be(_bolao.Id);
            var posts = _service.GetAll();
            posts.Last().Id.Should().Be(_bolao.Id);
        }

        [Test]
        public void BolaoServiceIntegradeWithSqlRepository_Update_Should_BeOk()
        {
            Action alvo = () => _service.Update(_bolao);
            alvo.Should().Throw<UnsupportedOperationException>();
        }

        [Test]
        public void BolaoServiceIntegradeWithSqlRepository_GetAll_ShouldBeOk()
        {
            var teste = _service.GetAll();
            teste.Count().Should().BeGreaterThan(0);
        }
        [Test]
        public void BolaoServiceIntegradeWithSqlRepository_GetById_ShouldBeOk()
        {
            _bolao.Id = 1;
            var teste = _service.GetById(_bolao.Id);
            teste.Apostas.Count.Should().BeGreaterThan(0);
        }
        [Test]
        public void BolaoServiceIntegradeWithSqlRepository_Delete_ShouldBeOk()
        {
            Action alvo = () => _service.Delete(_bolao);
            alvo.Should().Throw<UnsupportedOperationException>();
        }
    }
}
