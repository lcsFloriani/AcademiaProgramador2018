using Pizzaria.Application.Features.CEPs;
using Pizzaria.Application.Features.Clientes;
using Pizzaria.Application.Features.Pedidos;
using Pizzaria.Application.Features.Produtos;
using Pizzaria.Infra.Cep;
using Pizzaria.Infra.Data;
using Pizzaria.Infra.Data.Features.Clientes;
using Pizzaria.Infra.Data.Features.Pedidos;
using Pizzaria.Infra.Data.Features.Produtos;
using Pizzaria.WinApp.Common;
using Pizzaria.WinApp.Features.Clientes;
using Pizzaria.WinApp.Features.Pedidos;
using Pizzaria.WinApp.Features.Produtos;
using System;
using System.Windows.Forms;


namespace Pizzaria.WinApp
{
    public partial class PrincipalForm : Form
    {
        //Contexto do Banco
        private DataContext _contexto;

        //Repositorio
        private ClienteSQLRepositorio _clienteRepositorio;
        private ProdutoSQLRepository _produtoRepositorio;
        private PedidoSQLRepositorio _pedidoRepositorio;
        private CepRepositorio _cepRepositorio;

        //Servicos
        private ClienteServico _clienteServico;
        private ProdutoServico _produtoServico;
        private PedidoServico _pedidoServico;
        private CepServico _cepServico;

        //Gerenciador Tela
        private IGerenciadorFormulario _gerenciador;
        private PedidoGerenciadorFormulario _pedidoGerenciadorFormulario;
        private ClienteGerenciadorFormulario _clienteGerenciadorFormulario;
        private ProdutoGerenciadorFormulario _produtoGerenciadorFormulario;

        public PrincipalForm()
        {
            InitializeComponent();
            CarregandoDependencia();
        }

        private void CarregandoDependencia()
        {
            _contexto = new DataContext();
            new DatabaseBootstrapper(_contexto).Configure();

            _clienteRepositorio = new ClienteSQLRepositorio(_contexto);
            _produtoRepositorio = new ProdutoSQLRepository(_contexto);
            _pedidoRepositorio = new PedidoSQLRepositorio(_contexto);
            _cepRepositorio = new CepRepositorio();

            _clienteServico = new ClienteServico(_clienteRepositorio);
            _produtoServico = new ProdutoServico(_produtoRepositorio);
            _pedidoServico = new PedidoServico(_pedidoRepositorio);
            _cepServico = new CepServico(_cepRepositorio);

            _produtoGerenciadorFormulario = new ProdutoGerenciadorFormulario(_produtoServico);
            _clienteGerenciadorFormulario = new ClienteGerenciadorFormulario(_clienteServico, _cepServico);
            _pedidoGerenciadorFormulario = new PedidoGerenciadorFormulario(_pedidoServico, _clienteServico, _produtoServico);
        }

        private void CarregarCadastro(IGerenciadorFormulario gerenciador, string selecionado)
        {
            _gerenciador = gerenciador;

            UserControl listagem = _gerenciador.PegarControle();
            _gerenciador.CarregarListagem();

            EstadoBotoes estadoBotoes = _gerenciador.ObtemEstadoBotoes();
            TituloBotoes tituloBotoes = _gerenciador.ObtemTituloBotoes(selecionado);
            ModificarEstadoBotoes(estadoBotoes);
            ModificarTituloBotoes(tituloBotoes);

            listagem.Dock = DockStyle.Fill;

            panelControl.Controls.Clear();
            _gerenciador.LimparItemSelecionado();

            panelControl.Controls.Add(listagem);
        }

        private void ModificarEstadoBotoes(EstadoBotoes estadoBotoes)
        {
            ToolStripbtnGravar.Enabled = estadoBotoes.Gravar;
            ToolStripbtnEditar.Enabled = estadoBotoes.Editar;
            ToolStripbtnExcluir.Enabled = estadoBotoes.Excluir;
            toolStripFiltro.Enabled = estadoBotoes.Filtrar;
        }

        private void ModificarTituloBotoes(TituloBotoes tituloBotoes)
        {
            ToolStripbtnGravar.Text = tituloBotoes.Gravar;
            ToolStripbtnEditar.Text = tituloBotoes.Editar;
            ToolStripbtnExcluir.Text = tituloBotoes.Excluir;
            toolStripFiltro.Text = tituloBotoes.Filtrar;
        }

        private void ToolStripbtnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Gravar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripbtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Editar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripbtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.ItemSelecionado();
                var message = MessageBox.Show("Deseja excluir esse registro?", "Atenção!", MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    _gerenciador.Excluir();
                    MessageBox.Show("Registro deletado com sucesso!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                _gerenciador.Filtrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(_pedidoGerenciadorFormulario, "Pedido");
        }

        private void ClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(_clienteGerenciadorFormulario, "Cliente");
        }

        private void ProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(_produtoGerenciadorFormulario, "Produto");
        }
    }
}
