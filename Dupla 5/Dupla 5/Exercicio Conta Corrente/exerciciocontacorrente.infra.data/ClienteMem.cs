using ExercicioContaCorrente.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioContaCorrente.Infra.Data
{
    public class ClienteMem
    {
        private static List<Cliente> _clientes = new List<Cliente>();

        public static int id = 0;

        public void Insert(Cliente cliente)
        {
            id++;
            cliente.id = id;
            _clientes.Add(cliente);
        }

        public void Update(Cliente cliente)
        {
            Cliente clienteEncontrada = _clientes.Find(delegate (Cliente t) { return t.id == cliente.id; });

            clienteEncontrada.cpf = cliente.cpf;
            clienteEncontrada.nome = cliente.nome;
            clienteEncontrada.telefone = cliente.telefone;
            clienteEncontrada.email = cliente.email;
        }

        public void Delete(Cliente cliente)
        {
            cliente = _clientes.Find(delegate (Cliente t) { return t.id == cliente.id; });

            _clientes.Remove(cliente);
        }

        public Cliente GetById(long id)
        {
            return _clientes.Find(delegate (Cliente t) { return t.id == id; });
        }

        public List<Cliente> GetAll()
        {
            return _clientes;
        }
    }
}
