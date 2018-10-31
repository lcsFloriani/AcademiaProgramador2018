using Pizzaria.Application.Features.CEPs;
using Pizzaria.Application.Features.Clientes;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Clientes
{
    public partial class ClienteDialog : Form
    {
        private Endereco _endereco;
        private Cliente _cliente;

        private ClienteServico _servico;
        private CepServico _cepServico;

        public ClienteDialog(ClienteServico servico, CepServico cepServico)
        {
            InitializeComponent();
            Inicializacao();

            _servico = servico;
            _cepServico = cepServico;
        }

        public Cliente Valor
        {
            get
            {
                if (_endereco == null)
                    _endereco = new Endereco();

                _endereco.Logradouro = txtLogradouro.Text;
                _endereco.Bairro = txtBairro.Text;
                _endereco.Cidade = txtCidade.Text;
                _endereco.UF = txtUF.Text;
                _endereco.Cep = txtCep.Text;
                _endereco.Numero = Convert.ToInt32(Math.Round(nudNumero.Value, 0));
                _endereco.Complemento = txtComplemento.Text;

                if (_cliente == null)
                    _cliente = new Cliente();

                _cliente.Nome = txtNome.Text;
                _cliente.Telefone = txtTelefone.Text;
                _cliente.TipoCliente = (TipoClienteEnum)Enum.Parse(typeof(TipoClienteEnum), cbxTipoCliente.SelectedItem.ToString());
                _cliente.NumeroDocumento = txtNumeroDocumento.Text;
                _cliente.Endereco = _endereco;

                return _cliente;
            }
            set
            {
                _cliente = value;
                _endereco = _cliente.Endereco;

                txtNome.Text = _cliente.Nome;
                txtTelefone.Text = _cliente.Telefone;
                txtNumeroDocumento.Text = _cliente.NumeroDocumento;
                cbxTipoCliente.SelectedItem = _cliente.TipoCliente;

                txtLogradouro.Text = _endereco.Logradouro;
                txtBairro.Text = _endereco.Bairro;
                txtCidade.Text = _endereco.Cidade;
                txtUF.Text = _endereco.UF;
                txtCep.Text = _endereco.Cep;
                nudNumero.Value = _endereco.Numero;
                txtComplemento.Text = _endereco.Complemento;
            }
        }

        public void Inicializacao()
        {
            cbxTipoCliente.DataSource = Enum.GetValues(typeof(TipoClienteEnum));
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarOuAtualizar();
        }

        public void SalvarOuAtualizar()
        {
            try
            {
                Valor.Validar();

                if (_servico.VerificarClienteComTelefoneRepetido(_cliente)){
                    throw new ClienteTelefoneRepetidoExcecao();
                }
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoClienteEnum tipo = (TipoClienteEnum)Enum.Parse(typeof(TipoClienteEnum), cbxTipoCliente.SelectedItem.ToString());

            switch (tipo)
            {
                case TipoClienteEnum.Juridico:
                    lblNumeroDocumento.Text = "Cnpj:";
                    break;
                case TipoClienteEnum.Fisico:
                    lblNumeroDocumento.Text = "Cpf:";
                    break;
            }
        }

        private void buttonBuscaCep_Click(object sender, EventArgs e)
        {
            try
            {

                Endereco endereco = _cepServico.BuscarCep(txtCep.Text);

                txtLogradouro.Text = endereco.Logradouro;
                txtComplemento.Text = endereco.Complemento;
                txtBairro.Text = endereco.Bairro;
                txtCidade.Text = endereco.Cidade;
                txtUF.Text = endereco.UF;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
