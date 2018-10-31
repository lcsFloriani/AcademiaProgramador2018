using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Domain.Features.Taxes;

namespace Projeto_NFe.Infra.ORM.Context
{
	public class ProjetoNFeContext : DbContext {
		public ProjetoNFeContext() : base( "Apollo4_NFeDb" )
		{
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;
           
        }

		protected ProjetoNFeContext(DbConnection connection) : base( connection, true ) { }

        public ProjetoNFeContext(string connectionStringName) : base(string.Format("name={0}",connectionStringName)) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.AddFromAssembly( System.Reflection.Assembly.GetExecutingAssembly() );
			base.OnModelCreating( modelBuilder );
		}

		public override int SaveChanges()
		{
			try {
				return base.SaveChanges();
			} catch (DbEntityValidationException e) {
				var newException = new FormattedDbEntityValidationException( e );
				throw newException;
			}
		}

		public DbSet<Conveyor> Conveyors { get; set; }
		public DbSet<Emitter> Emitters { get; set; }
        public DbSet<InvoiceInProcess> InvoicesInProcess { get; set; }
        public DbSet<ItemInvoice> ItemInvoices { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Receiver> Receivers { get; set; }
	}
}
