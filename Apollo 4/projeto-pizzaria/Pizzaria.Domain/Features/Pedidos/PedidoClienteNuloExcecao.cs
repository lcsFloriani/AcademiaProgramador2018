using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Pedidos
{
    public class PedidoClienteNuloExcecao : NegocioExcecao
    {
        public PedidoClienteNuloExcecao() : base("O cliente não pode ser nulo!")
        {
        }
    }
}
