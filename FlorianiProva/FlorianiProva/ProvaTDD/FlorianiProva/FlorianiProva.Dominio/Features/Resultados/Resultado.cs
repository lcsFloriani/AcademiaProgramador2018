using FlorianiProva.Dominio.Features.Alunos;
using FlorianiProva.Dominio.Features.Avaliações;
using FlorianiProva.Dominio.Features.Resultados.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Features.Resultados
{
    public class Resultado
    {
        public int Id { get; set; }
        public double Nota { get; set; }
        public Aluno Aluno { get; set; }
        public Avaliacao Avaliacao { get; set; }

        public Resultado(Avaliacao avaliacao, Aluno aluno, double nota)
        {
            Avaliacao = avaliacao;
            Aluno = aluno;
            Nota = nota;
        }
        public void Validar()
        {
            if (Nota < 0)
                throw new NotaMenorQueZeroException();
        }
    }
}
