using System;
using System.Collections.Generic;
using ProjetoLoterica.Dominio.Features.Apostas;
using System.Data;
using ProjetoLoterica.Dominio.Exceptions;
using ProjetoLoterica.Dominio.Features.Concursos;

namespace ProjetoLoterica.Infra.Data.Features.Apostas
{
    public class ApostaRepository : IApostaRepository
    {
        public Aposta Add(Aposta aposta)
        {
            string sqlInsert = @"INSERT INTO TBApostas (ConcursoId, BolaoId, Data, Valor)
                VALUES (@ConcursoId, @BolaoId, @Data, @Valor)";

            aposta.Validar();

            aposta.Id = Db.Insert(sqlInsert, Take(aposta));

            foreach (var item in aposta.Dezenas)
            {
                string sqlInsertApostaDezena = @"INSERT INTO TBApostas_Dezenas(ApostaId, Dezena) VALUES (@ApostaId, @Dezena)";
                Db.Insert(sqlInsertApostaDezena, TakeApostaDezena(aposta, item));
            }

            return aposta;
        }

        public void Delete(Aposta aposta)
        {
            string sqlDeleteDezenas = @"DELETE FROM TBApostas_Dezenas WHERE [ApostaId] = @Id";
            string sqlDelete = @"DELETE FROM TBApostas WHERE Id = @Id";

            Db.Update(sqlDeleteDezenas, TakeId(aposta.Id));

            Db.Delete(sqlDelete, Take(aposta));
        }

        public Aposta Get(long id)
        {
            string sqlGet =
                @"SELECT A.Id AS ApostaId, A.BolaoId AS BolaoId, A.Data AS ApostaData, A.Valor AS ApostaValor, 
                    C.Id AS ConcursoId, C.Data AS ConcursoData, C.Numero AS ConcursoNumero, C.GanhadoresQuadra AS GanhadoresQuadra, 
                    C.GanhadoresQuina AS GanhadoresQuina, C.GanhadoresSena AS GanhadoresSena, 
                    C.LucroLoterica AS LucroLoterica, C.PremioGanhadoresQuadra AS PremioGanhadoresQuadra, C.PremioGanhadoresQuina AS PremioGanhadoresQuina, 
                    C.PremioGanhadoresSena AS PremioGanhadoresSena, 
                    C.PremioQuadra AS PremioQuadra, C.PremioQuina AS PremioQuina, C.PremioQuina AS PremioQuina, C.PremioSena AS PremioSena, 
                    C.Situacao AS Situacao, C.Premio AS ConcursoPremio FROM TBApostas as A 
                    INNER JOIN TBConcursos AS C on C.Id = A.ConcursoId WHERE A.Id = @Id";

            if (id <= 0)
                throw new IdentifierUndefinedException();

            return Db.Get(sqlGet, Make, TakeId(id));
        }

        public IList<Aposta> GetAll()
        {
            string sqlGetAll = @"SELECT A.Id AS ApostaId, A.BolaoId AS BolaoId, A.Data AS ApostaData, A.Valor AS ApostaValor, 
                C.Id AS ConcursoId, C.Data AS ConcursoData, C.Numero AS ConcursoNumero, C.GanhadoresQuadra AS GanhadoresQuadra, 
                C.GanhadoresQuina AS GanhadoresQuina, C.GanhadoresSena AS GanhadoresSena, 
                C.LucroLoterica AS LucroLoterica, C.PremioGanhadoresQuadra AS PremioGanhadoresQuadra, C.PremioGanhadoresQuina AS PremioGanhadoresQuina, 
                C.PremioGanhadoresSena AS PremioGanhadoresSena, 
                C.PremioQuadra AS PremioQuadra, C.PremioQuina AS PremioQuina, C.PremioQuina AS PremioQuina, C.PremioSena AS PremioSena, 
                C.Situacao AS Situacao, C.Premio AS ConcursoPremio FROM TBApostas as A 
                INNER JOIN TBConcursos AS C on C.Id = A.ConcursoId";

            return Db.GetAll(sqlGetAll, Make);
        }

        public IList<Aposta> GetApostasComBolao(long id)
        {
            string sqlGetApostasComBolao = @"SELECT * FROM TBApostas WHERE BolaoId = @Id";

            var parms = new object[] { "Id", id };

            return Db.GetAll(sqlGetApostasComBolao, Make, parms);
        }

        public Concurso GetConcurso(long id)
        {
            string SqlGetConcurso = "SELECT * FROM TBConcursos WHERE Id = @Id";

            if (id <= 0)
                throw new IdentifierUndefinedException();

            var parms = new object[] { "ID", id };

            return Db.Get(SqlGetConcurso, MakeConcurso, parms);
        }

        public Aposta Update(Aposta aposta)
        {
            aposta.Validar();

            string sqlUpdate = @"UPDATE TBApostas SET ConcursoId = @ConcursoId, Data = @Data, Valor = @Valor WHERE Id = @Id";

            Db.Update(sqlUpdate, Take(aposta));

            return aposta;
        }

        private static Func<IDataReader, Aposta> Make = reader =>
           new Aposta
           {
               Id = Convert.ToInt64(reader["ApostaId"]),
               Data = Convert.ToDateTime(reader["ApostaData"]),
               Valor = Convert.ToDouble(reader["ApostaValor"]),
               Concurso = new Concurso()
               {
                   Id = Convert.ToInt32(reader["ConcursoId"]),
                   Data = Convert.ToDateTime(reader["ConcursoData"]),
                   Numero = Convert.ToInt32(reader["ConcursoNumero"]),
                   Premio = Convert.ToDouble(reader["ConcursoPremio"]),
                   LucroLoterica = Convert.ToDouble(reader["LucroLoterica"]),
                   PremioQuadra = Convert.ToDouble(reader["PremioQuadra"]),
                   PremioQuina = Convert.ToDouble(reader["PremioQuina"]),
                   PremioSena = Convert.ToDouble(reader["PremioSena"]),
                   Ganhadores_Quadra  = Convert.ToInt32(reader["GanhadoresQuadra"]),
                   Ganhadores_Quina = Convert.ToInt32(reader["GanhadoresQuina"]),
                   Ganhadores_Sena = Convert.ToInt32(reader["GanhadoresSena"]),
                   PremioGanhadoresQuadra = Convert.ToInt32(reader["PremioGanhadoresQuadra"]), 
                   PremioGanhadoresQuina = Convert.ToInt32(reader["PremioGanhadoresQuina"]),
                   PremioGanhadoresSena = Convert.ToInt32(reader["PremioGanhadoresSena"]),
                   Situacao = Convert.ToBoolean(reader["Situacao"])
               }
           };

        private static Func<IDataReader, Concurso> MakeConcurso = reader =>
         new Concurso
         {
             Id = Convert.ToInt64(reader["Id"]),
             Numero = Convert.ToInt64(reader["Numero"]),
             Data = Convert.ToDateTime(reader["Data"]),
             Premio = Convert.ToDouble(reader["Premio"]),
         };

        private object[] Take(Aposta aposta)
        {
            return new object[]
            {
                "@Id", aposta.Id,
                "@ConcursoId", aposta.Concurso.Id,
                "@BolaoId", aposta.Bolao.Id,
                "@Data", aposta.Data,
                "@Valor", aposta.Valor
            };
        }

        private object[] TakeId(long id)
        {
            return new object[]
            {
                "@Id", id
            };
        }

        private object[] TakeApostaDezena(Aposta aposta, int dezena)
        {
            return new object[]
            {
                "@ApostaId", aposta.Id,
                "@Dezena", dezena
            };
        }
    }
}