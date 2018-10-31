using ProjetoLoterica.Dominio.Features.Apostas;
using System;
using System.Collections.Generic;

namespace ProjetoLoterica.Dominio.Features.Concursos
{
    public class Concurso
    {
        public long Id { get; set; }
        public long Numero { get; set; }
        public DateTime Data { get; set; }
        public double Premio { get; set; }
        public double PremioSena { get; set; }
        public double PremioQuina { get; set; }
        public double PremioQuadra { get; set; }
        public double LucroLoterica { get; set; }
        public int Ganhadores_Quadra { get; set; }
        public int Ganhadores_Quina { get; set; }
        public int Ganhadores_Sena { get; set; }
        public double PremioGanhadoresQuadra { get; set; }
        public double PremioGanhadoresQuina { get; set; }
        public double PremioGanhadoresSena { get; set; }
        public bool Situacao { get; set; }
        public List<int> Dezenas = new List<int>();
        public List<Aposta> Apostas = new List<Aposta>();
        
        public Concurso()
        {
            LucroLoterica = 0;
            Situacao = true;
        }

        public void Validar()
        {
            if (Numero <= 0)
                throw new ConcursoNumeroException();
            if (Premio < 0)
                throw new ConcursoPremioException();
            if (Data < DateTime.Now)
                throw new ConcursoDataException();
            if (Dezenas.Count < 6)
                throw new ConcursoDezenaException();
        }

        public void CalcularPremio()
        {
            foreach (var aposta in Apostas)
            {
                if (aposta.Bolao == null)
                    Premio += aposta.Valor;
                else
                    Premio += aposta.Valor - (aposta.Valor * 0.05);                
            }

            LucroLoterica += Premio * 0.10;
            Premio -= LucroLoterica;
        }

        public void CalcularPremioQuadra()
        {
            PremioQuadra = Premio * 0.10;
        }

        public void CalcularPremioQuina()
        {
            if (GanhadoresQuadra() > 0)
                PremioQuina = Premio * 0.20;
            else
                PremioQuina = Premio * 0.25;
        }

        public void CalcularPremioSena()
        {
            if (GanhadoresQuadra() > 0 && GanhadoresQuina() > 0)
                PremioSena = Premio * 0.70;
            else if (GanhadoresQuadra() == 0 && GanhadoresQuina() > 0)
                PremioSena = Premio * 0.75;
            else if (GanhadoresQuadra() > 0 && GanhadoresQuina() == 0)
                PremioSena = Premio * 0.90;
            else
                PremioSena = Premio;
        }

        public string RelacaoPremioQuadraGanhadores()
        {
            if (GanhadoresQuadra() == 0)
                return "Não houve acertador";
            else
                return String.Format("Quadra: {0} Apostas ganhadoras, R$ {1}",
                    GanhadoresQuadra(), (PremioQuadra / GanhadoresQuadra()));
        }

        public string RelacaoPremioQuinaGanhadores()
        {
            if (GanhadoresQuina() == 0)
                return "Não houve acertador";
            else
                return String.Format("Quina: {0} Apostas ganhadoras, R$ {1}",
                    GanhadoresQuina(), (PremioQuina / GanhadoresQuina()));
        }

        public string RelacaoPremioMegaGanhadores()
        {
            if (GanhadoresMega() == 0)
                return "Não houve acertador";
            else
                return String.Format("Sena: {0} Apostas ganhadoras, R$ {1}",
                    GanhadoresMega(), (PremioSena / GanhadoresMega()));
        }

        private int GanhadoresMega()
        {
            int countDezenasAcertadas = 0;
            int countGanhadoresMega = 0;
            foreach (var aposta in Apostas)
            {
                countDezenasAcertadas = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (aposta.Dezenas.Contains(Dezenas[i]))
                        countDezenasAcertadas++;
                }
                if (countDezenasAcertadas == 6)
                    countGanhadoresMega++;
            }
            Ganhadores_Sena = countGanhadoresMega;
            return countGanhadoresMega;
        }

        private int GanhadoresQuina()
        {
            int countDezenasAcertadas = 0;
            int countGanhadoresQuina = 0;

            foreach (var aposta in Apostas)
            {
                countDezenasAcertadas = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (aposta.Dezenas.Contains(Dezenas[i]))
                        countDezenasAcertadas++;
                }
                if (countDezenasAcertadas == 5)
                    countGanhadoresQuina++;
            }

            Ganhadores_Quina = countGanhadoresQuina;
            return countGanhadoresQuina;
        }
        
        private int GanhadoresQuadra()
        {
            int countDezenasAcertadas = 0;
            int countGanhadoresQuadra = 0;

            foreach (var aposta in Apostas)
            {
                countDezenasAcertadas = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (aposta.Dezenas.Contains(Dezenas[i]))
                        countDezenasAcertadas++;
                }
                if (countDezenasAcertadas == 4)
                    countGanhadoresQuadra++;
            }

            Ganhadores_Quadra = countGanhadoresQuadra;
            return countGanhadoresQuadra;
        }

        public void DezenasVencedoras(Random rnd)
        {
            for (int i = Dezenas.Count; i < 6; i++)
            {
                int rand = rnd.Next(1, 60);
                if (Dezenas.Contains(rand))
                    i--;
                else
                    Dezenas.Add(rand);
            }
        }

        public string LucroDaLoterica()
        {
            return String.Format("O lucro da loterica sobre esse concurso foi R$ {0}", LucroLoterica);
        }

        public void FazerAposta(Aposta aposta)
        {
            if (Situacao)
                Apostas.Add(aposta);
            else
                throw new ConcursoFechadoException();
        }

        public void Fechar()
        {
            Situacao = false;
            CalcularPremio();

            Random rnd = new Random();
            DezenasVencedoras(rnd);

            GanhadoresMega();
            GanhadoresQuadra();
            GanhadoresQuina();

            CalcularPremioSena();
            CalcularPremioQuadra();
            CalcularPremioQuina();

            if (Ganhadores_Quadra == 0)
                PremioGanhadoresQuadra = 0;
            else
                PremioGanhadoresQuadra = (PremioQuadra / Ganhadores_Quadra);

            if (Ganhadores_Quina == 0)
                PremioGanhadoresQuina = 0;
            else
                PremioGanhadoresQuina = (PremioQuina / Ganhadores_Quina);

            if (Ganhadores_Sena == 0)
                PremioGanhadoresSena = 0;
            else
                PremioGanhadoresSena = (PremioSena / Ganhadores_Sena);
        }
    }
}
