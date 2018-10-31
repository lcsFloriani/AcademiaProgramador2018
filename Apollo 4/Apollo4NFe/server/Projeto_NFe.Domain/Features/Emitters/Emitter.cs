using Projeto_NFe.Domain.Features.Addresses;

namespace Projeto_NFe.Domain.Features.Emitters
{
    public class Emitter
    {
        public long Id { get; set; }
        public string FantasyName { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string StateRegistration {get;set;}
        public string MunicipalRegistration {get;set;}
        public Address Address { get; set; } 

    }
}
