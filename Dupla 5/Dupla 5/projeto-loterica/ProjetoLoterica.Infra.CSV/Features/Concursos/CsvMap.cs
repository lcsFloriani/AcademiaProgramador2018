using CsvHelper.Configuration;
using ProjetoLoterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Infra.CSV.Features.Concursos
{
    public sealed class CsvMap : ClassMap<Concurso>
    {
        public CsvMap()
        {
            Map(x => x.Id).Name("ID");
            Map(x => x.Numero).Name("NÚMERO");
            Map(x => x.Data).Name("DATA");
            Map(x => x.Premio).Name("PREMIO");

            Map(x => x.PremioQuadra).Name("PREMIO QUADRA");
            Map(x => x.PremioQuina).Name("PREMIO QUINA");
            Map(x => x.PremioSena).Name("PREMIO SENA");

            Map(x => x.Ganhadores_Quadra).Name("GANHADORES QUADRA");
            Map(x => x.Ganhadores_Quina).Name("GANHADORES QUINA");
            Map(x => x.Ganhadores_Sena).Name("GANHADORES SENA");

            Map(x => x.PremioGanhadoresQuadra).Name("MEDIA PREMIO QUADRA");
            Map(x => x.PremioGanhadoresQuina).Name("MEDIA PREMIO QUINA");
            Map(x => x.PremioGanhadoresSena).Name("MEDIA PREMIO SENA");
            Map(x => x.LucroLoterica).Name("LUCRO LOTERICA");
            Map(x => x.Situacao).Name("SITUAÇÃO").TypeConverter<ConcursoSituacaoConverter>();
        }
    }
}
