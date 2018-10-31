using FlorianiProva.Dominio.Features.Avaliações.Excecoes;
using FlorianiProva.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Features.Avaliações
{
    public class Avaliacao
    {
        public long Id { get; set; }
        public string Assunto { get; set; }
        public DateTime Data { get; set; }
        public List<Resultado> Resultados { get; set; }
        public Avaliacao()
        {
            Resultados = new List<Resultado>();
        }
        public void Validar()
        {
            if (String.IsNullOrEmpty(Assunto))
                throw new AssuntoEmBrancoException();
        }
    }
}
