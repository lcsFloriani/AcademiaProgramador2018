using FlorianiProva.Dominio.Exceções;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Features.Alunos.Excecoes
{
    public class IdadeNegativaException : ExcecaoDeNegocio
    {
        public IdadeNegativaException() : base("Idade não pode ser negativa")
        {
        }
    }
}
