using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Exceptions
{
    public class IdentificadorIndefinidoExcecao : NegocioExcecao
    {
        public IdentificadorIndefinidoExcecao() : base("O id não pode ser vazio!")
        {
        }
    }
}
