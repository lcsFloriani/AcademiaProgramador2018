using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
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
        public static Conveyor GetConveyor(Address address)
        {
            return new Conveyor
            {
                NameCompanyName = "José da Silva",
                Address = address,
                FreightResponsibility = FreightResponsibility.EMITTER
            };
        }

        public static Conveyor GetPhysicalConveyorWithoutCpf(Address address)
        {
            return new Conveyor
            {
                NameCompanyName = "José da Silva",
                Address = address,
                Type = PersonType.PHYSICAL,
                FreightResponsibility = FreightResponsibility.EMITTER
            };
        }

        public static Conveyor GetPhysicalConveyor(Address address, Cpf cpf)
        {
            return new Conveyor
            {
                NameCompanyName = "José da Silva",
                Address = address,
                Type = PersonType.PHYSICAL,
                FreightResponsibility = FreightResponsibility.EMITTER,
                Cpf = cpf
        };
        }

        public static Conveyor GetPhysicalConveyorWithNameNullOrEmpty(Address address, Cpf cpf)
        {
            return new Conveyor
            {
                NameCompanyName = "",
                Cpf = cpf,
                Address = address,
                Type = PersonType.PHYSICAL,
                FreightResponsibility = FreightResponsibility.EMITTER
            };
        }

        public static Conveyor GetConveyorWithoutAddress()
        {
            return new Conveyor
            {
                NameCompanyName = "José da Silva",
                FreightResponsibility = FreightResponsibility.EMITTER
            };
        }

        public static Conveyor GetLegalConveyorWithoutCnpj(Address address)
        {
            return new Conveyor
            {
                NameCompanyName = "Empresa XY",
                Address = address,
                Type = PersonType.LEGAL,
                FreightResponsibility = FreightResponsibility.RECEIVER
            };
        }

        public static Conveyor GetLegalConveyorWithCnpj(Address address, Cnpj cnpj)
        {
            return new Conveyor
            {
                NameCompanyName = "Empresa XY",
                Cnpj = cnpj,
                Address = address,
                Type = PersonType.LEGAL,
                FreightResponsibility = FreightResponsibility.RECEIVER
            };
        }

        public static Conveyor GetLegalConveyorWithCompanyNameNullOrEmpty(Address address, Cnpj cnpj)
        {
            return new Conveyor
            {
                NameCompanyName = "",
                Type = PersonType.LEGAL,
                Cnpj = cnpj,
                Address = address,
                FreightResponsibility = FreightResponsibility.RECEIVER
            };
        }
    }
}
