using ExercicioContaCorrente.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioContaCorrente.Features.ContaCorrenteModule
{
    public partial class SacarDepositarContaCorrente : Form
    {
        private string operacao;
        Movimentacao _movimentacao = new Movimentacao();

        public SacarDepositarContaCorrente()
        {
            InitializeComponent();
        }

        public Conta NovoSaque
        {
            get
            {
                double valor = double.Parse(txtWithdrawValue.Text);

                getValueFromWithdraw(valor);

                return _conta;
            }

            set
            {
                _conta = value;

                lblNumero.Text = _conta.numero.ToString();
                lblSaldo.Text = string.Format("R$: {0:n2}", _conta.saldo);
            }
        }

        public string Operacao
        {
            get
            {
                return operacao;
            }
            set
            {
                operacao = value;
            }
        }

        Conta _conta = new Conta();

        public void getValueFromWithdraw(double valor)
        {
            if (operacao == "Saque")
            {
                bool retornoSaque = _conta.Saca(valor, _conta.numero);

                if (retornoSaque)
                {
                    _movimentacao.Insert(_conta.numero, "Retirada", valor);

                    MessageBox.Show("Saque realizado com sucesso");
                }
                else
                {
                    MessageBox.Show("Não foi possível realizar o saque");
                }
            }
            else
            {
                _conta.Deposita(valor, _conta.numero);
                _movimentacao.Insert(_conta.numero, "Debitado", valor);

                MessageBox.Show("Depósito realizado com sucesso");
            }

        }

    }
}
