using GerenciadorProvas.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Modal
{
    public class Disciplina : Entidade
    {
        public string Nome { get; set; }
        public List<Materia> Materias { get; set; }
        public List<Teste> Testes { get; set; }

        public Disciplina()
        {
            Materias = new List<Materia>();
            Testes = new List<Teste>();
        }

        public override void Validacoes()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new ValidacoesExcepection("\n O campo nome é um campo obrigatório.");

            if (Nome.Length <= 3)
                throw new ValidacoesExcepection("\n O campo nome deve ter mais de 3 caracteres.");

            if (Nome.Length >= 25)
                throw new ValidacoesExcepection("\n O campo nome deve ter menos de 25 caracteres.");

            if (Regex.IsMatch(Nome, @"^\d+$"))
                throw new ValidacoesExcepection("\n O campo nome não é um campo numérico.");

            if (Regex.IsMatch(Nome, @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]"))
                throw new ValidacoesExcepection("\n O campo nome não aceita caracteres especiais.");

            if (Regex.IsMatch(Nome, @"\s{2,}"))
                throw new ValidacoesExcepection("\n O campo nome não aceita espaços em branco.");
        }

        public void AddMateria(Materia materia)
        {
            Materias.Add(materia);
        }

        public void AddTeste(Teste teste)
        {
            Testes.Add(teste);
        }

        public override string ToString()
        {
            return string.Format("{0}", Nome);
        }

    }
}
