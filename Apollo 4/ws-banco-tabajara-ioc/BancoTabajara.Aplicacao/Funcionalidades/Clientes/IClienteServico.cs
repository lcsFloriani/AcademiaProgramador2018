using BancoTabajara.Dominio.Funcionalidades.Clientes;
using System.Collections.Generic;
using System.Linq;

namespace BancoTabajara.Aplicacao.Funcionalidades.Clientes
{
    public interface IClienteServico
    {
        long Adicionar(Cliente cliente);
        bool Atualizar(Cliente cliente);
        ClienteDTO BuscarPorId(long id);
        IQueryable<ClienteDTO> Listagem(int quantidade);
        bool Excluir(long id);
    }
}
