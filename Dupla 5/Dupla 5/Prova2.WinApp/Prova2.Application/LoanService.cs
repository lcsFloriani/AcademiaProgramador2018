using Prova2.Domain;
using Prova2.Infra.Data;
using Prova2.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Prova2.Applications
{
    public class LoanService
    {
        public LoanDAO _loanDAO = new LoanDAO();
        public Report _bookReport = new Report();

        public LoanService()
        {
        }

        public Loan AddLoan(Loan loan)
        {
            try
            {
                loan.Validate(); //Valida o emprestimo

                loan = _loanDAO.Add(loan);
                loan.Ex = false;
            }
            catch (Exception e)
            {
                loan.Ex = true;
                throw new Exception(e.Message);
            }

            return loan;

        }

        public Loan UpdateLoan(Loan loan)
        {
            try
            {
                loan.Validate(); //Valida o venda

                loan = _loanDAO.Update(loan);
                loan.Ex = false;
            }
            catch (Exception e)
            {
                loan.Ex = true;
                throw new Exception(e.Message);
            }

            return loan;
        }

        public Loan GetLoan(int id)
        {
            try
            {
                return _loanDAO.GetById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Loan> GetAllLoans()
        {
            try
            {
                return _loanDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int DeleteLoan(Loan loan)
        {
            try
            {
                return _loanDAO.Delete(loan.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void LoanPdfCreator(string FileName)
        {
            IList<Loan> list = GetAllLoans();
            string items = "";

            foreach (var item in list)
            {
                items += "\n";
                items += "Cliente: " + item.Customer + "\n";
                items += "Data de Retorno: " + item.ReturnDate.Day + "\n";
                items += "Livro: " + item.Book.Title + "\n";
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