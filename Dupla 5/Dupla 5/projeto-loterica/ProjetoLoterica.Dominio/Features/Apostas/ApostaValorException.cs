using ProjetoLoterica.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Dominio.Features.Apostas
{
    public class ApostaValorException : BusinessException
    {
        public ApostaValorException() : base("O valor da aposta nao pode ser menor ou igual a zero!")
        {
        }
    }
}
