using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Clientes
{
    public class ClienteTelefoneRepetidoExcecao : NegocioExcecao
    {
        public ClienteTelefoneRepetidoExcecao() : base("Esse telefone já está sendo usado por outro cliente!")
        {
        }
    }
}
