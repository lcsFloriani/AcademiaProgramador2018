using FlorianiProva.Dominio.Funcionalidades.Compromissos;
using FlorianiProva.Infra.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlorianiProva.Dominio.Funcionalidades.Contatos;

namespace FlorianiProva.Infra.Data
{
    public class CompromissoRepository : ICompromissoRepository
    {
        #region querys
        private readonly string _sqlInsertCompromisso = @"INSERT INTO TBCompromissos (assunto, local, data_inicio, data_fim) VALUES ({0}Assunto, {0}Local, {0}Data_Inicio, {0}Data_Fim)";
        private readonly string _sqlInsertCompromissoContato = @"INSERT INTO TBCompromissos_Contatos(id_compromisso, id_contato) VALUES ({0}Compromisso, {0}Contato)";
        private readonly string _sqlDeleteTBCompromissoContato = "DELETE FROM TBCompromissos_Contatos WHERE id_compromisso = {0}CompromissoID";
        private readonly string _sqlDeleteCompromisso = @"DELETE FROM TBCompromissos WHERE Id = {0}ID";
        private readonly string _sqlSelectAll = "SELECT * FROM TBCompromissos order by data_inicio";
        private readonly string _sqlSelectContatos = "SELECT CC.id_compromisso, C.Id, C.nome, C.email, C.departamento, C.endereco, C.telefone FROM TBCompromissos_Contatos AS CC INNER JOIN TBContato AS C ON C.Id = CC.id_contato WHERE cc.id_compromisso = {0}CompromissoID";
        private readonly string _sqlUpdate = "UPDATE TBCompromissos SET assunto = {0}Assunto, local = {0}Local, data_inicio = {0}Data_Inicio, data_fim = {0}Data_Fim  WHERE ID = {0}ID ";
        #endregion
        public Compromisso Adicionar(Compromisso entidade)
        {
            entidade.Id = Db.Insert(_sqlInsertCompromisso, GetParametros(entidade));
            return entidade;
        }

        public void AdicionarContatos_Compromisso(int compromisso, int contato)
        {
            Db.Insert(_sqlInsertCompromissoContato, TakeCompromissoContato(compromisso, contato));
        }

        public void Deletar(Compromisso entidade)
        {
            DeletarTabelaAuxiliar(entidade);

            var parms = new Dictionary<string, object> { { "ID", entidade.Id } };

            Db.Delete(_sqlDeleteCompromisso, parms);
        }

        public void DeletarTabelaAuxiliar(Compromisso entidade)
        {
            var parms = new Dictionary<string, object> { { "CompromissoID", entidade.Id } };

            Db.Delete(_sqlDeleteTBCompromissoContato, parms);
        }
        public IList<Contato> TrazerContatos(Compromisso compromisso)
        {
            var parms = new Dictionary<string, object> { { "CompromissoID", compromisso.Id } };
            return Db.GetAll(_sqlSelectContatos, MakeContato, parms);
        }
        public Compromisso Editar(Compromisso entidade)
        {
            Db.Update(_sqlUpdate, GetParametros(entidade));
            return entidade;
        }

        public IList<Compromisso> TrazerTodos()
        {
            return Db.GetAll(_sqlSelectAll, Make);
        }
        private Dictionary<string, object> GetParametros(Compromisso compromisso)
        {
            return new Dictionary<string, object>
            {
                { "ID", compromisso.Id},
                { "Assunto", compromisso.Assunto },
                { "Local", compromisso.Local },
                { "Data_Inicio", compromisso.Inicio },
                { "Data_Fim", compromisso.Fim }
            };
        }
        private Dictionary<string, object> TakeCompromissoContato(int compromisso, int contato)
        {
            return new Dictionary<string, object>
            {
                { "Compromisso", compromisso},
                { "Contato", contato}
            };
        }
        public Compromisso Make(IDataReader reader)
        {
            return new Compromisso
            {
                Id = Convert.ToInt32(reader["Id"]),
                Assunto = Convert.ToString(reader["assunto"]),
                Local = Convert.ToString(reader["local"]),
                Inicio = Convert.ToDateTime(reader["data_inicio"]),
                Fim = Convert.ToDateTime(reader["data_fim"])

            };
        }
        public Contato MakeContato(IDataReader reader)
        {
            return new Contato
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = Convert.ToString(reader["nome"]),
                Email = Convert.ToString(reader["email"]),
                Departamento = Convert.ToString(reader["departamento"]),
                Endereco = Convert.ToString(reader["endereco"]),
                Telefone = Convert.ToString(reader["telefone"])
            };
        }
    }
}
