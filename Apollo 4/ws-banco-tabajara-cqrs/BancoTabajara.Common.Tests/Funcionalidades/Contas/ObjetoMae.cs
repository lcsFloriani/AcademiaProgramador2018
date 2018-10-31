using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Common.Tests.Funcionalidades
{
    public partial class ObjetoMae
    {
        public static Conta ObterContaSemente()
        {
            return new Conta
            {   
                NumeroConta = 1452,
                Cliente = ObjetoMae.ObterClientePadrao(),
                Estado = true,
                Limite = 150,
                Saldo = 600,
            };
        }

        public static Conta ObterContaValida(Cliente cliente)
        {
            return new Conta
            {
                NumeroConta = 10,
                Saldo = 50,
                Limite = 50,
                Estado = true,
                Cliente = cliente
            };
        }


        public static Conta ObterContaValidaSemeada()
        {
            return new Conta
            {
                Id = 1,
                NumeroConta = 10,
                Saldo = 50,
                Limite = 50,
                Estado = true,
                Cliente = new Cliente
                {
                    Id = 1,
                    Nome = "José",
                    RG = "538702879",
                    CPF = "43242847866",
                    DataNascimento = new DateTime(1995, 04, 16)
                }

            };
        }


        public static Conta ObterContaIdInvalido(Cliente cliente)
        {
            return new Conta
            {
                Id = 0,
                NumeroConta = 10,
                Saldo = 50,
                Limite = 50,
                Estado = true,
                Cliente = cliente
            };
        }

        public static Conta ObterContaDestinatario()
        {
            return new Conta
            {
                NumeroConta = 11,
                ClienteId = 2,
                Saldo = -50,
                Limite = 50
            };
        }

        public static Conta ObterContaDestinatarioSemeado()
        {
            return new Conta
            {
                Id =2,
                NumeroConta = 11,
                ClienteId = 2,
                Saldo = -50,
                Limite = 50
            };
        }

        public static Conta ObterContaComNumeroInvalido()
        {
            return new Conta
            {
                NumeroConta = -10,
                ClienteId = 1
            };
        }

        public static Conta ObterContaComClienteIdInvalido()
        {
            return new Conta
            {
                NumeroConta = 10
            };
        }

        public static Conta ObterContaValidaComCliente(Cliente cliente)
        {
            return new Conta
            {
                NumeroConta = 10,
                ClienteId = cliente.Id,
                Cliente = cliente,
                Saldo = 50,
                Limite = 50,
                Estado = true
            };
        }
    }
}
