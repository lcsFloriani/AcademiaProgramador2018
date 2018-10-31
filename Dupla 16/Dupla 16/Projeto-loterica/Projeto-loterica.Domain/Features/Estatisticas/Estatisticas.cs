using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Domain.Features.Concursos
{
    public class Estatisticas
    {
        public Vencedor Quina { get; set; }
        public Vencedor Quadra { get; set; }
        public Vencedor Mega { get; set; }

        public Estatisticas()
        {
        }  
        public Estatisticas(Vencedor mega, Vencedor quadra, Vencedor quina)
        {
            Mega = mega;
            Quadra = quadra;
            Quina = quina;
        }
    }
}
