using FlorianiProva.Comum.ObjetosMae.Alunos;
using FlorianiProva.Comum.ObjetosMae.Avaliacoes;
using FlorianiProva.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Comum.ObjetosMae.Resultados
{
    public static class ResultadoObjetoMae
    {
        public static Resultado ResultadoComNotaNegativa()
        {
            var avaliacao = AvaliacaoObjetoMae.AvaliacaoValida();
            var aluno = AlunoObjetoMae.AlunoValido();
            var nota = -10.00;
            var resultado = new Resultado(avaliacao, aluno, nota);
            return resultado;
        }
        public static Resultado ResultadoValido()
        {
            var avaliacao = AvaliacaoObjetoMae.AvaliacaoValida();
            var aluno = AlunoObjetoMae.AlunoValido();
            var nota = 10.00;
            var resultado = new Resultado(avaliacao, aluno, nota);
            resultado.Id = 1;
            return resultado;
        }
    }
}
