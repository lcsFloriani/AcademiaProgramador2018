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
    public partial class ContaCorrenteExtratoDialog : Form
    {
        public ContaCorrenteExtratoDialog(ContaCorrente conta)
        {
            InitializeComponent();
            txtExtrato.Text = conta.Extrato();
            label1.Text = "Extrato da conta N° " + conta.Numero;
        }
    }
}
