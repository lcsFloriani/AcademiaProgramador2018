using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Clientes
{
    public class ClienteTelefoneNuloOuVazioExcecao : NegocioExcecao
    {
        public ClienteTelefoneNuloOuVazioExcecao() : base("O telefone não pode ser nulo ou vazio!")
        {
        }
    }
}
