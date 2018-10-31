using BancoTabajara.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Dominio.Funcionalidades.Contas
{
    public class ContaNumeroContaAlteradoExcecao : NegocioExcecao
    {
        public ContaNumeroContaAlteradoExcecao() : base(CodigoErro.ClientError, "O número da conta não pode ser alterado!")
        {
        }
    }
}
