using GerenciadorProvas.WinApp.Features;
using Pizzaria.Application.Features.Produtos;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.WinApp.Common;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Features.Produtos
{
    public class ProdutoGerenciadorFormulario : GerenciadorFormulario<Produto, ProdutoServico>
    {
        public ProdutoGerenciadorFormulario(ProdutoServico servico) : base(servico)
        {
        }

        public override void Gravar()
        {
            ProdutoDialog dialog = new ProdutoDialog(_servico);
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _servico.Adicionar(dialog.Valor);
                CarregarListagem();

                MessageBox.Show("Produto salvo com sucesso no sistema!");
            }
        }

        public override void Editar()
        {
            ProdutoDialog dialog = new ProdutoDialog(_servico);
            dialog.Valor = controle.Valor;
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _servico.Atualizar(dialog.Valor);
                controle.LimparItemSelecionado();
                CarregarListagem();

                MessageBox.Show("Produto alterado com sucesso!");
            }
        }
        
        public override void Filtrar()
        {
        }

        public override EstadoBotoes ObtemEstadoBotoes()
        {
            return new EstadoBotoes
            {
                Gravar = true,
                Editar = true,
                Excluir = true,
                Filtrar = false
            };
        }
    }
}
