using NDDResearch.Infra.Data.Contexts;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace NDDResearch.Infra.Data.Initializer
{
    /// <summary>
    /// Inicializador do Banco de dados.
    /// 
    /// Essa classe define a estratégia de inicializaçaõ do banco.
    /// 
    /// Foi alterado a interface de MigrateDatabaseToLatestVersion para IDatabaseInitializer, pois da forma antiga
    /// estava executando o Seed toda vez que instanciava a classe DbInitializer.
    /// Com essa nova implementação temos mais controle de quando executar a criação, atualização e o seed do banco.
    /// </summary>
    public class DbInitializer : IDatabaseInitializer<NDDResearchDbContext>
    {
        public void InitializeDatabase(NDDResearchDbContext context)
        {
            var configuration = new MigrationConfiguration();

            if (!context.Database.Exists())
            {
                context.Database.Create();
                configuration.CallSeed(context);
            }
            else if (!context.Database.CompatibleWithModel(true))
            {
                var migrator = new DbMigrator(configuration);

                if (migrator.GetPendingMigrations().Any())
                {
                    migrator.Update();
                }
            }
        }
    }
}
