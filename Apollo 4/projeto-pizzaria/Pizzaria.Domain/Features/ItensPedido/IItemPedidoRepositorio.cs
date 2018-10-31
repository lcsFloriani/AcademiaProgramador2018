using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.ItensPedido
{
    public interface IItemPedidoRepositorio
    {
        ItemPedido BuscarPorId(long id);
        IList<ItemPedido> Listagem();
        void Excluir(ItemPedido itemPedido);
    }
}
