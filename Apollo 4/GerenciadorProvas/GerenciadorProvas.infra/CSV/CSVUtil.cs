using CsvHelper;
using CsvHelper.Configuration;
using GerenciadorProvas.Dominio.Modal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorProvas.infra.CSV
{
    public class CSVUtil<T,E> 
        where T : Entidade
        where E : ClassMap<T>
    {
        public void Exportar(string caminho, T entidade)
        {
            List<T> lista = new List<T>();
            lista.Add(entidade);

            using (TextWriter writer = new StreamWriter(caminho, false, Encoding.UTF8))
            {
                var csv = new CsvWriter(writer);
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap<E>();
                csv.WriteRecords(lista);
                writer.Close();
            }
        }
    }
}
