using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlorianiProva.Aplicacao;
using FlorianiProva.Infra.Data;
using FlorianiProva.Dominio.Funcionalidades.Compromissos;

namespace FlorianiProva.WinApp.Funcionalidades.Compromissos
{
    public partial class CompromissoControl : UserControl
    {
        CompromissoService _compromissoService;
        CompromissoRepository _compromissoRepository;
        public CompromissoControl()
        {
            InitializeComponent();
            _compromissoRepository = new CompromissoRepository();
            _compromissoService = new CompromissoService(_compromissoRepository);
            CaarregaLista();

        }
        public void CaarregaLista() {
            lbCompromissos.Items.Clear();
            foreach (var item in _compromissoService.TrazerTodos())
            {
                lbCompromissos.Items.Add(item);
            }
        }
        public Compromisso GetSelected()
        {
            return (Compromisso)lbCompromissos.SelectedItem;
        }

        public void PopularListaCompromissos(IList<Compromisso> compromissos)
        {
            lbCompromissos.Items.Clear();

            foreach (Compromisso item in compromissos)
            {
                lbCompromissos.Items.Add(item);
            }
        }
    }
}
