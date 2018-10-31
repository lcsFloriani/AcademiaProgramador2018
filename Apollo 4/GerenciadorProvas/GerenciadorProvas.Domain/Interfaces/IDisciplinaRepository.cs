using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Interfaces
{
    public interface IDisciplinaRepository : IRepository<Disciplina>
    {

        bool RegistroRepetido(Disciplina entidade);

        bool RegistroComDependecia(Disciplina entidade);

    }
}
