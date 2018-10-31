using System.Linq;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using BancoTabajara.Dominio.Excecoes;
using BancoTabajara.Dominio.Enum;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.ViewModels;
using System.Collections.Generic;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Registrar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Atualizar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Deletar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.AlterarEstado;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Sacar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Depositar;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Commands.Transferir;
using BancoTabajara.Aplicacao.Funcionalidades.Contas.Querys;
using BancoTabajara.Dominio.Funcionalidades.Clientes;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas
{
    public class ContaServico : IContaServico
    {
        private IContaRepositorio _repositorio;
        private IClienteRepositorio _clienteRepositorio;


        public ContaServico(IContaRepositorio repositorio, IClienteRepositorio clienteRepositorio)
        {
            _repositorio = repositorio;
            _clienteRepositorio = clienteRepositorio;
        }

        public long Adicionar(ContaRegistroCommand command)
        {
            //conta.Validar();

            var conta = command.ConverterCommandParaConta();

            var cli = _clienteRepositorio.BuscarPorId(conta.ClienteId);

            if (cli == null)
                throw new NaoEncontradoExcecao();

            var novoConta = _repositorio.Adicionar(conta);

            return novoConta.Id;
        }

        public bool Atualizar(ContaAtualizaCommand command)
        {
            //if (conta.Id < _menorQue)
            //    throw new IdentificadorIndefinidoExcecao();

            //conta.Validar();

            //if (!_repositorio.VerificarNumeroConta(conta))
            //    throw new ContaNumeroContaAlteradoExcecao();

            var conta = command.ConverterCommandParaConta();

            return _repositorio.Atualizar(conta);
        }

        public Conta BuscarPorId(long id)
        {
            var ContaResultado = _repositorio.BuscarPorId(id);

            return ContaResultado;
        }

        public IQueryable<Conta> Listagem(ContaQuery query)
        {
            var lista = _repositorio.Listagem(query.Quantidade);

            return lista;
        }

        public bool Excluir(ContaDeletaCommand command)
        {
            //if (id < _menorQue)
            //    throw new IdentificadorIndefinidoExcecao();

            var contaDeletar = _repositorio.BuscarPorId(command.Id);

            return _repositorio.Excluir(contaDeletar);
        }

        public bool AlterarEstado(ContaEstadoCommand command)
        {
            //if (command.Id < _menorQue)
            //    throw new IdentificadorIndefinidoExcecao();

            var conta = _repositorio.BuscarPorId(command.Id);

            conta.Estado = command.EstadoConta;

            return _repositorio.AtualizarEstado(conta);
        }

        public bool Sacar(ContaSaqueCommand command)
        {
            //if (id < _menorQue)
            //    throw new IdentificadorIndefinidoExcecao();

            var conta = _repositorio.BuscarPorId(command.Id);

            conta.Sacar(command.ValorSaque);

            return _repositorio.AtualizarComMovimentacao(OperacaoContaEnum.SaqueOuDeposito, conta);
        }

        public bool Depositar(ContaDepositoCommand command)
        {
            Conta conta = _repositorio.BuscarPorId(command.Id);

            //if (id < _menorQue)
            //    throw new IdentificadorIndefinidoExcecao();

            conta.Depositar(command.ValorDeposito);

            return _repositorio.AtualizarComMovimentacao(OperacaoContaEnum.SaqueOuDeposito, conta);
        }

        public bool RealizarTransferencia(ContaTransferenciaCommand command)
        {
            //if (command.IdContaOrigem < _menorQue || command.IdContaDestino < _menorQue)
            //    throw new IdentificadorIndefinidoExcecao();

            Conta conta = _repositorio.BuscarPorId(command.IdContaOrigem);
            Conta destinatario = _repositorio.BuscarPorId(command.IdContaDestino);

            conta.RealizarTransferencia(command.ValorTransferencia, destinatario);

            return _repositorio.AtualizarComMovimentacao(OperacaoContaEnum.Transferencia, conta, destinatario);
        }

        public Conta GerarExtrato(long id)
        {
            //if (id < _menorQue)
            //    throw new IdentificadorIndefinidoExcecao();

            Conta conta = _repositorio.BuscarPorId(id);

            return conta;
        }
    }
}
