using ProjetoLoterica.Dominio.Features.Boloes;
using ProjetoLoterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;

namespace ProjetoLoterica.Dominio.Features.Apostas
{
    public class Aposta
    {
        public long Id { get; set; }
        public Concurso Concurso { get; set; }
        public Bolao Bolao { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public List<int> Dezenas = new List<int>();

        public Aposta()
        {

        }

        public Aposta(long bolaoId)
        {
            Bolao = new Bolao();
            Bolao.Id = bolaoId;
            Valor += (Valor * 0.05);
        }

        public void Validar()
        {
            if (Concurso == null)
                throw new ApostaConcursoException();
            if (Data < DateTime.Now)
                throw new ApostaDataException();
            if (Valor <= 0)
                throw new ApostaValorException();
            if (Dezenas.Count < 6)
                throw new ApostaDezenasException();
        }

        public string VerificarAposta()
        {
            int count = 0;
            if (Concurso.Situacao == false)
            {
                foreach (var dezena in Dezenas)
                {
                    if (Concurso.Dezenas.Contains(dezena))
                        count++;
                }

                if (count == 4)
                    return String.Format("Sua aposta ganhou R$ {0} válido pela Quadra no concurso {1}.",
                        Concurso.PremioGanhadoresQuadra, Concurso.Numero);
                else if (count == 5)
                    return String.Format("Sua aposta ganhou R$ {0} válido pela Quina no concurso {1}.",
                        Concurso.PremioGanhadoresQuina, Concurso.Numero);
                else if (count == 6)
                    return String.Format("Sua aposta ganhou R$ {0} válido pela Mega no concurso {1}.",
                        Concurso.PremioGanhadoresSena, Concurso.Numero);
                else
                    return String.Format("Sua aposta não foi contemplada no concurso {0}.", Concurso.Numero);
            }
            else
                return String.Format("Concurso {0} ainda está aberto.", Concurso.Numero);
        }
    }
}
