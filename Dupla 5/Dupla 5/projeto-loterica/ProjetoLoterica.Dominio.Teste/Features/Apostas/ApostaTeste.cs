using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoterica.Common.Teste.Features.Apostas;
using ProjetoLoterica.Dominio.Features.Apostas;
using ProjetoLoterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;

namespace ProjetoLoterica.Dominio.Teste.Features
{
    [TestFixture]
    public class ApostaTeste
    {
        [Test]
        public void Test_Aposta_Validate_ShouldBeOk()
        {
            var aposta = ApostaObjectMother.CriaApostaValida();
            Action action = () => aposta.Validar();
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Aposta_ValidateApostaComBolao_ShouldBeOk()
        {
            long bolaoId = 1;

            var aposta = ApostaObjectMother.CriaApostaValidaComBolao(bolaoId);

            Action action = () => aposta.Validar();
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Aposta_VerificarApostaGanhadorQuadra_ShouldBeOk()
        {
            Mock<Concurso> concurso = new Mock<Concurso>();
            concurso.Object.Numero = 1678;
            concurso.Object.Dezenas = new List<int> {1, 2, 3, 4, 5, 6 };
            concurso.Object.PremioGanhadoresQuadra = 3500;
            concurso.Object.Fechar();

            var aposta = ApostaObjectMother.CriaApostaValida();
            aposta.Concurso = concurso.Object;
            aposta.Dezenas = new List<int> { 11, 22, 3, 4, 5, 6};

            aposta.VerificarAposta().Should().Equals(
                "Sua aposta ganhou R$ 3500 válido pela Quadra no concurso 1678.");
        }

        [Test]
        public void Test_Aposta_VerificarApostaGanhadorQuina_ShouldBeOk()
        {
            Mock<Concurso> concurso = new Mock<Concurso>();
            concurso.Object.Numero = 1678;
            concurso.Object.Dezenas = new List<int> { 1, 2, 3, 4, 5, 6 };
            concurso.Object.PremioGanhadoresQuadra = 30500;
            concurso.Object.Fechar();

            var aposta = ApostaObjectMother.CriaApostaValida();
            aposta.Concurso = concurso.Object;
            aposta.Dezenas = new List<int> { 11, 2, 3, 4, 5, 6 };

            aposta.VerificarAposta().Should().Equals(
                "Sua aposta ganhou R$ 30500 válido pela Quadra no concurso 1678.");
        }

        [Test]
        public void Test_Aposta_VerificarApostaGanhadorSena_ShouldBeOk()
        {
            Mock<Concurso> concurso = new Mock<Concurso>();
            concurso.Object.Numero = 1678;
            concurso.Object.Dezenas = new List<int> { 1, 2, 3, 4, 5, 6 };
            concurso.Object.PremioGanhadoresQuadra = 3500300;
            concurso.Object.Fechar();

            var aposta = ApostaObjectMother.CriaApostaValida();
            aposta.Concurso = concurso.Object;
            aposta.Dezenas = new List<int> { 1, 2, 3, 4, 5, 6 };

            aposta.VerificarAposta().Should().Equals(
                "Sua aposta ganhou R$ 3500300 válido pela Quadra no concurso 1678.");
        }

        [Test]
        public void Test_Aposta_VerificarApostaSemGanhador_ShouldBeOk()
        {
            Mock<Concurso> concurso = new Mock<Concurso>();
            concurso.Object.Numero = 1678;
            concurso.Object.Dezenas = new List<int> { 1, 2, 3, 4, 5, 6 };
            concurso.Object.Fechar();

            var aposta = ApostaObjectMother.CriaApostaValida();
            aposta.Concurso = concurso.Object;
            aposta.Dezenas = new List<int> { 11, 12, 13, 14, 15, 16 };

            aposta.VerificarAposta().Should().Equals(
                "Sua aposta não foi contemplada no concurso 1678.");
        }

        [Test]
        public void Test_Aposta_VerificarApostaConcursoAberto_ShouldBeOk()
        {
            Mock<Concurso> concurso = new Mock<Concurso>();
            concurso.Object.Numero = 1678;

            var aposta = ApostaObjectMother.CriaApostaValida();
            aposta.Concurso = concurso.Object;
            aposta.Dezenas = new List<int> { 11, 12, 13, 14, 15, 16 };

            aposta.VerificarAposta().Should().Equals(
                "Concurso 1678 ainda está aberto.");
        }

        [Test]
        public void Test_Aposta_ValidateData_ShouldBeFail()
        {
            var aposta = ApostaObjectMother.CriaApostaInvalidaDataInvalida();
            Action action = () => aposta.Validar();
            action.Should().Throw<ApostaDataException>();
        }

        [Test]
        public void Test_Aposta_ValidateValor_ShouldBeFail()
        {
            var aposta = ApostaObjectMother.CriaApostaInvalidaValorInvalido();
            Action action = () => aposta.Validar();
            action.Should().Throw<ApostaValorException>();
        }

        [Test]
        public void Test_Aposta_ValidateDezenas_ShouldBeFail()
        {
            var aposta = ApostaObjectMother.CriaApostaInvalidaDezenaInvalida();
            Action action = () => aposta.Validar();
            action.Should().Throw<ApostaDezenasException>();
        }

        [Test]
        public void Test_Aposta_ValidateConcruso_ShouldBeFail()
        {
            var aposta = ApostaObjectMother.CriaApostaInvalidaConcursoInvalido();
            Action action = () => aposta.Validar();
            action.Should().Throw<ApostaConcursoException>();
        }
    }
}
