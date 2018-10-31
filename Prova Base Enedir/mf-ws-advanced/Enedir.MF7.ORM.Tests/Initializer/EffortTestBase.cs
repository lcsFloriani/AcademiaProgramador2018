using Effort;
using Effort.Provider;
using Enedir.MF7.Domain.Features.Functionaries;
using Enedir.MF7.Domain.Features.Outgoing;
using Enedir.MF7.ORM.Tests.Context;
using NUnit.Framework;
using System;

namespace Enedir.MF7.ORM.Tests.Initializer
{
    public class EffortTestBase
    {
        protected DbContextFake context;
        private Functionary functionary1;
        private Functionary functionary2;
        private Outgo outgo1;

        [OneTimeSetUp]
        public void InitializeOneTime()
        {
            EffortProviderConfiguration.RegisterProvider();
        }

        [SetUp]
        public void Init()
        {
            EffortProviderFactory.ResetDb();

            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            context = new DbContextFake(connection);

            // Seed DataBase
            CreateFunctionary();
            CreateOutgo();

            context.SaveChanges();
        }

        private void CreateFunctionary()
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

        private void CreateOutgo()
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
