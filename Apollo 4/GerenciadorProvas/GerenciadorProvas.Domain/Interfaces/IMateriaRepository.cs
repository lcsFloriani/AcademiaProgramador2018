using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Interfaces
{
    public interface IMateriaRepository : IRepository<Materia>
    {

        bool RegistroRepetido(Materia entidade);

        bool RegistroComDependeciaComQuestao(Materia entidade);

        bool RegistroComDependeciaComTeste(Materia entidade);

        IList<Materia> ProcurarMateriaPorDisciplinaSerie(Disciplina disciplina, Serie serie);

        IList<Materia> ProcurarMateriaPorDisciplina(Disciplina disciplina);
    }
}
