using Prova2.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Prova2.Infra.Data
{
    public class LoanDAO
    {
        # region queries
        private const string sqlInsertLoan = @"INSERT INTO Loan
                               (Customer
                               ,ReturnDate
                               ,BookId)
                           VALUES
                                 (@Customer
                                  ,@ReturnDate
                                  ,@BookId)";

        private const string sqlGetLoanById = @"SELECT o.Id
                                 ,o.Customer
                                 ,o.ReturnDate
                                 ,o.BookId
	                             ,b.Title
	                             ,b.Theme
	                             ,b.Autor
	                             ,b.IsAvailable
	                             ,b.Volume
	                             ,b.DatePublication
                           FROM Loan AS o
                           INNER JOIN Book AS b
                           ON b.Id = o.BookId
                           WHERE o.[Id] = @Id";

        private const string sqlGetAllLoans = @"SELECT o.Id
                                 ,o.Customer
                                 ,o.ReturnDate
                                 ,o.BookId
	                             ,b.Title
	                             ,b.Theme
	                             ,b.Autor
                                 ,b.Volume
	                             ,b.IsAvailable
	                             ,b.DatePublication
                           FROM Loan AS o
                           INNER JOIN Book AS b
                           ON b.Id = o.BookId";

        private const string sqlUpdateLoan = @"UPDATE Loan
                           SET Customer = @Customer
                              ,ReturnDate = @ReturnDate
                              ,BookId = @BookId
                            WHERE Id = @Id";

        private const string sqlDeleteLoan = @"DELETE FROM Loan WHERE Id = @Id";

        #endregion queries

        public LoanDAO()
        {
        }

        public Loan Add(Loan loan)
        {
            DB.Add(sqlInsertLoan, GetParam(loan));

            return loan;
        }

        public Loan GetById(int loanId)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", loanId);

            return DB.GetById(sqlGetLoanById, Converter, dic);
        }

        public IList<Loan> GetAll()
        {
            return DB.GetAll(sqlGetAllLoans, Converter);
        }

        public Loan Update(Loan loan)
        {
            DB.Update(sqlUpdateLoan, GetParam(loan));

            return loan;
        }

        public int Delete(int loanId)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", loanId);

            DB.Delete(sqlDeleteLoan, dic);

            return loanId;
        }

        private static Loan Converter(IDataReader _reader)
        {
            Loan loan = new Loan();
            loan.Id = Convert.ToInt32(_reader["Id"]);
            loan.Customer = Convert.ToString(_reader["Customer"]);
            loan.ReturnDate = Convert.ToDateTime(_reader["ReturnDate"]);
            loan.Book.Id = Convert.ToInt32(_reader["BookId"]);
            loan.Book.Title = Convert.ToString(_reader["Title"]);
            loan.Book.Theme = Convert.ToString(_reader["Theme"]);
            loan.Book.Autor = Convert.ToString(_reader["Autor"]);
            loan.Book.Volume = Convert.ToInt32(_reader["Volume"]);
            loan.Book.IsAvailable = Convert.ToBoolean(_reader["IsAvailable"]);
            loan.Book.DatePublication = Convert.ToDateTime(_reader["DatePublication"]);

            return loan;
        }

        public Dictionary<string, object> GetParam(Loan loan)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", loan.Id);
            dic.Add("Customer", loan.Customer);
            dic.Add("ReturnDate", loan.ReturnDate);
            dic.Add("BookId", loan.Book.Id);

            return dic;
        }
    }
}