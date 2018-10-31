using ExercicioContaCorrente.Domain;
using ExercicioContaCorrente.Infra.Data;
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
    public partial class TransferirContaCorrente : Form
    {
        public TransferirContaCorrente(Conta conta)
        {
            InitializeComponent();

            _conta = conta;

            ListContas();
        }

        Conta _conta = new Conta();
        Conta _contaTransferencia = new Conta();
        ContaCorrenteMem _contaMemoria = new ContaCorrenteMem();
        Movimentacao _movimentacao = new Movimentacao();

        public Conta ContaOrigem
        {
            get
            {
                double valor = double.Parse(txtValor.Text);

                getValueFromTransfer(valor, _conta.numero, _contaTransferencia);

                return _conta;
            }
        }

        public Conta ContaDestino
        {
            get
            {
                return _contaTransferencia;
            }
        }

        private void ListContas()
        {
            cbTrasfereContas.Items.Clear();

            List<Conta> list = new List<Conta>();

            list = _contaMemoria.GetAll();

            foreach (var item in list)
            {
                if (item.numero != _conta.numero)
                {
                    cbTrasfereContas.Items.Add(item);
                }
            }
        }

        public void getValueFromTransfer(double valor, int numero, Conta contaTransferencia)
        {
            bool resultadoTransferencia = _conta.Transfere(contaTransferencia, valor, numero);

            if (resultadoTransferencia == true)
            {
                try
                {
                    _movimentacao.Insert(_conta.numero, "Transferencia", valor);
                    _movimentacao.Insert(_contaTransferencia.numero, "Debitado (transferencia)", valor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Transferencia realizada com sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao realizar transferencia");
            }

        }

        private void cbTrasfereContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            _contaTransferencia = cbTrasfereContas.SelectedItem as Conta;
        }
    }
}