using Banco.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Infra.Data
{
    public class ClienteMem
    {
        private List<Cliente> clientes = new List<Cliente>();

        public void AdicionarCliente(Cliente novoCliente)
        {
            if (novoCliente != null)
                clientes.Add(novoCliente);
        }
        public List<Cliente> TrazerClientes()
        {
            return clientes;
        }
        public void ExcluirCliente(Cliente cliente)
        {
            clientes.Remove(cliente);
        }
    }
}
