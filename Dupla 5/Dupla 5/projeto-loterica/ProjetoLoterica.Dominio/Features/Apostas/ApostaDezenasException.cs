using ProjetoLoterica.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Dominio.Features.Apostas
{
    public class ApostaDezenasException : BusinessException
    {
        public ApostaDezenasException() : base("A Quantidade de dezenas não pode ser menor que 6!")
        {
        }
    }
}
