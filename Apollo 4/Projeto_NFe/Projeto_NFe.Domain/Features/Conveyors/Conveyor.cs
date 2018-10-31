using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.Commons.Interfaces;
using Projeto_NFe.Infra.CPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Conveyors
{
    public class Conveyor : IEntity
    {
        public long Id { get; set; }
        public PersonType Type { get; set; }
        public string NameCompanyName { get; set; }
        public FreightResponsibility FreightResponsibility { get; set; }
        public Cpf Cpf { get; set; }
        public Cnpj Cnpj { get; set; }
        public Address Address { get; set; }

        public virtual void Validate()
        {
            if (FreightResponsibility == FreightResponsibility.DEFAULT)
                throw new ConveyorFreightResponsibilityDefaultException();

            if (Address == null)
                throw new ConveyorAddressNullException();

            Address.Validate();

            switch (Type)
            {
                case PersonType.PHYSICAL:

                    if (string.IsNullOrEmpty(NameCompanyName))
                        throw new ConveyorNameNullOrEmptyException();

                    if (Cpf == null)
                        throw new ConveyorCpfNullException();

                    Cpf.Validate();

                    break;

                case PersonType.LEGAL:

                    if (string.IsNullOrEmpty(NameCompanyName))
                        throw new ConveyorCompanyNameNullOrEmptyException();

                    if (Cnpj == null)
                        throw new ConveyorCnpjNullException();

                    Cnpj.Validate();

                    break;
                default:
                    throw new ConveyorTypeDefaultException();
            }

        }

        public void SetCpf(string value)
        {
            Cpf = new Cpf();
            Cpf.Value = value;

            Cpf.Validate();
            Type = PersonType.PHYSICAL;
        }

        public void SetCnpj(string value)
        {
            Cnpj = new Cnpj();
            Cnpj.Value = value;

            Cnpj.Validate();
            Type = PersonType.LEGAL;
        }
    }
}
