using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoterica.Common.Teste.Features.Bolões;
using ProjetoLoterica.Dominio.Features.Boloes;
using ProjetoLoterica.Dominio.Features.Concursos;
using System;

namespace ProjetoLoterica.Dominio.Teste.Features.Bolões
{
    [TestFixture]
    public class BolaoTeste
    {
        [Test]
        public void Test_Bolao_Validate_ShouldBeOk()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            Action action = () => bolao.Validar();
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Bolao_GerarApostas_ShouldBeOk()
        {
            var bolao = BolaoObjectMother.CriaBolaoValido();

            Mock<Concurso> concurso = new Mock<Concurso>();

            int numApostas = 10;

            Action action = () => bolao.GerarApostas(concurso.Object, numApostas);
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Bolao_DezenasAleatorias_ShouldBeOk()
        {
            int _numerosAleatorios = 30;

            var bolao = BolaoObjectMother.CriaBolaoValido();

            Mock<Random> _mockRandom = new Mock<Random>();
            _mockRandom.Setup(rd => rd.Next(1, 61))
                .Returns(() => _numerosAleatorios++);

            var dezenas = bolao.DezenasAleatorias(_mockRandom.Object);
            dezenas.Count.Should().Be(6);
        }

        [Test]
        public void Test_Bolao_ValidateNumeroNegativo_ShouldFail()
        {
            var bolao = BolaoObjectMother.CriaBolaoInvalidoNumeroInvalido();

            Action action = () => bolao.Validar();
            action.Should().Throw<BolaoNumeroExeption>();
        }
    }
}
