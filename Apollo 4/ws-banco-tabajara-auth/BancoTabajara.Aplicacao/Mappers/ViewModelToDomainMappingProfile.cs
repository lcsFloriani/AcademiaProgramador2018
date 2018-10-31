using AutoMapper;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Commands;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.AlterarEstado;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Atualizar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Depositar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Registrar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Sacar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Transferir;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Contas;

namespace BancoTabajara.Aplicacao.Mappers
{
    class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Cliente
            CreateMap<ClienteRegistraCommand, Cliente>();
            CreateMap<ClienteAtualizaCommand, Cliente>();
            CreateMap<ClienteDeletaCommand, Cliente>();

            //Conta
            CreateMap<ContaRegistroCommand, Conta>();
            CreateMap<ContaAtualizaCommand, Conta>();
            CreateMap<ContaDepositoCommand, Conta>();
            CreateMap<ContaSaqueCommand, Conta>();
            CreateMap<ContaTransferenciaCommand, Conta>();
            CreateMap<ContaEstadoCommand, Conta>();
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

    }
}
