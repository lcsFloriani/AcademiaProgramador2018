using Pizzaria.Application.Features.Clientes;
using Pizzaria.Application.Features.Produtos;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;
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
    public partial class PedidoDialog : Form
    {
        private Pedido _entidade = new Pedido();

        private ClienteServico _clienteServico;
        private ProdutoServico _produtoServico;
        private List<Produto> _pizzas;
        private Cliente _cliente;
        private ItemPedido _itemSelecionado;
        private TamanhoProdutoEnum _tamanho;
        private ItemPedido _item;

        public PedidoDialog(ClienteServico clienteServico, ProdutoServico produtoServico)
        {
            InitializeComponent();

            _clienteServico = clienteServico;
            _produtoServico = produtoServico;

            InicializacaoComponenteTela();
        }

        public Pedido Valor
        {
            get
            {
                _entidade.Cliente = _cliente;
                _entidade.FormaPagamento = (FormaPagamentoEnum)Enum.Parse(typeof(FormaPagamentoEnum), cbxCartao.SelectedItem.ToString());
                _entidade.Responsavel = txtResponsavel.Text;
                _entidade.Setor = txtSetor.Text;
                _entidade.EmitirNFe = cbEmitirNFe.Checked;
                _entidade.Documento = txtDocumento.Text;
                _entidade.Observacao = rtxObservacao.Text;
                _entidade.Data = DateTime.Now;

                return _entidade;
            }
        }

        private void InicializacaoComponenteTela()
        {
            cbxCartao.DataSource = Enum.GetValues(typeof(FormaPagamentoEnum));

            cbxTamanho.Items.Add(TamanhoProdutoEnum.Pequena);
            cbxTamanho.Items.Add(TamanhoProdutoEnum.Media);
            cbxTamanho.Items.Add(TamanhoProdutoEnum.Grande);

            List<Produto> calzones = _produtoServico.BuscarProdutoPorTamanhoETipo(TamanhoProdutoEnum.Padrao, TipoProdutoEnum.Calzone);
            cbxSaborCalzone.Items.AddRange(calzones.ToArray());
            cbxSaborCalzone.DisplayMember = "Descricao";

            List<Produto> bebidas = _produtoServico.BuscarProdutoPorTamanhoETipo(TamanhoProdutoEnum.Litro, TipoProdutoEnum.Bebida);
            cbxBebida.Items.AddRange(bebidas.ToArray());
            cbxBebida.DisplayMember = "Descricao";
        }

        private void btnProcuraPorTelefone_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTelefone.Text))
            {
                BuscarClientePorTelefone();
            }
            else
            {
                MessageBox.Show("Informe o telefone do cliente!");
            }

        }


        private void txtTelefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtTelefone.Text))
                {
                    BuscarClientePorTelefone();
                }
                else
                {
                    MessageBox.Show("Informe o telefone do cliente para realizar a procura!");
                }
            }
        }

        private void BuscarClientePorTelefone()
        {
            string telefone = txtTelefone.Text;

            _cliente = _clienteServico.BuscarPorTelefone(telefone);

            if (_cliente != null)
            {
                txtClienteNome.Text = _cliente.Nome;
                txtLogradouro.Text = _cliente.Endereco.Logradouro;
                txtBairro.Text = _cliente.Endereco.Bairro;
                txtNumero.Text = _cliente.Endereco.Numero.ToString();
                txtComplemento.Text = _cliente.Endereco.Complemento;

                if (_cliente.TipoCliente == TipoClienteEnum.Juridico)
                {
                    txtResponsavel.Enabled = true;
                    txtSetor.Enabled = true;
                    lblDocumento.Text = "Número CPNJ:";
                }
                else
                {
                    txtResponsavel.Enabled = false;
                    txtSetor.Enabled = false;
                    lblDocumento.Text = "Número CPF:";
                }
            }
            else
            {
                LimparCliente();
                MessageBox.Show("Não existe nenhum cliente com esse telefone!");
            }
        }

        private void LimparCliente()
        {
            lblDocumento.Text = "  Documento:";
            txtClienteNome.Clear();
            txtLogradouro.Clear();
            txtBairro.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtResponsavel.Enabled = false;
            txtSetor.Enabled = false;
        }

        private void cbxTamanho_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tamanho = (TamanhoProdutoEnum)Enum.Parse(typeof(TamanhoProdutoEnum), cbxTamanho.SelectedItem.ToString());
            _pizzas = _produtoServico.BuscarProdutoPorTamanhoETipo(_tamanho, TipoProdutoEnum.Pizza);

            if (_pizzas.Count == 0)
            {
                cbxSabor1.Items.Clear();
                cbxSabor1.ResetText();
                cbMeia.Checked = false;
                cbxSabor2.Enabled = false;
                cbxSabor2.Items.Clear();
                cbxSabor2.ResetText();
                cbBorda.Checked = false;
                cbxSaborBorda.Enabled = false;
                cbxSaborBorda.Items.Clear();
                cbxSaborBorda.ResetText();
                MessageBox.Show("Nenhuma pizza encontrada com esse tamanho!");
            }
            else
            {
                cbMeia.Checked = false;
                cbxSabor2.Enabled = false;
                cbxSabor2.Items.Clear();
                cbxSabor2.ResetText();
                cbBorda.Checked = false;
                cbxSaborBorda.Enabled = false;
                cbxSaborBorda.Items.Clear();
                cbxSaborBorda.ResetText();
                cbxSabor1.Items.AddRange(_pizzas.ToArray());
                cbxSabor1.DisplayMember = "Descricao";
            }

        }

        private void cbMeia_CheckedChanged(object sender, EventArgs e)
        {
            bool meia = cbMeia.Checked;

            if (meia)
            {
                cbxSabor2.Enabled = true;
                cbxSabor2.Items.AddRange(_pizzas.ToArray());
                cbxSabor2.DisplayMember = "Descricao";
            }
            else
            {
                cbxSabor2.Enabled = false;
                cbxSabor2.Items.Clear();
                cbxSabor2.ResetText();
            }
        }

        private void cbBorda_CheckedChanged(object sender, EventArgs e)
        {
            bool borda = cbBorda.Checked;

            if (borda)
            {

                List<Produto> adicionais = _produtoServico.BuscarProdutoPorTamanhoETipo(_tamanho, TipoProdutoEnum.Adicional);

                cbxSaborBorda.Enabled = true;

                if (adicionais.Count == 0)
                {
                    cbxSaborBorda.Items.Clear();
                    cbxSaborBorda.ResetText();
                    MessageBox.Show("Nenhum adicional encontrado com esse tamanho!");
                }
                else
                {
                    cbxSaborBorda.Items.AddRange(adicionais.ToArray());
                    cbxSaborBorda.DisplayMember = "Descricao";
                }
            }
            else
            {
                cbxSaborBorda.Enabled = false;
                cbxSaborBorda.Items.Clear();
                cbxSaborBorda.ResetText();
            }
        }

        private void cbEmitirNFe_CheckedChanged(object sender, EventArgs e)
        {
            bool emitir = cbEmitirNFe.Checked;

            if (emitir)
            {
                txtDocumento.Enabled = true;
                txtDocumento.Text = _cliente == null ? "" : _cliente.NumeroDocumento;
            }
            else
            {
                txtDocumento.Enabled = false;
                txtDocumento.Clear();
            }

        }

        private void btnAdicionarPizza_Click(object sender, EventArgs e)
        {
            int quantidade = Convert.ToInt32(nudQuantidadePizza.Value);
            Produto sabor1 = cbxSabor1.SelectedItem as Produto;

            if (sabor1 != null)
            {
                var message = MessageBox.Show("Deseja adicionar essa pizza na lista de pedidos?", "Atenção!", MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    try
                    {
                        Produto sabor2 = null;
                        Produto adicional = null;

                        if (cbMeia.Checked)
                        {
                            sabor2 = cbxSabor2.SelectedItem as Produto;
                        }

                        if (cbBorda.Checked)
                        {
                            adicional = cbxSaborBorda.SelectedItem as Produto;
                        }


                        if (_itemSelecionado == null)
                        {
                            _item = new ItemPedido(sabor1, sabor2, adicional, quantidade);
                            _entidade.AdicionarItem(_item);
                        }
                        else
                        {
                            List<ItemPedido> items = _entidade.ItensPedidos as List<ItemPedido>;

                            int indice = items.IndexOf(_itemSelecionado);

                            _itemSelecionado.PrimeiroProduto = sabor1;
                            _itemSelecionado.SegundoProduto = sabor2;
                            _itemSelecionado.Adicional = adicional;

                            items.RemoveAt(indice);
                            items.Insert(indice, _itemSelecionado);
                        }

                        lblValorTotal.Text = _entidade.ValorTotal.ToString();
                        listPedidos.Items.Clear();
                        listPedidos.Items.AddRange(_entidade.ItensPedidos.ToArray());
                        LimparTabPizza();
                    }
                    catch (NegocioExcecao ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione o sabor 1 de pizza!");
            }
        }

        private void btnAdicionarCalzone_Click(object sender, EventArgs e)
        {
            int quantidade = Convert.ToInt32(nudQuantidadeCalzone.Value);
            Produto calzone = cbxSaborCalzone.SelectedItem as Produto;

            if (calzone != null)
            {
                var message = MessageBox.Show("Deseja adicionar esse calzone na lista de pedidos?", "Atenção!", MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    try
                    {
                        _item = new ItemPedido(calzone, quantidade);
                        _entidade.AdicionarItem(_item);

                        lblValorTotal.Text = _entidade.ValorTotal.ToString();
                        listPedidos.Items.Clear();
                        listPedidos.Items.AddRange(_entidade.ItensPedidos.ToArray());
                        LimparTabCalzone();
                    }
                    catch (NegocioExcecao ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um sabor de calzone!");
            }
        }

        private void btnAdicionarBebida_Click(object sender, EventArgs e)
        {
            int quantidade = Convert.ToInt32(nudQuantidadeBebida.Value);
            Produto bebida = cbxBebida.SelectedItem as Produto;

            if (bebida != null)
            {
                var message = MessageBox.Show("Deseja adicionar essa bebida na lista de pedidos?", "Atenção!", MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    try
                    {
                        _item = new ItemPedido(bebida, quantidade);
                        _entidade.AdicionarItem(_item);

                        lblValorTotal.Text = _entidade.ValorTotal.ToString();
                        listPedidos.Items.Clear();
                        listPedidos.Items.AddRange(_entidade.ItensPedidos.ToArray());
                        LimparTabBebida();
                    }
                    catch (NegocioExcecao ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma bebida!");
            }
        }

        private void listPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _itemSelecionado = listPedidos.SelectedItem as ItemPedido;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (_itemSelecionado == null)
            {
                MessageBox.Show("Selecione um item para remover na lista!");
            }
            else
            {
                var message = MessageBox.Show("Deseja remover esse item?", "Atenção!", MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    List<ItemPedido> itens = listPedidos.Items.Cast<ItemPedido>().ToList();
                    int indice = itens.IndexOf(_itemSelecionado);
                    itens.RemoveAt(indice);
                    _entidade.ItensPedidos = itens;

                    listPedidos.Items.Clear();

                    if (_entidade.ItensPedidos.Count > 0)
                    {
                        listPedidos.Items.AddRange(_entidade.ItensPedidos.ToArray());
                        lblValorTotal.Text = _entidade.ValorTotal.ToString();
                    }
                    else
                    {
                        lblValorTotal.Text = "0.00";
                    }
                    _itemSelecionado = null;

                    MessageBox.Show("Item removido com sucesso!");
                }
            }
        }

        public void LimparTabPizza()
        {
            //Combobox de merda.
            cbxTamanho.Items.Clear();
            cbxTamanho.ResetText();
            cbxTamanho.Items.Add(TamanhoProdutoEnum.Pequena);
            cbxTamanho.Items.Add(TamanhoProdutoEnum.Media);
            cbxTamanho.Items.Add(TamanhoProdutoEnum.Grande);

            cbxSabor1.Items.Clear();
            cbxSabor1.ResetText();
            cbMeia.Checked = false;
            cbxSabor2.Enabled = false;
            cbxSabor2.Items.Clear();
            cbxSabor2.ResetText();
            cbBorda.Checked = false;
            cbxSaborBorda.Enabled = false;
            cbxSaborBorda.Items.Clear();
            cbxSaborBorda.ResetText();
            nudQuantidadePizza.Value = 1;
        }

        public void LimparTabCalzone()
        {
            cbxSaborCalzone.ResetText();
            cbxSaborCalzone.SelectedItem = null;
            nudQuantidadeCalzone.Value = 1;
        }

        public void LimparTabBebida()
        {
            cbxBebida.ResetText();
            cbxBebida.SelectedItem = null;
            nudQuantidadeBebida.Value = 1;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Limpar()
        {
            txtTelefone.Clear();
            listPedidos.Items.Clear();
            rtxObservacao.Clear();
            cbxCartao.SelectedIndex = 0;
            cbEmitirNFe.Checked = false;
            txtDocumento.Clear();
            lblDocumento.Text = "  Documento:";

            LimparCliente();
            LimparTabPizza();
            LimparTabCalzone();
            LimparTabBebida();

            _entidade = new Pedido();
        }
    }
}
