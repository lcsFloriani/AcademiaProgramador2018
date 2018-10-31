using ORM01.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Dominio.Features.Enderecos
{
    public class NumeroEnderecoInvalidoException : BusinessException
    {
        public NumeroEnderecoInvalidoException() : base("Numero do endereco não pode ser menor do que zero")
        {
        }
    }
}
