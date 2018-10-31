using Projeto_loterica.Domain.Entidades;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Boloes;
using Projeto_loterica.Domain.Features.Enums;
using Projeto_loterica.Domain.Features.Resultados;
using System;
using System.Collections.Generic;

namespace Projeto_loterica.Domain.Features.Concursos
{
    public class Concurso : Entidade
    {
        public List<Bolao> Boloes { get; set; }
        public List<Aposta> Apostas { get; set; }
        public double ValorPremioTotal { get; set; }
        public double ValorGanhoLoteria { get; set; }
        public DateTime DataConcurso { get; set; }
        public Resultado resultado { get; set; }
        public Estatisticas Estatistica { get; set; }

        public Concurso()
        {
            Boloes = new List<Bolao>();
            Apostas = new List<Aposta>();
        }
        public Concurso(Estatisticas estatisticas)
        {
            Boloes = new List<Bolao>();
            Apostas = new List<Aposta>();
            Estatistica = estatisticas;
        }


        public double GerarValorPremio()
        {
            var custo = CalcularTodosOsValoresPagos();
            custo -= custo * 0.1;
            return custo;
        }

        public virtual void GerarResultado(Random r)
        {
            resultado = new Resultado(r);
            ValorPremioTotal = GerarValorPremio();
            ValorGanhoLoteria = ValorGanhaDaLoteriaCalcular();
            CalcularGanhos();
        }

        public void VerificarResultadoApostas()
        {
            foreach (var item in Apostas)
            {
                VerificarVencedor(VerificarResultadoDaAposta(item), item);
            }
        }
        public void VerificarResultadoBolao()
        {
            foreach (var item in Boloes)
            {
                foreach (var aposta in item.Apostas)
                {
                    VerificarVencedor(VerificarResultadoDaAposta(aposta), aposta);
                }
            }
        }
        public double ValorGanhaDaLoteriaCalcular()
        {
            return CalcularTodosOsValoresPagos() * 0.1;
        }

        public double CalcularMediaDoPremioDaQuina()
        {
            return Estatistica.Quadra.QuantidadeGanhadores > 0 ? (ValorPremioTotal * Estatistica.Quina.porcentagem) / Estatistica.Quina.QuantidadeGanhadores : 0;
        }
        public double CalcularMediaDoPremiaDaMega()
        {
            return Estatistica.Quadra.QuantidadeGanhadores > 0 ? (ValorPremioTotal * Estatistica.Mega.porcentagem) / Estatistica.Mega.QuantidadeGanhadores: 0;
        }
        public double CalcularMediaDoPremiaDaQuadra()
        {
            return Estatistica.Quadra.QuantidadeGanhadores > 0?  (ValorPremioTotal * Estatistica.Quadra.porcentagem) / Estatistica.Quadra.QuantidadeGanhadores : 0;
        }

        public int VerificarResultadoDaAposta(Aposta aposta)
        {
            int quantidadeDeNumerosSorteadas = 0;

            foreach (var numerosDosBilhetes in aposta.Numeros)
            {
                foreach (var numerosSortiados in resultado.numeros)
                {
                    if (numerosDosBilhetes.Valor == numerosSortiados.Valor)
                    {
                        quantidadeDeNumerosSorteadas++;
                    }
                }
            }
            return quantidadeDeNumerosSorteadas;
        }
        public void Validar()
        {
            if (DataConcurso.Date < DateTime.Now)
                throw new DataConcursoInvalidaException();
        }

        #region privateMethods
        public void CalcularGanhosApostas(List<Aposta> Apostas)
        {
            foreach (var item in Apostas)
            {
                switch (item.Resultado)
                {
                    case Enums.Vencedora.NaoSorteado:
                        item.ValorRecebido = 0;
                        break;
                    case Vencedora.Quadra:
                        item.ValorRecebido = Estatistica.Quadra.MediaDoPremio;
                        break;
                    case Vencedora.Quina:
                        item.ValorRecebido = Estatistica.Quina.MediaDoPremio;
                        break;
                    case Vencedora.Mega:
                        item.ValorRecebido = Estatistica.Mega.MediaDoPremio;
                        break;
                }
            }
        }
        private void setEstatisticasMediaPremiada()
        {
            Estatistica.Quadra.MediaDoPremio = CalcularMediaDoPremiaDaQuadra();
            Estatistica.Mega.MediaDoPremio = CalcularMediaDoPremiaDaMega();
            Estatistica.Quina.MediaDoPremio = CalcularMediaDoPremioDaQuina();
        }
        private double CalcularTodosOsValoresPagos()
        {
            double custo = 0;
            foreach (var item in Apostas)
            {
                custo += item.ValorPago;
            }
            foreach (var bolao in Boloes)
            {
                foreach (var aposta in bolao.Apostas)
                {
                    custo += aposta.ValorPago;
                }
            }

            return custo;
        }
        private void CalcularGanhoBoloes()
        {
            foreach (var item in Boloes)
            {
                CalcularGanhosApostas(item.Apostas);
                item.CalcularCustoTotal();
                item.CalcularGanho();
            }
        }
        private void CalcularQuantidadeGanhadoresApostas(List<Aposta> Apostas)
        {
            foreach (var item in Apostas)
            {
                switch (item.Resultado)
                {
                    case Enums.Vencedora.Quadra:
                        Estatistica.Quadra.QuantidadeGanhadores++;
                        break;
                    case Enums.Vencedora.Quina:
                        Estatistica.Quina.QuantidadeGanhadores++;
                        break;
                    case Enums.Vencedora.Mega:
                        Estatistica.Mega.QuantidadeGanhadores++;
                        break;
                }
            }
        }
        private void CalcularPorcentagensDosVencedores()
        {
            if (Estatistica.Mega.QuantidadeGanhadores > 0 || Estatistica.Quadra.QuantidadeGanhadores > 0 || Estatistica.Quina.QuantidadeGanhadores > 0)
            {
                if (Estatistica.Quadra.QuantidadeGanhadores > 0 && Estatistica.Quina.QuantidadeGanhadores > 0 && Estatistica.Mega.QuantidadeGanhadores > 0)
                {
                    Estatistica.Mega.porcentagem = 0.7;
                    Estatistica.Quina.porcentagem = 0.2;
                    Estatistica.Quadra.porcentagem = 0.1;
                }
                else if (Estatistica.Quadra.QuantidadeGanhadores > 0 && Estatistica.Quina.QuantidadeGanhadores > 0)
                {
                    Estatistica.Mega.porcentagem = 0;
                    Estatistica.Quina.porcentagem = 0.2;
                    Estatistica.Quadra.porcentagem = 0.1;
                }
                else if (Estatistica.Quadra.QuantidadeGanhadores > 0 && Estatistica.Mega.QuantidadeGanhadores > 0)
                {
                    Estatistica.Mega.porcentagem = 0.9;
                    Estatistica.Quina.porcentagem = 0;
                    Estatistica.Quadra.porcentagem = 0.1;
                }
                else if (Estatistica.Quina.QuantidadeGanhadores > 0 && Estatistica.Mega.QuantidadeGanhadores > 0)
                {
                    Estatistica.Mega.porcentagem = 0.75;
                    Estatistica.Quina.porcentagem = 0.25;
                    Estatistica.Quadra.porcentagem = 0;
                }
                else if (Estatistica.Quina.QuantidadeGanhadores > 0)
                {
                    Estatistica.Mega.porcentagem = 0;
                    Estatistica.Quina.porcentagem = 0.3;
                    Estatistica.Quadra.porcentagem = 0;
                }
                else if (Estatistica.Quadra.QuantidadeGanhadores > 0)
                {
                    Estatistica.Mega.porcentagem = 0;
                    Estatistica.Quina.porcentagem = 0;
                    Estatistica.Quadra.porcentagem = 0.1;
                }
                else
                {
                    Estatistica.Mega.porcentagem = 1;
                    Estatistica.Quina.porcentagem = 0;
                    Estatistica.Quadra.porcentagem = 0;
                }
            }
            else
            {
                Estatistica.Mega.porcentagem = 0;
                Estatistica.Quina.porcentagem = 0;
                Estatistica.Quadra.porcentagem = 0;
            }
        }

        private void CalcularQuantidadeGanhadoresDentroDoBolao()
        {
            foreach (var item in Boloes)
            {
                CalcularQuantidadeGanhadoresApostas(item.Apostas);
            }
        }
        private void CalcularGanhos()
        {
            VerificarResultadoApostas();
            VerificarResultadoBolao();

            CalcularQuantidadeGanhadoresApostas(Apostas);
            CalcularQuantidadeGanhadoresDentroDoBolao();

            CalcularPorcentagensDosVencedores();
            setEstatisticasMediaPremiada();

            CalcularGanhosApostas(Apostas);
            CalcularGanhoBoloes();
        }
        private static void VerificarVencedor(int quantidadeDeNumerosSortiados, Aposta aposta)
        {
            switch (quantidadeDeNumerosSortiados)
            {
                case 4:
                    aposta.Resultado = Vencedora.Quadra;
                    break;
                case 5:
                    aposta.Resultado = Vencedora.Quina;
                    break;
                case 6:
                    aposta.Resultado = Vencedora.Mega;
                    break;
                default:
                    aposta.Resultado = Vencedora.NaoSorteado;
                    break;
            }
        }
        #endregion
    }
}