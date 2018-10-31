using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Receivers;

namespace Projeto_NFe.Domain.Features.Addresses
{
    public class Address
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighbourhood { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public Country Country { get => Country.Brasil; }

    }
}
