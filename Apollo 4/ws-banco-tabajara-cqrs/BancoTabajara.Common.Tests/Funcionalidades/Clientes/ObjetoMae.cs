using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Commands;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Querys;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using System;

namespace BancoTabajara.Common.Tests.Funcionalidades
{
    public partial class ObjetoMae
    {

        public static Cliente ObterClientePadrao()
        {
            return new Cliente
            {
                Nome = "José",
                RG = "538702879",
                CPF = "43242847866",
                DataNascimento = new DateTime(1995, 04, 16)
            };
        }

        public static Cliente ObterClienteSemeado()
        {
            return new Cliente
            {
                Id = 3,
                Nome = "José",
                RG = "538702879",
                CPF = "43242847866",
                DataNascimento = new DateTime(1995, 04, 16)
            };
        }

        public static Cliente ObterClienteComIdInexistente()
        {
            return new Cliente
            {
                Id = 2,
                Nome = "José",
                RG = "538702879",
                CPF = "43242847866",
                DataNascimento = new DateTime(1995, 04, 16)
            };
        }

        public static Cliente ObterClientePadraoComId()
        {
            return new Cliente
            {
                Id = 1,
                Nome = "José",
                RG = "538702879",
                CPF = "43242847866",
                DataNascimento = new DateTime(1995, 04, 16)
            };
        }

        public static Cliente ObterClienteComNomeNuloOuVazio()
        {
            return new Cliente
            {
                Nome = "",
                RG = "538702879",
                CPF = "43242847866",
                DataNascimento = new DateTime(1995, 04, 16)
            };
        }

        public static Cliente ObterClienteComCPFNuloOuVazio()
        {
            return new Cliente
            {
                Nome = "Jão",
                RG = "538702879",
                CPF = "",
                DataNascimento = new DateTime(1995, 04, 16)
            };
        }

        public static Cliente ObterClienteComRGNuloOuVazio()
        {
            return new Cliente
            {
                Nome = "Jão",
                RG = "",
                CPF = "43242847866",
                DataNascimento = new DateTime(1995, 04, 16)
            };
        }

        public static Cliente ObterClienteComContaNula()
        {
            return new Cliente
            {
                Nome = "Jão",
                RG = "538702879",
                CPF = "43242847866",
                DataNascimento = new DateTime(1995, 04, 16)
            };
        }

        public static ClienteRegistraCommand ObterClienteRegistraCommand()
        {
            return new ClienteRegistraCommand
            {
                Nome = "José",
                RG = "538702879",
                CPF = "43242847866",
                DataNascimento = new DateTime(1995, 04, 16)
            };
        }

        public static ClienteAtualizaCommand ObterClienteAtualizaCommand()
        {
            return new ClienteAtualizaCommand
            {
                Id = 1,
                Nome = "José",
                RG = "538702879",
                CPF = "43242847866",
                DataNascimento = new DateTime(1995, 04, 16)
            };
        }

        public static ClienteDeletaCommand ObterClienteDeletaCommand()
        {
            return new ClienteDeletaCommand
            {
                Id = 1
            };
        }

        public static ClienteQuery ObterClienteQuery(int quantidade)
        {
            return new ClienteQuery(quantidade){ };
        }
    }
}
