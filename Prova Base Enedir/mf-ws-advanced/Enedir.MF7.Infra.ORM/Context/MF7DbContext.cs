using Enedir.MF7.Domain.Features.Functionaries;
using Enedir.MF7.Domain.Features.Outgoing;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics.CodeAnalysis;

namespace Enedir.MF7.Infra.ORM.Context
{
    [ExcludeFromCodeCoverage]
    public class MF7DbContext : DbContext
    {
        public MF7DbContext(): base("MF_WSA_Enedir")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected MF7DbContext(DbConnection connection) : base(connection, true) { }

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

        public DbSet<Functionary> Functionaries { get; set; }
        public DbSet<Outgo> Outgoing { get; set; }

    }
}
