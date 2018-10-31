using Prova2.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using Prova2.Infra;
using Prova2.Infra.Database;

namespace Prova2.Infra.Data
{
    public class LivroDAO
    {
        public const string _sqlInsert = @"INSERT INTO Livro
                                                       (Titulo,
                                                        Tema,
                                                        Autor,
                                                        Volume,
                                                        DataPublicacao,
                                                        Disponibilidade)
                                                  VALUES
                                                        ({0}Titulo,
                                                        {0}Tema,
                                                        {0}Autor,
                                                        {0}Volume,
                                                        {0}DataPublicacao,
                                                        {0}Disponibilidade)";

        public const string _sqlSelectAll = @"SELECT Id
                                                    ,Titulo
                                                    ,Tema
                                                    ,Autor
                                                    ,Volume
                                                    ,DataPublicacao
                                                    ,Disponibilidade
                                                 FROM Livro";

        public const string _sqlSelect = @"SELECT Id
                                                 ,Titulo
                                                 ,Tema
                                                 ,Autor
                                                 ,Volume
                                                 ,DataPublicacao                                        
                                                 ,Disponibilidade
                                                 FROM Livro
                                                    WHERE Id = {0}Id";

        public const string _sqlUpdate = @"UPDATE Livro
                                                        SET Titulo = {0}Titulo
                                                           ,Tema = {0}Tema
                                                           ,Autor = {0}Autor
                                                           ,Volume = {0}Volume
                                                           ,DataPublicacao = {0}DataPublicacao
                                                           ,Disponibilidade = {0}Disponibilidade
                                             WHERE Id = {0}Id";

        public static string _sqlDelete = @"DELETE FROM Livro 
                                             WHERE Id = {0}Id";

        public Livro Add(Livro livro)
        {
            livro.Id = Db.Insert(_sqlInsert, Take(livro));

            return livro;
        }
        public IList<Livro> GetAll()
        {
            return Db.GetAll(_sqlSelectAll, Make);
        }

        public void Update(Livro livro)
        {
            Db.Update(_sqlUpdate, Take(livro));
        }
        public Livro GetById(int id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", id } };

            return Db.Get(_sqlSelect, Make, parms);
        }
        public void Delete(int id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", id } };

            Db.Delete(_sqlDelete, parms);
        }

        private Dictionary<string, object> Take(Livro livro)
        {
            return new Dictionary<string, object>
            {
                { "Id", livro.Id },
                { "Titulo", livro.Titulo },
                { "Tema", livro.Tema },
                { "Autor", livro.Autor },
                { "Volume", livro.Volume },
                { "DataPublicacao", livro.DataPublicacao },
                { "Disponibilidade", livro.Disponibilidade }
            };
        }

        private static Func<IDataReader, Livro> Make = reader =>
          new Livro
          {
              Id = Convert.ToInt32(reader["Id"]),
              Titulo = Convert.ToString(reader["Titulo"]),
              Tema = Convert.ToString(reader["Tema"]),
              Autor = Convert.ToString(reader["Autor"]),
              Volume = Convert.ToInt32(reader["Volume"]),
              DataPublicacao = Convert.ToDateTime(reader["DataPublicacao"]),
              Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"])
          };
        
    }
}