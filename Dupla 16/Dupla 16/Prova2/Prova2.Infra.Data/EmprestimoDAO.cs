using System;
using System.Collections.Generic;
using Prova2.Domain;
using Prova2.Infra.Database;
using System.Data;

namespace Prova2.Infra.Data
{
    public class EmprestimoDAO
    {
        public const string _sqlInsert = @"INSERT INTO Emprestimo
                                                       (Cliente
                                                       ,id_livro
                                                       ,dataDevolucao)
                                                   VALUES
                                                         ({0}Cliente,
                                                          {0}id_livro,
                                                          {0}dataDevolucao)";

        public const string _sqlSelectAll = @"SELECT  E.Id
                                                     ,E.Cliente
                                                     ,E.id_livro
                                                     ,E.dataDevolucao
	                                                 ,L.Titulo
	                                                 ,L.Tema
	                                                 ,L.Autor
	                                                 ,L.Disponibilidade
	                                                 ,L.Volume
	                                                 ,L.DataPublicacao
                                               FROM Emprestimo AS E
                                               INNER JOIN LIVRO AS L
                                               ON L.Id = E.id_livro";

        public const string _sqlSelect = @"SELECT  E.Id
                                                     ,E.Cliente
                                                     ,E.id_livro
                                                     ,E.dataDevolucao
	                                                 ,L.Titulo
	                                                 ,L.Tema
	                                                 ,L.Autor
	                                                 ,L.Disponibilidade
	                                                 ,L.Volume
	                                                 ,L.DataPublicacao
                                               FROM Emprestimo AS E
                                               INNER JOIN LIVRO AS L
                                               ON l.Id = E.id_livro
                                           WHERE E.Id = {0}Id";

        public const string _sqlUpdate = @"UPDATE Emprestimo
                                                   SET Cliente = {0}Cliente
                                                      ,id_livro = {0}id_livro
                                                      ,dataDevolucao = {0}dataDevolucao
                                                    WHERE Id = {0}Id";

        public static string _sqlDelete = @"DELETE FROM Emprestimo
                                                    WHERE Id = {0}Id";

        public Emprestimo Add(Emprestimo emprestimo)
        {
            emprestimo.Id = Db.Insert(_sqlInsert, Take2(emprestimo));

            return emprestimo;
        }

        public IList<Emprestimo> GetAll()
        {
            return Db.GetAll(_sqlSelectAll, Make);
        }
        public Emprestimo GetById(int id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", id } };

            return Db.Get(_sqlSelect, Make, parms);
        }

        public void Update(Emprestimo emprestimo)
        {
            Db.Update(_sqlUpdate, Take2(emprestimo));
        }

        public void Delete(int id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", id } };

            Db.Delete(_sqlDelete, parms);
        }


        private Dictionary<string, object> Take2(Emprestimo emprestimo)
        {
            return new Dictionary<string, object>
            {
                { "Id", emprestimo.Id },
                { "Cliente", emprestimo.Cliente },
                { "id_livro", emprestimo.Livro.Id },
                { "dataDevolucao", emprestimo.dataDevolucao }
            };
        }

        private Emprestimo Make(IDataReader reader)
        {
            Emprestimo emprestimo = new Emprestimo();

            emprestimo.Id = Convert.ToInt32(reader["Id"]);
            emprestimo.Cliente = Convert.ToString(reader["Cliente"]);
            emprestimo.dataDevolucao = Convert.ToDateTime(reader["dataDevolucao"]);
            emprestimo.Livro.Id = Convert.ToInt32(reader["id_livro"]);
            emprestimo.Livro.Titulo = Convert.ToString(reader["Titulo"]);
            emprestimo.Livro.Tema = Convert.ToString(reader["Tema"]);
            emprestimo.Livro.Autor = Convert.ToString(reader["Autor"]);
            emprestimo.Livro.Volume = Convert.ToInt32(reader["Volume"]);
            emprestimo.Livro.DataPublicacao = Convert.ToDateTime(reader["DataPublicacao"]);
            emprestimo.Livro.Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"]);

            return emprestimo;
        }
    }
}
