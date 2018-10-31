using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Clientes
{
    public class ClienteEnderecoNuloExcecao : NegocioExcecao
    {
        public ClienteEnderecoNuloExcecao() : base("O endereço não pode ser nulo!")
        {
        }
    }
}
