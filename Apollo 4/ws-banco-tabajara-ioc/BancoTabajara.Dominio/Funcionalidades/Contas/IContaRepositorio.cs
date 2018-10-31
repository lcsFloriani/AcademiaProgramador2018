using BancoTabajara.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Dominio.Funcionalidades.Contas
{
    public interface IContaRepositorio
    {
        Conta Adicionar(Conta conta);
        bool Atualizar(Conta conta);
        bool AtualizarComMovimentacao(OperacaoContaEnum OperacaoConta, params Conta[] contas);
        bool AtualizarEstado(Conta conta);
        Conta BuscarPorId(long id);
        IQueryable<Conta> Listagem(int quantidade);
        bool Excluir(Conta conta);
        bool VerificarNumeroConta(Conta conta);
    }
}
