using FluentAssertions;
using NUnit.Framework;
using Projeto_loterica.Common.Tests.Base;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Apostas;
using System;
using System.Linq;

namespace Projeto_loterica.Infra.Data.Features.Apostas
{
    [TestFixture]
    public class ApostaSqlRepositoryTest
    {
        ApostaSQLRepository _apostaRepository;
        Aposta _aposta;

        [SetUp]
        public void ApostaRepositorySet()
        {
            _apostaRepository = new ApostaSQLRepository();
            _aposta = new Aposta();
            _aposta = ObjectMother.apostaValida;

            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void ApostaRepository_Save_Should_BeOk()
        {
            _apostaRepository.Add(_aposta);
            _aposta.Id.Should().BeGreaterThan(0);
        }

        
        [Test]
        public void ApostaRepository_Update_Should_BeOk()
        {
            Action comparison = () =>  _apostaRepository.Update(_aposta); 
            comparison.Should().Throw<UnsupportedOperationException>();
        }

        [Test]
        public void ApostaRepository_GetAll_ShouldBeOk()
        {
            var teste = _apostaRepository.GetAll();
            teste.Count().Should().BeGreaterThan(0);
        }
        [Test]
        public void ApostaRepository_GetById_ShouldBeOk()
        {
            _aposta.Id = 1;
            var teste = _apostaRepository.GetById(_aposta.Id);
            teste.ValorPago.Should().Be(3.00);
        }
        [Test]
        public void ApostaRepository_Delete_ShouldBeOk()
        {
            Action comparison = () =>  _apostaRepository.Delete(_aposta); 
            comparison.Should().Throw<UnsupportedOperationException>();
        }
    }
}
