
using ProjetoLoterica.Dominio.Features.Apostas;
using ProjetoLoterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;

namespace ProjetoLoterica.Dominio.Features.Boloes
{
    public class Bolao
    {
        public long Id { get; set; }
        public int Numero { get; set; }

        public void Validar()
        {
            if (Numero <= 0)
                throw new BolaoNumeroExeption();
        }

        public List<Aposta> GerarApostas(Concurso concurso, int numeroApostas)
        {
            List<Aposta> apostasAleatorias = new List<Aposta>();
            Random rnd = new Random();
            for (int i = 0; i < numeroApostas; i++)
            {
                var aposta = new Aposta(Id)
                {
                    Concurso = concurso,
                    Data = DateTime.Now,
                    Dezenas = DezenasAleatorias(rnd),
                    Valor = 3.50
                };
                apostasAleatorias.Add(aposta);
            }
            return apostasAleatorias;
        }

        public List<int> DezenasAleatorias(Random rnd)
        {
            List<int> dezenas = new List<int>();

            for (int i = dezenas.Count; i < 6; i++)
            {
                int rand = rnd.Next(1, 61);
                if (dezenas.Contains(rand))
                    i--;
                else
                    dezenas.Add(rand);
            }

            return dezenas;
        }
    }
}
