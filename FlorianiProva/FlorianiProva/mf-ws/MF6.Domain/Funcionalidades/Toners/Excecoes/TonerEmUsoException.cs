using MF6.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF6.Domain.Funcionalidades.Toners.Excecoes
{
    public class TonerEmUsoException : ExcecaoDeNegocio
    {
        public TonerEmUsoException() : base(CodigoErros.NotAllowed, "Toner em uso")
        {
        }
    }
}
