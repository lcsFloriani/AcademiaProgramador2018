using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Dominio.Excecoes
{
    public class IdentificadorIndefinidoExcecao : NegocioExcecao
    {
        public IdentificadorIndefinidoExcecao() : base(CodigoErro.ClientError,"O id é inválido!")
        {
        }
    }
}