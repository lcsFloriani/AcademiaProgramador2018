using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Emitters
{
    public class Emitter : IEntity
    {
        public long Id { get; set; }
        public string FantasyName { get; set; }
        public string CompanyName { get; set; }
        public Cnpj Cnpj { get; set; }
        public string StateRegistration {get;set;}
        public string MunicipalRegistration {get;set;}
        public Address Address { get; set; } 

        public virtual void Validate()
        {
            if(Address != null)
            {
                Address.Validate();
            } else
            {
                throw new EmitterAddressNullException();
            }

            if (string.IsNullOrEmpty(FantasyName))
                throw new EmitterFantasyNameNullOrEmptyException();

            if (string.IsNullOrEmpty(CompanyName))
                throw new EmitterCompanyNameNullOrEmptyException();

            if (Cnpj == null)
                throw new EmitterCnpjNullException();
            Cnpj.Validate();

            if (string.IsNullOrEmpty(StateRegistration))
                throw new EmitterStateRegistrationNullOrEmptyException();

            if (string.IsNullOrEmpty(MunicipalRegistration))
                throw new EmitterMunicipalRegistrationNullOrEmptyException();
        }

        public void SetCnpj(string value)
        {
            Cnpj = new Cnpj();
            Cnpj.Value = value;

            Cnpj.Validate();
        }
    }
}
