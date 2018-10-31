using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_loterica.Application.Features.Apostas;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_loterica.Service.Tests.Features.Apostas
{
    [TestFixture]
    public class ApostaServiceTest
    {
        private ApostaService Alvo;

        private Mock<IApostaRepository> _mock;

        Aposta _aposta;

        [SetUp]
        public void ApostaService_Set()
        {
            _mock = new Mock<IApostaRepository>();
            Alvo = new ApostaService(_mock.Object);
            _aposta = ObjectMother.apostaValida;
        }

        [Test]
        public void ApostaService_AddTest_Should_BeOk()
        {
            _mock.Setup(x => x.Add(_aposta)).Returns(new Aposta() { Id = 1 });

            var obtido = Alvo.Add(_aposta);

            obtido.Id.Should().BeGreaterThan(0);

        }

        [Test]
        public void ApostaService_AddTest_Should_BeFail_NumerosIguais()
        {
            _aposta = ObjectMother.apostaInvalidaNumerosIguais;

            Action action = () =>  Alvo.Add(_aposta); 
            action.Should().Throw<NumeroRepetidoEmApostaException>();
            _mock.VerifyNoOtherCalls();

        }

        [Test]
        public void ApostaService_AddTest_Should_BeFail_NumeroMenor6()
        {
            _aposta = ObjectMother.apostaInvalidaMenosDe6Numeros;

            Action action = () =>  Alvo.Add(_aposta); 
            action.Should().Throw<ApostaInvalidaException>();
            _mock.VerifyNoOtherCalls();

        }

        [Test]
        public void ApostaService_DeleteTest_Should_BeOK()
        {
            
            _mock.Setup(x => x.Delete(_aposta));

            Alvo.Delete(_aposta);

            _mock.Verify(x => x.Delete(_aposta));
        }

        [Test]
        public void ApostaService_DeleteTest_Should_BeFail()
        {
            _aposta.Id = 0;
            _mock.Setup(x => x.Delete(_aposta));

            Action action = () =>  Alvo.Delete(_aposta);
            action.Should().Throw<IdentifierUndefinedException>();
            _mock.VerifyNoOtherCalls();
        }

        [Test]
        public void ApostaService_GetAllTest_ShouldBeOK()
        {

            _mock.Setup(x => x.GetAll()).Returns(new List<Aposta>() {
               _aposta
            });
           
            var obtido = Alvo.GetAll();
            _mock.Verify(x => x.GetAll());
            obtido.First().Should().Be(_aposta);
        }

        [Test]
        public void ApostaService_GetAllTest_ShouldBeFail()
        {
            List<Aposta> list = new List<Aposta>();
            list.Add(new Aposta { Id = 0 });
            _mock.Setup(x => x.GetAll()).Returns(list);


            Action action = () => Alvo.GetAll();
            action.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void ApostaService_GetById_ShouldBeOK()
        {

            _mock.Setup(x => x.GetById(_aposta.Id)).Returns(_aposta);

            var obtido = Alvo.GetById(_aposta.Id);

            _mock.Verify(x => x.GetById(_aposta.Id));
            _aposta.Should().Be(obtido);
        }

        [Test]
        public void ApostaService_GetByIdPastId0_ShouldBeFail()
        {
            _aposta.Id = 0;
            _mock.Setup(x => x.GetById(_aposta.Id)).Returns(_aposta);


            Action action = () => Alvo.GetById(_aposta.Id);
            action.Should().Throw<IdentifierUndefinedException>();
            _mock.VerifyNoOtherCalls();

        }

        [Test]
        public void ApostaService_GetByIdTakeId0_ShouldBeFail()
        {
            _mock.Setup(x => x.GetById(_aposta.Id)).Returns(new Aposta { Id = 0 });


            Action action = () => Alvo.GetById(_aposta.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void ApostaService_UpdateTest_ShouldBeOK()
        {
            _mock.Setup(x => x.Update(_aposta)).Returns(new Aposta() { Id = 1 });

            var obtido = Alvo.Update(_aposta);

            _mock.Verify(x => x.Update(_aposta));
            obtido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void ApostaService_UpdateTest_ShouldBeFail()
        {
            _aposta.Id = 0;
            _mock.Setup(x => x.Update(_aposta)).Returns(new Aposta() { Id = 1 });

            Action action = () => Alvo.Update(_aposta);
            action.Should().Throw<IdentifierUndefinedException>();
            _mock.VerifyNoOtherCalls();
        }
    }
}
