using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Infra.Metodo_Extensao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Pedidos
{
    public partial class PedidoStatusDialog : Form
    {
        private Pedido _pedido;

        public PedidoStatusDialog()
        {
            InitializeComponent();
            Inicializacao();
        }

        public Pedido Valor
        {
            get
            {
                _pedido.StatusPedido = (StatusPedidoEnum)Enum.Parse(typeof(StatusPedidoEnum), cbxStatusPedido.SelectedItem.ToString());

                return _pedido;
            }
            set
            {
                _pedido = value;
                
                cbxStatusPedido.SelectedItem = _pedido.StatusPedido;
                txtDataPedidoEnviado.Text = _pedido.Data.ToString("MM/dd/yyyy HH:mm");
                txtTempo.Text = VerificaTempoPedido();
                listBox.Items.AddRange(_pedido.ItensPedidos.ToArray());
                MudarStatusDeProcesso(_pedido.StatusPedido);
            }
        }

        private string VerificaTempoPedido()
        {
            string tempo = " - / -";

            if(_pedido.StatusPedido != StatusPedidoEnum.Entregue)
                tempo = _pedido.Data.CompararDataComDataAtualRetornarDiferenca().ToString("HH:mm:ss");

            return tempo;
        }

        public void Inicializacao()
        {
            cbxStatusPedido.DataSource = Enum.GetValues(typeof(StatusPedidoEnum));
        }

        private void cbxStatusPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusPedidoEnum status = (StatusPedidoEnum)Enum.Parse(typeof(StatusPedidoEnum), cbxStatusPedido.SelectedItem.ToString());
            MudarStatusDeProcesso(status);
        }

        private void MudarStatusDeProcesso(StatusPedidoEnum status)
        {
            switch (status)
            {
                case StatusPedidoEnum.AguardandoMontagem:
                    lblAguardandoMontagem.ForeColor = System.Drawing.Color.LightGreen;
                    lblEmMontagem.ForeColor = System.Drawing.Color.Red;
                    lblAguardandoEntrega.ForeColor = System.Drawing.Color.Red;
                    lblEmEntrega.ForeColor = System.Drawing.Color.Red;
                    lblEntregue.ForeColor = System.Drawing.Color.Red;
                    break;
                case StatusPedidoEnum.EmMontagem:
                    lblAguardandoMontagem.ForeColor = System.Drawing.Color.LightGreen;
                    lblEmMontagem.ForeColor = System.Drawing.Color.LightGreen;
                    lblAguardandoEntrega.ForeColor = System.Drawing.Color.Red;
                    lblEmEntrega.ForeColor = System.Drawing.Color.Red;
                    lblEntregue.ForeColor = System.Drawing.Color.Red;
                    break;
                case StatusPedidoEnum.AguardandoEntrega:
                    lblAguardandoMontagem.ForeColor = System.Drawing.Color.LightGreen;
                    lblEmMontagem.ForeColor = System.Drawing.Color.LightGreen;
                    lblAguardandoEntrega.ForeColor = System.Drawing.Color.LightGreen;
                    lblEmEntrega.ForeColor = System.Drawing.Color.Red;
                    lblEntregue.ForeColor = System.Drawing.Color.Red;
                    break;
                case StatusPedidoEnum.EmEntrega:
                    lblAguardandoMontagem.ForeColor = System.Drawing.Color.LightGreen;
                    lblEmMontagem.ForeColor = System.Drawing.Color.LightGreen;
                    lblAguardandoEntrega.ForeColor = System.Drawing.Color.LightGreen;
                    lblEmEntrega.ForeColor = System.Drawing.Color.LightGreen;
                    lblEntregue.ForeColor = System.Drawing.Color.Red;
                    break;
                case StatusPedidoEnum.Entregue:
                    lblAguardandoMontagem.ForeColor = System.Drawing.Color.LightGreen;
                    lblEmMontagem.ForeColor = System.Drawing.Color.LightGreen;
                    lblAguardandoEntrega.ForeColor = System.Drawing.Color.LightGreen;
                    lblEmEntrega.ForeColor = System.Drawing.Color.LightGreen;
                    lblEntregue.ForeColor = System.Drawing.Color.LightGreen;
                    break;
            }
        }
    }
}
