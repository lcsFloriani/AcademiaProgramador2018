using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Dominio.Exceptions
{
    public class IdentifierUndefinedException : Exception
    {
        public IdentifierUndefinedException() : base("O id não pode ser vazio")
        {

        }
    }
}
