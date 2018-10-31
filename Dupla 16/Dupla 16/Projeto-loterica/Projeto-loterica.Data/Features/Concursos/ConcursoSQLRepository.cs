using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Boloes;
using Projeto_loterica.Domain.Features.Concursos;
using Projeto_loterica.Domain.Features.Enums;
using Projeto_loterica.Domain.Features.Resultados;
using Projeto_loterica.Infra.Dbs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_loterica.Infra.Data.Features.Concursos
{
    public class ConcursoSQLRepository : IConcursoRepository
    {
        #region readOnly

        private readonly string SaveSql = @"INSERT INTO TBConcurso(
                                            ResultadoSorteado,
                                            ResultadoValor,
                                            DataConcurso,
                                            QuantidadeQuadra,
                                            QuantidadeMega,
                                            QuantidadeQuina,
                                            MediaQuina,
                                            MediaQuadra,
                                            MediaSena
                                               ) 
                                             VALUES
                                            (@ResultadoSorteado,
                                            @ResultadoValor,
                                            @DataConcurso,
                                            @QuantidadeQuadra,
                                            @QuantidadeMega,
                                            @QuantidadeQuina,
                                            @MediaQuina,
                                            @MediaQuadra,
                                            @MediaSena
                                            
                                            )";



        private readonly string SaveInTBConcursoAndTBApostaSql = @"INSERT INTO TBApostaConcurso(
                                            aposta_id,
                                            concurso_id)
                                             VALUES
                                            (@aposta_id,
                                             @concurso_id
                                            )";
        private readonly string SaveInTBConcursoAndTBBolaoSql = @"INSERT INTO TBBolaoConcurso(
                                            concurso_id,
                                            bolao_id)
                                             VALUES
                                            (@concurso_id,
                                             @bolao_id
                                            )";
        readonly string getAllSQLApostasEmConcurso = @"select A.Id_aposta, A.Numeros, A.ValorPago, A.Vencedor, A.ValorRecebido
                                            from TBAposta as A
                                            inner join TBApostaConcurso as AC on AC.aposta_id = A.Id_aposta
                                            inner join TBConcurso as C on C.Id_concurso = AC.concurso_id
                                            where C.Id_concurso = @Id_concurso";

        readonly string getAllSQLBoloesEmConcurso = @"select B.Id_bolao
                                            from TBBolao as B
                                            inner join TBBolaoConcurso as BC on BC.bolao_id = B.Id_bolao
                                            inner join TBConcurso as C on C.Id_concurso = BC.concurso_id
                                            where C.Id_concurso = @Id_concurso";
        readonly string getAllApostasInBolaoSQL = @"select A.Id_aposta, A.Numeros, A.ValorPago, A.Vencedor, A.ValorRecebido
                                    from TBAposta as A
                                    inner join TBApostaBolao as AB on AB.aposta_id = A.Id_aposta
                                    inner join TBBolao as B on B.Id_bolao = AB.bolao_id
                                    where b.Id_bolao = @bolao_id";

        readonly string getAllSQL = @"SELECT Id_concurso,
                                            ResultadoSorteado,
                                            ResultadoValor,
                                            DataConcurso,
                                            QuantidadeQuadra,
                                            QuantidadeMega,
                                            QuantidadeQuina,
                                            MediaQuina,
                                            MediaQuadra,
                                            MediaSena
   
                                    FROM TBConcurso";

        readonly string getByIDSQL = @"SELECT Id_concurso,
                                            ResultadoSorteado,
                                            ResultadoValor,
                                            DataConcurso,
                                            QuantidadeQuadra,
                                            QuantidadeMega,
                                            QuantidadeQuina,
                                            MediaQuina,
                                            MediaQuadra,
                                            MediaSena
   
                                            
                                FROM TBConcurso
                                WHERE Id_concurso = @Id_concurso";

        readonly string UpdateSql = @"UPDATE TBConcurso
                                      SET ResultadoValor = @ResultadoValor,
                                          ResultadoSorteado = @ResultadoSorteado,
                                          DataConcurso = @DataConcurso,
                                          QuantidadeQuadra = @QuantidadeQuadra,
                                          QuantidadeMega = @QuantidadeMega,
                                          QuantidadeQuina = @QuantidadeQuina,
                                          MediaQuina = @MediaQuina,
                                          MediaQuadra = @MediaQuadra,
                                          MediaSena = @MediaSena
   
                                      WHERE Id_concurso = @Id_concurso";


        #endregion

        public Concurso Add(Concurso objeto)
        {
            objeto.Id = Db.Insert(SaveSql, Take(objeto));
            foreach (var item in objeto.Apostas)
            {
                Db.Insert(SaveInTBConcursoAndTBApostaSql, TakeAposta(objeto,item));
            }
            foreach (var item in objeto.Boloes)
            {
                Db.Insert(SaveInTBConcursoAndTBBolaoSql, TakeBolao(objeto, item));
            }
            return objeto;
        }

        public void Delete(Concurso objeto)
        {
            throw new UnsupportedOperationException();
        }

        public IEnumerable<Concurso> GetAll()
        {
            var list = Db.GetAll(getAllSQL, Make);
            foreach (var item in list)
            {
                item.Apostas.AddRange(Db.GetAll(getAllSQLApostasEmConcurso, MakeAposta, TakeConcursoId(item.Id)));
            }
            foreach (var item in list)
            {
                item.Boloes.AddRange(Db.GetAll(getAllSQLBoloesEmConcurso, MakeBolao, TakeConcursoId(item.Id)));
                foreach (var bolao in item.Boloes)
                {
                    bolao.Apostas.AddRange(Db.GetAll(getAllApostasInBolaoSQL, MakeAposta, TakeBolaoId(bolao.Id)));
                }
            }
            return list;
        }

        public Concurso GetById(long Id)
        {
            var item = Db.Get(getByIDSQL, Make, TakeConcursoId(Id));
            item.Apostas.AddRange(Db.GetAll(getAllSQLApostasEmConcurso, MakeAposta, TakeConcursoId(item.Id)));

            item.Boloes.AddRange(Db.GetAll(getAllSQLBoloesEmConcurso, MakeBolao, TakeConcursoId(item.Id)));

            foreach (var bolao in item.Boloes)
            {
                bolao.Apostas.AddRange(Db.GetAll(getAllApostasInBolaoSQL, MakeAposta, TakeBolaoId(bolao.Id)));
            }
            return item;
        }

        public Concurso Update(Concurso objeto)
        {
            Db.Update(UpdateSql, Take(objeto));
            return objeto;
        }
        private static Func<IDataReader, Bolao> MakeBolao = reader => new Bolao
        {
            Id = Convert.ToInt32(reader["Id_bolao"])
        };

        private static Func<IDataReader, Aposta> MakeAposta = reader => new Aposta
        {
            Id = Convert.ToInt32(reader["Id_aposta"]),
            Numeros = Aposta.ConversaoParaLista(reader["Numeros"].ToString()),
            ValorPago = Convert.ToDouble(reader["ValorPago"]),
            ValorRecebido = Convert.ToDouble(reader["ValorRecebido"]),
            Resultado = (Domain.Features.Enums.Vencedora)Convert.ToInt32(reader["Vencedor"])
        };


        private static Func<IDataReader, Concurso> Make = reader => new Concurso(new Estatisticas(new Vencedor(), new Vencedor(), new Vencedor()))
        {

            Id = Convert.ToInt32(reader["Id_concurso"]),
            resultado = (Resultado)reader["ResultadoSorteado"].ToString(),
            DataConcurso = Convert.ToDateTime(reader["DataConcurso"]),
            Estatistica = new Estatisticas(new Domain.Features.Concursos.Vencedor(), new Domain.Features.Concursos.Vencedor(), new Domain.Features.Concursos.Vencedor()) {
                Mega = new Domain.Features.Concursos.Vencedor {
                    QuantidadeGanhadores = Convert.ToInt32(reader["QuantidadeMega"]),
                    MediaDoPremio = Convert.ToDouble(reader["MediaSena"])
                },
                Quadra = new Domain.Features.Concursos.Vencedor
                {
                    QuantidadeGanhadores = Convert.ToInt32(reader["QuantidadeQuadra"]),
                    MediaDoPremio = Convert.ToDouble(reader["MediaQuadra"])
                },
                Quina = new Domain.Features.Concursos.Vencedor {
                    QuantidadeGanhadores = Convert.ToInt32(reader["QuantidadeQuina"]),
                    MediaDoPremio = Convert.ToDouble(reader["MediaQuina"])
                }
            }
        };

        private object[] TakeBolao(Concurso concurso,Bolao bolao)
        {
            return new object[]
            {
                "@bolao_id", bolao.Id,
                "@concurso_id", concurso.Id

            };
        }
        private object[] TakeAposta(Concurso concurso,Aposta aposta)
        {
            return new object[]
            {
                "@aposta_id", aposta.Id,
                "@concurso_id", concurso.Id
            };
        }
        private object[] Take(Concurso concurso)
        {
            return new object[]
            {
                "@Id_concurso", concurso.Id,
                "@ResultadoSorteado", (string)concurso.resultado,
                "@ResultadoValor", concurso.ValorPremioTotal,
                "@DataConcurso", concurso.DataConcurso,
                "@QuantidadeMega", concurso.Estatistica.Mega.QuantidadeGanhadores,
                "@QuantidadeQuadra", concurso.Estatistica.Quadra.QuantidadeGanhadores,
                "@QuantidadeQuina", concurso.Estatistica.Quina.QuantidadeGanhadores,
                "@MediaQuina", concurso.Estatistica.Quina.MediaDoPremio,
                "@MediaQuadra", concurso.Estatistica.Quadra.MediaDoPremio,
                "@MediaSena", concurso.Estatistica.Mega.MediaDoPremio
            };
        }

        private object[] TakeConcursoId(long Id)
        {

            return new object[]
            {
                "@Id_concurso", Id
            };
        }
        private object[] TakeBolaoId(long Id)
        {

            return new object[]
            {
                "@bolao_id", Id
            };
        }
    }
}
