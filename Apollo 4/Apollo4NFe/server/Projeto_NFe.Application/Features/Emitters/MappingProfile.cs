using AutoMapper;
using Projeto_NFe.Application.Features.Emitters.Commands;
using Projeto_NFe.Application.Features.Emitters.ViewModels;
using Projeto_NFe.Domain.Features.Emitters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Emitters
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmitterRegisterCommand, Emitter>();
            CreateMap<Emitter, EmitterViewModel>();
            CreateMap<EmitterUpdateCommand, Emitter>();
        }
    }
}
