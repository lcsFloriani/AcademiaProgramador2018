using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BancoTabajara.Dominio.Excecoes;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Infra.ORM.Contexto;

namespace BancoTabajara.Infra.ORM.Funcionalidades.Clientes
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private BancoTabajaraDbContexto _contexto;
        private int _linhasAfetadas = 0;

        public ClienteRepositorio(BancoTabajaraDbContexto contexto)
        {
            _contexto = contexto;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            var novoCliente = _contexto.Clientes.Add(cliente);
            _contexto.SaveChanges();

            return novoCliente;
        }

        public Cliente BuscarPorId(long id)
        {
            Cliente cliente = _contexto.Clientes.Where(c => c.Id == id).FirstOrDefault();

            if (cliente == null)
                throw new NaoEncontradoExcecao();

            return cliente;
        }

        public IQueryable<Cliente> Listagem(int quantidade)
        {
            return _contexto.Clientes.Take(quantidade);
        }

        public bool Atualizar(Cliente cliente)
        {
           // _contexto.Clientes.Attach(cliente);
            _contexto.Entry(cliente).State = EntityState.Modified;

            return _contexto.SaveChanges() > _linhasAfetadas;
        }

        public bool Excluir(Cliente cliente)
        {
            _contexto.Clientes.Remove(cliente);

            return _contexto.SaveChanges() > _linhasAfetadas;
        }
    }
}
