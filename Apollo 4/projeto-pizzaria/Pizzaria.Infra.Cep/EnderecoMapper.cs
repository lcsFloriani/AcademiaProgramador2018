using Pizzaria.Domain.Features.Enderecos;
using EnderecoViaCep = MosaicoSolutions.ViaCep.Modelos.Endereco;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Cep
{
    public class EnderecoMapper
    {
        private Endereco _endereco;

        public Endereco Mapear(EnderecoViaCep enderecoViaCep)
        {
            _endereco = new Endereco();

            _endereco.Cep = enderecoViaCep.Cep;
            _endereco.Logradouro = enderecoViaCep.Logradouro;
            _endereco.Complemento = enderecoViaCep.Complemento;
            _endereco.Bairro = enderecoViaCep.Bairro;
            _endereco.Cidade = enderecoViaCep.Localidade;
            _endereco.UF = enderecoViaCep.UF;

            return _endereco;
        }
    }
}
