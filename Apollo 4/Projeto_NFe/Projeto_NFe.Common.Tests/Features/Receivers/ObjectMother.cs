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
        public static Receiver GetReceiver(Address address)
        {
            return new Receiver()
            {
                NameCompanyName = "Test",
                StateRegistration = "Test",
                Address = address
            };
        }

        public static Receiver GetReceiverPhysical(Address address)
        {
            return new Receiver()
            {
                NameCompanyName = "Test",
                StateRegistration = "Test",
                Address = address,
                Type = PersonType.PHYSICAL
            };
        }

        public static Receiver GetReceiverPhysicalWithCpf(Address address, Cpf cpf)
        {
            return new Receiver()
            {
                NameCompanyName = "Test",
                StateRegistration = "Test",
                Address = address,
                Cpf = cpf,
                Type = PersonType.PHYSICAL
            };
        }

        public static Receiver GetReceiverLegalWithoutCnpj(Address address)
        {
            return new Receiver()
            {
                NameCompanyName = "Test",
                StateRegistration = "Test",
                Address = address,
                Type = PersonType.LEGAL
            };
        }
        public static Receiver GetReceiverLegalWithCnpj(Address address, Cnpj cnpj)
        {
            return new Receiver()
            {
                NameCompanyName = "Test",
                StateRegistration = "Test",
                Address = address,
                Cnpj = cnpj,
                Type = PersonType.LEGAL
            };
        }

        public static Receiver GetReceiverPhysicalWithNameEmpty(Address address)
        {
            return new Receiver()
            {
                NameCompanyName = "",
                StateRegistration = "Test",
                Address = address,
                Type = PersonType.PHYSICAL
            };
        }

        public static Receiver GetReceiverLegalWithCompanyNameEmpty(Address address)
        {
            return new Receiver()
            {
                NameCompanyName = "",
                StateRegistration = "Test",
                Address = address,
                Type = PersonType.LEGAL
            };
        }

        public static Receiver GetReceiverWithStateRegistrationEmpty(Address address)
        {
            return new Receiver()
            {
                NameCompanyName = "Test",
                StateRegistration = "",
                Address = address,
                Type = PersonType.LEGAL
            };
        }

        public static Receiver GetReceiverWithoutAddress()
        {
            return new Receiver()
            {
                NameCompanyName = "Test",
                StateRegistration = "Test"
            };
        }
    }
}
