using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Application.Features.Receivers.Commands;
using Projeto_NFe.Application.Features.Receivers.ViewModels;
using Projeto_NFe.Domain.Features.Receivers;
using AutoMapper;

namespace Projeto_NFe.Application.Features.Receivers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ReceiverRegisterCommand, Receiver>()
				.ForMember(vm => vm.Address, mo => mo.MapFrom( r => r.Address));

			CreateMap<Receiver, ReceiverViewModel>()
                .ForMember(vm => vm.Type, mo => mo.MapFrom(r => (int) r.Type));

            CreateMap<ReceiverUpdateCommand, Receiver>()
				.ForMember( vm => vm.Address, mo => mo.MapFrom( r => r.Address ) );
		}

	}
}
