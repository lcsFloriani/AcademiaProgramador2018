namespace Enedir.MF7.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Enedir.MF7.Domain.Features.Functionaries;
    using Enedir.MF7.Domain.Features.Outgoing;
    using Enedir.MF7.Infra.ORM.Context;

    internal sealed class Configuration : DbMigrationsConfiguration<MF7DbContext>
    {
        private Functionary functionary1;
        private Functionary functionary2;
        private Outgo outgo1;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Enedir.MF7.Infra.ORM.Context.MF7DbContext";
        }

        protected override void Seed(MF7DbContext context)
        {
            CreateFunctionary(context);
            CreateOutgo(context);

            context.SaveChanges();
        }

        private void CreateFunctionary(MF7DbContext context)
        {
            functionary1 = new Functionary
            {
                FirstName = "Carla",
                LastName = "Rosa",
                User = "r16",
                Password = "12345",
                Status = true,
                Office = OfficeEnum.Desenvolvedor
            };

            functionary2 = new Functionary
            {
                FirstName = "William",
                LastName = "dos anjos",
                User = "will",
                Password = "abc",
                Status = true,
                Office = OfficeEnum.Tester
            };

            context.Functionaries.Add(functionary1);
            context.Functionaries.Add(functionary2);
        }

        private void CreateOutgo(MF7DbContext context)
        {

            outgo1 = new Outgo
            {
                Description = "Viagem",
                Date = DateTime.Now.AddDays(-1),
                Functionary = functionary2,
                Price = 753.36,
                OutgoType = OutgoTypeEnum.Viagem

            };

            context.Outgoing.Add(outgo1);
        }
    }
}
