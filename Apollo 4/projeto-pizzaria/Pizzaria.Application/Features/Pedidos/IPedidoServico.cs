using Pizzaria.Domain.Features.Pedidos;
using System.Collections.Generic;

namespace Pizzaria.Application.Features.Pedidos
{
    public interface IPedidoServico : IServico<Pedido>
    {
        IList<Pedido> BuscarPedidoPorTelefoneDoCliente(string telefone);
    }
}
