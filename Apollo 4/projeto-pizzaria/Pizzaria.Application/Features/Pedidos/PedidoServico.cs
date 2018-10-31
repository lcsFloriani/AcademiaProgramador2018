using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;

namespace Pizzaria.Application.Features.Pedidos
{
    public class PedidoServico : IPedidoServico
    {
        private IPedidoRepositorio _repositorio;
        private int menorQue = 1;

        public PedidoServico(IPedidoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Pedido Adicionar(Pedido entidade)
        {
            entidade.Validar();
            entidade = _repositorio.Salvar(entidade);

            return entidade;
        }

        public Pedido Atualizar(Pedido entidade)
        {
            if (entidade.Id < menorQue)
                throw new IdentificadorIndefinidoExcecao();

            entidade.Validar();
            entidade = _repositorio.Atualizar(entidade);

            return entidade;
        }

        public Pedido BuscarPorId(long id)
        {
            if (id < menorQue)
                throw new IdentificadorIndefinidoExcecao();

            return _repositorio.BuscarPorId(id);
        }

        public List<Pedido> Listagem()
        {
            return _repositorio.Listagem() as List<Pedido>;
        }

        public void Excluir(Pedido entidade)
        {
            if (entidade.Id < menorQue)
                throw new IdentificadorIndefinidoExcecao();

            _repositorio.Excluir(entidade);
        }

        public IList<Pedido> BuscarPedidoPorTelefoneDoCliente(string telefone)
        {
            if (string.IsNullOrEmpty(telefone))
                throw new PedidoTelefoneProcuraNuloOuVazioExcecao();

            return _repositorio.BuscarPedidoPorTelefoneDoCliente(telefone);
        }
    }
}
