using CsvHelper.Configuration;
using Projeto_loterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.CSV.Features.Concursos
{
    public class ConcursoMap : ClassMap<Concurso>
    {
        public ConcursoMap()
        {
            Map(x => x.DataConcurso).Index(0).Name("Data Concurso");
            Map(x => x.Estatistica.Mega.QuantidadeGanhadores).Index(1).Name("Quantidade De Ganhadores Mega");
            Map(x => x.Estatistica.Quina.QuantidadeGanhadores).Index(2).Name("Quantidade De Ganhadores Quina");
            Map(x => x.Estatistica.Quadra.QuantidadeGanhadores).Index(3).Name("Quantidade De Ganhadores Quadra");
            Map(x => x.Estatistica.Mega.MediaDoPremio).Index(4).Name("Media da Mega Por vencedor");
            Map(x => x.Estatistica.Quina.MediaDoPremio).Index(5).Name("Media da Quina Por vencedor");
            Map(x => x.Estatistica.Quadra.MediaDoPremio).Index(6).Name("Media da Quadra Por vencedor");
            Map(x => x.Estatistica.Mega.PremioGanho).Index(7).Name("Premio da Mega Por vencedor");
            Map(x => x.Estatistica.Quina.PremioGanho).Index(8).Name("Premio da Quina Por vencedor");
            Map(x => x.Estatistica.Quadra.PremioGanho).Index(9).Name("Premio da Quadra Por vencedor");
            Map(x => x.resultado).Index(10).Name("Resultado");
            Map(x => x.ValorPremioTotal).Index(11).Name("Prêmio Total");
            Map(x => x.ValorGanhoLoteria).Index(12).Name("Lucro Da Loteria");
        }
    }
}
