using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Dominio
{
    public class ContaCorrente
    {
        private double _numero;
        private double _saldo;
        private Boolean _especial;
        private double _limite;
        private Cliente _titular;
        private List<Movimentacao> _movimentacoes = new List<Movimentacao>();
        
        public double Numero { get => _numero; set => _numero = value; }
        public bool Especial { get => _especial; set => _especial = value; }
        public double Limite { get => _limite; set => _limite = value; }
        public double Saldo { get => _saldo + Limite; set => _saldo = value; }
        public Cliente Titular { get => _titular; set => _titular = value; }

        #region Operações da Conta
        //Sacar
        public void Sacar(double valor)
        {
            if (Saldo >= valor)
            {
                _saldo -= valor;
                RegistrarMovimentacao(valor, "Debito");
            }
        }
        //Depositar
        public void Depositar(double valor)
        {
            _saldo += valor;
            RegistrarMovimentacao(valor, "Crédito");
        }
        //Transferir
        public void TransferirPara(ContaCorrente contaDestino, double valor)
        {
            this.Sacar(valor);
            contaDestino.Depositar(valor);
            this.RegistrarMovimentacao(valor, "Debito");
            contaDestino.RegistrarMovimentacao(valor, "Crédito");
        }
        //Extrato
        public string Extrato()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Número da Conta: " + Numero).AppendLine();
            sb.AppendFormat("Movimentações: ").AppendLine();

            foreach (Movimentacao movi in _movimentacoes)
            {
                if (movi != null)
                    sb.AppendFormat(movi.ObtemMovimentacao()).AppendLine(); ;
            }
            sb.AppendFormat("Saldo Atual: " + Saldo).AppendLine();
            return sb.ToString();
        }
        public void Validar()
        {
            if (Numero.Equals("") || Numero.Equals(null))
                throw new Exception("Numero Invalido!");
            if (Saldo.Equals("") || Saldo.Equals(null))
                throw new Exception("Saldo Invalido!");
            if (Limite.Equals("") || Limite.Equals(null))
                throw new Exception("Limite Invalido!");
            if (Titular.Equals(null))
                throw new Exception("Titular Invalido!!");
        }
        public override string ToString()
        {
            return ("Titular: " + Titular + " Numero: " + Numero + " / Saldo: R$" + Saldo);
        }
        #endregion

        #region Movimentações da conta

        private void RegistrarMovimentacao(double quantia, string tipoMovimentacao)
        {
            Movimentacao _movi = new Movimentacao(tipoMovimentacao, quantia);
            _movimentacoes.Add(_movi);
        }
        public List<Movimentacao> PegarMovimentacoes()
        {
            return _movimentacoes;
        }
        public Cliente TrazerTitular() {
            return _titular;
        }
        #endregion
    }
}
