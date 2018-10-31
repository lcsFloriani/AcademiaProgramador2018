using FlorianiProva.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Funcionalidades.Compromissos
{
    public interface ICompromissoRepository : IRepository<Compromisso>
    {
        void AdicionarContatos_Compromisso(int compromisso, int contato);
    }
}
