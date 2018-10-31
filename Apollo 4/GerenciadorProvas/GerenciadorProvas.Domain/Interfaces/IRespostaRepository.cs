using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Interfaces
{
   public interface IRespostaRepository : IRepository<Resposta>
    {
        IList<Resposta> ListagemPorQuestao(Questao entidade);
  
    }
}
