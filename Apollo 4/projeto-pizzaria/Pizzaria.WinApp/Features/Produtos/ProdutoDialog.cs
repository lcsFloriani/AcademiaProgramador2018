using Pizzaria.Application.Features.Produtos;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Produtos;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Produtos
{
    public partial class ProdutoDialog : Form
    {
        private Produto _produto;
        private IProdutoServico _servico;
        private string str = "";

        public ProdutoDialog(IProdutoServico servico)
        {
            InitializeComponent();
            Inicializacao();

            _servico = servico;
        }

        public void Inicializacao()
        {
            cbxTipoProduto.DataSource = Enum.GetValues(typeof(TipoProdutoEnum));
        }

        public Produto Valor
        {
            get
            {
                if (_produto == null)
                    _produto = new Produto();

                _produto.Descricao = txtDescricao.Text;
                _produto.Tipo = (TipoProdutoEnum)Enum.Parse(typeof(TipoProdutoEnum), cbxTipoProduto.SelectedItem.ToString());
                _produto.Tamanho = (TamanhoProdutoEnum)Enum.Parse(typeof(TamanhoProdutoEnum), cbxTamanhoProduto.SelectedItem.ToString());
                _produto.Valor = ObterValorNumerico(txtValor.Text);

                return _produto;
            }
            set
            {
                _produto = value;

                txtDescricao.Text = _produto.Descricao;
                cbxTipoProduto.SelectedItem = _produto.Tipo;
                cbxTamanhoProduto.SelectedItem = _produto.Tamanho;
                txtValor.Text = _produto.Valor.ToString();
            }
        }

        private double ObterValorNumerico(string numero)
        {
            double valor = 0;

            if (!string.IsNullOrEmpty(numero))
                valor = Convert.ToDouble(txtValor.Text, CultureInfo.InvariantCulture);

            return valor;
        }

        private void cbxTipoProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valorTipoCombobox = (TipoProdutoEnum)cbxTipoProduto.SelectedItem;

            bool habilitarTamanho = valorTipoCombobox == TipoProdutoEnum.Pizza ||
                                 valorTipoCombobox == TipoProdutoEnum.Adicional ? true : false;

            gerenciarComboBox(habilitarTamanho, valorTipoCombobox);
        }

        public void gerenciarComboBox(bool habilitarTamanho, TipoProdutoEnum tipoProduto)
        {
            cbxTamanhoProduto.Enabled = habilitarTamanho;
            cbxTamanhoProduto.Items.Clear();

            if (tipoProduto == TipoProdutoEnum.Calzone)
            {
                cbxTamanhoProduto.Items.Add(TamanhoProdutoEnum.Padrao);
                cbxTamanhoProduto.SelectedItem = TamanhoProdutoEnum.Padrao;
            }
            else if (tipoProduto == TipoProdutoEnum.Bebida)
            {
                cbxTamanhoProduto.Items.Add(TamanhoProdutoEnum.Litro);
                cbxTamanhoProduto.SelectedItem = TamanhoProdutoEnum.Litro;
            }
            else
            {
                cbxTamanhoProduto.Items.Add(TamanhoProdutoEnum.Pequena);
                cbxTamanhoProduto.Items.Add(TamanhoProdutoEnum.Media);
                cbxTamanhoProduto.Items.Add(TamanhoProdutoEnum.Grande);
                cbxTamanhoProduto.SelectedItem = TamanhoProdutoEnum.Pequena;
            }
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Valor.Validar();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            int KeyCode = e.KeyValue;

            if (!Numerico(KeyCode))
            {
                e.Handled = true;
                return;
            }
            else
            {
                e.Handled = true;
            }
            if (((KeyCode == 8) || (KeyCode == 46)) && (str.Length > 0))
            {
                str = str.Substring(0, str.Length - 1);
            }
            else if (!((KeyCode == 8) || (KeyCode == 46)))
            {
                str = str + Convert.ToChar(KeyCode);
            }
            if (str.Length == 0)
            {
                txtValor.Text = "";
            }
            if (str.Length == 1)
            {
                txtValor.Text = "0.0" + str;
            }
            else if (str.Length == 2)
            {
                txtValor.Text = "0." + str;
            }
            else if (str.Length > 2)
            {
                txtValor.Text = str.Substring(0, str.Length - 2) + "." +
                                str.Substring(str.Length - 2);
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private bool Numerico(int Val)
        {
            return ((Val >= 48 && Val <= 57) || (Val == 8) || (Val == 46));
        }
    }
}
