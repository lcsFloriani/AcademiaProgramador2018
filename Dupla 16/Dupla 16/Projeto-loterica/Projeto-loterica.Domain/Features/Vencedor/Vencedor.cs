using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Domain.Features.Concursos
{
    public class Vencedor
    {
        public int QuantidadeGanhadores { get; set; }
        public double MediaDoPremio { get; set; }
        public double PremioGanho { get { return QuantidadeGanhadores * MediaDoPremio; } }
        public double porcentagem { get; set; }
    }
}
