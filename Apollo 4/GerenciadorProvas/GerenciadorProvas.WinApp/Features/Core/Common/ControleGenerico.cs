using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GerenciadorProvas.Dominio.Modal;
using GerenciadorProvas.Dominio.Exceptions;

namespace GerenciadorProvas.WinApp.Features.Core.Common
{
    public partial class ControleGenerico<T> : UserControl where T : Entidade 
    {
   
        private T _valor;
        public T Valor
        {
            set
            {
                _valor = value;
            }
            get
            { 
                ItemSelecionado();
                return _valor;
            }
        }

        public ControleGenerico()
        {
            InitializeComponent();
        }

        public void PopularListagem(List<T> entidades)
        {
            foreach (T entidade in entidades)
            {
                listBox.Items.Add(entidade);
            }

        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _valor = listBox.SelectedItem as T;
        }


        public void LimparLista()
        {
            listBox.Items.Clear();
        }

        public void LimparItemSelecionado()
        {
            _valor = null;
        }

        public void ItemSelecionado() {
            if (_valor == null)
            {
                throw new ValidacoesExcepection("Selecione um registro!");
            }

        }
    }
}
