using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Infra.CNPJs;
using Pizzaria.Infra.CPFs;

namespace Pizzaria.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Cliente ObterClienteTipoPessoaFisica(Endereco endereco)
        {
            return new Cliente
            {
                Nome = "José",
                Telefone = "999418993",
                NumeroDocumento = "32999959010",
                Endereco = endereco,
                TipoCliente = TipoClienteEnum.Fisico
            };
        }

        public static Cliente ObterClienteTipoPessoaFisicaComCpfInvalido(Endereco endereco)
        {
            return new Cliente
            {
                Nome = "Teste",
                Telefone = "999988993",
                NumeroDocumento = "3299995901",
                Endereco = endereco,
                TipoCliente = TipoClienteEnum.Fisico
            };
        }

        public static Cliente ObterClienteTipoPessoaJuridica(Endereco endereco)
        {
            return new Cliente
            {
                Nome = "Ndd",
                Telefone = "4932518000",
                NumeroDocumento = "06255692000103",
                Endereco = endereco,
                TipoCliente = TipoClienteEnum.Juridico
            };
        }

        public static Cliente ObterClienteTipoPessoaJuridicaComCnpjInvalido(Endereco endereco)
        {
            return new Cliente
            {
                Nome = "Teste",
                Telefone = "999988993",
                NumeroDocumento = "086716960001",
                Endereco = endereco,
                TipoCliente = TipoClienteEnum.Juridico
            };
        }

        public static Cliente ObterClienteComNomeNuloOuVazio(Endereco endereco)
        {
            return new Cliente
            {
                Nome = "",
                Telefone = "999988993",
                NumeroDocumento = "871738378",
                Endereco = endereco,
                TipoCliente = TipoClienteEnum.Juridico
            };
        }

        public static Cliente ObterClienteComTelefoneNuloOuVazio(Endereco endereco)
        {
            return new Cliente
            {
                Nome = "Teste",
                Telefone = "",
                NumeroDocumento = "871738378",
                Endereco = endereco,
                TipoCliente = TipoClienteEnum.Juridico
            };
        }

        public static Cliente ObterClienteComNumeroDocumentoNuloOuVazio(Endereco endereco)
        {
            return new Cliente
            {
                Nome = "Teste",
                Telefone = "999988993",
                NumeroDocumento = "",
                Endereco = endereco,
                TipoCliente = TipoClienteEnum.Juridico
            };
        }

        public static Cliente ObterClienteComEnderecoNulo()
        {
            return new Cliente
            {
                Nome = "Teste",
                Telefone = "999988993",
                NumeroDocumento = "871738378",
                TipoCliente = TipoClienteEnum.Juridico
            };
        }
    }
}
