using ProjetoLoterica.Dominio.Features.Apostas;
using ProjetoLoterica.Dominio.Features.Boloes;
using ProjetoLoterica.Dominio.Features.Concursos;
using System;

namespace ProjetoLoterica.Common.Teste.Features.Apostas
{
    public static class ApostaObjectMother
    {
        public static Aposta CriaApostaValida()
        {
            return new Aposta
            {
                Id = 1,
                Concurso = new Concurso { Id = 1 },
                Bolao = new Bolao { Id = 1 },
                Data = DateTime.Now.AddDays(2),
                Valor = 3,
                Dezenas = { 1, 2, 3, 4, 5, 6 },
            };
        }

        public static Aposta CriaApostaValidaComBolao(long bolaoId)
        {
            return new Aposta(bolaoId)
            {
                Id = 1,
                Concurso = new Concurso { Id = 1 },
                Bolao = new Bolao { Id = bolaoId },
                Data = DateTime.Now.AddDays(2),
                Valor = 3,
                Dezenas = { 1, 2, 3, 4, 5, 6 },
            };
        }

        public static Aposta CriaApostaInvalidaIdInvalido()
        {
            return new Aposta
            {
                Id = -1,
                Concurso = new Concurso { Id = 1 },
                Bolao = new Bolao { Id = 1 },
                Data = DateTime.Now.AddDays(2),
                Valor = 3,
                Dezenas = { 1, 2, 3, 4, 5, 6 },
            };
        }

        public static Aposta CriaApostaInvalidaDataInvalida()
        {
            return new Aposta
            {
                Id = 1,
                Concurso = new Concurso { Id = 1 },
                Bolao = new Bolao { Id = 1 },
                Data = DateTime.Now.AddDays(-2),
                Valor = 3,
                Dezenas = { 1, 2, 3, 4, 5, 6 },
            };
        }

        public static Aposta CriaApostaInvalidaValorInvalido()
        {
            return new Aposta
            {
                Id = 1,
                Concurso = new Concurso { Id = 1 },
                Bolao = new Bolao { Id = 1 },
                Data = DateTime.Now.AddDays(2),
                Valor = 0,
                Dezenas = { 1, 2, 3, 4, 5, 6 },
            };
        }

        public static Aposta CriaApostaInvalidaDezenaInvalida()
        {
            return new Aposta
            {
                Id = 1,
                Concurso = new Concurso { Id = 1 },
                Bolao = new Bolao { Id = 1 },
                Data = DateTime.Now.AddDays(2),
                Valor = 3,
                Dezenas = { 4, 5, 6 },
            };
        }

        public static Aposta CriaApostaInvalidaConcursoInvalido()
        {
            return new Aposta
            {
                Id = 1,
                Concurso = null,
                Bolao = new Bolao { Id = 1 },
                Data = DateTime.Now.AddDays(1),
                Valor = 3,
                Dezenas = { 4, 5, 6 },
            };
        }
    }
}