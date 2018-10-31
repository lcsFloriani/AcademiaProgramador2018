using BancoTabajara.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Dominio.Funcionalidades.Contas
{
    public class ContaValorNegativoOuZeroExcecao : NegocioExcecao
    {
        public ContaValorNegativoOuZeroExcecao() : base(CodigoErro.ClientError, "O valor não pode ser negativo ou zero!")
        {
        }
    }
}
