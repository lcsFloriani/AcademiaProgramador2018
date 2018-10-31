using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Infra.ORM.Contexto
{
    [ExcludeFromCodeCoverage]
    public class BancoTabajaraDbContexto : DbContext
    {
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        
        public BancoTabajaraDbContexto() : base("BancoTabajaraBD_Apollo4")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        //public BancoTabajaraDbContexto(string connectionString) : base(connectionString)
        //{
        //    Configuration.LazyLoadingEnabled = false;
        //    Configuration.ProxyCreationEnabled = false;
        //}

        protected BancoTabajaraDbContexto(DbConnection connection) : base(connection, true) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }
    }
}
