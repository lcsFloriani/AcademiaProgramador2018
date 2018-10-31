using GerenciadorProvas.Aplicacao;
using GerenciadorProvas.Aplicacao.Features.DisciplinaServico;
using GerenciadorProvas.Aplicacao.Features.MateriaServico;
using GerenciadorProvas.Aplicacao.Features.QuestaoServico;
using GerenciadorProvas.Aplicacao.Features.TesteServico;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.WinApp.Features.DisciplinaModulo;
using GerenciadorProvas.WinApp.Features.MateriaModulo;
using GerenciadorProvas.WinApp.Features.QuestaoModulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorProvas.WinApp.Features.TesteModulo
{
    public class TesteGerenciadorFormulario : GerenciadorFormulario<Teste, TesteServico>
    {

        private DisciplinaServico _servicoDisciplina;
        private MateriaServico _servicoMateria;
        private QuestaoServico _servicoQuestao;



        public TesteGerenciadorFormulario(
         DisciplinaServico servicoDisciplina,
         MateriaServico servicoMateria,
         QuestaoServico servicoQuestao)
        {
            _servicoDisciplina = servicoDisciplina;
            _servicoMateria = servicoMateria;
            _servicoQuestao = servicoQuestao;
        }


        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Filtrar()
        {
            throw new NotImplementedException();
        }

        public override void Gravar()
        {
            TesteDialog dialog = new TesteDialog(
                   _servicoDisciplina,
                   _servicoMateria,
                   _servicoQuestao,
                   ObterServico(),
                   "Gravar Teste");

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                ObterServico().Adicionar(dialog.Valor);
                CarregarListagem();

                MessageBox.Show("Teste salvo com sucesso!");
            }
        }


        public override EstadoBotoes ObtemEstadoBotoes()
        {
            return new EstadoBotoes
            {
                Gravar = true,
                Editar = false,
                Excluir = true,
                PDF = true,
                CSV = true,
                XML = true
            };
        }

        public override TituloBotoes ObtemTituloBotoes(string selecionado)
        {
            return new TituloBotoes
            {
                Gravar = "Adicionar " + selecionado,
                Editar = "Editar " + selecionado,
                Excluir = "Excluir " + selecionado,
                PDF = "PDF " + selecionado,
                CSV = "CSV " + selecionado,
                XML = "XML " + selecionado
            };
        }

        public void VisualizarPDF(string caminho)
        {
            try
            {
                controle.ItemSelecionado();
                ObterServico().VisualizarPDF(controle.Valor, caminho);
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}
