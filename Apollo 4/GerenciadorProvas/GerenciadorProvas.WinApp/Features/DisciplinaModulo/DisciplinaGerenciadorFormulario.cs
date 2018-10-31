using GerenciadorProvas.Aplicacao;
using GerenciadorProvas.Aplicacao.Features.DisciplinaServico;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.WinApp.DisciplinaModulo;
using System;
using System.Windows.Forms;

namespace GerenciadorProvas.WinApp.Features.DisciplinaModulo
{
    public class DisciplinaGerenciadorFormulario : GerenciadorFormulario<Disciplina, DisciplinaServico>
    {
     
        public override void Editar()
        {
            try
            {
                DisciplinaDialog dialog = new DisciplinaDialog(ObterServico(), "Editar Disciplina");
                dialog.Valor = (Disciplina) controle.Valor;
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ObterServico().Atualizar(dialog.Valor);
                    controle.LimparItemSelecionado();
                    CarregarListagem();

                    MessageBox.Show("Disciplina alterada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Gravar()
        {
            DisciplinaDialog dialog = new DisciplinaDialog(ObterServico(), "Gravar Disciplina");
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                ObterServico().Adicionar(dialog.Valor);
                CarregarListagem();

                MessageBox.Show("Disciplina salva com sucesso!");
            }
        }

        public override void Excluir()
        {
            try
            {
                Disciplina d = controle.Valor;
                ObterServico().Excluir(d);
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
