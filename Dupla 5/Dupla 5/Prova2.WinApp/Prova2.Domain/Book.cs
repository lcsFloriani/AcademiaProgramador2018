using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Domain
{
    public class Book
    {
        /// <summary>
        /// Prorpiedades com seus respectivos getters e setters (Convenção Pascal Casing)
        /// </summary>
        public int Id { get; set; }
        public string Title { get; set; }
        public string Theme { get; set; }
        public string Autor { get; set; }
        public int Volume { get; set; }
        public DateTime DatePublication { get; set; }
        public bool IsAvailable { get; set; }
        public bool Ex { get; set; }

        public Book()
        {
        }

        public override string ToString()
        {
            return String.Format("Id: {0} - Título: {1} - Volume: {2} - Disponível: {3}", Id, Title, Volume, IsAvailable ? "Sim" : "Não");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Book book = obj as Book;
            if (book == null)
                return false;
            else
                return Id.Equals(book.Id);
        }

        public void Validate()
        {
            if (Title.Length < 4 || String.IsNullOrEmpty(Title))
                throw new Exception("Deve ter um titulo com mais de 4 caracteres!");
            if (Theme.Length < 4 || String.IsNullOrEmpty(Theme))
                throw new Exception("Deve ter um tema com mais de 4 caracteres!");
            if (Autor.Length < 4 || String.IsNullOrEmpty(Autor))
                throw new Exception("Deve ter um autor com mais de 4 caracteres!");
            if (Volume <= 0)
                throw new Exception("Deve ter um volume maior que 0!");
            if (DatePublication > DateTime.Now)
                throw new Exception("Deve ter uma data de publicação menor que a data atual!");
        }
    }
}
