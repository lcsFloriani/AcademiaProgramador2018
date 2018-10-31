using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;

namespace Projeto_NFe.Domain.Features.Receivers
{
    public class Receiver
    {
        public long Id { get; set; }
        public PersonType Type { get; set; }
        public string NameCompanyName { get; set; }
        public string CpfCnpj { get; set; }
        public string StateRegistration { get; set; }
        public Address Address { get; set; }

    }
}
