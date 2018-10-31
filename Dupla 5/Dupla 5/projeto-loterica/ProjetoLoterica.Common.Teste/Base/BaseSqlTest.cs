using ProjetoLoterica.Infra;

namespace ProjetoLoterica.Common.Teste.Base
{
    public static class BaseSqlTest
    {
        private const string RECREATE_CONCURSO_TABLE = "DELETE FROM TBConcursos";
        private const string RECREATE_APOSTA_TABLE = "DELETE FROM TBApostas";
        private const string RECREATE_BOLAO_TABLE = "DELETE FROM TBBoloes";
        private const string RECREATE_APOSTAS_DEZENAS_TABLE = "DELETE FROM TBApostas_Dezenas";
        private const string RECREATE_CONCURSOS_DEZENAS_TABLE = "DELETE FROM TBConcursos_Dezenas";

        private const string RESET_AA_CONCURSO = "DBCC CHECKIDENT('TBConcursos', RESEED, 0)";
        private const string RESET_AA_APOSTA = "DBCC CHECKIDENT('TBApostas', RESEED, 0)";
        private const string RESET_AA_BOLAO = "DBCC CHECKIDENT('TBBoloes', RESEED, 0)";
        private const string RESET_AA_APOSTA_DEZENA = "DBCC CHECKIDENT('TBApostas_Dezenas', RESEED, 0)";
        private const string RESET_AA_CONCURSO_DEZENA = "DBCC CHECKIDENT('TBConcursos_Dezenas', RESEED, 0)";

        private const string INSERT_CONCURSO =
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
                (1000,
                 GETDATE(),
                 1500250,
                 50000,
                 75000,
                 100000,
                 100500,
                 30,
                 20,
                 1,
                 1667,
                 3750,
                 100000,
                 0)";
        
        private const string INSERT_APOSTA =
            @"INSERT INTO TBApostas
                (ConcursoID,
                 Data,
                 Valor)
            VALUES
                (1,
                 GETDATE(),
                 10)";

        private const string INSERT_BOLAO = @"INSERT INTO TBBoloes (Numero) VALUES (1234)";

        private const string INSERT_DEZENAS_CONCURSO =
            @"INSERT INTO TBConcursos_Dezenas
                (ConcursoId,
                 Dezena)
            VALUES
                (1,
                 @Dezenas)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_CONCURSOS_DEZENAS_TABLE);
            Db.Update(RECREATE_APOSTAS_DEZENAS_TABLE);
            Db.Update(RECREATE_APOSTA_TABLE);
            Db.Update(RECREATE_CONCURSO_TABLE);
            Db.Update(RECREATE_BOLAO_TABLE);

            Db.Update(RESET_AA_CONCURSO);
            Db.Update(RESET_AA_APOSTA);
            Db.Update(RESET_AA_BOLAO);
            Db.Update(RESET_AA_APOSTA_DEZENA);
            Db.Update(RESET_AA_CONCURSO_DEZENA);

            Db.Update(INSERT_CONCURSO);
            Db.Update(INSERT_APOSTA);
            Db.Update(INSERT_BOLAO);

            for (int i = 1; i <= 6; i++)
            {
                Db.Insert(INSERT_DEZENAS_CONCURSO, Take(i));
            }
        }

        private static object[] Take(long id)
        {
            return new object[]
            {
                "@Dezenas", id
            };
        }
    }
}
