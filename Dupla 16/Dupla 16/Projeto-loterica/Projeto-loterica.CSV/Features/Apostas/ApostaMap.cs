using CsvHelper.Configuration;
using Projeto_loterica.Domain.Features.Apostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.CSV.Features.Apostas
{
    public class ApostaMap : ClassMap<Aposta>
    {
        public ApostaMap()
        {
            Map(x => x.Numeros).Index(0).Name("Numeros");
            Map().Index(0).Name(" ");
            Map().Index(0).Name(" ");
            Map().Index(0).Name(" ");
            Map().Index(0).Name(" ");
            Map().Index(0).Name(" ");
            Map(x => x.Resultado).Index(1).Name("Resultado");
            Map(x => x.ValorPago).Index(2).Name("Valor Pago");
            Map(x => x.ValorRecebido).Index(3).Name("Valor Recebido");

        }
    }
}
