using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pizzaria.WinApp.Common
{
    public partial class ControleFormulario<T> : UserControl
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

        public ControleFormulario()
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
            _valor =(T) listBox.SelectedItem;
        }


        public void LimparLista()
        {
            listBox.Items.Clear();
        }

        public void LimparItemSelecionado()
        {
            _valor = (T)(object) null;
        }

        public void ItemSelecionado() {
            if (_valor == null)
            {
                throw new ControleFormularioItemNaoSelecionadoException();
            }

        }
    }
}
