using FlorianiProva.Dominio.Funcionalidades.Contatos;
using FlorianiProva.Infra.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlorianiProva.Dominio.Funcionalidades.Compromissos;

namespace FlorianiProva.Infra.Data
{
    public class ContatoRepository : IContatoRepository
    {
        #region Querys
        private readonly string _sqlInsert = @"INSERT INTO TBContato (nome, email, departamento, endereco, telefone) VALUES ({0}NOME, {0}EMAIL, {0}DEPARTAMENTO, {0}ENDERECO, {0}TELEFONE)";
        private readonly string _sqlUpdate = @"UPDATE TBContato set nome = {0}NOME, email = {0}EMAIL, departamento = {0}DEPARTAMENTO, endereco = {0}ENDERECO, telefone = {0}TELEFONE where Id={0}ID";
        private readonly string _sqlDelete = @"DELETE FROM TBContato WHERE Id={0}ID";
        private readonly string _sqlSelectAll = "SELECT * FROM TBContato order by nome";
        private readonly string _sqlSelectPorContato = "SELECT * FROM TBCompromissos_Contatos where id_contato = {0}ContatoID";
        #endregion
        public Contato Adicionar(Contato entidade)
        {
            entidade.Id = Db.Insert(_sqlInsert, GetParametros(entidade));
            return entidade;
        }
        public void Deletar(Contato entidade)
        {
            var parms = new Dictionary<string, object> { { "ID", entidade.Id } };
            Db.Delete(_sqlDelete, parms);
        }

        public Contato Editar(Contato entidade)
        {
            Db.Update(_sqlUpdate, GetParametros(entidade));
            return entidade;
        }

        public IList<Contato> TrazerTodos()
        {
            return Db.GetAll(_sqlSelectAll, Converter);
        }

        private Dictionary<string, object> GetParametros(Contato contato)
        {
            return new Dictionary<string, object>
            {
                { "ID", contato.Id },
                { "NOME", contato.Nome },
                { "EMAIL", contato.Email },
                { "DEPARTAMENTO", contato.Departamento },
                { "ENDERECO", contato.Endereco },
                { "TELEFONE", contato.Telefone }
            };
        }


        private static Func<IDataReader, Contato> Converter = reader =>
            new Contato
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = Convert.ToString(reader["nome"]),
                Email = Convert.ToString(reader["email"]),
                Departamento = Convert.ToString(reader["departamento"]),
                Endereco = Convert.ToString(reader["endereco"]),
                Telefone = Convert.ToString(reader["telefone"])
            };

        public bool BuscarContato(int entidadeId)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "ContatoID", entidadeId } };
            Contato t = Db.Get<Contato>(_sqlSelectPorContato, MakePorContato, parms);

            if (t == null)
                return true;

            return false;
        }
        private static Func<IDataReader, Contato> MakePorContato = reader =>
            new Contato()
            {
                Id = Convert.ToInt32(reader["id_contato"])
            };
    }
}
