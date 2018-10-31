using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics.CodeAnalysis;

using Floriani.MF7.Dominio.Funcionalidades.Funcionarios;
using Floriani.MF7.Dominio.Funcionalidades.Gastos;

namespace Floriani.MF7.Infra.ORM.Contexto
{
	[ExcludeFromCodeCoverage]
	public class FlorianiMF7Contexto : DbContext
	{
		public FlorianiMF7Contexto(string connection = "Name=MF_WSA_FLORIANI") : base(connection)
			=>	Configuration.LazyLoadingEnabled = true;		

		protected FlorianiMF7Contexto(DbConnection connection) : base(connection, true) { }

		public DbSet<Funcionario> Funcionarios { get; set; }
		public DbSet<Gasto> Gastos { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}

		public override int SaveChanges()
		{
			try { return base.SaveChanges(); } catch (DbEntityValidationException e) {
				foreach (var eve in e.EntityValidationErrors) {
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
