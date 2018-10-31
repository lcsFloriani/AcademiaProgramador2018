using Projeto_loterica.Domain.Exceptions;
using Projeto_loterica.Domain.Features.Apostas;
using Projeto_loterica.Domain.Features.Enums;
using Projeto_loterica.Infra.Dbs;
using System;
using System.Collections.Generic;
using System.Data;

namespace Projeto_loterica.Infra.Data.Features.Apostas
{
    public class ApostaSQLRepository : IApostaRepository
    {
        #region readOnly
        private readonly string SaveSql = @"INSERT INTO TBAposta(
                                            Numeros,
                                            Vencedor,
                                            ValorRecebido,
                                            ValorPago) 
                                             VALUES
                                            (@Numeros,
                                            @Vencedor,
                                            @ValorRecebido,
                                            @ValorPago
                                            )";

       
        readonly string getAllSQL = @"SELECT Id_aposta,
                                            Numeros,
                                            Vencedor,
                                            ValorRecebido,
                                            ValorPago                                             
                                    FROM TBAposta";

        readonly string getByIDSQL = @"SELECT Id_aposta,
                                            Numeros,
                                            Vencedor,
                                            ValorRecebido,
                                            ValorPago 
                                FROM TBAposta
                                WHERE Id_aposta = @Id_aposta";
        #endregion

        public Aposta Add(Aposta objeto)
        {
            objeto.Id = Db.Insert(SaveSql, Take(objeto));
                
            return objeto;
        }

        public void Delete(Aposta objeto)
        {
            throw new UnsupportedOperationException();
        }

        public IEnumerable<Aposta> GetAll()
        {
            return Db.GetAll(getAllSQL, Make);
        }

        public Aposta GetById(long Id)
        {
            return Db.Get(getByIDSQL, Make, TakeApostaId(Id));
        }

        public Aposta Update(Aposta objeto)
        {
            throw new UnsupportedOperationException();
        }

        private static Func<IDataReader, Aposta> Make = reader => new Aposta
        {
            
            Id = Convert.ToInt32(reader["Id_aposta"]),
            Numeros = Aposta.ConversaoParaLista(reader["Numeros"].ToString()),
            ValorPago = Convert.ToDouble(reader["ValorPago"]),
            ValorRecebido = Convert.ToDouble(reader["ValorRecebido"]),
            Resultado = (Vencedora)Convert.ToInt32(reader["Vencedor"])
            
        };

        private object[] Take(Aposta aposta)
        {
            return new object[]
            {
                "@Id_aposta", aposta.Id,
                "@Numeros", Aposta.ConversaoParaString(aposta.Numeros),
                "@ValorPago", aposta.ValorPago,
                "@ValorRecebido", aposta.ValorRecebido,
                "@Vencedor", aposta.Resultado
            };
        }

        private object[] TakeApostaId(long Id)
        {

            return new object[]
            {
                "@Id_aposta", Id
            };
        }
    }
}
