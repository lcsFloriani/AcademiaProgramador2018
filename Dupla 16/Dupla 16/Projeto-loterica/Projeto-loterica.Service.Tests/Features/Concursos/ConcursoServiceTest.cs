using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_loterica.Application.Features.Concursos;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_loterica.Service.Tests.Features.Concursos
{
    [TestFixture]
    public class ConcursoServiceTest
    {
        private ConcursoService Alvo;

        private Mock<IConcursoRepository> _mock;


        Concurso _Concurso;

        [SetUp]
        public void BolaoService_Set()
        {
            _mock = new Mock<IConcursoRepository>();
            Alvo = new ConcursoService(_mock.Object);
            _Concurso = ObjectMother.ConcursoValido;
        }

        [Test]
        public void BolaoService_AddTest_Should_BeOk()
        {
            _mock.Setup(x => x.Add(_Concurso)).Returns(new Concurso(new Estatisticas(new Vencedor(), new Vencedor(), new Vencedor())) { Id = 1 });

            var obtido = Alvo.Add(_Concurso);

            obtido.Id.Should().BeGreaterThan(0);

        }

        [Test]
        public void BolaoService_AddTest_Should_BeFail_DataInvalida()
        {
            _Concurso = ObjectMother.ConcursoInvalido;

            Action action = () => Alvo.Add(_Concurso);
            action.Should().Throw<DataConcursoInvalidaException>();
            _mock.VerifyNoOtherCalls();

        }

        [Test]
        public void BolaoService_DeleteTest_Should_BeOK()
        {

            _mock.Setup(x => x.Delete(_Concurso));

            Alvo.Delete(_Concurso);

            _mock.Verify(x => x.Delete(_Concurso));
        }

        [Test]
        public void BolaoService_DeleteTest_Should_BeFail()
        {
            _Concurso.Id = 0;
            _mock.Setup(x => x.Delete(_Concurso));

            Action action = () => Alvo.Delete(_Concurso);
            action.Should().Throw<IdentifierUndefinedException>();
            _mock.VerifyNoOtherCalls();
        }

        [Test]
        public void BolaoService_GetAllTest_ShouldBeOK()
        {
            _mock.Setup(x => x.GetAll()).Returns(new List<Concurso>() {
               _Concurso
            });

            var obtido = Alvo.GetAll();
            _mock.Verify(x => x.GetAll());
            obtido.First().Should().Be(_Concurso);
        }

        [Test]
        public void BolaoService_GetAllTest_ShouldBeFail()
        {
            List<Concurso> list = new List<Concurso>();
            list.Add(new Concurso (new Estatisticas(new Vencedor(), new Vencedor(), new Vencedor())) { Id = 0 });
            _mock.Setup(x => x.GetAll()).Returns(list);


            Action action = () => Alvo.GetAll();
            action.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void BolaoService_GetById_ShouldBeOK()
        {

            _mock.Setup(x => x.GetById(_Concurso.Id)).Returns(_Concurso);

            var obtido = Alvo.GetById(_Concurso.Id);

            _mock.Verify(x => x.GetById(_Concurso.Id));
            _Concurso.Should().Be(obtido);
        }

        [Test]
        public void BolaoService_GetByIdPastId0_ShouldBeFail()
        {
            _Concurso.Id = 0;
            _mock.Setup(x => x.GetById(_Concurso.Id)).Returns(_Concurso);


            Action action = () => Alvo.GetById(_Concurso.Id);
            action.Should().Throw<IdentifierUndefinedException>();
            _mock.VerifyNoOtherCalls();
        }

        [Test]
        public void BolaoService_GetByIdTakeId0_ShouldBeFail()
        {
            _mock.Setup(x => x.GetById(_Concurso.Id)).Returns(new Concurso(new Estatisticas(new Vencedor(), new Vencedor(), new Vencedor())) { Id = 0 });


            Action action = () => Alvo.GetById(_Concurso.Id);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void BolaoService_UpdateTest_ShouldBeOK()
        {
            _mock.Setup(x => x.Update(_Concurso)).Returns(new Concurso(new Estatisticas(new Vencedor(), new Vencedor(), new Vencedor())) { Id = 1 });

            var obtido = Alvo.Update(_Concurso);

            _mock.Verify(x => x.Update(_Concurso));
            obtido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void BolaoService_UpdateTest_Wrong_Id_ShouldBeFail()
        {
            _Concurso.Id = 0;
            _mock.Setup(x => x.Update(_Concurso)).Returns(new Concurso(new Estatisticas(new Vencedor(), new Vencedor(), new Vencedor())) { Id = 1 });

            Action action = () => Alvo.Update(_Concurso);
            action.Should().Throw<IdentifierUndefinedException>();
            _mock.VerifyNoOtherCalls();
        }

        [Test]
        public void BolaoService_GerarResultadoTest_ShouldBeOK()
        {
            Mock<Concurso> _mockConcurso = new Mock<Concurso>();
            var r = new Random();
            
            _mockConcurso.Setup(x => x.GerarResultado(It.IsAny<Random>()));

            Alvo.GerarResultado(_mockConcurso.Object);

            _mockConcurso.Verify(x => x.GerarResultado(It.IsAny<Random>()));
            
        }

    }
}
