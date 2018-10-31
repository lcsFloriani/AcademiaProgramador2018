using BancoTabajara.Common.Tests.Funcionalidades;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;
using BancoTabajara.Infra.ORM.Tests.Contexto;
using Effort;
using Effort.Provider;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BancoTabajara.Infra.ORM.Tests.Inicializador
{

    public class EffortBaseTeste
    {
        protected DbContextoFalso contexto;
        private Cliente cliente;
        private Cliente cliente2;
        private Conta conta;
        private Conta conta2;


        [OneTimeSetUp]
        public void InicializarUmaVez()
        {
            EffortProviderConfiguration.RegisterProvider();
        }

        [SetUp]
        public void SemearBDVirtual()
        {
            EffortFabricaConexoes.ResetarDb();

            var conexao = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            contexto = new DbContextoFalso(conexao);

            //Semente
            CriarCliente(contexto);
            CriarContas(contexto);

            contexto.SaveChanges();
        }

        private void CriarCliente(DbContextoFalso contexto)
        {
            cliente = ObjetoMae.ObterClientePadrao();
            cliente2 = new Cliente
            {
                Nome = "Pedro",
                RG = "53874515",
                CPF = "36942847866",
                DataNascimento = new DateTime(1992, 01, 16)
            };

            contexto.Clientes.Add(cliente);
            contexto.Clientes.Add(cliente2);
        }

        private void CriarContas(DbContextoFalso contexto)
        {
            conta = new Conta
            {
                NumeroConta = 1452,
                Cliente = cliente,
                Estado = true,
                Limite = 150,
                Saldo = 600
            };

             conta2 = new Conta
            {
                NumeroConta = 2258,
                Cliente = cliente2,
                Estado = true,
                Limite = 300,
                Saldo = 1000
            };

            conta.Depositar(1000);
            conta.Sacar(200);

            contexto.Contas.Add(conta);

            conta2.Depositar(1500);
            conta2.Sacar(275);

            contexto.Contas.Add(conta2);
        }
    }
}
