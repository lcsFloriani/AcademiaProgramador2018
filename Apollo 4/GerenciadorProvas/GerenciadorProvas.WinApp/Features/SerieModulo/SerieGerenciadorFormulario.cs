using GerenciadorProvas.Aplicacao;
using GerenciadorProvas.Aplicacao.Features;
using GerenciadorProvas.Aplicacao.Features.SerieServico;
using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorProvas.WinApp.Features.SerieModulo
{
    public class SerieGerenciadorFormulario : GerenciadorFormulario<Serie, SerieServico>
    {
 
        public override void Editar()
        {
            try
            {
                SerieDialog dialog = new SerieDialog(ObterServico(), "Editar Série");
                dialog.Valor = controle.Valor;
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ObterServico().Atualizar(dialog.Valor);
                    controle.LimparItemSelecionado();
                    CarregarListagem();

                    MessageBox.Show("Série alterada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Gravar()
        {
            SerieDialog dialog = new SerieDialog(ObterServico(), "Gravar Série");
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                ObterServico().Adicionar(dialog.Valor);
                CarregarListagem();

                MessageBox.Show("Série salva com sucesso!");
            }
        }

        public override void Excluir()
        {
            try
            {
                Serie s = controle.Valor;
                var servico = ObterServico();
                servico.Excluir(s);
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
