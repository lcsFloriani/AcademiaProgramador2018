using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Interfaces
{
    public interface IQuestaoRepository : IRepository<Questao>
    {

        bool RegistroComDependecia(Questao entidade);
        bool RegistroRepetido(Questao entidade);

        void DeletarResposta(Resposta entidade);

        IList<Questao> ListagemPorMateria(Materia entidade);


    }
}
