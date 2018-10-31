using Banco.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco.WindowsApp.Features.ContaCorrenteModule
{
    public partial class ContaCorrenteSacarDepositarDialog : Form
    {
        ContaCorrente contaSelecionada;
        public ContaCorrenteSacarDepositarDialog(ContaCorrente conta)
        {
            contaSelecionada = conta;
            InitializeComponent();
            labInfo.Text = "Conta N° " + contaSelecionada.Numero + "\nSaldo: R$" + contaSelecionada.Saldo;
            
        }
        public double ValorOperacao
        {
            get
            {
                double valor = Convert.ToDouble(txtSacar.Text);
                return valor;
            }
        }
    }
}
