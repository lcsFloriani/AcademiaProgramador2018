using CsvHelper;
using Projeto_loterica.CSV.Features.Apostas;
using Projeto_loterica.CSV.Features.Boloes;
using Projeto_loterica.CSV.Features.Concursos;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Boloes;
using Projeto_loterica.Domain.Features.Concursos;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Projeto_loterica.CSV.Features.CSVGeral
{
    public class GerarCSV
    {
        

        public void GerarRelatorio(Concurso concurso, string caminho)
        {
            using (FileStream s = File.Create(caminho))
            using (var writer = new StreamWriter(s, Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.CultureInfo = CultureInfo.GetCultureInfo("pt-BR");

                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.HasHeaderRecord = true;
                csvWriter.Configuration.RegisterClassMap<ApostaMap>();
                csvWriter.Configuration.RegisterClassMap<BolaoMap>();
                csvWriter.Configuration.RegisterClassMap<ConcursoMap>();
                EscreverConcursos(concurso, csvWriter);
            }
        }
        public void GerarEspelhoDoBanco(List<Concurso> concursos, string caminho)
        {
            using (FileStream s = File.Create(caminho))
            using (var writer = new StreamWriter(s, Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.CultureInfo = CultureInfo.GetCultureInfo("pt-BR");

                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.HasHeaderRecord = true;
                csvWriter.Configuration.RegisterClassMap<ApostaMap>();
                csvWriter.Configuration.RegisterClassMap<BolaoMap>();
                csvWriter.Configuration.RegisterClassMap<ConcursoMap>();
                foreach (var item in concursos)
                {
                    EscreverConcursos(item, csvWriter);
                }
            }
        }

        private static void EscreverConcursos(Concurso concurso, CsvWriter csvWriter)
        {
            csvWriter.WriteField("Concurso");
            csvWriter.NextRecord();
            csvWriter.WriteHeader(concurso.GetType());
            csvWriter.NextRecord();
            csvWriter.WriteRecord(concurso);
            csvWriter.NextRecord();
            foreach (Aposta aposta in concurso.Apostas)
            {
                csvWriter.WriteField("Aposta");
                csvWriter.NextRecord();
                csvWriter.WriteHeader(aposta.GetType());
                csvWriter.NextRecord();
                csvWriter.WriteRecord(aposta);
                csvWriter.NextRecord();
            }

            csvWriter.WriteHeader<BolaoMap>();
            csvWriter.NextRecord();
            foreach (Bolao bolao in concurso.Boloes)
            {
                csvWriter.WriteField("Bolao");
                csvWriter.NextRecord();
                csvWriter.WriteHeader(bolao.GetType());
                csvWriter.NextRecord();
                csvWriter.WriteRecord(bolao);
                csvWriter.NextRecord();
                foreach (Aposta aposta in bolao.Apostas)
                {
                    csvWriter.WriteField("Aposta");
                    csvWriter.NextRecord();
                    csvWriter.WriteHeader(aposta.GetType());
                    csvWriter.NextRecord();
                    csvWriter.WriteRecord(aposta);
                    csvWriter.NextRecord();
                }
            }


            csvWriter.NextRecord();
        }
    }
}
