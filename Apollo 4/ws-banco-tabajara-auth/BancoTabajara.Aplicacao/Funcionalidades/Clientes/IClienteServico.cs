using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Commands;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Querys;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.ViewModels;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using System.Collections.Generic;
using System.Linq;

namespace BancoTabajara.Aplicacao.Funcionalidades.Clientes
{
    public interface IClienteServico
    {
        long Adicionar(ClienteRegistraCommand command);
        bool Atualizar(ClienteAtualizaCommand command);
        Cliente BuscarPorId(long id);
        IQueryable<Cliente> Listagem(ClienteQuery query);
        bool Excluir(ClienteDeletaCommand command);
    }
}
