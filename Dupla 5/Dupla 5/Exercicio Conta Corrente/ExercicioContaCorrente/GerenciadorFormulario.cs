using System;
using System.Windows.Forms;

namespace ExercicioContaCorrente
{
    public abstract class GerenciadorFormulario
    {
        public abstract void Adicionar();

        public abstract void Atualizar();

        public abstract void Remover();

        public virtual void Sacar()
        {

        }

        public virtual void Depositar()
        {

        }

        public virtual void Extrato()
        {

        }

        public virtual void Transferir()
        {

        }

        public abstract UserControl CarregarListagem();
        public abstract string ObtemTipoCadastro();
        public abstract TituloBotoes ObtemTituloBotoes();
        public abstract EstadoBotoes ObtemEstadoBotoes();

    }
}