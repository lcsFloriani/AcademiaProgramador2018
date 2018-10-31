using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Clientes
{
    public interface IClienteRepositorio
    {
        Cliente Salvar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        Cliente BuscarPorId(long id);
        Cliente BuscarPorTelefone(string telefone);
        IList<Cliente> Listagem();
        void Excluir(Cliente cliente);
        bool VerificarClienteComTelefoneRepetido(Cliente cliente);
    }
}
