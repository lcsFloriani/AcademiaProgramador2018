using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExercicioContaCorrente.Domain;

namespace ExercicioContaCorrente.Features.ContaCorrenteModule
{
    public partial class ContaCorrenteControl : UserControl
    {
        public ContaCorrenteControl()
        {
            InitializeComponent();
        }

        public void PopularListagemContasCorrentes(List<Conta> contas)
        {
            listContasCorrente.Items.Clear();

            foreach (Conta c in contas)
            {
                listContasCorrente.Items.Add(c);
            }
        }

        public Conta GetConta()
        {
            return listContasCorrente.SelectedItem as Conta;
        }
    }
}
