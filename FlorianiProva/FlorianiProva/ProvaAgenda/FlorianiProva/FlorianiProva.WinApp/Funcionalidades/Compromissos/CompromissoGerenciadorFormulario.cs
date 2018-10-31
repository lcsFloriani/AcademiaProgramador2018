using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FlorianiProva.Aplicacao;
using FlorianiProva.Dominio.Funcionalidades.Compromissos;
using FlorianiProva.Dominio.Funcionalidades.Contatos;
using FlorianiProva.Infra.Data;

namespace FlorianiProva.WinApp.Funcionalidades.Compromissos
{
    public class CompromissoGerenciadorFormulario : GerenciadorFormulario
    {
        private CompromissoService _compromissoService;
        private CompromissoControl _compromissoControl;
        private ContatoRepository _contatoRepository;
        public CompromissoGerenciadorFormulario(CompromissoService compromissoService, ContatoRepository contatoRepository)
        {
            _compromissoService = compromissoService;
            _contatoRepository = contatoRepository;
        }

        public override void Adicionar()
        {
            CompromissoDialog compromissoDialog = new CompromissoDialog(_contatoRepository, _compromissoService, "Cadastrar Compromisso", "Cadastrar");
            DialogResult result = compromissoDialog.ShowDialog();

            ListarCompromissos();
        }

        public override void AtualizarLista()
        {
            ListarCompromissos();
        }
        private void ListarCompromissos()
        {
            IList<Compromisso> compromissos = _compromissoService.TrazerTodos();

            _compromissoControl.PopularListaCompromissos(compromissos);
        }
        public override UserControl CarregarListagem()
        {
            if (_compromissoControl == null)
                _compromissoControl = new CompromissoControl();

            return _compromissoControl;
        }

        public override void Editar()
        {
            if (_compromissoControl.GetSelected() != null)
            {
                CompromissoDialog compromissoDialog = new CompromissoDialog(_contatoRepository, _compromissoService, "Editar Compromisso", "Editar", _compromissoControl.GetSelected());
                DialogResult resultado = compromissoDialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _compromissoService.Editar(_compromissoControl.GetSelected());
                }

                ListarCompromissos();
            }
            else
            {
                MessageBox.Show("Selecione um compromisso!");
            }
        }

        public override void Excluir()
        {
            if (_compromissoControl.GetSelected() != null)
            {
                try
                {

                    if (MessageBox.Show("Tem certeza que deseja excluir?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var compromisso = _compromissoControl.GetSelected();
                        _compromissoService.Deletar(compromisso);
                        MessageBox.Show("Exluído com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Você precisa selecionar um compromisso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            AtualizarLista();
        }

        public override string ObtemTipoCadastro()
        {
            return "Compromisso";
        }
    }
}
