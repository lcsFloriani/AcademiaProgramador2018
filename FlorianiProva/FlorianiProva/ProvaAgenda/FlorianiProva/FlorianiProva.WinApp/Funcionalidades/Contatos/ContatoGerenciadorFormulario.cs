using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlorianiProva.Aplicacao;
using FlorianiProva.Dominio.Funcionalidades.Contatos;
namespace FlorianiProva.WinApp.Funcionalidades.Contatos
{
    public class ContatoGerenciadorFormulario : GerenciadorFormulario
    {
        private readonly ContatoService _contatoService;
        private ContatoControl _contatoControl;

        public ContatoGerenciadorFormulario(ContatoService contatoService) {
            _contatoService = contatoService;
        }
        public override void Adicionar()
        {
            ContatoDialog contatoDialog = new ContatoDialog(_contatoService, "Cadastrar Contato", "Cadastrar");
            DialogResult result = contatoDialog.ShowDialog();

            ListarContatos();

        }

        public override void AtualizarLista()
        {
            ListarContatos();
        }

        public override UserControl CarregarListagem()
        {
            if (_contatoControl == null)
                _contatoControl = new ContatoControl();

            return _contatoControl;
        }

        public override void Editar()
        {
            if (_contatoControl.ObtemContatoSelecionado() != null)
            {
                ContatoDialog dialog = new ContatoDialog(_contatoService, "Editar Contato", "Editar", _contatoControl.ObtemContatoSelecionado());
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _contatoService.Editar(_contatoControl.ObtemContatoSelecionado());
                }

                ListarContatos();
            }
            else
            {
                MessageBox.Show("Selecione um contato!");
            }
        }

        public override void Excluir()
        {
            Contato contatoSelecionado = _contatoControl.ObtemContatoSelecionado();

            if (contatoSelecionado != null)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir o contato "
                    + contatoSelecionado.Nome, "Excluir Contato",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        _contatoService.Deletar(contatoSelecionado);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    ListarContatos();
                }
            }
            else
            {
                MessageBox.Show("Selecione um Contato!");
            }
        }

        private void ListarContatos()
        {
            IList<Contato> contatos = _contatoService.TrazerTodos();

            _contatoControl.PopularListagemContatos(contatos);
        }

        public override string ObtemTipoCadastro()
        {
            return "Contatos";
        }
    }
}
