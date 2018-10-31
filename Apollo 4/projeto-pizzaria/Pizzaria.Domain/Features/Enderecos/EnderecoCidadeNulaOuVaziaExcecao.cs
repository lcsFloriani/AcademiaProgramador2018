using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Enderecos
{
    public class EnderecoCidadeNulaOuVaziaExcecao : NegocioExcecao
    {
        public EnderecoCidadeNulaOuVaziaExcecao() : base("A cidade não pode ser nula ou vazia!")
        {
        }
    }
}
