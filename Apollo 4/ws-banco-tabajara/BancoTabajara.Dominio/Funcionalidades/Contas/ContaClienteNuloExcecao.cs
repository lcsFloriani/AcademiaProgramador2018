using BancoTabajara.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Dominio.Funcionalidades.Contas
{
    public class ContaClienteNullExcecao : NegocioExcecao
    {
        public ContaClienteNullExcecao() : base(CodigoErro.ClientError, "O cliente não pode ser nulo!")
        {
        }
    }
}
