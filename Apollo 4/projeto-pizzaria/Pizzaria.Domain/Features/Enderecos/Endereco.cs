using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzaria.Domain.Features.Enderecos
{
    public class Endereco
    {
        public string Logradouro { get;set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(Logradouro))
                throw new EnderecoLogradouroNuloOuVazioExcecao();

            if (string.IsNullOrEmpty(Bairro))
                throw new EnderecoBairroNuloOuVazioExcecao();

            if (string.IsNullOrEmpty(Cidade))
                throw new EnderecoCidadeNulaOuVaziaExcecao();

            if (string.IsNullOrEmpty(UF))
                throw new EnderecoUFNuloOuVazioExcecao();

            if (string.IsNullOrEmpty(Cep))
                throw new EnderecoCepNuloOuVazioExcecao();

            if (Numero < 0)
                throw new EnderecoNumeroInvalidoExcecao();

            if (string.IsNullOrEmpty(Complemento))
                throw new EnderecoComplementoNuloOuVazioExcecao();
        }
    }
}