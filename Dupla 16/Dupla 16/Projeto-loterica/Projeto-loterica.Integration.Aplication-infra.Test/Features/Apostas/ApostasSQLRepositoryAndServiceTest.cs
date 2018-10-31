using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Projeto_loterica.Infra.Data.Features.Boloes;
using Projeto_loterica.Application.Features.Boloes;
using Projeto_loterica.Domain.Features.Boloes;
using Projeto_loterica.Common.Tests.Base;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Infra.Data.Features.Apostas;
using Projeto_loterica.Application.Features.Apostas;
using Projeto_loterica.Domain.Features.Apostas;

namespace Projeto_loterica.Integration.Test.Features.Apostas
{
    [TestFixture]
    class ApostasSQLRepositoryAndServiceTest
    {
        ApostaSQLRepository _apostaSqlRepository;
        Aposta _aposta;
        ApostaService _service;

        [SetUp]
        public void ApostaRepository_Set()
        {
            _apostaSqlRepository = new ApostaSQLRepository();
            BaseSqlTest.SeedDatabase();
            _service = new ApostaService(_apostaSqlRepository);
            _aposta = ObjectMother.apostaValida;
        }
        [Test]
        public void ApostaServiceIntegradeWithSqlRepository_add_Should_BeOk()
        {
            _service.Add(_aposta);
            _aposta.Id.Should().BeGreaterThan(0);
            var post = _service.GetById(_aposta.Id);
            post.Id.Should().Be(_aposta.Id);
            var posts = _service.GetAll();
            posts.Last().Id.Should().Be(_aposta.Id);
        }

        [Test]
        public void ApostaServiceIntegradeWithSqlRepository_Update_Should_BeOk()
        {
            Action alvo = () => _service.Update(_aposta);
            alvo.Should().Throw<UnsupportedOperationException>();
        }

        [Test]
        public void ApostaServiceIntegradeWithSqlRepository_GetAll_ShouldBeOk()
        {
            var teste = _service.GetAll();
            teste.Count().Should().BeGreaterThan(0);
        }
        [Test]
        public void ApostaServiceIntegradeWithSqlRepository_GetById_ShouldBeOk()
        {
            _aposta.Id = 1;
            var teste = _service.GetById(_aposta.Id);
            teste.Numeros.Count.Should().BeGreaterThan(0);
        }
        [Test]
        public void ApostaServiceIntegradeWithSqlRepository_Delete_ShouldBeOk()
        {
            Action alvo = () => _service.Delete(_aposta);
            alvo.Should().Throw<UnsupportedOperationException>();
        }
    }
}
