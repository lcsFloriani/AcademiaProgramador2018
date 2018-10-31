using Projeto_loterica.Domain.Features.Concursos;
using Projeto_loterica.Domain.Features.Resultados;
using System;

namespace Projeto_loterica.Common.Tests.Features.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static Concurso ConcursoValido
        {
            get
            {
                var concurso = new Concurso(new Estatisticas(new Vencedor(), new Vencedor(), new Vencedor()));
                concurso.Id = 1;
                concurso.DataConcurso = DateTime.Now.AddDays(2);
                concurso.resultado = (Resultado)"1,2,3,4,5,6";

                return concurso;
            }
        }
        public static Concurso ConcursoInvalido
        {
            get
            {
                var concurso = new Concurso(new Estatisticas(new Vencedor(), new Vencedor(), new Vencedor()));
                concurso.Id = 1;
                concurso.DataConcurso = DateTime.Now.AddDays(-2);
                return concurso;
            }
        }
    }
}
