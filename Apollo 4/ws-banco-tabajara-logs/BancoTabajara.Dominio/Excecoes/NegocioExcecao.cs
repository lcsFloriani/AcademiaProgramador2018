using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Dominio.Excecoes
{
    public class NegocioExcecao : Exception
    {
        public NegocioExcecao(CodigoErro codigoDeErro, string message) : base(message)
        {
            CodigoErro = codigoDeErro;
        }

        public CodigoErro CodigoErro { get; }
    }
}
