using FlorianiProva.Dominio.Exceções;
using FlorianiProva.Dominio.Features.Alunos;
using FlorianiProva.Infra.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Infra.Data.Features.Alunos
{
    public class AlunoRepository : IAlunoRepository
    {
        #region sql 
        private string _sqlInserir = @"INSERT INTO [TBAluno]
                                                       ([Nome]
                                                       ,[Idade])
                                                 VALUES
                                                       ({0}Nome
                                                       ,{0}Idade)";
        private string _sqlUpdate = @"UPDATE TBAluno SET Nome = {0}Nome, Idade = {0}Idade WHERE Id = @Id";
        private string _sqlDeletar = @"DELETE FROM [dbo].[TBAluno] WHERE Id = {0}Id";
        private string _sqlObterPorId = @"SELECT * FROM [dbo].[TBAluno] WHERE Id = {0}Id";
        private string _sqlObterTodos = @"SELECT * FROM [dbo].[TBAluno]";
        #endregion

        private Dictionary<string, object> ObtemParametros(Aluno aluno)
        {
            var parms = new Dictionary<string, object>
            {
                { "Id", aluno.Id },
                { "Nome", aluno.Nome },
                { "Idade", aluno.Idade }
            };
            return parms;
        }
        private Aluno SetarParmetros(IDataReader reader) => new Aluno
        {
            Id = Convert.ToInt64(reader["Id"]),
            Nome = Convert.ToString(reader["Nome"]),
            Idade = Convert.ToInt32(reader["Idade"])
        };
        public Aluno Atualizar(Aluno aluno)
        {
            aluno.Validar();
            Db.Update(_sqlUpdate, ObtemParametros(aluno));
            return aluno;
        }

        public bool Deletar(long id)
        {
            if (id <= 0 ) throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "Id", id } };

            int linhasAfetadas = Db.Delete(_sqlDeletar, parms);

            if (linhasAfetadas < 1)
                return false;

            return true;
        }

        public Aluno Inserir(Aluno aluno)
        {
            aluno.Validar();
            aluno.Id = Db.Insert(_sqlInserir, ObtemParametros(aluno));
            return aluno;
        }

        public Aluno ObterPorId(long id)
        {
            if (id <=  0) throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "Id", id } };

            return Db.Get<Aluno>(_sqlObterPorId, SetarParmetros, parms);
        }

        public List<Aluno> ObterTodos() => Db.GetAll(_sqlObterTodos, SetarParmetros);
    }
}
