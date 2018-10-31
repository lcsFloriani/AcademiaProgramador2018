using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Features.Pedidos
{
    public class PedidoSQLRepositorio : IPedidoRepositorio
    {
        private DataContext _contexto;

        public PedidoSQLRepositorio(DataContext contexto)
        {
            _contexto = contexto;
        }

        public Pedido Salvar(Pedido pedido)
        {
            _contexto.Pedidos.Add(pedido);
            _contexto.SaveChanges();

            return pedido;
        }

        public Pedido Atualizar(Pedido pedido)
        {
            _contexto.Entry(pedido).State = EntityState.Modified;
            _contexto.SaveChanges();

            return pedido;
        }

        public Pedido BuscarPorId(long id)
        {
            return _contexto.Pedidos.Where(c => c.Id == id).FirstOrDefault();
        }

        public IList<Pedido> Listagem()
        {
            return _contexto.Pedidos.ToList();
        }

        public void Excluir(Pedido pedido)
        {
            _contexto.Pedidos.Remove(pedido);
            _contexto.SaveChanges();
        }

        public IList<Pedido> BuscarPedidoPorTelefoneDoCliente(string telefone)
        {
            List<Pedido> pedidos = (from p in _contexto.Pedidos join c in _contexto.Clientes on p.ClienteId equals c.Id where c.Telefone.Equals(telefone) select p).ToList();

            return pedidos;
        }
    }
}
