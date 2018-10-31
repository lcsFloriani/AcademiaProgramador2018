using AutoMapper;
using NDDResearch.Application.Features.Addresses.Commands;
using NDDResearch.Application.Features.Addresses.Queries;
using NDDResearch.Domain.Features.Addresses;

namespace NDDResearch.Application.Features.Addresses
{
    /// <summary>
    /// 
    ///  Realiza o mapeamento entre o Command/Query e a entidade de domínio Address
    ///  
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressRegisterCommand, Address>();
            CreateMap<AddressUpdateCommand, Address>();
            CreateMap<Address, AddressQuery>();
        }
    }
}
