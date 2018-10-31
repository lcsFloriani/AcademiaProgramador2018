using FlorianiProva.Dominio.Exceções;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Features.Avaliações.Excecoes
{
    public class AssuntoEmBrancoException : ExcecaoDeNegocio
    {
        public AssuntoEmBrancoException() : base("Assunto não pode estar em branco")
        {
        }
    }
}
