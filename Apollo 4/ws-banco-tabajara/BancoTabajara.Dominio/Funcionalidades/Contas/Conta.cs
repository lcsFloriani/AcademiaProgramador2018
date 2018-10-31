using BancoTabajara.Dominio.Enum;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Dominio.Funcionalidades.Extratos;
using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BancoTabajara.Dominio.Funcionalidades.Contas
{
    public class Conta
    {
        private double _menorQue = 0;

        public long Id { get; set; }
        public int NumeroConta { get; set; }
        public double Saldo { get; set; }
        public bool Estado { get; set; }
        public double Limite { get; set; }
        public virtual List<Movimentacao> Movimentacoes { get; set; }

        public long ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public Conta()
        {
            Movimentacoes = new List<Movimentacao>();
        }

        public void Validar()
        {
            if (NumeroConta < 1)
                throw new ContaNumeroContaNegativoExcecao();

            if (Cliente == null)
                throw new ContaClienteNullExcecao();
        }

        public double SaldoTotal
        {
            get
            {
                return Saldo + Limite;
            }
        }

        public void Sacar(double valor)
        {
            if (valor <= _menorQue)
                throw new ContaValorNegativoOuZeroExcecao();

            if (SaldoTotal < valor)
                throw new ContaSaldoIndisponivelExcecao();
            
            Saldo -= valor;

            CriarMovimentacao(TipoOperacaoEnum.Debito, valor);
        }

        public void Depositar(double valor)
        {
            if (valor <= _menorQue)
                throw new ContaValorNegativoOuZeroExcecao();

            Saldo += valor;

            CriarMovimentacao(TipoOperacaoEnum.Credito, valor);
        }

        public void RealizarTransferencia(double valor, Conta destinatario)
        {
            Sacar(valor);

            destinatario.Depositar(valor);
        }

        private void CriarMovimentacao(TipoOperacaoEnum tipoOperacao, double valor)
        {
            Movimentacao movimentacao = new Movimentacao
            {
                Data = DateTime.Now,
                TipoOperacao = tipoOperacao,
                Valor = valor,
                Conta = this
            };

            Movimentacoes.Add(movimentacao);
        }

        public Extrato GerarExtrato()
        {
            return new Extrato
            {
                NumeroConta = this.NumeroConta,
                DataEmissao = DateTime.Now,
                NomeCliente = this.Cliente.Nome,
                Movimentacoes = this.Movimentacoes,
                SaldoDisponivel = this.Saldo,
                LimiteAtual = this.Limite
            };
        }
    }
}