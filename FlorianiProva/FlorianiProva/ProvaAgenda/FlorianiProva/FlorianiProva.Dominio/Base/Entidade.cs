using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Base
{
    public abstract class Entidade
    {
        public int Id { get; set; }

        public abstract void Valida();

    }
}
