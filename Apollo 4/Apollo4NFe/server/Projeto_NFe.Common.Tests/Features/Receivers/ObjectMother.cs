using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base 
{
    public partial class ObjectMother
    {
        public static Receiver GetReceiverPhysical(Address address)
        {
            return new Receiver()
            {
                NameCompanyName = "Test",
                StateRegistration = "Test",
                Address = address,
                CpfCnpj = "58026616073",
                Type = PersonType.PHYSICAL
            };
        }

        public static Receiver GetReceiverLegal(Address address)
        {
            return new Receiver()
            {
                NameCompanyName = "Test",
                StateRegistration = "Test",
                Address = address,
                CpfCnpj = "73029790000101",
				Type = PersonType.LEGAL
            };
        }
    }
}
