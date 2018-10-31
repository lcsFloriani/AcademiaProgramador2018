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

namespace Projeto_NFe.Domain.Features.Receivers
{
    public class Receiver : IEntity
    {
        public long Id { get; set; }
        public PersonType Type { get; set; }
        public string NameCompanyName { get; set; }
        public Cpf Cpf { get; set; }
        public Cnpj Cnpj { get; set; }
        public string StateRegistration { get; set; }
        public Address Address { get; set; }

        public virtual void Validate()
        {

            if (Address == null)
                throw new ReceiverAddressNullException();
            else
                Address.Validate();


            switch (Type)
            {
                case PersonType.PHYSICAL:

                    if (string.IsNullOrEmpty(NameCompanyName))
                        throw new ReceiverNameNullOrEmptyException();

                    if (Cpf == null)
                        throw new ReceiverCpfNullException();

                    Cpf.Validate();
                    break;

                case PersonType.LEGAL:
                    if (string.IsNullOrEmpty(StateRegistration))
                        throw new ReceiverStateRegistrationNullOrEmptyException();

                    if (string.IsNullOrEmpty(NameCompanyName))
                        throw new ReceiverNameNullOrEmptyException();

                    if (Cnpj == null)
                        throw new ReceiverCnpjNullException();
                    
                    Cnpj.Validate();
                    break;
                default:
                    throw new ReceiverTypeDefaultException();


                    //inscriçao estadual nao pode ser vasia
                    //transportadora
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
