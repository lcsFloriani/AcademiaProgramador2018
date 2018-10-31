using ORM01.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Dominio.Features.Enderecos
{
    public class LougradouroVazioEnderecoException : BusinessException
    {
        public LougradouroVazioEnderecoException() : base("Lougradouro do endereco tem que ser preenchido")
        {
        }
    }
}
