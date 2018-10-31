using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prova2.Domain;
using System.Data;
using System.Data.Common;
using System.Collections;

namespace Prova2.Infra.Data
{
    public class BookDAO
    {

        #region queries 
        private const string sqlInsertBook = @"INSERT INTO Book
                    (Title
                    ,Theme
                    ,Autor
                    ,Volume
                    ,DatePublication
                    ,IsAvailable)
                VALUES
                        (@Title
                        ,@Theme
                        ,@Autor
                        ,@Volume
                        ,@DatePublication
                        ,@IsAvailable);";

        private const string sqlGetBookById = @"SELECT Id
                                 ,Title
                                 ,Theme
                                 ,Autor
                                 ,Volume
                                 ,DatePublication
                                 ,IsAvailable
                           FROM Book
                           WHERE Id = @Id";

        private const string sqlGetAllBooks = @"SELECT Id
                                 ,Title
                                 ,Theme
                                 ,Autor
                                 ,Volume
                                 ,DatePublication
                                 ,IsAvailable
                           FROM Book";

        private const string sqlUpdateBook = @"UPDATE Book
                           SET Title = @Title
                              ,Theme = @Theme
                              ,Autor = @Autor
                              ,Volume = @Volume
                              ,DatePublication = @DatePublication
                              ,IsAvailable = @IsAvailable
                            WHERE Id = @Id";

        private const string sqlDeleteBook = @"DELETE FROM Book WHERE Id = @Id";

        #endregion queries

        public BookDAO()
        {
        }

        public Book Add(Book book)
        {
            DB.Add(sqlInsertBook, GetParam(book));

            return book;
        }

        public Book GetById(int bookId)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", bookId);

            return DB.GetById(sqlGetBookById, Converter, dic );            
        }

        public IList<Book> GetAll()
        {
            return DB.GetAll(sqlGetAllBooks, Converter);
        }

        public Book Update(Book book)
        {
            DB.Update(sqlUpdateBook, GetParam(book));

            return book;
        }

        public int Delete(int bookId)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", bookId);

            DB.Delete(sqlDeleteBook, dic);

            return bookId;
        }

        private static Book Converter(IDataReader _reader)
        {
            Book book = new Book();
            book.Id = Convert.ToInt32(_reader["Id"]);
            book.Title = Convert.ToString(_reader["Title"]);
            book.Theme = Convert.ToString(_reader["Theme"]);
            book.Autor = Convert.ToString(_reader["Autor"]);
            book.Volume = Convert.ToInt32(_reader["Volume"]);
            book.IsAvailable = Convert.ToBoolean(_reader["IsAvailable"]);
            book.DatePublication = Convert.ToDateTime(_reader["DatePublication"]);

            return book;
        }

        public Dictionary<string, object> GetParam(Book book)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", book.Id);
            dic.Add("Title", book.Title);
            dic.Add("Theme", book.Theme);
            dic.Add("Autor", book.Autor);
            dic.Add("Volume", book.Volume);
            dic.Add("DatePublication", book.DatePublication);
            dic.Add("IsAvailable", book.IsAvailable);

            return dic;
        }
    }
}
