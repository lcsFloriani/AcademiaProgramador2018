using FlorianiProva.Infra.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Comum.Base
{
    public static class BaseSqlTeste
    {
        private const string DELETAR_ALUNO = @"DELETE FROM TBAluno DBCC CHECKIDENT('TBAluno', RESEED, 0)";
        private const string DELETAR_AVALIACAO = @"DELETE FROM TBAvaliacao DBCC CHECKIDENT('TBAvaliacao', RESEED, 0)";
        private const string INSERIR_ALUNO = @"INSERT INTO TBAluno (Nome, Idade) VALUES ('Lucas Floriani', 20)";
        private const string INSERIR_AVALIACAO = @"INSERT INTO TBAvaliacao (Assunto, Data) VALUES ('tdd', GETDATE())";
        public static void SemearBanco()
        {
            Db.Delete(DELETAR_ALUNO);
            Db.Delete(DELETAR_AVALIACAO);
            Db.Update(INSERIR_ALUNO);
            Db.Update(INSERIR_AVALIACAO);
        }       
    }
}
