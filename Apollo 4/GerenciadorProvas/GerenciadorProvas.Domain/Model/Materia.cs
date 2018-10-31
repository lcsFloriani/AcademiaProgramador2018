using GerenciadorProvas.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Modal
{

    public class Materia : Entidade
    {
        public string Nome { get; set; }
        public Disciplina Cadeira { get; set; }
        public Serie Serie { get; set; }

        public Materia()
        {
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

            if (Regex.IsMatch(Nome, @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç;:)ªº(\s]"))
                throw new ValidacoesExcepection("\n O campo nome não aceita caracteres especiais.");

            if (Regex.IsMatch(Nome, @"\s{2,}"))
                throw new ValidacoesExcepection("\n O campo nome não aceita espaços em branco.");

            if (Serie == null)
                throw new ValidacoesExcepection("\n O campo série é um campo obrigatório");

            if (Cadeira == null)
                throw new ValidacoesExcepection("\n O campo disciplina é um campo obrigatório");
        }

        public override string ToString()
        {
            return string.Format("Matéria: {0} - Disciplina: {1} - Série: {2}ª", Nome, Cadeira.Nome, Serie.Grau.ToString());
        }
    }
}
