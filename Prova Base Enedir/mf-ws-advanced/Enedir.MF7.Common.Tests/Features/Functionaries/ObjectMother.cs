using Enedir.MF7.Application.Features.Functionaries.Commands;
using Enedir.MF7.Application.Features.Functionaries.Querys;
using Enedir.MF7.Domain.Features.Functionaries;

namespace Enedir.MF7.Common.Tests.Features
{
    public partial class ObjectMother
    {
        public static Functionary GetFunctionaryDefault()
        {
            return new Functionary
            {
                FirstName = "Galise",
                LastName = "da Silva",
                User = "Fulano",
                Password = "123",
                Status = true,
                Office = OfficeEnum.Desenvolvedor
            };
        }

        public static Functionary GetFunctionarySeed()
        {
            return new Functionary
            {
                Id = 1,
                FirstName = "Galise",
                LastName = "da Silva",
                User = "Fulano",
                Password = "123",
                Status = true,
                Office = OfficeEnum.Desenvolvedor
            };
        }


        public static FunctionaryRegisterCommand GetFunctionaryRegisterCommand()
        {
            return new FunctionaryRegisterCommand
            {
                FirstName = "Galise",
                LastName = "da Silva",
                User = "Fulano",
                Password = "123",
                Status = true,
                Office = OfficeEnum.Desenvolvedor
            };
        }

        public static FunctionaryUpdateCommand GetFunctionaryUpdateCommand()
        {
            return new FunctionaryUpdateCommand
            {
                Id = 1,
                FirstName = "Galise",
                LastName = "da Silva",
                User = "Fulano",
                Password = "123",
                Status = true,
                Office = OfficeEnum.Desenvolvedor
            };
        }

        public static FunctionaryQuery GetFunctionaryQuery()
        {
            return new FunctionaryQuery(3);
        }

        public static FunctionaryDeleteCommand GetFunctionaryDeleteCommand()
        {
            return new FunctionaryDeleteCommand
            {
                Id = 1,
            };
        }
    }
}
