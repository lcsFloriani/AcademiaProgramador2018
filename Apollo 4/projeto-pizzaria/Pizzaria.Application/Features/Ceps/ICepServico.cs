using Pizzaria.Domain.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Application.Features.CEPs
{
    public interface ICepServico
    {
        Endereco BuscarCep(string cep);
    }
}
