using FlorianiProva.Dominio.Exceções;
using FlorianiProva.Dominio.Features.Avaliações;
using FlorianiProva.Infra.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorianiProva.Infra.Data.Features.Avaliacoes
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private const string _sqlInserir = @"
                    INSERT INTO TBAvaliacao (Assunto, Data) VALUES ({0}Assunto, {0}Data)";
        private const string _sqlUpdate = @"UPDATE TBAvaliacao SET Assunto = {0}Assunto, Data = {0}Data WHERE Id = {0}Id";

        private const string _sqlDelete = @"DELETE FROM TBAvaliacao WHERE Id = {0}Id";
        private const string _sqlObterTodos = @"SELECT * FROM TBAvaliacao";
        private const string _sqlObterPorId = @"SELECT * FROM TBAvaliacao WHERE Id = {0}Id";
        private Dictionary<string, object> ObtemParametros(Avaliacao avaliacao)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("Id", avaliacao.Id);
            parms.Add("Assunto", avaliacao.Assunto);
            parms.Add("Data", avaliacao.Data);
            return parms;
        }
        private Avaliacao SetarParmetros(IDataReader reader) => new Avaliacao
        {
            Id = Convert.ToInt64(reader["Id"]),
            Assunto = Convert.ToString(reader["Assunto"]),
            Data = Convert.ToDateTime(reader["Data"])
        };

        public Avaliacao Atualizar(Avaliacao avaliacao)
        {
            avaliacao.Validar();
            Db.Update(_sqlUpdate, ObtemParametros(avaliacao));
            return avaliacao;
        }

        public bool Deletar(long id)
        {
            if (id <= 0) throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "Id", id } };

            int linhasAfetadas = Db.Delete(_sqlDelete, parms);

            if (linhasAfetadas < 1)
                return false;

            return true;
        }
        public Avaliacao Inserir(Avaliacao avaliacao)
        {
            avaliacao.Validar();
            avaliacao.Id = Db.Insert(_sqlInserir, ObtemParametros(avaliacao));
            return avaliacao;
        }

        public Avaliacao ObterPorId(long id)
        {
            if (id <= 0) throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "Id", id } };

            return Db.Get<Avaliacao>(_sqlObterPorId, SetarParmetros, parms);
        }

        public List<Avaliacao> ObterTodos() => Db.GetAll(_sqlObterTodos, SetarParmetros);
    }
}
