using BancoTabajara.Infra.ORM.Contexto;
using BancoTabajara.Infra.ORM.Migrations;
using System.Data.Entity.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace BancoTabajara.Infra.ORM.Inicializar
{
    [ExcludeFromCodeCoverage]
    public class InicializadorDB
    {
        private readonly BancoTabajaraDbContexto _context;

        public InicializadorDB(BancoTabajaraDbContexto context)
        {
            _context = context;
        }

        public void Configurar()
        {
            if (_context.Database.Exists())
                return;

            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }
    }
}
