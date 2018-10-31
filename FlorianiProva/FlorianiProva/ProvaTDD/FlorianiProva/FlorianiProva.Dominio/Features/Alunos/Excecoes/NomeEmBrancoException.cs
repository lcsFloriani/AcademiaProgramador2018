using FlorianiProva.Dominio.Exceções;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Features.Alunos.Excecoes
{
    public class NomeEmBrancoException : ExcecaoDeNegocio
    {
        public NomeEmBrancoException() : base("Nome não pode estar em branco")
        {
        }
    }
}
