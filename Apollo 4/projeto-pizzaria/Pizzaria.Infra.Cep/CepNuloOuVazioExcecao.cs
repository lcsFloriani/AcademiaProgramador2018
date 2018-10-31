using Pizzaria.Infra.Cep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra.Cep
{
    public class CepNuloOuVazioExcecao : CepExcecao
    {
        public CepNuloOuVazioExcecao() : base("O CEP não pode ser nulo ou vazio!")
        {
        }
    }
}
