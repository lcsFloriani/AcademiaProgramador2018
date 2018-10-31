using System.Collections.Generic;
using System.Linq;

namespace BancoTabajara.Dominio.Funcionalidades.Clientes
{
    public interface IClienteRepositorio
    {
        Cliente Adicionar(Cliente cliente);
        bool Atualizar(Cliente cliente);
        Cliente BuscarPorId(long id);
        IQueryable<Cliente> Listagem(int quantidade);
        bool Excluir(Cliente cliente);
    }
}
