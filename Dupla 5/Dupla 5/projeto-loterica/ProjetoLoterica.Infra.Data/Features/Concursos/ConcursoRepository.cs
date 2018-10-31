using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Apostas;
using ProjetoLoterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProjetoLoterica.Infra.Data.Features.Concursos
{
    public class ConcursoRepository : IConcursoRepository
    {
        public Concurso Add(Concurso concurso)
        {
            string sqlInsert =
                @"INSERT INTO TBConcursos
                    (Numero,
                     Data,
                     Premio,
                     PremioQuadra,
                     PremioQuina,
                     PremioSena,
                     LucroLoterica,
                     GanhadoresQuadra,
                     GanhadoresQuina,
                     GanhadoresSena,
                     PremioGanhadoresQuadra,
                     PremioGanhadoresQuina,
                     PremioGanhadoresSena,
                     Situacao)
                VALUES
                    (@Numero,
                     @Data,
                     @Premio,
                     @PremioQuadra,
                     @PremioQuina,
                     @PremioSena,
                     @LucroLoterica,
                     @GanhadoresQuadra,
                     @GanhadoresQuina,
                     @GanhadoresSena,
                     @PremioGanhadoresQuadra,
                     @PremioGanhadoresQuina,
                     @PremioGanhadoresSena,                     
                     @Situacao)";

            concurso.Validar();

            concurso.Id = Db.Insert(sqlInsert, Take(concurso));

            foreach (var item in concurso.Dezenas)
            {
                string sqlInsertConcursoDezenas =
                    @"INSERT INTO TBConcursos_Dezenas
                        (ConcursoId,
                         Dezena)
                    VALUES
                        (@ConcursoId,
                         @Dezena)";
                Db.Insert(sqlInsertConcursoDezenas, TakeConcursoDezenas(concurso, item));
            }

            return concurso;
        }

        public void Delete(Concurso concurso)
        {
            if(GetAllApostasNoConcurso(concurso.Id).Count <= 0)
            {
                string sqlDeleteDezenas =
                    @"DELETE FROM
                        TBConcursos_Dezenas
                    WHERE
                        ConcursoId = @id";

                string sqlDelete = @"DELETE FROM TBConcursos WHERE Id = @Id";

                Db.Delete(sqlDeleteDezenas, TakeId(concurso.Id));
                Db.Delete(sqlDelete, TakeId(concurso.Id));
            }
            else
            {
                throw new ConcursoTemApostasException();
            }
        }

        public Concurso Get(long id)
        {
            string sqlGet =
                @"SELECT
                    C.Id,
                    C.Numero AS Numero,
                    C.Data AS Data,
                    C.Premio AS Premio,
                    C.PremioQuadra AS PremioQuadra,
                    C.PremioQuina AS PremioQuina,
                    C.PremioSena AS PremioSena,
                    C.LucroLoterica AS LucroLoterica,
                    C.GanhadoresQuadra AS GanhadoresQuadra,
                    C.GanhadoresQuina AS GanhadoresQuina,
                    C.GanhadoresSena AS GanhadoresSena,
                    C.PremioGanhadoresQuadra AS PremioGanhadoresQuadra,
                    C.PremioGanhadoresQuina AS PremioGanhadoresQuina,
                    C.PremioGanhadoresSena AS PremioGanhadoresSena,
                    C.Situacao AS Situacao
                FROM
                    TBConcursos AS C
                INNER JOIN
                    TBConcursos_Dezenas AS CD ON C.Id = CD.ConcursoId WHERE C.Id = @Id";

            string sqlGetDezenas = @"SELECT CD.Dezena FROM
                TBConcursos AS C
                INNER JOIN TBConcursos_Dezenas AS CD ON C.Id = CD.ConcursoId WHERE C.Id = @Id";

            if (id <= 0)
                throw new IdentifierUndefinedException();

            var concurso = Db.Get(sqlGet, Make, TakeId(id));
            if (concurso != null)
                concurso.Dezenas = Db.GetAll(sqlGetDezenas, MakeDezena, TakeId(id));

            return concurso;
        }

        private IList<Aposta> GetAllApostasNoConcurso(long concursoId)
        {
            string sqlGetAll = "SELECT * FROM TBApostas WHERE ConcursoId = @Id";
            return Db.GetAll(sqlGetAll, MakeAposta, TakeId(concursoId));
        }

        public IList<Concurso> GetAll()
        {
            string sqlGetAll =
                @"SELECT
                    C.Id,
                    C.Numero AS Numero,
                    C.Data AS Data,
                    C.Premio AS Premio,
                    C.PremioQuadra AS PremioQuadra,
                    C.PremioQuina AS PremioQuina,
                    C.PremioSena AS PremioSena,
                    C.LucroLoterica AS LucroLoterica,
                    C.GanhadoresQuadra AS GanhadoresQuadra,
                    C.GanhadoresQuina AS GanhadoresQuina,
                    C.GanhadoresSena AS GanhadoresSena,
                    C.PremioGanhadoresQuadra AS PremioGanhadoresQuadra,
                    C.PremioGanhadoresQuina AS PremioGanhadoresQuina,
                    C.PremioGanhadoresSena AS PremioGanhadoresSena,
                    C.Situacao AS Situacao
                FROM TBConcursos AS C";

            string sqlGetDezenas =
                @"SELECT
                    CD.Dezena
                FROM TBConcursos AS C
                    INNER JOIN TBConcursos_Dezenas AS CD ON C.Id = CD.ConcursoId
                WHERE C.Id = @Id";

            IList<Concurso> concursos =  Db.GetAll(sqlGetAll, Make);
            
            for (int i = 0; i < concursos.Count; i++)
            {
                concursos[i].Dezenas = Db.GetAll(sqlGetDezenas, MakeDezena, TakeId(concursos[i].Id));
            }

            return concursos;
        }

        public IList<Concurso> GetAllConcursosFechados()
        {
            string sqlGetAll =
                @"SELECT
                    C.Id,
                    C.Numero AS Numero,
                    C.Data AS Data,
                    C.Premio AS Premio,
                    C.PremioQuadra AS PremioQuadra,
                    C.PremioQuina AS PremioQuina,
                    C.PremioSena AS PremioSena,
                    C.LucroLoterica AS LucroLoterica,
                    C.GanhadoresQuadra AS GanhadoresQuadra,
                    C.GanhadoresQuina AS GanhadoresQuina,
                    C.GanhadoresSena AS GanhadoresSena,
                    C.PremioGanhadoresQuadra AS PremioGanhadoresQuadra,
                    C.PremioGanhadoresQuina AS PremioGanhadoresQuina,
                    C.PremioGanhadoresSena AS PremioGanhadoresSena,
                    C.Situacao AS Situacao
                FROM TBConcursos AS C WHERE Situacao = 0";

            string sqlGetDezenas =
                @"SELECT
                    CD.Dezena
                FROM TBConcursos AS C
                    INNER JOIN TBConcursos_Dezenas AS CD ON C.Id = CD.ConcursoId
                WHERE C.Id = @Id";

            IList<Concurso> concursos = Db.GetAll(sqlGetAll, Make);

            for (int i = 0; i < concursos.Count; i++)
            {
                concursos[i].Dezenas = Db.GetAll(sqlGetDezenas, MakeDezena, TakeId(concursos[i].Id));
            }

            return concursos;
        }

        public Concurso Update(Concurso concurso)
        {
            string sqlUpdate =
                @"UPDATE TBConcursos SET
                    Data = @Data,
                    Situacao = @Situacao WHERE Id = @Id";

            concurso.Validar();

            Db.Update(sqlUpdate, Take(concurso));

            return concurso;
        }

        public Concurso UpdateSituacao(Concurso concurso) {
            string sqlUpdateSituacao = 
                @"UPDATE TBConcursos SET 
                    Situacao = @Situacao WHERE Id = @Id";

            bool novaSituacao;
            if (concurso.Situacao) {
                novaSituacao = false;
                concurso.Fechar();
            }
            else
                novaSituacao = true;

            Db.Update(sqlUpdateSituacao, TakeSituacao(novaSituacao, concurso.Id));
            return concurso;
        }

        private object[] TakeSituacao(bool situacao, long id)
        {
            return new object[]
            {
                "@Situacao", situacao,
                "@Id", id
            };
        }
        private static Func<IDataReader, Concurso> Make = reader =>
          new Concurso
          {
              Id = Convert.ToInt64(reader["Id"]),
              Numero = Convert.ToInt64(reader["Numero"]),
              Data = Convert.ToDateTime(reader["Data"]),
              Premio = Convert.ToDouble(reader["Premio"]),
              PremioQuadra = Convert.ToDouble(reader["PremioQuadra"]),
              PremioQuina = Convert.ToDouble(reader["PremioQuina"]),
              PremioSena = Convert.ToDouble(reader["PremioSena"]),
              LucroLoterica = Convert.ToDouble(reader["LucroLoterica"]),
              Ganhadores_Quadra = Convert.ToInt32(reader["GanhadoresQuadra"]),
              Ganhadores_Quina = Convert.ToInt32(reader["GanhadoresQuina"]),
              Ganhadores_Sena = Convert.ToInt32(reader["GanhadoresSena"]),
              PremioGanhadoresQuadra = Convert.ToDouble(reader["PremioGanhadoresQuadra"]),
              PremioGanhadoresQuina = Convert.ToDouble(reader["PremioGanhadoresQuina"]),
              PremioGanhadoresSena = Convert.ToDouble(reader["PremioGanhadoresSena"]),
              Situacao = Convert.ToBoolean(reader["Situacao"]),
          };

        private static Func<IDataReader, Int32> MakeDezena = reader =>
              Convert.ToInt32(reader["Dezena"]);

        private static Func<IDataReader, Aposta> MakeAposta = reader =>
           new Aposta
           {
               Id = Convert.ToInt64(reader["Id"]),
               Data = Convert.ToDateTime(reader["Data"]),
               Valor = Convert.ToDouble(reader["Valor"])
           };

        private object[] Take(Concurso concurso)
        {
            return new object[]
            {
                "@Id", concurso.Id,
                "@Numero", concurso.Numero,
                "@Data", concurso.Data,
                "@Premio", concurso.Premio,
                "@PremioQuadra", concurso.PremioQuadra,
                "@PremioQuina", concurso.PremioQuina,
                "@PremioSena", concurso.PremioSena,
                "@LucroLoterica", concurso.LucroLoterica,
                "@GanhadoresQuadra", concurso.Ganhadores_Quadra,
                "@GanhadoresQuina", concurso.Ganhadores_Quina,
                "@GanhadoresSena", concurso.Ganhadores_Sena,
                "@PremioGanhadoresQuadra", concurso.PremioGanhadoresQuadra,
                "@PremioGanhadoresQuina", concurso.PremioGanhadoresQuina,
                "@PremioGanhadoresSena", concurso.PremioGanhadoresSena,
                "@Situacao", concurso.Situacao
            };
        }

        private object[] TakeId(long id)
        {
            return new object[]
            {
                "@Id", id
            };
        }

        private object[] TakeConcursoDezenas(Concurso concurso, int dezena)
        {
            return new object[]
            {
                "@ConcursoId", concurso.Id,
                "@Dezena", dezena
            };
        }
    }
}
