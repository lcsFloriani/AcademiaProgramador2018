using GerenciadorProvas.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorProvas.Dominio.Modal
{
    public class Resposta : Entidade
    {
        public string Descricao { get; set; }
        public Questao Questao { get; set; }
        public bool Certa { get; set; }
        public char Letra { get; set; }

        public void AtribuirLetra(int numeroLetra)
        {
            switch (numeroLetra)
            {
                case 0:
                    Letra = 'A';
                    break;
                case 1:
                    Letra = 'B';
                    break;
                case 2:
                    Letra = 'C';
                    break;
                case 3:
                    Letra = 'D';
                    break;
                case 4:
                    Letra = 'E';
                    break;
                default:
                    Letra = '@';
                    break;
            }
        }

        public override void Validacoes()
        {
            if (string.IsNullOrEmpty(Descricao))
                throw new ValidacoesExcepection("\n O campo descrição é um campo obrigatório.");

            if (Descricao.Length < 1)
                throw new ValidacoesExcepection("\n O campo descrição deve ter mais de 1 caractere.");

            if (Descricao.Length >= 100)
                throw new ValidacoesExcepection("\n O campo descrição deve ter menos de 100 caracteres.");

            //if (Questao == null)
            //    throw new ValidacoesExcepection("\n O campo questão é um campo obrigatório");

            if (Regex.IsMatch(Descricao, @"\s{2,}"))
                throw new ValidacoesExcepection("\n O campo descrição não aceita espaços em branco.");
        }

        public override string ToString()
        {
            return string.Format("Letra: {0} Descrição: {1} Certa: {2}", Letra, Descricao, Certa ? "Sim" : "Não");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Resposta resItem = obj as Resposta;


            return resItem.Id == this.Id && resItem.Letra.Equals(this.Letra);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

       

        public static bool VerificarRespostaRepetida (List<Resposta> respostas, Resposta resposta)
        {
            foreach(Resposta r in respostas)
            {
                if (r.Descricao.Equals(resposta.Descricao) && r.Id!= resposta.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
