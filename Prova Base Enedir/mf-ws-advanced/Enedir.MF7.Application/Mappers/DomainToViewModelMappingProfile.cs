using AutoMapper;

using Enedir.MF7.Application.Features.Functionaries.ViewModels;
using Enedir.MF7.Application.Features.Outgoing.ViewModels;
using Enedir.MF7.Domain.Features.Functionaries;
using Enedir.MF7.Domain.Features.Outgoing;

namespace Enedir.MF7.Application.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Functionary, FunctionaryViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.GetFullName()));

            CreateMap<Outgo, OutgoViewModel>()
                .ForMember(dest => dest.FunctionaryName, opt => opt.MapFrom(src => src.Functionary.GetFullName()));
        }

        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

    }
}
