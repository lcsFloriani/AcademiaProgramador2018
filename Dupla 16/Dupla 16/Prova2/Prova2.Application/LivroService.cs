using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prova2.Infra.Data;
using Prova2.Domain;
using Prova2.Infra.PDF;

namespace Prova2.Applications
{
    public class LivroService
    {
        public LivroDAO _livroDAO = new LivroDAO();
        public PDFCreator _pdfCreator;

        public LivroService()
        {
        }
      public Livro AddLivro(Livro livro)
        {
            try
            {
                livro.Validate(); 

                livro = _livroDAO.Add(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return livro;
        }


       public Livro UpdateLivro(Livro livro)
        {
            try
            {
                livro.Validate();
                _livroDAO.Update(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return livro;
        }

      public Livro GetLivro(int id)
        {
            try
            {
                return _livroDAO.GetById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

         public IList<Livro> GetAllLivros()
        {
            try
            {
                return _livroDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

         public void DeleteLivro(Livro livro)
        {
            try
            {
                _livroDAO.Delete(livro.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public void ReportList(string fileName)
        {
            try
            {

                IList<Livro> livroList = _livroDAO.GetAll();

                _pdfCreator = new PDFCreator(fileName);

                _pdfCreator.OpenDocument();

                _pdfCreator.Write("Lista de Livros: ");

                foreach (var item in livroList)
                {
                    _pdfCreator.Write(item.ToString());
                }

                _pdfCreator.CloseDocument();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
