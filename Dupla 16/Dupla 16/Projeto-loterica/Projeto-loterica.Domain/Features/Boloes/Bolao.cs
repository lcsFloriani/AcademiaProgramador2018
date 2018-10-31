using Projeto_loterica.Domain.Entidades;
using Projeto_loterica.Domain.Enums;
using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Domain.Features.Boloes
{
    public class Bolao : Entidade
    {
        public List<Aposta> Apostas { get; set; }
        
        public double custoTotal { get; set; }

        public void CalcularCustoTotal()
        {
            double custo = 0;
            foreach (var item in Apostas)
            {
                custo += item.ValorPago;
            }
            custo += custo * 0.05;
            custoTotal = custo;
        }

        public double ganho {get; set;}

        public void CalcularGanho()
        {
            double ganha = 0;
            foreach (var item in Apostas)
            {
                ganha += item.ValorRecebido;
            }
            ganho = ganha;
        }

        public Bolao()
        {
            Apostas = new List<Aposta>();
        }
        public void validar()
        {
            if (Apostas.Count < 1)
                throw new BolaoSemApostaException();
        }
        
        public void GerarBolaoAleatorio(int QuantidadeDeApostas, int ValorDeCadaAposta) {
            List<Aposta> list = new List<Aposta>();
            for (int i = 0; i < QuantidadeDeApostas; i++)
               list.Add(NovaAposta(ValorDeCadaAposta, new Random()));

            Apostas = list;
        }

        private Aposta NovaAposta(int ValorDeCadaAposta, Random r)
        {
            var aposta = new Aposta();
            aposta.ValorPago = ValorDeCadaAposta;
            for (int x = 0; x < 6; x++)
            {
                aposta.Numeros.Add(r.Next((int)ValorMinMaxAposta.Min,
                    (int)ValorMinMaxAposta.Max));
            }
            return aposta;
        }
    }
}
