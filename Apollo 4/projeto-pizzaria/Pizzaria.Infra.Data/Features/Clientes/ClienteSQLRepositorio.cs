using Pizzaria.Domain.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Features.Clientes
{
    public class ClienteSQLRepositorio : IClienteRepositorio
    {
        private DataContext _contexto;

        public ClienteSQLRepositorio(DataContext contexto)
        {
            _contexto = contexto;
        }

        public Cliente Salvar(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            _contexto.SaveChanges();

            return cliente;
        }

        public Cliente Atualizar(Cliente cliente)
        {
            _contexto.Entry(cliente).State = EntityState.Modified;
            _contexto.SaveChanges();

            return cliente;
        }

        public Cliente BuscarPorId(long id)
        {
            return _contexto.Clientes.Where(c => c.Id == id).FirstOrDefault();
        }

        public Cliente BuscarPorTelefone(string telefone)
        {
            return _contexto.Clientes.Where(c => c.Telefone == telefone).FirstOrDefault();
        }

        public IList<Cliente> Listagem()
        {
            return _contexto.Clientes.ToList();
        }

        public void Excluir(Cliente cliente)
        {
            _contexto.Clientes.Remove(cliente);
            _contexto.SaveChanges();
        }

        public bool VerificarClienteComTelefoneRepetido(Cliente cliente)
        {
            int count = _contexto.Clientes.Where(c => c.Telefone == cliente.Telefone && c.Id != cliente.Id).Count();

            return count > 0; 
        }
    }
}
