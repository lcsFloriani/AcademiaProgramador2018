using AutoMapper;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.ViewModels;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.ViewModels;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Contas;

namespace BancoTabajara.Aplicacao.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            //Cliente
            CreateMap<Cliente, ClienteViewModel>();

            //Conta
            CreateMap<Conta, ContaViewModel>();
            CreateMap<Conta, ContaExtratoViewModel>()
                .ForMember(dest => dest.NomeCliente, opt => opt.MapFrom(src => src.Cliente.Nome))
                .ForMember(dest => dest.SaldoDisponivel, opt => opt.MapFrom(src => src.Saldo))
                .ForMember(dest => dest.LimiteAtual, opt => opt.MapFrom(src => src.Limite));
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
