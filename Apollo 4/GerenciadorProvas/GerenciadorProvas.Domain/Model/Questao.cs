using GerenciadorProvas.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Modal
{
   
    public class Questao : Entidade
    {
        public string Enunciado { get; set; }
        public string Bimestre { get; set; }
        public Materia Materia { get; set; }
        public List<Resposta> Respostas { get; set; }

        public override void Validacoes()
        {
            if (string.IsNullOrEmpty(Enunciado))
                throw new ValidacoesExcepection("\n O campo enunciado é um campo obrigatório.");

            if (Enunciado.Length <= 3)
                throw new ValidacoesExcepection("\n O campo enunciado deve ter mais de 3 caracteres.");

            if (Enunciado.Length >= 500)
                throw new ValidacoesExcepection("\n O campo enunciado deve ter menos de 500 caracteres.");
            
            //if (Regex.IsMatch(Enunciado, @"\s{2,}"))
            //    throw new ValidacoesExcepection("\n O campo enunciado não aceita espaços em branco.");

            if (Materia == null)
                throw new ValidacoesExcepection("\n O campo matéria é um campo obrigatório.");

            if (Respostas.Count <= 1)
                throw new ValidacoesExcepection("\n Não é permitido questão com apenas 1 alternativa.");

            if (Respostas.Count > 5)
                throw new ValidacoesExcepection("\n Não é permitido teste com mais de 5 alternativas.");

            if (!ExisteCerta())
                throw new ValidacoesExcepection("\n Não existe resposta correta!");

        }

        private bool ExisteCerta()
        {
            foreach (Resposta r in Respostas)
            {
                if (r.Certa == true)
                {
                    return true;
                }

            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("Questão de {0} Bimestre: {1} Nº Respostas: {2}", Materia.Nome,Bimestre,Respostas.Count.ToString());
        }

        public Resposta AltenativaCorreta() {

            foreach (Resposta r in Respostas)
                if (r.Certa)
                    return r;

            return null;
        }

    }
}
