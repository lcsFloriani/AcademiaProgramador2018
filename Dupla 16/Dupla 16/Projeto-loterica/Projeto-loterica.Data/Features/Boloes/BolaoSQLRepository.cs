using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Boloes;
using Projeto_loterica.Domain.Features.Enums;
using Projeto_loterica.Infra.Dbs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Infra.Data.Features.Boloes
{
    public class BolaoSQLRepository : IBolaoRepository
    {
        private readonly string SaveSql = @"INSERT INTO TBBolao(
                                            ValorApostas)
                                             VALUES
                                            (@ValorApostas
                                            )";

        private readonly string SaveInTBBolaoAndTBApostaSql = @"INSERT INTO TBApostaBolao(
                                            aposta_id,
                                            bolao_id)
                                             VALUES
                                            (
                                             @aposta_id,
                                             @bolao_id
                                            )";

        readonly string getAllSQL = @"SELECT Id_bolao,                                           
                                            ValorApostas                                            
                                    FROM TBBolao";
        readonly string getAllApostasInBolaoSQL = @"select A.Id_aposta, A.Numeros, A.ValorPago, A.Vencedor, A.ValorRecebido
                                    from TBAposta as A
                                    inner join TBApostaBolao as AB on AB.aposta_id = A.Id_aposta
                                    inner join TBBolao as B on B.Id_bolao = AB.bolao_id
                                    where b.Id_bolao = @Id_bolao";

        readonly string getByIDSQL = @"SELECT Id_bolao,                                           
                                            ValorApostas 
                                FROM TBBolao
                                WHERE Id_bolao = @Id_bolao";

        public Bolao Add(Bolao objeto)
        {
            objeto.Id = Db.Insert(SaveSql, Take(objeto));

            foreach (var item in objeto.Apostas)
            {
                Db.Insert(SaveInTBBolaoAndTBApostaSql, Take(objeto, item));
            }

            return objeto;
        }

        public void Delete(Bolao objeto)
        {
            throw new UnsupportedOperationException();
        }

        public IEnumerable<Bolao> GetAll()
        {
            var list = Db.GetAll(getAllSQL, Make);

            foreach (var item in list)
            {
                item.Apostas.AddRange(Db.GetAll(getAllApostasInBolaoSQL, MakeAposta,TakeBolaoId(item.Id)));
            }
            return list;
        }

        public Bolao GetById(long Id)
        {
            var bolao = Db.Get(getByIDSQL, Make, TakeBolaoId(Id));
            bolao.Apostas.AddRange(Db.GetAll(getAllApostasInBolaoSQL, MakeAposta, TakeBolaoId(Id)));
            return bolao;
        }

        public Bolao Update(Bolao objeto)
        {
            throw new UnsupportedOperationException();
        }

        private static Func<IDataReader, Bolao> Make = reader => new Bolao
        {
            Id = Convert.ToInt32(reader["Id_bolao"])
        };
        private static Func<IDataReader, Aposta> MakeAposta = reader => new Aposta
        {

            Id = Convert.ToInt32(reader["Id_aposta"]),
            Numeros = Aposta.ConversaoParaLista(reader["Numeros"].ToString()),
            ValorPago = Convert.ToDouble(reader["ValorPago"]),
            ValorRecebido = Convert.ToDouble(reader["ValorRecebido"]),
            Resultado = (Vencedora)Convert.ToInt32(reader["Vencedor"])

        };

        private object[] Take(Bolao bolao, Aposta aposta)
        {
            return new object[]
            {
                "@aposta_id", aposta.Id,
                "@bolao_id", bolao.Id
            };
        }
        private object[] Take(Bolao bolao)
        {
            return new object[]
            {
                "@aposta_id", bolao.Id,
                "@ValorApostas", (bolao.custoTotal/bolao.Apostas.Count)
            };
        }

        private object[] TakeBolaoId(long Id)
        {

            return new object[]
            {
                "@Id_bolao", Id
            };
        }
    }
}
