using MF6.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF6.Domain.Excecoes
{
    public class TonerInvalidoException : ExcecaoDeNegocio
    {
        public TonerInvalidoException() : base(CodigoErros.InvalidObject, "Toner invalido")
        {
        }
    }
}
