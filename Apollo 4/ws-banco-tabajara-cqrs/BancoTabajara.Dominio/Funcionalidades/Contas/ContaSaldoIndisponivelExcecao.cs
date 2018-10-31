using BancoTabajara.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Dominio.Funcionalidades.Contas
{
    public class ContaSaldoIndisponivelExcecao : NegocioExcecao
    {
        public ContaSaldoIndisponivelExcecao() : base(CodigoErro.ClientError, "Você não possui saldo suficiente para realizar essa operação!")
        {
        }
    }
}
