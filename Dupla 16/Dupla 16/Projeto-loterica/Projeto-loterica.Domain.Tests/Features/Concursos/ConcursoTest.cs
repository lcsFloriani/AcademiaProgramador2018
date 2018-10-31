using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Boloes;
using Projeto_loterica.Domain.Features.Concursos;
using Projeto_loterica.Domain.Features.Enums;
using Projeto_loterica.Domain.Features.Resultados;
using System;
using System.Collections.Generic;
namespace Projeto_loterica.Domain.Tests.Features.Concursos
{
    [TestFixture]
    public class ConcursoTest
    {
        Mock<Estatisticas> estatisticas;
        Mock<Bolao> bolao;
        Mock<Aposta> aposta;
        Mock<Vencedor> vencedor;
        Mock<Resultado> resultado;
        Concurso concurso;
        [SetUp]
        public void set() {
            estatisticas = new Mock<Estatisticas>();
            concurso = new Concurso(estatisticas.Object);
            vencedor = new Mock<Vencedor>();
            estatisticas.Object.Quadra = vencedor.Object;
            estatisticas.Object.Quina = vencedor.Object;
            estatisticas.Object.Mega = vencedor.Object;
            aposta = new Mock<Aposta>();
        }
        [Test]
        public void Test_criar_concurso_should_beOk() {
            concurso = new Concurso();
            concurso.DataConcurso = DateTime.Now.AddDays(5);
            concurso.Validar();
        }

        [Test]
        public void Test_CalcularGanhosInvalidos_Should_BeFail()
        {
            var list = new List<Aposta>();
            list.Add(new Aposta() { Resultado = (Vencedora)19, ValorPago = 2 });
            concurso.CalcularGanhosApostas(list);
        }
        [Test]
        public void Test_criar_concurso_should_beFail()
        {
            concurso = new Concurso();
            concurso.DataConcurso = DateTime.Now.AddDays(-5);
            Action teste = () =>concurso.Validar();
            teste.Should().Throw<DataConcursoInvalidaException>();
        }

        [Test]
        public void Test_Method_GerarValorPremio_BeOk()
        {
            aposta.Object.ValorPago = 10;
            concurso.Apostas.Add(aposta.Object);
            concurso.Apostas.Add(aposta.Object);
            var test = concurso.GerarValorPremio();
            test.Should().Be(18);
        }
        [Test]
        public void Test_Method_Verificar_Resultado_da_Aposta_Should_BeOk() {
            for (int i = 0; i < 6; i++)
            {
                aposta.Object.Numeros.Add(i+1);
            }
            concurso.resultado = (Resultado)"1,2,3,4,5,6";
            int test = concurso.VerificarResultadoDaAposta(aposta.Object);
            test.Should().Be(6);
        }
        [Test]
        public void Test_Calcular_Media_Do_Premia_Da_Quadra_should_BeOk() {
            concurso.ValorPremioTotal = 10;
            concurso.Estatistica.Quadra.porcentagem = 0.1;
            concurso.Estatistica.Quadra.QuantidadeGanhadores = 1;
            double test = concurso.CalcularMediaDoPremiaDaQuadra();
            test.Should().Be(1);
        }
        [Test]
        public void Test_Calcular_Media_Do_Premia_Da_Quina_should_BeOk()
        {
            concurso.ValorPremioTotal = 10;
            concurso.Estatistica.Quina.porcentagem = 0.1;
            concurso.Estatistica.Quina.QuantidadeGanhadores = 1;
            double test = concurso.CalcularMediaDoPremioDaQuina();
            test.Should().Be(1);
        }
        [Test]
        public void Test_Calcular_Media_Do_Premia_Da_Mega_should_BeOk()
        {
            concurso.ValorPremioTotal = 10;
            concurso.Estatistica.Mega.porcentagem = 0.1;
            concurso.Estatistica.Mega.QuantidadeGanhadores = 1;
            double test = concurso.CalcularMediaDoPremiaDaMega();
            test.Should().Be(1);
        }
        [Test]
        public void Test_Calcular_Media_Do_Premia_Da_Quadra_Sem_Vencendor_should_BeOk()
        {
            concurso.Estatistica.Quadra.QuantidadeGanhadores = 0;
            double test = concurso.CalcularMediaDoPremiaDaQuadra();
            test.Should().Be(0);
        }
        [Test]
        public void Test_Calcular_Media_Do_Premia_Da_Quina_Sem_Vencendor_should_BeOk()
        {
            concurso.Estatistica.Quina.QuantidadeGanhadores = 0;
            double test = concurso.CalcularMediaDoPremioDaQuina();
            test.Should().Be(0);
        }
        [Test]
        public void Test_Calcular_Media_Do_Premia_Da_Mega_Sem_Vencendor_should_BeOk()
        {
            concurso.Estatistica.Mega.QuantidadeGanhadores = 0;
            double test = concurso.CalcularMediaDoPremiaDaMega();
            test.Should().Be(0);
        }
        [Test]
        public void Test_Valor_Ganha_Da_Loteria_Calcular() {
            
            aposta.Object.ValorPago = 10;
            concurso.Apostas.Add(aposta.Object);
            concurso.Apostas.Add(aposta.Object);
            var test = concurso.ValorGanhaDaLoteriaCalcular();
            test.Should().Be(2);
        }
    }
}
