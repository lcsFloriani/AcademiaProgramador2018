using GerenciadorProvas.Aplicacao;
using GerenciadorProvas.Aplicacao.Features.DisciplinaServico;
using GerenciadorProvas.Aplicacao.Features.MateriaServico;
using GerenciadorProvas.Aplicacao.Features.SerieServico;
using GerenciadorProvas.Dominio.Modal;
using System;
using System.Windows.Forms;

namespace GerenciadorProvas.WinApp.Features.MateriaModulo
{
    public class MateriaGerenciadorFormulario : GerenciadorFormulario<Materia, MateriaServico>
    {

        private DisciplinaServico _servicoDisplina;
        private SerieServico _servicoSerie;


        public MateriaGerenciadorFormulario(
            DisciplinaServico servicoDisplina,
            SerieServico servicoSerie)
        {
            _servicoDisplina = servicoDisplina;
            _servicoSerie = servicoSerie;
        }

        public override void Editar()
        {
            try
            {
                MateriaDialog dialog = new MateriaDialog(
                    (MateriaServico)ObterServico(),
                    _servicoDisplina,
                    _servicoSerie,
                    "Editar Matéria");

                dialog.Valor = controle.Valor;
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ObterServico().Atualizar(dialog.Valor);
                    controle.LimparItemSelecionado();
                    CarregarListagem();

                    MessageBox.Show("Materia alterada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Gravar()
        {
            MateriaDialog dialog = new MateriaDialog(
                    (MateriaServico)ObterServico(),
                    _servicoDisplina,
                    _servicoSerie,
                    "Editar Matéria");

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                ObterServico().Adicionar(dialog.Valor);
                CarregarListagem();

                MessageBox.Show("Materia salva com sucesso!");
            }
        }

        public override void Excluir()
        {
            try
            {
                Materia m = controle.Valor;
                MateriaServico servico = (MateriaServico)ObterServico();
                servico.Excluir(m);
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
