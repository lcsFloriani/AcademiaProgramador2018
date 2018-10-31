using Prova2.Domain;
using Prova2.Infra.Data;
using Prova2.Infra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Prova2.Applications
{
    public class BookService
    {
        public BookDAO _bookDAO = new BookDAO();

        public Report _bookReport = new Report();

        public BookService()
        {
        }

        public Book AddBook(Book book)
        {
            try
            {
                book.Validate(); //Valida o produto

                book = _bookDAO.Add(book);

                book.Ex = false;
            }
            catch (Exception e)
            {
                book.Ex = true;
                throw new Exception(e.Message);
            }

            return book;
        }

        public Book UpdateBook(Book book)
        {
            try
            {
                book.Validate(); //Valida o produto.

                book = _bookDAO.Update(book);
                book.Ex = false;
            }
            catch (Exception e)
            {
                book.Ex = true;
                throw new Exception(e.Message);
            }


            return book;
        }

        public Book GetBook(int id)
        {
            try
            {
                return _bookDAO.GetById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Book> GetAllBooks()
        {
            try
            {
                return _bookDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int DeleteBook(Book book)
        {
            try
            {
                return _bookDAO.Delete(book.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void BookPdfCreator(string FileName)
        {
            IList<Book> list = GetAllBooks();
            string items = "";

            foreach (var item in list)
            {
                items += "\n";
                items += "Título: " + item.Title + "\n";
                items += "Tema: " + item.Theme + "\n";
                items += "Autor: " + item.Autor + "\n";
            }

            if (FileName != "")
            {
                try
                {
                    _bookReport.GeneratePdf(FileName, items);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
