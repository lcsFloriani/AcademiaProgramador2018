using CsvHelper.TypeConversion;
using System;
using CsvHelper;
using CsvHelper.Configuration;

namespace ProjetoLoterica.Dominio.Features.Concursos
{
    public class ConcursoSituacaoConverter : DefaultTypeConverter
    {
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            var boolValue = (bool)value;

            return boolValue ? "Aberto" : "Fechado";
        }
    }
}
