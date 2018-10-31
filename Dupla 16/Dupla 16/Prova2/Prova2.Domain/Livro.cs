using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Domain
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Tema { get; set; }
        public string Autor { get; set; }
        public int Volume { get; set; }
        public DateTime DataPublicacao { get; set; }
        public bool Disponibilidade { get; set; }

        public Livro(){

        }
        public override string ToString()
        {
            string disp;
            if (Disponibilidade)
                disp = "Disponivel";
            else
                disp = "Indisponivel";
            return String.Format("{0} : Volume: {1} / {2}", Titulo, Volume, disp);
        }

        public void Validate() {
            if (Titulo.Length < 4 || String.IsNullOrEmpty(Titulo))
                throw new Exception("Deve ter um titulo com mais de 4 caracteres!");
            if (Tema.Length < 4 || String.IsNullOrEmpty(Tema)) {
                throw new Exception("Deve ter um tema com mais de 4 caracteres!");
            }
            if (Autor.Length < 4 || String.IsNullOrEmpty(Autor)){
                throw new Exception("Deve ter um Autor com mais de 4 caracteres!");
            }
            if (Volume < 1){
                throw new Exception("Deve ter um volume maior que 0");
            }
        }

        public string ToRelatorio()
        {

            string disp;
            if (Disponibilidade)
                disp = "Disponivel";
            else
                disp = "Indisponivel";

            return String.Format("Titulo: {0}, Volume: {1}, Publicado em: {2}, {3} \n", Titulo, Volume, DataPublicacao.ToShortDateString(), disp);
        } 
    }
}
