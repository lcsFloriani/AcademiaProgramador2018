using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Boloes;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjetoLoterica.Infra.Data.Features.Boloes
{
    public class BolaoRepository : IBolaoRepository
    {
        public Bolao Add(Bolao bolao)
        {
            string sqlInsert = @"INSERT INTO TBBoloes (Numero) VALUES (@Numero)";

            bolao.Validar();

            bolao.Id = Db.Insert(sqlInsert, Take(bolao));

            return bolao;
        }

        public void Delete(Bolao bolao)
        {
            string sqlDelete = @"DELETE FROM TBBoloes WHERE Id = @Id";

            Db.Delete(sqlDelete, Take(bolao));
        }

        public Bolao Get(long id)
        {
            string sqlGet = @"SELECT * FROM TBBoloes WHERE Id = @Id";

            if (id <= 0)
                throw new IdentifierUndefinedException();

            return Db.Get(sqlGet, Make, TakeId(id));
        }

        public IList<Bolao> GetAll()
        {
            string sqlGetAll = @"SELECT * FROM TBBoloes";

            return Db.GetAll(sqlGetAll, Make);
        }

        public Bolao Update(Bolao bolao)
        {
            throw new BolaoUpdateException();
        }

        private static Func<IDataReader, Bolao> Make = reader =>
         new Bolao
         {
             Id = Convert.ToInt64(reader["Id"]),
             Numero = Convert.ToInt32(reader["Numero"]),
         };

        private object[] Take(Bolao bolao)
        {
            return new object[]
            {
                "@Id", bolao.Id,
                "@Numero", bolao.Numero
            };
        }

        private object[] TakeId(long id)
        {
            return new object[]
            {
                "@Id", id
            };
        }
    }
}
