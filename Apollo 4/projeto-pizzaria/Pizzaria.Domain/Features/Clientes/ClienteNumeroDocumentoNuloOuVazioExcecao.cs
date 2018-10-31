using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Clientes
{
    public class ClienteNumeroDocumentoNuloOuVazioExcecao : NegocioExcecao
    {
        public ClienteNumeroDocumentoNuloOuVazioExcecao() : base("O número do documento não pode ser nulo ou vazio!")
        {
        }
    }
}
