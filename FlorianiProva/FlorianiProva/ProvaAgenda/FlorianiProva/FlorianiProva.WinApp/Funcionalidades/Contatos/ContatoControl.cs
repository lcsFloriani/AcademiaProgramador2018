using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlorianiProva.Dominio.Funcionalidades.Contatos;
using FlorianiProva.Infra.Data;
using FlorianiProva.Aplicacao;

namespace FlorianiProva.WinApp.Funcionalidades.Contatos
{
    public partial class ContatoControl : UserControl
    {
        private ContatoRepository _contatoRepository;
        private IContatoService _contatoService;
        public ContatoControl()
        {
            InitializeComponent();
            _contatoRepository = new ContatoRepository();
            _contatoService = new ContatoService(_contatoRepository);
        }

        public Contato ObtemContatoSelecionado()
        {
            return (Contato)lbContato.SelectedItem;
        }

        public void PopularListagemContatos(IList<Contato> contatos)
        {
            lbContato.Items.Clear();

            foreach (Contato item in contatos)
            {
                lbContato.Items.Add(item);
            }
        }
    }
}
