using AutoMapper;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Commands;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.ViewModels;
using BancoTabajara.Dominio.Funcionalidades.Clientes;

namespace BancoTabajara.Aplicacao.Funcionalidades.Clientes
{
    public static class ClienteMapeador
    {
        public static ClienteViewModel ConverterParaViewModel(this Cliente cliente)
        {
           return Mapper.Map<Cliente, ClienteViewModel>(cliente);
        }

        public static Cliente ConverterParaObjeto(this ClienteRegistraCommand command)
        {
            return Mapper.Map<ClienteRegistraCommand, Cliente>(command);
        }

        public static Cliente ConverterParaObjeto(this ClienteAtualizaCommand command)
        {
            return Mapper.Map<ClienteAtualizaCommand, Cliente>(command);
        }

        public static Cliente ConverterParaObjeto(this ClienteDeletaCommand command)
        {
            return Mapper.Map<ClienteDeletaCommand, Cliente>(command);
        }
    }
}
