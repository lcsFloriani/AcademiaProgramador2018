using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Enderecos
{
    public class EnderecoLogradouroNuloOuVazioExcecao : NegocioExcecao
    {
        public EnderecoLogradouroNuloOuVazioExcecao() : base("O logradouro não pode ser nulo ou vazio!")
        {
        }
    }
}
