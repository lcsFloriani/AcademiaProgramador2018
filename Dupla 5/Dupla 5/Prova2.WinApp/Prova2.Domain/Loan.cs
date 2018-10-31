using System;

namespace Prova2.Domain
{
    public class Loan
    {

        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime ReturnDate { get; set; }
        public Book Book { get; set; }
        public double Tax { get; set; }
        public bool Ex { get; set; }

        public override string ToString()
        {
            return String.Format("{0} emprestou {1} - retorno {2}.", Customer, Book.Title, ReturnDate);
        }

        public Loan()
        {
            Book = new Book();
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
            if (Customer.Length < 4 || String.IsNullOrEmpty(Customer))
                throw new Exception("Deve ter um cliente com mais de 4 caracteres!");
            if (Book.Id == 0)
                throw new Exception("Deve ter um Livro!");
            if (ReturnDate <= DateTime.Now)
                throw new Exception("Deve ter uma data de retorno maior data atual!");

        }

        public double GetTax(Loan loan)
        {
            if (DateTime.Now > loan.ReturnDate)
            {
                int result = DateTime.Now.Subtract(loan.ReturnDate).Days;
                return result * 2.5;
            }
            else
            {
                return 0.00;
            }
        }
    }
}