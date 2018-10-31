using System;
using NUnit.Framework;
using FluentAssertions;
using ProjetoLoterica.Dominio.Features.Concursos;
using System.Collections.Generic;
using ProjetoLoterica.Common.Teste.Features.Concusos;
using ProjetoLoterica.Dominio.Features.Apostas;
using Moq;
using ProjetoLoterica.Dominio.Features.Boloes;

namespace ProjetoLoterica.Dominio.Teste.Features
{
    [TestFixture]
    public class ConcursoTeste
    {
        Mock<Random> _mockRandom;
        int _primeiroNumero;
        int _segundoNumero;
        int _numerosAleatorios;

        public ConcursoTeste()
        {
            _mockRandom = new Mock<Random>();

            _primeiroNumero = 1;
            _segundoNumero = 61;
            _numerosAleatorios = 30;
        }

        [Test]
        public void Test_Concurso_Validar_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Action action = () => concurso.Validar();
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Concurso_CalclularPremio_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Action action = () => concurso.CalcularPremio();
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Concurso_CalclularPremioBolaoValido_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Bolao> bolao = new Mock<Bolao>();
            bolao.Object.Id = 1;

            Mock<Aposta> aposta = new Mock<Aposta>();
            aposta.Object.Bolao = bolao.Object;

            concurso.FazerAposta(aposta.Object);

            Action action = () => concurso.CalcularPremio();
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Concurso_CalclularPremioBolaoNulo_ShouldBeOk()
        {
            Mock<Aposta> aposta = new Mock<Aposta>();

            var concurso = ConcursoObjectMother.CriaConcursoValido();
            concurso.FazerAposta(aposta.Object);

            Action action = () => concurso.CalcularPremio();
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Concurso_CalclularPremioQuadra_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Action action = () => concurso.CalcularPremioQuadra();
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Concurso_CalclularPremioQuina_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Action action = () => concurso.CalcularPremioQuina();
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Concurso_CalclularPremioQuinaGanhadorQuadra_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Aposta> aposta = new Mock<Aposta>();
            aposta.Object.Dezenas = new List<int> { 13, 23, 2, 4, 5, 6 };

            concurso.FazerAposta(aposta.Object);

            Action action = () => concurso.CalcularPremioQuina();
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Concurso_CalclularPremioSena_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Action action = () => concurso.CalcularPremioSena();
            action.Should().Equals(concurso.Premio);
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Concurso_CalclularPremioSenaGanhadorQuadra_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Aposta> aposta = new Mock<Aposta>();
            aposta.Object.Dezenas = new List<int> { 13, 23, 2, 4, 5, 6 };

            concurso.FazerAposta(aposta.Object);

            Action action = () => concurso.CalcularPremioSena();
            action.Should().Equals(concurso.Premio * 0.90);
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Concurso_CalclularPremioSenaGanhadorQuina_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Aposta> aposta = new Mock<Aposta>();
            aposta.Object.Dezenas = new List<int> { 13, 2, 3, 4, 5, 6 };

            concurso.FazerAposta(aposta.Object);

            Action action = () => concurso.CalcularPremioSena();
            action.Should().Equals(concurso.Premio * 0.75);
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Concurso_CalclularPremioSenaGanhadorQuadraQuina_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Aposta> aposta = new Mock<Aposta>();
            aposta.Object.Dezenas = new List<int> { 13, 23, 2, 4, 5, 6 };
            concurso.FazerAposta(aposta.Object);

            Mock<Aposta> aposta2 = new Mock<Aposta>();
            aposta2.Object.Dezenas = new List<int> { 13, 2, 3, 4, 5, 6 };
            concurso.FazerAposta(aposta2.Object);

            Action action = () => concurso.CalcularPremioSena();
            action.Should().Equals(concurso.Premio * 0.70);
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Test_Concurso_RelacaoPremioQuadraGanhadoresSemAcertador_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            string texto = concurso.RelacaoPremioQuadraGanhadores();
            texto.Should().Be("Não houve acertador");
        }

        [Test]
        public void Test_Concurso_RelacaoPremioQuinaGanhadoresSemAcertador_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            string texto = concurso.RelacaoPremioQuinaGanhadores();
            texto.Should().Be("Não houve acertador");
        }

        [Test]
        public void Test_Concurso_RelacaoPremioMegaGanhadoresSemAcertador_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Aposta> aposta = new Mock<Aposta>();
            aposta.Object.Dezenas = new List<int> { 13, 23, 2, 44, 55, 6 };

            concurso.FazerAposta(aposta.Object);

            string texto = concurso.RelacaoPremioMegaGanhadores();
            texto.Should().Be("Não houve acertador");
        }

        [Test]
        public void Test_Concurso_RelacaoPremioQuadraGanhadores_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Aposta> aposta = new Mock<Aposta>();
            aposta.Object.Dezenas = new List<int> { 13, 23, 2, 4, 5, 6 };

            concurso.FazerAposta(aposta.Object);

            string texto = concurso.RelacaoPremioQuadraGanhadores();
            texto.Should().Be("Quadra: 1 Apostas ganhadoras, R$ 10000");
        }

        [Test]
        public void Test_Concurso_RelacaoPremioQuinaGanhadores_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Aposta> aposta = new Mock<Aposta>();
            aposta.Object.Dezenas = new List<int> { 13, 2, 3, 4, 5, 6 };

            concurso.FazerAposta(aposta.Object);

            string texto = concurso.RelacaoPremioQuinaGanhadores();
            texto.Should().Be("Quina: 1 Apostas ganhadoras, R$ 20000");
        }

        [Test]
        public void Test_Concurso_RelacaoPremioMegaGanhadores_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Aposta> aposta = new Mock<Aposta>();
            aposta.Object.Dezenas = new List<int> { 1, 2, 3, 4, 5, 6 };

            concurso.FazerAposta(aposta.Object);

            string texto = concurso.RelacaoPremioMegaGanhadores();
            texto.Should().Be("Sena: 1 Apostas ganhadoras, R$ 30000");
        }

        [Test]
        public void Test_Concurso_RandomDezenasGanhadora_ShouldBeOk()
        {
            _mockRandom.Setup(rd => rd.Next(_primeiroNumero, _segundoNumero))
                .Returns(() => _numerosAleatorios++);

            var concurso = ConcursoObjectMother.CriaConcursoValido();
            concurso.DezenasVencedoras(_mockRandom.Object);

            concurso.Dezenas.Count.Should().Be(6);
        }

        [Test]
        public void Test_Concurso_Dezenas_ShoudBeOk()
        {
            _mockRandom.Setup(rd => rd.Next(_primeiroNumero, _segundoNumero))
                .Returns(() => _numerosAleatorios++);

            var concurso = ConcursoObjectMother.CriaConcursoValido();
            concurso.DezenasVencedoras(_mockRandom.Object);

            var numeros = new HashSet<int>(concurso.Dezenas);
            numeros.Should().HaveCount(6);
        }

        [Test]
        public void Test_Concurso_FecharGanhadorQuadra_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Aposta> aposta = new Mock<Aposta>();
            aposta.Object.Dezenas = new List<int> { 11, 22, 3, 4, 5, 6 };
            concurso.FazerAposta(aposta.Object);

            concurso.Fechar();

            concurso.PremioGanhadoresQuadra.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_Concurso_FecharGanhadorQuina_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Aposta> aposta = new Mock<Aposta>();
            aposta.Object.Dezenas = new List<int> { 11, 2, 3, 4, 5, 6 };
            concurso.FazerAposta(aposta.Object);

            concurso.Fechar();

            concurso.PremioGanhadoresQuina.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_Concurso_FecharGanhadorSena_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Aposta> aposta = new Mock<Aposta>();
            aposta.Object.Dezenas = new List<int> { 1, 2, 3, 4, 5, 6 };
            concurso.FazerAposta(aposta.Object);

            concurso.Fechar();

            concurso.PremioGanhadoresSena.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_Concurso_Dezenas_Repeat_ShoudBeFail()
        {
            //arrange
            _mockRandom.Setup(rd => rd.Next(1, 60))
                .Returns(() => _numerosAleatorios++);

            var concurso = ConcursoObjectMother.CriaConcursoValido();
            concurso.Dezenas = new List<int> { 30 };

            //action
            concurso.DezenasVencedoras(_mockRandom.Object);

            //verify
            var numeros = new HashSet<int>(concurso.Dezenas);
            numeros.Should().HaveCount(6);
        }

        [Test]
        public void Test_Concurso_ValidarNumero_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoNumeroInvalido();

            Action action = () => concurso.Validar();
            action.Should().Throw<ConcursoNumeroException>();
        }

        [Test]
        public void Test_Concurso_ValidarData_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoDataInvalida();

            Action action = () => concurso.Validar();
            action.Should().Throw<ConcursoDataException>();
        }

        [Test]
        public void Test_Concurso_ValidarDezenas_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoQuantidadeDezenasInvalidas();

            Action action = () => concurso.Validar();
            action.Should().Throw<ConcursoDezenaException>();
        }

        [Test]
        public void Test_Concurso_ValidarPremio_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoInvalidoPremioInvalido();

            Action action = () => concurso.Validar();
            action.Should().Throw<ConcursoPremioException>();
        }

        [Test]
        public void Test_Concurso_LucroLoterica_ShouldBeOk()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();

            Mock<Aposta> aposta = new Mock<Aposta>();

            concurso.FazerAposta(aposta.Object);
            concurso.CalcularPremio();

            concurso.LucroLoterica.Should().Be(6500);
            concurso.LucroDaLoterica().Should().Be("O lucro da loterica sobre esse concurso foi R$ 6500");
        }

        [Test]
        public void Test_Concurso_ConcursoFechado_ShouldFail()
        {
            var concurso = ConcursoObjectMother.CriaConcursoValido();
            concurso.Fechar();

            Mock<Aposta> aposta = new Mock<Aposta>();

            Action action = () => concurso.FazerAposta(aposta.Object);
            action.Should().Throw<ConcursoFechadoException>();
        }
    }
}
