using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Infra.CNPJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Emitter GetEmitter(Address address, Cnpj cnpj) {
            return new Emitter()
            {
                FantasyName = "asd",
                CompanyName = "Jequiti",
                MunicipalRegistration = "2039102",
                StateRegistration = "3123123",
                Address = address,
                Cnpj = cnpj
            };
        }

        public static Emitter getEmitterInvalidFantasyName(Address address, Cnpj cnpj) {
            return new Emitter()
            {
                FantasyName = "",
                Cnpj = cnpj,
                CompanyName = "Jequiti",
                MunicipalRegistration = "2039102",
                StateRegistration = "3123123",
                Address = address
            };
        }

        public static Emitter getEmitterInvalidCnpj(Address address,Cnpj cnpj)
        {
            return new Emitter()
            {
                FantasyName = "asd",
                Cnpj = cnpj,
                CompanyName = "Jequiti",
                MunicipalRegistration = "2039102",
                StateRegistration = "3123123",
                Address = address
            };
        }

        public static Emitter getEmitterInvalidCompanyName(Address address, Cnpj cnpj)
        {
            return new Emitter()
            {
                FantasyName = "asd",
                Cnpj = cnpj,
                CompanyName = "",
                MunicipalRegistration = "2039102",
                StateRegistration = "3123123",
                Address = address
            };
        }
        public static Emitter getEmitterInvalidMunicipalRegistration(Address address, Cnpj cnpj)
        {
            return new Emitter()
            {
                FantasyName = "asd",
                Cnpj = cnpj,
                CompanyName = "Jequiti",
                MunicipalRegistration = "",
                StateRegistration = "3123123",
                Address = address
            };
        }
        public static Emitter getEmitterInvalidStateRegistration(Address address, Cnpj cnpj)
        {
            return new Emitter()
            {
                FantasyName = "asd",
                Cnpj = cnpj,
                CompanyName = "Jequiti",
                MunicipalRegistration = "2039102",
                StateRegistration = "",
                Address = address
            };
        }

        public static Emitter getEmitterInvalidAddress(Cnpj cnpj)
        {
            return new Emitter()
            {
                FantasyName = "asd",
                Cnpj = cnpj,
                CompanyName = "Jequiti",
                MunicipalRegistration = "2039102",
                StateRegistration = "3123123"                
            };
        }
    }
}
