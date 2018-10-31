using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prova2.Domain;
using Prova2.Infra.Data;
using Prova2.Infra.PDF;

namespace Prova2.Applications
{
    public class EmprestimoService
    {
        public EmprestimoDAO _EmprestimoDAO = new EmprestimoDAO();
        public PDFCreator _pdfCreator;

        public EmprestimoService()
        {
        }
        public Emprestimo AddEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                emprestimo.Validate(); 

                emprestimo = _EmprestimoDAO.Add(emprestimo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return emprestimo;
        }

      
        public Emprestimo UpdateEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                emprestimo.Validate();

                _EmprestimoDAO.Update(emprestimo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return emprestimo;
        }

        public Emprestimo GetEmprestimo(int id)
        {
            try
            {
                return _EmprestimoDAO.GetById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       
        public IList<Emprestimo> GetAllEmprestimos()
        {
            try
            {
                return _EmprestimoDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
      public void DeleteEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                _EmprestimoDAO.Delete(emprestimo.Id);
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

                IList<Emprestimo> emprestimoList = _EmprestimoDAO.GetAll();

                _pdfCreator = new PDFCreator(fileName);

                _pdfCreator.OpenDocument();

                _pdfCreator.Write("Lista de Empréstimos:");

                foreach (var item in emprestimoList)
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
