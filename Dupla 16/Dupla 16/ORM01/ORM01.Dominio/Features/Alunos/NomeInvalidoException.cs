using ORM01.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Dominio.Features.Alunos
{
    public class NomeInvalidoException : BusinessException
    {
        public NomeInvalidoException() : base("Nome inválido ou vázio")
        {
        }
    }
}
