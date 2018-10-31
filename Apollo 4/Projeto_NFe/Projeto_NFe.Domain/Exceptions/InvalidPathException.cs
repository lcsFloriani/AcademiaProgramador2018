using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Exceptions
{
    public class InvalidPathException : Exception
    {
        public InvalidPathException() : base("Caminho do arquivo inválido!")
        {

        }
    }
}
