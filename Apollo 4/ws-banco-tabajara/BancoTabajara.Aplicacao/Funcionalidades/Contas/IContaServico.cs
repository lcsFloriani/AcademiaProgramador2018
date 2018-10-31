using BancoTabajara.Aplicacao.Funcionalidades.Extratos;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using System.Linq;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas
{
    public interface IContaServico
    {
        long Adicionar(Conta conta);
        bool Atualizar(Conta conta);
        ContaDTO BuscarPorId(long id);
        IQueryable<ContaDTO> Listagem(int quantidade);
        bool Excluir(long id);
        bool Sacar(long id, double valor);
        bool Depositar(long id, double valor);
        bool RealizarTransferencia(long contaId, long destinatarioId, double valor);
        bool AlterarEstado(long id, bool estado);
        ExtratoDTO GerarExtrato(long id);
    }
}
