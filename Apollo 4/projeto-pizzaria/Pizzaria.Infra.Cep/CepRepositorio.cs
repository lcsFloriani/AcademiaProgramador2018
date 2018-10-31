using MosaicoSolutions.ViaCep;
using NDDTwitter.Infra.Cep;
using Pizzaria.Domain.Features.Enderecos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pizzaria.Infra.Cep
{
    public class CepRepositorio
    {
        private IViaCepService _viaCepService;
        private EnderecoMapper _map;

        public CepRepositorio()
        {
            _viaCepService = ViaCepService.Default();
            _map = new EnderecoMapper();
        }

        public virtual Endereco BuscarCep(string cep)
        {
            var enderecoViaCep = _viaCepService.ObterEndereco(cep);

            return _map.Mapear(enderecoViaCep);
        }
    }
}
