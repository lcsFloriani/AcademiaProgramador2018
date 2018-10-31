using ExercicioContaCorrente.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioContaCorrente.Features.ContaCorrenteModule
{
    public partial class ExtratoContaCorrente : Form
    {
        public ExtratoContaCorrente(Conta conta)
        {
            InitializeComponent();
            ListaExtrato(conta);
        }

        public void ListaExtrato(Conta conta)
        {
            var extrato = conta.MostrarRegistros(conta.numero);
            foreach (Movimentacao registro in extrato)
            {
                ltbExtrato.Items.Add(registro);
            }
        }
    }
}
