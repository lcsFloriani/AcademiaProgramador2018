using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDDTwitter.Infra.Cep;
using Pizzaria.Application.Features.CEPs;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Infra.Cep;

namespace Pizzaria.Application.Features.CEPs
{
    public class CepServico : ICepServico
    {
        private CepRepositorio _repositorio;

        public CepServico(CepRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Endereco BuscarCep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
                throw new CepNuloOuVazioExcecao();

            return _repositorio.BuscarCep(cep);
        }
    }
}
