using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.AlterarEstado;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Atualizar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Deletar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Depositar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Registrar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Sacar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Transferir;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Querys;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.ViewModels;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using System.Linq;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas
{
    public interface IContaServico
    {
        long Adicionar(ContaRegistroCommand command);
        bool Atualizar(ContaAtualizaCommand command);
        Conta BuscarPorId(long id);
        IQueryable<Conta> Listagem(ContaQuery query);
        bool Excluir(ContaDeletaCommand command);
        bool Sacar(ContaSaqueCommand command);
        bool Depositar(ContaDepositoCommand command);
        bool RealizarTransferencia(ContaTransferenciaCommand command);
        bool AlterarEstado(ContaEstadoCommand command);
        Conta GerarExtrato(long id);
    }
}
