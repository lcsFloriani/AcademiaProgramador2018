using Projeto_NFe.Domain.Enums;

namespace Projeto_NFe.Application.Features.Addresses
{
    public class AddressCommand
	{
		public string Street { get; set; }
		public int Number { get; set; }
		public string Neighbourhood { get; set; }
		public string City { get; set; }
		public State State { get; set; }
	}
}
