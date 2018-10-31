using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Pedidos
{
    public class PedidoTelefoneProcuraNuloOuVazioExcecao : NegocioExcecao
    {
        public PedidoTelefoneProcuraNuloOuVazioExcecao() : base("O telefone não pode ser nulo ou vazio!")
        {
        }
    }
}
