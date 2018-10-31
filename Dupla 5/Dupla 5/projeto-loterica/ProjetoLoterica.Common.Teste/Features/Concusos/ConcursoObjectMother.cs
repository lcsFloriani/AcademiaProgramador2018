using ProjetoLoterica.Common.Teste.Features.Apostas;
using ProjetoLoterica.Dominio.Features.Apostas;
using ProjetoLoterica.Dominio.Features.Boloes;
using ProjetoLoterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;

namespace ProjetoLoterica.Common.Teste.Features.Concusos
{
    public static class ConcursoObjectMother
    {
        public static Concurso CriaConcursoValido()
        {
            return new Concurso
            {
                Id = 2,
                Data = DateTime.Now.AddDays(2),
                Numero = 1000,
                Premio = 50000,
                PremioQuadra = 10000,
                PremioQuina = 20000,
                PremioSena = 30000,
                LucroLoterica = 1500,
                Dezenas = { 1, 2, 3, 4, 5, 6 },
            };
        }

        public static Concurso CriaConcursoInvalidoDataInvalida()
        {
            return new Concurso
            {
                Id = 2,
                Data = DateTime.Now.AddDays(-2),
                Numero = 1000,
                Premio = 50000,
                PremioQuadra = 10000,
                PremioQuina = 20000,
                PremioSena = 30000,
                LucroLoterica = 1500,
                Dezenas = { 1, 2, 3, 4, 5, 6 }
            };
        }

        public static Concurso CriaConcursoInvalidoNumeroInvalido()
        {
            return new Concurso
            {
                Id = 2,
                Data = DateTime.Now.AddDays(2),
                Numero = -1000,
                Premio = 50000,
                PremioQuadra = 10000,
                PremioQuina = 20000,
                PremioSena = 30000,
                LucroLoterica = 1500,
                Dezenas = { 1, 2, 3, 4, 5, 6 }
            };
        }

        public static Concurso CriaConcursoInvalidoPremioInvalido()
        {
            return new Concurso
            {
                Id = 2,
                Data = DateTime.Now.AddDays(2),
                Numero = 1000,
                Premio = -50000,
                PremioQuadra = 10000,
                PremioQuina = 20000,
                PremioSena = 30000,
                LucroLoterica = 1500,
                Dezenas = { 1, 2, 3, 4, 5, 6 }
               
            };
        }
        public static Concurso CriaConcursoInvalidoQuantidadeDezenasInvalidas()
        {
            return new Concurso
            {
                Id = 2,
                Data = DateTime.Now.AddDays(2),
                Numero = 1000,
                Premio = 50000,
                PremioQuadra = 10000,
                PremioQuina = 20000,
                PremioSena = 30000,
                LucroLoterica = 1500,
                Dezenas = { 4, 5, 6 }
            };
        }
    }
}
