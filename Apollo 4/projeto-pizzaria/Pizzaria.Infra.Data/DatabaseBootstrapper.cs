using Pizzaria.Infra.Data.Migrations;
using System.Data.Entity.Migrations;


namespace Pizzaria.Infra.Data
{
    public class DatabaseBootstrapper
    {
        private readonly DataContext _context;

        public DatabaseBootstrapper(DataContext context)
        {
            _context = context;
        }

        public void Configure()
        {
            if (_context.Database.Exists())
                return;

            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }
    }
}
