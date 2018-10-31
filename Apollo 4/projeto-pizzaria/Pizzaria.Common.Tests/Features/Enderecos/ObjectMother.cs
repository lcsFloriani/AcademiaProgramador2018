using Pizzaria.Domain.Features.Enderecos;

namespace Pizzaria.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Endereco ObterEndereco()
        {
            return new Endereco
            {
                Logradouro = "Av. Presidente Vargas",
                Bairro = "Coral",
                Cidade = "Lages",
                UF = "SC",
                Cep = "88509501",
                Numero = 1090,
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoComLogradouroNuloOuVazio()
        {
            return new Endereco
            {
                Logradouro = "",
                Bairro = "Coral",
                Cidade = "Lages",
                UF = "SC",
                Cep = "00000000",
                Numero = 123,
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoComBairroNuloOuVazio()
        {
            return new Endereco
            {
                Logradouro = "ABC",
                Bairro = "",
                Cidade = "Lages",
                UF = "SC",
                Cep = "00000000",
                Numero = 123,
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoComCidadeNulaOuVazia()
        {
            return new Endereco
            {
                Logradouro = "ABC",
                Bairro = "Coral",
                Cidade = "",
                UF = "SC",
                Cep = "00000000",
                Numero = 123,
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoComUFNuloOuVazio()
        {
            return new Endereco
            {
                Logradouro = "ABC",
                Bairro = "Coral",
                Cidade = "Lages",
                UF = "",
                Cep = "00000000",
                Numero = 123,
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoComCepNuloOuVazio()
        {
            return new Endereco
            {
                Logradouro = "ABC",
                Bairro = "Coral",
                Cidade = "Lages",
                UF = "SC",
                Cep = "",
                Numero = 123,
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoComNumeroInvalido()
        {
            return new Endereco
            {
                Logradouro = "ABC",
                Bairro = "Coral",
                Cidade = "Lages",
                UF = "SC",
                Cep = "00000000",
                Numero = -123,
                Complemento = "Casa"
            };
        }

        public static Endereco ObterEnderecoComComplementoNuloOuVazio()
        {
            return new Endereco
            {
                Logradouro = "ABC",
                Bairro = "Coral",
                Cidade = "Lages",
                UF = "SC",
                Cep = "00000000",
                Numero = 123,
                Complemento = ""
            };
        }
    }
}
