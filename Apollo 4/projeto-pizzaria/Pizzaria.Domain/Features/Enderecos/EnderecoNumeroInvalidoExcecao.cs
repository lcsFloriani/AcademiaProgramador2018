using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Enderecos
{
    public class EnderecoNumeroInvalidoExcecao : NegocioExcecao
    {
        public EnderecoNumeroInvalidoExcecao() : base("O número deve ser maior que zero!")
        {
        }
    }
}
