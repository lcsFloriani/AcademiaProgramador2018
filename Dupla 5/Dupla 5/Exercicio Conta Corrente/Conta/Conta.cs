using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioContaCorrente.Domain
{
    public class Conta
    {
        public int id;
        public int numero;
        public bool especial;
        public double saldo;
        public Cliente cliente;
        public double limite;

        Movimentacao _movimentacao = new Movimentacao();

        public Conta()
        {
        }

        public bool Saca(double quantia, int numero)
        {
            if (saldo + limite < quantia)
                return false;
            else
            {
                double novoSaldo = saldo - quantia;
                this.saldo = novoSaldo;
                return true;
            }
        }

        public bool Transfere(Conta contaDestino, double quantia, int numero)
        {
            bool realizouSaque = this.Saca(quantia, numero);

            if (realizouSaque)
            {
                contaDestino.Deposita(quantia, numero);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Deposita(double quantia, int numero)
        {
            this.saldo += quantia;
        }

        public string Saldo()
        {
            return saldo.ToString();
        }

        public List<Movimentacao> MostrarRegistros(int numero)
        {
            return _movimentacao.GetAll(numero);
        }

        public void Valida()
        {
            
        }

        public override string ToString()
        {
            return string.Format("Numero conta: {0} - Saldo R$: {1:n2}", numero, saldo);
        }
    }
}
