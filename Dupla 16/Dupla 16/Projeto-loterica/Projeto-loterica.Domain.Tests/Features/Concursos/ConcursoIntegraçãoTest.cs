using FluentAssertions;
using NUnit.Framework;
using Projeto_loterica.Common.Tests.Features.ObjectMothers;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Boloes;
using Projeto_loterica.Domain.Features.Concursos;
using Projeto_loterica.Domain.Features.Enums;
using System;
using System.Collections.Generic;

namespace Projeto_loterica.Domain.Tests.Features.Concursos
{
    [TestFixture]
    public class ConcursoIntegraçãoTest
    {
        Concurso _concurso;
        Aposta mega = ObjectMother.apostaValidaMega;
        Aposta quina = ObjectMother.apostaValidaQuina;
        Aposta quadra = ObjectMother.apostaValidaQuadra;
        Aposta perdedor = ObjectMother.apostaValida;

        [SetUp]
        public void setTime()
        {
            _concurso = new Concurso(new Estatisticas(new Vencedor(), new Vencedor(), new Vencedor()));

        }
        [Test]
        public void ConcursoValidaSucess()
        {
            _concurso.Boloes.Add(new Bolao());
            _concurso.Apostas.Add(new Aposta());
            _concurso.DataConcurso = DateTime.Now.AddDays(5);
            _concurso.Validar();
        }

        [Test]
        public void Concurso_DataConcurso_Should_BeFail()
        {
            _concurso.DataConcurso = DateTime.Now;
            Action comparison = _concurso.Validar;
            comparison.Should().Throw<DataConcursoInvalidaException>();
        }

        [Test]
        public void Test_Resultado_Have_Mega_Quina_Quadra_Should_BeOk() {

            var bolao = ObjectMother.BolãoValido;
            bolao.Apostas.Add(mega);
            bolao.Apostas.Add(quadra);

            _concurso.Apostas.Add(mega);
            _concurso.Apostas.Add(quadra);
            _concurso.Apostas.Add(quina);
            _concurso.Apostas.Add(perdedor);
            
            _concurso.Boloes.Add(bolao);


            _concurso.GerarResultado(new FakeRandom());

            quadra.Resultado.Should().Be(Vencedora.Quadra);
            quina.Resultado.Should().Be(Vencedora.Quina);
            mega.Resultado.Should().Be(Vencedora.Mega);

            _concurso.Estatistica.Mega.QuantidadeGanhadores.Should().Be(2);
            _concurso.Estatistica.Quina.QuantidadeGanhadores.Should().Be(1);
            _concurso.Estatistica.Quadra.QuantidadeGanhadores.Should().Be(2);

            _concurso.ValorPremioTotal.Should().Be(63);

            mega.ValorRecebido.Should().Be(_concurso.Estatistica.Mega.MediaDoPremio);
            quadra.ValorRecebido.Should().Be(_concurso.Estatistica.Quadra.MediaDoPremio);
            quina.ValorRecebido.Should().Be(_concurso.Estatistica.Quina.MediaDoPremio);
            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(_concurso.Estatistica.Mega.MediaDoPremio + _concurso.Estatistica.Quadra.MediaDoPremio);
        }
        [Test]
        public void Test_Resultado_ApenasMega_Should_BeOk()
        {
            var mega = ObjectMother.apostaValidaMega;
            var perdedor = ObjectMother.apostaValida;

            var bolao = ObjectMother.BolãoValido;
            bolao.Apostas.Add(mega);
            
            _concurso.Apostas.Add(perdedor);


            _concurso.Boloes.Add(bolao);


            _concurso.GerarResultado(new FakeRandom());
            
            mega.Resultado.Should().Be(Vencedora.Mega);

            _concurso.ValorPremioTotal.Should().Be(27);

            mega.ValorRecebido.Should().Be(_concurso.Estatistica.Mega.MediaDoPremio);
            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(_concurso.Estatistica.Mega.MediaDoPremio);
        }
        [Test]
        public void Test_Resultado_ApenasQuina_Should_BeOk()
        {
            var quina = ObjectMother.apostaValidaQuina;
            var perdedor = ObjectMother.apostaValida;

            var bolao = ObjectMother.BolãoValido;
            bolao.Apostas.Add(quina);

            _concurso.Apostas.Add(quina);


            _concurso.Boloes.Add(bolao);


            _concurso.GerarResultado(new FakeRandom());

            quina.Resultado.Should().Be(Vencedora.Quina);

            _concurso.ValorPremioTotal.Should().Be(27);

            quina.ValorRecebido.Should().Be(_concurso.Estatistica.Quina.MediaDoPremio);
            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(_concurso.Estatistica.Quina.MediaDoPremio);
        }

        [Test]
        public void Test_Resultado_ApenasQuadra_Should_BeOk()
        {
            var perdedor = ObjectMother.apostaValida;

            var bolao = ObjectMother.BolãoValido;
            bolao.Apostas.Add(perdedor);

            _concurso.Apostas.Add(quadra);

            _concurso.Boloes.Add(bolao);


            _concurso.GerarResultado(new FakeRandom());

            perdedor.Resultado.Should().Be(Vencedora.NaoSorteado);

            _concurso.ValorPremioTotal.Should().Be(27);

            quadra.ValorRecebido.Should().Be(_concurso.Estatistica.Quadra.MediaDoPremio);
            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(0);
        }
        [Test]
        public void Test_Resultado_ValorPremioTotal_Should_BeOk()
        {
            var perdedor = ObjectMother.apostaValida;

            var bolao = ObjectMother.BolãoValido;
            
            _concurso.Apostas.Add(perdedor);

            double ValorPremioTotal = 0;
            foreach (var item in _concurso.Apostas)
            {
                ValorPremioTotal += item.ValorPago;
            }
            foreach (var item in bolao.Apostas)
            {
                ValorPremioTotal += item.ValorPago;
            }
            ValorPremioTotal -= (ValorPremioTotal*0.1);
            _concurso.Boloes.Add(bolao);
            
            _concurso.GerarResultado(new FakeRandom());

            perdedor.Resultado.Should().Be(Vencedora.NaoSorteado);

            _concurso.ValorPremioTotal.Should().Be(ValorPremioTotal);

            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(0);
        }

        [Test]
        public void Test_Resultado_ValorGanhoLoteria_Should_BeOk()
        {
            var perdedor = ObjectMother.apostaValida;

            var bolao = ObjectMother.BolãoValido;

            _concurso.Apostas.Add(perdedor);
            _concurso.Apostas.Add(perdedor);

            double valorRecebido = 0;
            foreach (var item in _concurso.Apostas)
            {
                valorRecebido += item.ValorPago;
            }
            foreach (var item in bolao.Apostas)
            {
                valorRecebido += item.ValorPago;
            }
            valorRecebido = (valorRecebido * 0.1);
            _concurso.Boloes.Add(bolao);

            _concurso.GerarResultado(new FakeRandom());

            perdedor.Resultado.Should().Be(Vencedora.NaoSorteado);

            _concurso.ValorGanhoLoteria.Should().Be(valorRecebido);

            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(0);
        }
        [Test]
        public void Test_Resultado_Mega_Quina_Should_BeOk()
        {
            var mega = ObjectMother.apostaValidaMega;
            var quina = ObjectMother.apostaValidaQuina;
            var perdedor = ObjectMother.apostaValida;

            var bolao = ObjectMother.BolãoValido;
            bolao.Apostas.Add(mega);

            _concurso.Apostas.Add(mega);
            _concurso.Apostas.Add(quina);
            _concurso.Apostas.Add(perdedor);
           

            _concurso.Boloes.Add(bolao);


            _concurso.GerarResultado(new FakeRandom());

            quina.Resultado.Should().Be(Vencedora.Quina);
            mega.Resultado.Should().Be(Vencedora.Mega);
            
            _concurso.ValorPremioTotal.Should().Be(45);

            mega.ValorRecebido.Should().Be(_concurso.Estatistica.Mega.MediaDoPremio);


            quina.ValorRecebido.Should().Be(_concurso.Estatistica.Quina.MediaDoPremio);

            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(_concurso.Estatistica.Mega.MediaDoPremio);
        }
        [Test]
        public void Test_Resultado_Quadra_Mega_Should_BeOk()
        {

            var bolao = ObjectMother.BolãoValido;
            bolao.Apostas.Add(mega);

            _concurso.Apostas.Add(mega);
            _concurso.Apostas.Add(quadra);


            _concurso.Boloes.Add(bolao);


            _concurso.GerarResultado(new FakeRandom());

            quadra.Resultado.Should().Be(Vencedora.Quadra);
            mega.Resultado.Should().Be(Vencedora.Mega);

            _concurso.ValorPremioTotal.Should().Be(36);

            quadra.ValorRecebido.Should().Be(_concurso.Estatistica.Quadra.MediaDoPremio);
            mega.ValorRecebido.Should().Be(_concurso.Estatistica.Mega.MediaDoPremio);

            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(_concurso.Estatistica.Mega.MediaDoPremio);
        }
        [Test]
        public void Test_Resultado_Quadra_Quina_Should_BeOk()
        {

            var bolao = ObjectMother.BolãoValido;
            bolao.Apostas.Add(quina);

            _concurso.Apostas.Add(quina);
            _concurso.Apostas.Add(quadra);


            _concurso.Boloes.Add(bolao);


            _concurso.GerarResultado(new FakeRandom());

            quadra.Resultado.Should().Be(Vencedora.Quadra);
            quina.Resultado.Should().Be(Vencedora.Quina);

            _concurso.ValorPremioTotal.Should().Be(36);

            quadra.ValorRecebido.Should().Be(_concurso.Estatistica.Quadra.MediaDoPremio);
            quina.ValorRecebido.Should().Be(_concurso.Estatistica.Quina.MediaDoPremio);

            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(_concurso.Estatistica.Quina.MediaDoPremio);
        }
        [Test]
        public void Test_Resultado_ApenasPerdedores_Should_BeOk()
        {
            var quadra = ObjectMother.apostaValidaQuadra;
            var perdedor = ObjectMother.apostaValida;

            var bolao = ObjectMother.BolãoValido;
            bolao.Apostas.Add(quadra);
            bolao.Apostas.Add(perdedor);
            bolao.Apostas.Add(perdedor);

            _concurso.Apostas.Add(quadra);


            _concurso.Boloes.Add(bolao);


            _concurso.GerarResultado(new FakeRandom());

            quadra.Resultado.Should().Be(Vencedora.Quadra);

            _concurso.ValorPremioTotal.Should().Be(45);

            quadra.ValorRecebido.Should().Be(_concurso.Estatistica.Quadra.MediaDoPremio);
            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(_concurso.Estatistica.Quadra.MediaDoPremio);
        }
        [Test]
        public void Test_CalcularGanhosInvalidos_Should_BeOk()
        {
            var list = new List<Aposta>();
            list.Add(new Aposta() { Resultado = (Vencedora)19, ValorPago = 2 });
            _concurso.CalcularGanhosApostas(list);
        }

        [Test]
        public void Test_Concurso_QuantidadeMega()
        {
            _concurso = ObjectMother.ConcursoValido;
            _concurso.Estatistica.Mega.MediaDoPremio.Should().Be(0);
        }

        [Test]
        public void Test_Concurso_QuantidadeQuina()
        {
            _concurso = ObjectMother.ConcursoValido;
            _concurso.Estatistica.Quina.MediaDoPremio.Should().Be(0);
        }

        [Test]
        public void Test_Concurso_QuantidadeQuadra()
        {
            _concurso = ObjectMother.ConcursoValido;
            _concurso.Estatistica.Quadra.MediaDoPremio.Should().Be(0);
        }

        [Test]
        public void Test_Resultado_premioMega_valido_Should_BeOk()
        {

            var bolao = ObjectMother.BolãoValido;

            _concurso.Apostas.Add(mega);
            _concurso.Apostas.Add(perdedor);
            
            _concurso.Boloes.Add(bolao);

            _concurso.GerarResultado(new FakeRandom());

            perdedor.Resultado.Should().Be(Vencedora.NaoSorteado);
            _concurso.Estatistica.Mega.MediaDoPremio.Should().Be(mega.ValorRecebido);
           
            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(0);
        }

        [Test]
        public void Test_Resultado_premioQuina_valido_Should_BeOk()
        {

            var bolao = ObjectMother.BolãoValido;

            _concurso.Apostas.Add(quina);
            _concurso.Apostas.Add(perdedor);

            _concurso.Boloes.Add(bolao);

            _concurso.GerarResultado(new FakeRandom());

            perdedor.Resultado.Should().Be(Vencedora.NaoSorteado);
           
            _concurso.Estatistica.Quina.MediaDoPremio.Should().Be(quina.ValorRecebido);
           
            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(0);
        }

        [Test]
        public void Test_Resultado_premioQuadra_valido_Should_BeOk()
        {
            var bolao = ObjectMother.BolãoValido;

            _concurso.Apostas.Add(quadra);
            _concurso.Apostas.Add(perdedor);

            _concurso.Boloes.Add(bolao);

            _concurso.GerarResultado(new FakeRandom());

            perdedor.Resultado.Should().Be(Vencedora.NaoSorteado);
          
            _concurso.Estatistica.Quadra.MediaDoPremio.Should().Be(quadra.ValorRecebido);
            perdedor.ValorRecebido.Should().Be(0);

            bolao.ganho.Should().Be(0);
        }
        [Test]
        public void Concurso_Vencedora_PremioGanho_Should_BeOk()
        {
            var bolao = ObjectMother.BolãoValido;

            _concurso.Apostas.Add(quadra);
            _concurso.Apostas.Add(mega);
            _concurso.Apostas.Add(quina);

            _concurso.Boloes.Add(bolao);

            _concurso.GerarResultado(new FakeRandom());

            mega.ValorRecebido.Should().Be(_concurso.Estatistica.Mega.PremioGanho);
            quina.ValorRecebido.Should().Be(_concurso.Estatistica.Quina.PremioGanho);
            quadra.ValorRecebido.Should().Be(_concurso.Estatistica.Quadra.PremioGanho);
        }
    }
}