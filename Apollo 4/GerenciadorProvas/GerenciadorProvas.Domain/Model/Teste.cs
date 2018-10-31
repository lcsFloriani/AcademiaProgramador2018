using GerenciadorProvas.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Modal
{
    public class Teste : Entidade
    {
        public string Titulo { get; set; }
        public int NumeroQuestoes { get; set; }
        public Materia Cadeira { get; set; }
        public DateTime DataGeracao { get; set; }
        public List<Questao> Questoes { get; set; }

        public Teste()
        {
            Questoes = new List<Questao>();
        }
        public override void Validacoes()
        {
            if (string.IsNullOrEmpty(Titulo))
                throw new ValidacoesExcepection("\n O campo título é um campo obrigatório.");

            if (Titulo.Length <= 5)
                throw new ValidacoesExcepection("\n O campo título deve ter mais de 5 caracteres.");

            if (Titulo.Length >= 50)
                throw new ValidacoesExcepection("\n O campo título deve ter menos de 50 caracteres.");

            if (Regex.IsMatch(Titulo, @"\s{2,}"))
                throw new ValidacoesExcepection("\n O campo título não aceita espaços em branco.");

            //if (Questoes.Count >= 30)
            //    throw new ValidacoesExcepection("\n O teste não pode ter mais de 30 questões.");

            //if (Questoes.Count <= 1)
            //    throw new ValidacoesExcepection("\n O teste não pode ter menos de 1 questão.");

            if (NumeroQuestoes > Questoes.Count)
                throw new ValidacoesExcepection("\n Não existe um número de questões suficientes no sistema para esta determinada matéria.");

            if (Cadeira == null)
                throw new ValidacoesExcepection("\n Cadeira é um campo obrigatório.");
        }

        public string ObterDataGeracao()
        {

            return DataGeracao.ToString();
        }

        public override string ToString()
        {
            return string.Format("Título: {0} Matéria: {1} Data de Geracao: {2}", Titulo, Cadeira.Nome, DataGeracao.ToShortDateString());
        }

        public List<Questao> GerarQuestoesAleatorias()
        {
            List<Questao> lista = new List<Questao>();
            Random random = new Random();

            int[] numerosAleatorios = GerarNumerosAleatorios(random, Questoes.Count);

            for (int index = 0; index < NumeroQuestoes; index++) {
                int numeroAleatorio = numerosAleatorios[index];
                lista.Add(Questoes[numeroAleatorio]);
            }

            return lista;
        }


        public int[] GerarNumerosAleatorios(Random random, int length)
        {
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < length)
            {
                numbers.Add(random.Next(0, length));
            }

            return numbers.ToArray();
        }
    }
}
