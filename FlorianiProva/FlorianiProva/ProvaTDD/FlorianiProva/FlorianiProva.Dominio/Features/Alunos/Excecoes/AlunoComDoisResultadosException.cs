using FlorianiProva.Dominio.Exceções;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Features.Alunos.Excecoes
{
    public class AlunoComDoisResultadosException : ExcecaoDeNegocio
    {
        public AlunoComDoisResultadosException() : base("Um Aluno não pode ter 2 resultados")
        {
        }
    }
}
