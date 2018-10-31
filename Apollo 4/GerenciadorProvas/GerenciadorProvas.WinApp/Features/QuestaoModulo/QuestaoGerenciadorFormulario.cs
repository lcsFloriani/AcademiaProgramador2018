using GerenciadorProvas.Dominio.Modal;
using System;
using System.Windows.Forms;
using GerenciadorProvas.Aplicacao.Features.QuestaoServico;
using GerenciadorProvas.Aplicacao.Features.DisciplinaServico;
using GerenciadorProvas.Aplicacao.Features.SerieServico;
using GerenciadorProvas.Aplicacao.Features.MateriaServico;

namespace GerenciadorProvas.WinApp.Features.QuestaoModulo
{
    public class QuestaoGerenciadorFormulario : GerenciadorFormulario<Questao, QuestaoServico>
    {
        private DisciplinaServico _servicoDisplina;
        private SerieServico _servicoSerie;
        private MateriaServico _servicoMateria;

        public QuestaoGerenciadorFormulario(DisciplinaServico servicoDisplina, SerieServico servicoSerie, MateriaServico servicoMateria) 
        {
            _servicoDisplina = servicoDisplina;
            _servicoSerie = servicoSerie;
            _servicoMateria = servicoMateria;
        }

        public override void Editar()
        {
            try
            {
                QuestaoDialog dialog = new QuestaoDialog(
                    _servicoDisplina,
                    _servicoSerie,
                    _servicoMateria,
                     ObterServico(),
                     controle.Valor);

                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ObterServico().Atualizar(dialog.Valor);
                    controle.LimparItemSelecionado();
                    CarregarListagem();

                    MessageBox.Show("Questão alterada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Gravar()
        {
            QuestaoDialog dialog = new QuestaoDialog(
                _servicoDisplina,
                _servicoSerie, 
                _servicoMateria,
                (QuestaoServico)ObterServico());

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                ObterServico().Adicionar(dialog.Valor);
                CarregarListagem();

                MessageBox.Show("Questão salva com sucesso!");
            }
        }

        public override void Excluir()
        {
            try
            {
                Questao q = controle.Valor;
                var servico = ((QuestaoServico)ObterServico());
                servico.Excluir(q);
                controle.LimparItemSelecionado();
                CarregarListagem();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Filtrar()
        {
            throw new NotImplementedException();
        }

    }
}
