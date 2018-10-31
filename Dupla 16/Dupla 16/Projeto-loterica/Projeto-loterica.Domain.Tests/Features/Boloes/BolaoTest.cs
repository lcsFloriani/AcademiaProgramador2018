using FluentAssertions;
using NUnit.Framework;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Boloes;
using Projeto_loterica.Domain.Features.Concursos;
using System;

namespace Projeto_loterica.Domain.Tests.Features.Boloes
{
    [TestFixture]
    public class BolaoTest
    {
        Bolao bolao;
        Aposta aposta;
        Concurso concurso;
        [SetUp]
        public void setTime()
        {
            bolao = ObjectMother.BolãoValido;
            aposta = ObjectMother.apostaValida;
            concurso = ObjectMother.ConcursoValido;
        }

        [Test]
        public void Test_Bolao_valido_Be_Ok()
        {
            bolao.Apostas.Add(aposta);
            bolao.validar();
            bolao.Apostas.Count.Should().BeGreaterThan(0);

        }

        [Test]
        public void Test_Bolao_Invalido_Be_Ok()
        {
            bolao.Apostas.Clear();
            Action comparison = bolao.validar;
            comparison.Should().Throw<BolaoSemApostaException>();

        }

        [Test]
        public void Test_Bolao_custoTotal_Valido_BeOk()
        {
            bolao.Apostas.Add(aposta);
            bolao.CalcularCustoTotal();
            bolao.custoTotal.Should().Be(21.0);
        }

        [Test]
        public void Test_Bolao_ganho_Valido_BeOk()
        {
            aposta.ValorRecebido = 1;
            bolao.Apostas.Add(aposta);
            bolao.CalcularGanho();
            bolao.ganho.Should().Be(aposta.ValorRecebido);
        }
        [Test]
        public void Test_Bolao_GerarBolaoAleatorio_BeOk()
        {
            bolao.GerarBolaoAleatorio(2,3);
            bolao.Apostas.Count.Should().BeGreaterThan(0);
        }
    }
}
