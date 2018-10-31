using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Dominio.Exceptions
{
    public class EnderecoInvalidoException : BusinessException
    {
        public EnderecoInvalidoException() : base("Endereço inválido ou vázio")
        {
        }
    }
}
