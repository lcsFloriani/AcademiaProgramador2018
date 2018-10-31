using NDDResearch.Domain.Features.Addresses;
using NDDResearch.Domain.Features.Customers;
using NDDResearch.Domain.Features.Sites;
using NDDResearch.Domain.Users;
using System.Data.Common;
using System.Data.Entity;

namespace NDDResearch.Infra.Data.Contexts
{
    /// <summary>
    /// Contexto de banco de dados do NDDResearch
    /// </summary>
    public class NDDResearchDbContext : DbContext
    {
        public NDDResearchDbContext(string connection = "Name=NDDResearchDBContext") : base(connection)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// Test Only.
        /// 
        /// Esse construtor deve ser chamado pela classe de teste que herdará desse contexto.
        /// Para classes externas esse construtor não está acessível (protected).
        /// 
        /// </summary>
        /// <param name="connection"></param>
        protected NDDResearchDbContext(DbConnection connection) : base(connection, true) { }

        // Stores por entidade do contexto
        public DbSet<Address> Adresses { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Site> Sites { get; set; }

        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Método que é executado quando o modelo de banco de dados está sendo criado pelo EF.
        /// Útil para realizar configurações
        /// </summary>
        /// <param name="modelBuilder">É o construtor de modelos do EF</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Busca todos as configurações criadas nesse assembly, que são as classes que são derivadas de EntityTypeConfiguration
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            // Chama o OnModelCreating do EF para dar continuidade na criação do modelo
            base.OnModelCreating(modelBuilder);
        }
    }
}
