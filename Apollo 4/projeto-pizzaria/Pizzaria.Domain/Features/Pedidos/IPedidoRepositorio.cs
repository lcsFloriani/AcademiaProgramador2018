using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Pedidos
{
    public interface IPedidoRepositorio
    {
        Pedido Salvar(Pedido pedido);
        Pedido Atualizar(Pedido pedido);
        Pedido BuscarPorId(long id);
        IList<Pedido> Listagem();
        void Excluir(Pedido pedido);
        IList<Pedido> BuscarPedidoPorTelefoneDoCliente(string telefone);
    }
}
