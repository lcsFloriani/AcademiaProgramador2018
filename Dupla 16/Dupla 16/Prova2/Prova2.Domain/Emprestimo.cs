using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Domain
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public Livro Livro { get; set; }
        public DateTime dataDevolucao { get; set; }
        
        public Emprestimo()
        {
            Livro = new Livro();
        }

        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        
        public override bool Equals(object obj)
        {
            Livro livro = obj as Livro;
            if (livro == null)
                return false;
            else
                return Id.Equals(livro.Id);
        }
        public override string ToString()
        {
            return String.Format("Cliente: {0} / Titulo: {1} / Devolução: {2}", Cliente, Livro.Titulo, dataDevolucao);
        }
     
      
        public void Validate()
        {
            if (Cliente.Length < 4 || String.IsNullOrEmpty(Cliente))
                throw new Exception("Deve ter um cliente com mais de 4 caracteres!");
            if (Livro == null)
                throw new Exception("Deve ter um produto!");
            //if (dataDevolucao < DateTime.Now)
            //    throw new Exception("Data de devolução deve ser a partir de amanhã");
        }

        public string ToEmp()
        {
            return String.Format("Cliente: {0} / Titulo: {1} / Devolução: {2} \n", Cliente, Livro.Titulo, dataDevolucao.ToShortDateString());
        }
    }
}
