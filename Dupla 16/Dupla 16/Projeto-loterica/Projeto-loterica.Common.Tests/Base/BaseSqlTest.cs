using Projeto_loterica.Infra.Dbs;

namespace Projeto_loterica.Common.Tests.Base
{
    public class BaseSqlTest
    {
        private const string RECREATE_TABLES = "TRUNCATE TABLE [dbo].[TBApostaBolao];" +
                                                   "TRUNCATE TABLE [dbo].[TBBolaoConcurso];" +
                                                   "TRUNCATE TABLE [dbo].[TBApostaConcurso];" +
                                                   "delete from [dbo].[TBConcurso] DBCC checkident ('TBConcurso',RESEED,0);" +
                                                   "delete from [dbo].[TBAposta] DBCC checkident ('TBAposta',RESEED,0);" +
                                                   "delete from [dbo].[TBBolao] DBCC checkident ('TBBolao',RESEED,0)";
                                                  

        private const string INSERT_APOSTA = "INSERT INTO TBAposta(Numeros,Vencedor,ValorRecebido,ValorPago) VALUES ('12,2,19,3,22,30', 1,0,3);" +
                                             "INSERT INTO TBAposta(Numeros,Vencedor,ValorRecebido,ValorPago) VALUES ('5,2,11,4,12,10', 2,0,3)";

        private const string INSERT_BOLAO = "INSERT INTO TBBolao(ValorApostas) VALUES(5.00)";

        private const string INSERT_CONCURSO = "INSERT INTO TBConcurso(ResultadoSorteado,ResultadoValor,DataConcurso,QuantidadeQuadra,QuantidadeMega,QuantidadeQuina, MediaQuina, MediaQuadra, MediaSena) VALUES ('1,2,3,4,5,6',1000,GETDATE(),0,0,0,0,0,0)";

        private const string INSERT_APOSTA_BOLAO = "INSERT INTO TBApostaBolao(aposta_id,bolao_id) VALUES (1,1)";

        private const string INSERT_BOLAO_CONCURSO = "INSERT INTO TBBolaoConcurso(bolao_id,concurso_id) VALUES (1,1)";

        private const string INSERT_APOSTA_CONCURSO = "INSERT INTO TBApostaConcurso(aposta_id,concurso_id) VALUES (2,1)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_TABLES);

            Db.Update(INSERT_APOSTA);
            Db.Update(INSERT_BOLAO);
            Db.Update(INSERT_CONCURSO);
            Db.Update(INSERT_APOSTA_BOLAO);
            Db.Update(INSERT_BOLAO_CONCURSO);
            Db.Update(INSERT_APOSTA_CONCURSO);
        }
    }
}
