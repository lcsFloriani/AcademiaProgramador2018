using System;
using Enedir.MF7.Application.Features.Functionaries.Commands;
using Enedir.MF7.Application.Features.Functionaries.Querys;
using Enedir.MF7.Application.Features.Outgoing.Commands;
using Enedir.MF7.Application.Features.Outgoing.Querys;
using Enedir.MF7.Domain.Features.Functionaries;
using Enedir.MF7.Domain.Features.Outgoing;

namespace Enedir.MF7.Common.Tests.Features
{
    public partial class ObjectMother
    {
        public static Outgo GetOutgoDefault()
        {
            return new Outgo
            {
                Description = "Viagem",
                Date = DateTime.Now.AddYears(-1),
                Functionary = new Functionary {
                    FirstName = "Thiago",
                    LastName = "Sartor",
                    User = "sartor",
                    Password = "123456",
                    Status = true,
                    Office = OfficeEnum.Desenvolvedor
                },
                Price = 753.36,
                OutgoType = OutgoTypeEnum.Viagem

            };
        }

        public static Outgo GetOutgoSeed()
        {
            return new Outgo
            {
                Id = 1,
                Description = "Viagem",
                Date = DateTime.Now.AddYears(-1),
                Functionary = new Functionary
                {
                    FirstName = "Thiago",
                    LastName = "Sartor",
                    User = "sartor",
                    Password = "123456",
                    Status = true,
                    Office = OfficeEnum.Desenvolvedor
                },
                Price = 753.36,
                OutgoType = OutgoTypeEnum.Viagem
            };
        }


        public static OutgoRegisterCommand GetOutgoRegisterCommand()
        {
            return new OutgoRegisterCommand
            {
                Description = "Viagem",
                Date = DateTime.Now.AddYears(-1),
                FunctionaryId = 1,
                Price = 753.36,
                OutgoType = OutgoTypeEnum.Viagem
            };
        }

        public static OutgoQuery GetOutgoQuery()
        {
            return new OutgoQuery(3);
        }

        public static OutgoDeleteCommand GetOutgoDeleteCommand()
        {
            return new OutgoDeleteCommand
            {
                Id = 1,
            };
        }
    }
}
