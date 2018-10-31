using Pizzaria.Domain.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Application.Features.Clientes
{
    public interface IClienteServico : IServico<Cliente>
    {
        Cliente BuscarPorTelefone(string telefone);
        bool VerificarClienteComTelefoneRepetido(Cliente cliente);
    }
}
