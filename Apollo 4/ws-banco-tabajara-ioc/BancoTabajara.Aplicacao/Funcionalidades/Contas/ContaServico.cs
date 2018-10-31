using System.Linq;
using BancoTabajara.Dominio.Funcionalidades.Contas;
using BancoTabajara.Dominio.Excecoes;
using BancoTabajara.Aplicacao.Funcionalidades.Extratos;
using BancoTabajara.Dominio.Enum;
using BancoTabajara.Dominio.Funcionalidades.Extratos;

namespace BancoTabajara.Aplicacao.Funcionalidades.Contas
{
    public class ContaServico : IContaServico
    {
        private IContaRepositorio _repositorio;

        private static long _menorQue = 1;

        public ContaServico(IContaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public long Adicionar(Conta conta)
        {
            conta.Validar();

            var novoConta = _repositorio.Adicionar(conta);

            return novoConta.Id;
        }

        public bool Atualizar(Conta conta)
        {
            if (conta.Id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            conta.Validar();
            
            if (!_repositorio.VerificarNumeroConta(conta))
                throw new ContaNumeroContaAlteradoExcecao();

            return _repositorio.Atualizar(conta);
        }

        public ContaDTO BuscarPorId(long id)
        {
            return BuscarContaPorId(id).ConverterParaDTO();
        }

        public IQueryable<ContaDTO> Listagem(int quantidade)
        {
            return _repositorio.Listagem(quantidade).ConverterParaListaDTO();
        }

        public bool Excluir(long id)
        {
            if (id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            Conta c = BuscarContaPorId(id);

            return _repositorio.Excluir(c);
        }

        public bool AlterarEstado(long id, bool estado)
        {
            if (id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            Conta conta = BuscarContaPorId(id);

            conta.Estado = estado;

            return _repositorio.AtualizarEstado(conta);
        }

        public bool Sacar(long id, double valor)
        {
            if (id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            Conta conta = BuscarContaPorId(id);
            
            conta.Sacar(valor);

            return _repositorio.AtualizarComMovimentacao(OperacaoContaEnum.SaqueOuDeposito, conta);
        }

        public bool Depositar(long id, double valor)
        {
            Conta conta = BuscarContaPorId(id);

            if (id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            conta.Depositar(valor);

            return _repositorio.AtualizarComMovimentacao(OperacaoContaEnum.SaqueOuDeposito, conta);
        }

        public bool RealizarTransferencia(long idConta, long idDestinatario, double valor)
        {
            if (idConta < _menorQue || idDestinatario < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            Conta conta = BuscarContaPorId(idConta);
            Conta destinatario = BuscarContaPorId(idDestinatario);

            conta.RealizarTransferencia(valor, destinatario);

            return _repositorio.AtualizarComMovimentacao(OperacaoContaEnum.Transferencia, conta, destinatario);
        }

        public ExtratoDTO GerarExtrato(long id)
        {
            if (id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            Conta conta = _repositorio.BuscarPorId(id);

            Extrato extrato = conta.GerarExtrato();

            return extrato.ConverterParaDTO();
        }

        public Conta BuscarContaPorId(long id)
        {
            if (id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            return _repositorio.BuscarPorId(id);
        }
    }
}
