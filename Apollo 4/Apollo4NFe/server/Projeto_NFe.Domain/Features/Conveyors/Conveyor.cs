using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Addresses;

namespace Projeto_NFe.Domain.Features.Conveyors
{
    public class Conveyor
    {
        public long Id { get; set; }
        public PersonType PersonType { get; set; }
        public string NameCompanyName { get; set; }
        public FreightResponsibility FreightResponsibility { get; set; }
        public string CpfCnpj { get; set; }
        public Address Address { get; set; }

    }
}
