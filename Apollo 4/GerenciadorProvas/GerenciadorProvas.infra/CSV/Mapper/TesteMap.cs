using CsvHelper.Configuration;
using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.infra.CSV.Mapper
{
    public sealed class TesteMap : ClassMap<Teste>
    {
        public TesteMap()
        {
            Map(t => t.Id).Name("Id").Index(0);
            Map(t => t.Titulo).Name("Titulo").Index(1);
            Map(t => t.NumeroQuestoes).Name("Numero Questões").Index(2);
            Map(t => t.Cadeira.Id).Name("Cadeira Id").Index(3);
            Map(t => t.Cadeira.Nome).Name("Cadeira").Index(4);
            Map(t => t.DataGeracao).TypeConverterOption.Format("dd_MM_yyyy").Name("Data Geração").Index(5);
        
        }
    }
}
