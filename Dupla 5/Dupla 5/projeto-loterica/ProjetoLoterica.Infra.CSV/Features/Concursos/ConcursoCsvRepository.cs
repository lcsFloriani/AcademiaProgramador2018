using CsvHelper;
using ProjetoLoterica.Dominio.Features.Concursos;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjetoLoterica.Infra.CSV.Features.Concursos
{
    public static class ConcursoCsvRepository
    {
        public static string SerializeCSV<Concurso>(IList<Concurso> concursos, string caminho)
        {
           File.Delete(caminho);

            using (StreamWriter writer = new StreamWriter(caminho, true, Encoding.UTF8))
            {
                CsvWriter csvWriter = new CsvWriter(writer);
                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.RegisterClassMap<CsvMap>();
                csvWriter.WriteRecords(concursos);
            }
            return concursos.ToString();
        }
    }
}
