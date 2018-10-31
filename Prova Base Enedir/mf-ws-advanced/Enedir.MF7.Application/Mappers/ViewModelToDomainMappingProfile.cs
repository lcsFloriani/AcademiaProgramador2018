using AutoMapper;

using Enedir.MF7.Application.Features.Functionaries.Commands;
using Enedir.MF7.Application.Features.Outgoing.Commands;
using Enedir.MF7.Domain.Features.Functionaries;
using Enedir.MF7.Domain.Features.Outgoing;

namespace Enedir.MF7.Application.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<FunctionaryRegisterCommand, Functionary>();
            CreateMap<FunctionaryUpdateCommand, Functionary>();
            CreateMap<FunctionaryDeleteCommand, Functionary>();
            CreateMap<FunctionaryChangeStatusCommand, Functionary>();

            CreateMap<OutgoRegisterCommand, Outgo>();
            CreateMap<OutgoDeleteCommand, Outgo>();
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
    }
}
