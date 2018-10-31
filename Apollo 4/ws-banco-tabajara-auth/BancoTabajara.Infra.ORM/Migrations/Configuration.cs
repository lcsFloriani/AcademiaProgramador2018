namespace BancoTabajara.Infra.ORM.Migrations
{
    using BancoTabajara.Dominio.Funcionalidades.Clientes;
    using BancoTabajara.Dominio.Funcionalidades.Contas;
    using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;
    using BancoTabajara.Infra.ORM.Contexto;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    [ExcludeFromCodeCoverage]
    internal sealed class Configuration : DbMigrationsConfiguration<BancoTabajaraDbContexto>
    {
        private Cliente cliente1;
        private Cliente cliente2;
        private Cliente cliente3;
        private Conta conta1;
        private Conta conta2;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BancoTabajaraDbContexto contexto)
        {
            CriarClientes(contexto);
            CriarContas(contexto);
        
            contexto.SaveChanges();
        }

        private void CriarContas(BancoTabajaraDbContexto contexto)
        {
            conta1 = new Conta
            {
                NumeroConta = 035892,
                Cliente = cliente1,
                Estado = true,
                Limite = 150,
                Saldo = 600,
            };

            conta1.Depositar(300);
            conta1.Sacar(100);

            conta2 = new Conta
            {
                NumeroConta = 709748,
                Cliente = cliente2,
                Estado = true,
                Limite = 150,
                Saldo = 1000,
            };

            conta2.RealizarTransferencia(375.40, conta1);

            contexto.Contas.Add(conta1);
            contexto.Contas.Add(conta2);
        }

        private void CriarClientes(BancoTabajaraDbContexto contexto)
        {
            cliente1 = new Cliente
            {
                Nome = "José",
                RG = "538702879",
                CPF = "43242847866",
                DataNascimento = new DateTime(1995, 04, 16)
            };

            cliente2 = new Cliente
            {
                Nome = "Ana",
                RG = "274497232",
                CPF = "56247018290",
                DataNascimento = new DateTime(1988, 06, 10)
            };

            cliente3 = new Cliente
            {
                Nome = "Carla",
                RG = "357001485",
                CPF = "21126699233",
                DataNascimento = new DateTime(1989, 07, 15)
            };

            contexto.Clientes.Add(cliente1);
            contexto.Clientes.Add(cliente2);
            contexto.Clientes.Add(cliente3);
        }
    }
}
