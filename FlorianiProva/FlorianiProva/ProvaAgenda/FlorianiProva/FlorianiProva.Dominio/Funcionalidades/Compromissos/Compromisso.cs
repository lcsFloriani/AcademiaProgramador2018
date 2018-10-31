using FlorianiProva.Dominio.Base;
using FlorianiProva.Dominio.Funcionalidades.Contatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorianiProva.Dominio.Funcionalidades.Compromissos
{
    public class Compromisso : Entidade
    {
        public string Assunto{ get; set; }

        public IList<Contato> Contatos { get; set; }

        public string Local { get; set; }

        public bool DiaTodo { get; set; }

        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

        public override void Valida()
        {
            if (string.IsNullOrEmpty(Assunto) || Assunto.Trim() == "")
                throw new Exception("O Assunto não pode ser em branco");
            if (Assunto.Length > 255)
                throw new Exception("O Assunto deve ser menor que 255 caracteres");
            if (Contatos.Count <= 0)
                throw new Exception("Você deve selecionar pelo menos 1 contato para o compromisso.");
            if (string.IsNullOrEmpty(Local) || Local.Trim() == "")
                throw new Exception("O Local não pode ser em branco");
            if (Local.Length > 100)
                throw new Exception("O Local deve ser menor que 100 caracteres");
        }

        private string FormatToStringInicio()
        {
            return String.Format("{0}/{1}/{2}", Inicio.Day, Inicio.Month, Inicio.Year);
        }
        private string FormatToStringFim()
        {
            return String.Format("{0}/{1}/{2}", Fim.Day, Fim.Month, Fim.Year);
        }
        public override string ToString()
        {
            if(Fim == DateTimePicker.MinimumDateTime)
                return String.Format("=> {0} - {1} [Dia Todo]", Assunto, FormatToStringInicio());
            return String.Format("=> {0} - {1} até {2}", Assunto, FormatToStringInicio(), FormatToStringFim());
        }
    }
}
