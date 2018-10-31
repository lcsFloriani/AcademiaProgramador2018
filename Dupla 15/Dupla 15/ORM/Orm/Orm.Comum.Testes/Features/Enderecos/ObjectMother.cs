using Orm.Dominio.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.Comum.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Endereco EnderecoComLogradouroEmBranco() => new Endereco
        {
            Cidade = "Lages",
            Bairro = "Penha",
            Logradouro = "",
            Numero = "81",
            UF = "SC",
            Complemento = "Casa"
        };
        public static Endereco EnderecoComCidadeEmBranco() => new Endereco
        {
            Cidade = "",
            Bairro = "Penha",
            Logradouro = "Olavo Bilac",
            Numero = "81",
            UF = "SC",
            Complemento = "Casa"
        };
        public static Endereco EnderecoComBairroEmBranco() => new Endereco
        {
            Cidade = "Lages",
            Bairro = "",
            Logradouro = "Olavo Bilac",
            Numero = "81",
            UF = "SC",
            Complemento = "Casa"
        };
        public static Endereco EnderecoComUFEmBranco() => new Endereco
        {
            Cidade = "Lages",
            Bairro = "Penha",
            Logradouro = "Olavo Bilac",
            Numero = "81",
            UF = "",
            Complemento = "Casa"
        };
        public static Endereco EnderecoComNumeroEmBranco() => new Endereco
        {
            Cidade = "Lages",
            Bairro = "Penha",
            Logradouro = "Olavo Bilac",
            Numero = "",
            UF = "SC",
            Complemento = "Casa"
        };
        public static Endereco EnderecoComComplementoEmBranco() => new Endereco
        {
            Cidade = "Lages",
            Bairro = "Penha",
            Logradouro = "Olavo Bilac",
            Numero = "81",
            UF = "SC",
            Complemento = ""
        };
        public static Endereco EnderecoValido() => new Endereco
        {
            Id = 2,
            Cidade = "Lages",
            Bairro = "Penha",
            Logradouro = "Olavo Bilac",
            Numero = "81",
            UF = "SC",
            Complemento = "Casa"
        };
    }
}
