using FlorianiProva.Dominio.Features.Alunos.Excecoes;
using FlorianiProva.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Dominio.Features.Alunos
{
    public class Aluno
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Idade{ get; set; }
        public List<Resultado> Resultados { get; set; }

        public Aluno()
        {
            Resultados = new List<Resultado>();
        }
        public double CalcularMedia()
        {
            int contador = 0;
            double media = 0;
            foreach (var resultado in Resultados)
            {
                media += resultado.Nota;
                contador++;
            }
            media = media / contador;

            media = Math.Truncate(media);

            media += Arredondamento(media);

            return media;
        }
        public double Arredondamento(double valor)
        {
            double valorQuebrado = Math.Truncate(valor);

            double novoValor = valor - valorQuebrado;

            if (novoValor < 0.35)
                return 0;
            else if ((novoValor >= 0.35) && (novoValor < 0.75))
                return 0.5;
            else
                return 1;
        }
        public void Validar()
        {
            if (String.IsNullOrEmpty(Nome))
                throw new NomeEmBrancoException();
            if (Nome.Length > 150)
                throw new NomeMuitoGrandeException();
            if (Idade < 0)
                throw new IdadeNegativaException();
        }

    }
}
