using AutoMapper;
using Projeto_NFe.Domain.Features.Addresses;

namespace Projeto_NFe.Application.Features.Addresses
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<AddressCommand, Address>();
            CreateMap<Address, AddressViewModel>();
        }
	}
}
