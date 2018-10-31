using AutoMapper;
using Projeto_NFe.Application.Features.Conveyors.Commands;
using Projeto_NFe.Application.Features.Conveyors.ViewModels;
using Projeto_NFe.Domain.Features.Conveyors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Conveyors
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ConveyorRegisterCommand, Conveyor>()
                .ForMember(vm => vm.Address, mo => mo.MapFrom(r => r.Address));

            CreateMap<Conveyor, ConveyorViewModel>();

            CreateMap<ConveyorUpdateCommand, Conveyor>()
                .ForMember(vm => vm.Address, mo => mo.MapFrom(r => r.Address));
        }
    }
}