using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Pedidos
{
    public class PedidoItensPedidosVazioExcecao : NegocioExcecao
    {
        public PedidoItensPedidosVazioExcecao() : base("A lista de item de pedido não pode ser vazia!")
        {
        }
    }
}
