using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Exceções
{
    public class ExcecaoDeNegocio : Exception
    {
        public ExcecaoDeNegocio(string mensagem) : base (mensagem)
        {
        }
    }
}
