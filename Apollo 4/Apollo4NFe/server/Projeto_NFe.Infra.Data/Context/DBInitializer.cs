using Projeto_NFe.Infra.ORM.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Context
{
    public class DbInitializer : IDatabaseInitializer<ProjetoNFeContext>
    {
        public void InitializeDatabase(ProjetoNFeContext context)
        {
            var configuration = new Configuration();

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
