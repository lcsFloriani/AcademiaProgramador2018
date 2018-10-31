namespace ORM01.Infra.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ORM01.Infra.ContextORM>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ORM01.Infra.ContextORM";
        }

        protected override void Seed(ORM01.Infra.ContextORM context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
