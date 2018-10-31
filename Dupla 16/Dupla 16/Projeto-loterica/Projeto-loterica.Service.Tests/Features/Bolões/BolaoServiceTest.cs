using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_loterica.Application.Features.Boloes;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Boloes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_loterica.Service.Tests.Features.Bolões
{
    [TestFixture]
    public class BolaoServiceTest
    {
        private BolaoService Alvo;

        private Mock<IBolaoRepository> _mock;

        Bolao _bolao;

        [SetUp]
        public void BolaoService_Set()
        {
            _mock = new Mock<IBolaoRepository>();
            Alvo = new BolaoService(_mock.Object);
            _bolao = ObjectMother.BolãoValido;
        }

        [Test]
        public void BolaoService_AddTest_Should_BeOk()
        {
            _mock.Setup(x => x.Add(_bolao)).Returns(new Bolao() { Id = 1 });

            var obtido = Alvo.Add(_bolao);

            obtido.Id.Should().BeGreaterThan(0);

        }

        [Test]
        public void BolaoService_AddTest_Should_BeFail_NãoContemApostas()
        {
            _bolao = ObjectMother.BolãoInvalido;

            Action action = () => Alvo.Add(_bolao);
            action.Should().Throw<BolaoSemApostaException>();
            _mock.VerifyNoOtherCalls();

        }

        [Test]
        public void BolaoService_DeleteTest_Should_BeOK()
        {

            _mock.Setup(x => x.Delete(_bolao));

            Alvo.Delete(_bolao);

            _mock.Verify(x => x.Delete(_bolao));
        }

        [Test]
        public void BolaoService_DeleteTest_Should_BeFail()
        {
            _bolao.Id = 0;
            _mock.Setup(x => x.Delete(_bolao));

            Action action = () => Alvo.Delete(_bolao);
            action.Should().Throw<IdentifierUndefinedException>();
            _mock.VerifyNoOtherCalls();
        }

        [Test]
        public void BolaoService_GetAllTest_ShouldBeOK()
        {

            _mock.Setup(x => x.GetAll()).Returns(new List<Bolao>() {
               _bolao
            });

            var obtido = Alvo.GetAll();
            _mock.Verify(x => x.GetAll());
            obtido.First().Should().Be(_bolao);
        }

        [Test]
        public void BolaoService_GetAllTest_ShouldBeFail()
        {
            List<Bolao> list = new List<Bolao>();
            list.Add(new Bolao { Id = 0 });
            _mock.Setup(x => x.GetAll()).Returns(list);


            Action action = () => Alvo.GetAll();
            action.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void BolaoService_GetById_ShouldBeOK()
        {

            _mock.Setup(x => x.GetById(_bolao.Id)).Returns(_bolao);

            var obtido = Alvo.GetById(_bolao.Id);

            _mock.Verify(x => x.GetById(_bolao.Id));
            _bolao.Should().Be(obtido);
        }

        [Test]
        public void BolaoService_GetByIdPastId0_ShouldBeFail()
        {
            _bolao.Id = 0;
            _mock.Setup(x => x.GetById(_bolao.Id)).Returns(_bolao);


            Action action = () => Alvo.GetById(_bolao.Id);
            action.Should().Throw<IdentifierUndefinedException>();
            _mock.VerifyNoOtherCalls();
        }

        [Test]
        public void BolaoService_GetByIdTakeId0_ShouldBeFail()
        {
            _mock.Setup(x => x.GetById(_bolao.Id)).Returns(new Bolao { Id = 0 });


            Action action = () => Alvo.GetById(_bolao.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void BolaoService_UpdateTest_ShouldBeOK()
        {
            _mock.Setup(x => x.Update(_bolao)).Returns(new Bolao() { Id = 1 });

            var obtido = Alvo.Update(_bolao);

            _mock.Verify(x => x.Update(_bolao));
            obtido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void BolaoService_UpdateTest_Wrong_Id_ShouldBeFail()
        {
            _bolao.Id = 0;
            _mock.Setup(x => x.Update(_bolao)).Returns(new Bolao() { Id = 1 });

            Action action = () => Alvo.Update(_bolao);
            action.Should().Throw<IdentifierUndefinedException>();
            _mock.VerifyNoOtherCalls();
        }
    }
}
