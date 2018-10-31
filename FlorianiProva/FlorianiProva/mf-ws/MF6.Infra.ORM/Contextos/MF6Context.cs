using MF6.Domain.Funcionalidades.Impressoras;
using MF6.Domain.Funcionalidades.Toners;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MF6.Infra.ORM.Contexts
{
    public class MF6Context : DbContext
    {
        public MF6Context() : base("MF_WS_Floriani")
        {
            Configuration.LazyLoadingEnabled = true;
        }
        protected MF6Context(DbConnection connection) : base(connection, true) { }

        public DbSet<Impressora> Impressoras { get; set; }
        public DbSet<Toner> Toners { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try { return base.SaveChanges(); }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                        Console.WriteLine("- Propriedade: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                }
                throw;
            }
        }
    }
}
