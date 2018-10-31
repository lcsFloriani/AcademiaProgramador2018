using AutoMapper;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.AlterarEstado;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Atualizar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Deletar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Depositar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Registrar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Sacar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Transferir;
using BancoTabajara.Dominio.Funcionalidades.Contas;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas
{
    public static class ContaMapeador
    {
        public static Conta ConverterCommandParaConta(this ContaRegistroCommand command)
        {
            return Mapper.Map<ContaRegistroCommand, Conta>(command);
        }

        public static Conta ConverterCommandParaConta(this ContaAtualizaCommand command)
        {
            return Mapper.Map<ContaAtualizaCommand, Conta>(command);
        }

        public static Conta ConverterCommandParaConta(this ContaDeletaCommand command)
        {
            return Mapper.Map<ContaDeletaCommand, Conta>(command);
        }

        public static Conta ConverterCommandParaConta(this ContaSaqueCommand command)
        {
            return Mapper.Map<ContaSaqueCommand, Conta>(command);
        }

        public static Conta ConverterCommandParaConta(this ContaDepositoCommand command)
        {
            return Mapper.Map<ContaDepositoCommand, Conta>(command);
        }

        public static Conta ConverterCommandParaConta(this ContaTransferenciaCommand command)
        {
            return Mapper.Map<ContaTransferenciaCommand, Conta>(command);
        }

        public static Conta ConverterCommandParaConta(this ContaEstadoCommand command)
        {
            return Mapper.Map<ContaEstadoCommand, Conta>(command);
        }
    }
}
