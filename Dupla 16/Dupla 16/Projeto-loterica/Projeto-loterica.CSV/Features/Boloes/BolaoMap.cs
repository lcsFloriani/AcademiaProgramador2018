using CsvHelper.Configuration;
using Projeto_loterica.Domain.Features.Boloes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.CSV.Features.Boloes
{
    public class BolaoMap : ClassMap<Bolao>
    {
        public BolaoMap()
        {
            Map(x => x.custoTotal).Index(1).Name("Custo total");
        }
    }
}
