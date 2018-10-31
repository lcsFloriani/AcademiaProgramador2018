using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Infra.CNPJ;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.Emitters
{
    public class EmitterSqlRepository : IEmitterRepository
    {
        private readonly string SQL_SAVE = "INSERT INTO TBEmitter(FantasyName,CompanyName,Cnpj,StateRegistration,MunicipalRegistration,Street,Number,Neighbourhood,City,State) VALUES (@FantasyName,@CompanyName,@Cnpj,@StateRegistration,@MunicipalRegistration,@Street,@Number,@Neighbourhood,@City,@State)";
        private readonly string SQL_UPDATE = "UPDATE TBEmitter SET FantasyName = @FantasyName, CompanyName = @CompanyName, Cnpj = @Cnpj, StateRegistration = @StateRegistration, MunicipalRegistration = @MunicipalRegistration, Street = @Street, Number = @Number, Neighbourhood = @Neighbourhood, City = @City, State = @State WHERE IdEmitter = @IdEmitter";
        private readonly string SQL_GET = "SELECT * FROM TBEmitter WHERE IdEmitter = @IdEmitter";
        private readonly string SQL_DELETE = "DELETE FROM TBEmitter WHERE IdEmitter = @IdEmitter";
        private readonly string SQL_GETALL = "SELECT * FROM TBEmitter";
        private readonly string SQL_CHECK_DEPENDENCY = "SELECT CAST(CASE WHEN EXISTS(SELECT IdEmitter FROM TBEmitter INNER JOIN TBInvoiceInProcess ON IdEmitter = EmitterId WHERE IdEmitter = @IdEmitter) THEN 1 ELSE 0 END AS BIT) AS Exist";

        private readonly long _lessThan = 1;
        private readonly int _exist = 1;

        public Emitter Save(Emitter emitter)
        {
            emitter.Validate();

            emitter.Id = Db.Insert(SQL_SAVE, Take(emitter, false));

            return emitter;
        }

        public Emitter Update(Emitter emitter)
        {
            if (emitter.Id < _lessThan)
                throw new IdentifierUndefinedException();
            emitter.Validate();

            Db.Update(SQL_UPDATE, Take(emitter));

            return emitter;
        }
        public Emitter Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();
            return Db.Get(SQL_GET, Make, new object[] { "@IdEmitter", id });
        }

        public IEnumerable<Emitter> GetAll()
        {
            return Db.GetAll(SQL_GETALL, Make);
        }

        public void Delete(Emitter emitter)
        {
            if (emitter.Id < _lessThan)
                throw new IdentifierUndefinedException();
            Db.Delete(SQL_DELETE, new object[]
            {
                "@IdEmitter", emitter.Id
            });
        }

        public bool CheckDependency(Emitter emitter)
        {
            int result = Db.Get(SQL_CHECK_DEPENDENCY, MakeExist, new object[]
                {
                "@IdEmitter", emitter.Id
                }
            );

            return result == _exist;
        }

        private static Func<IDataReader, int> MakeExist = ReadInt;

        private static int ReadInt(IDataReader reader)
        {
            return Convert.ToInt32(reader["Exist"]);
        }

        private static Func<IDataReader, Emitter> Make = reader =>
        new Emitter
        {
            Id = Convert.ToInt64(reader["IdEmitter"]),
            Cnpj = new Cnpj
            { 
                Value = Convert.ToString(reader["Cnpj"])
            },
            CompanyName = Convert.ToString(reader["CompanyName"]),
            FantasyName = Convert.ToString(reader["FantasyName"]),
            StateRegistration = Convert.ToString(reader["StateRegistration"]),
            MunicipalRegistration = Convert.ToString(reader["MunicipalRegistration"]),
            Address = new Address
            {
                State = (State)Enum.Parse(typeof(State), Convert.ToString(reader["State"])),
                City = Convert.ToString(reader["City"]),
                Neighbourhood = Convert.ToString(reader["Neighbourhood"]),
                Street = Convert.ToString(reader["Street"]),
                Number = Convert.ToInt32(reader["Number"])
            }
        };

        private object[] Take(Emitter emitter, bool hasId = true)
        {
            object[] parameters = null;

            if (hasId)
            {
                parameters = new object[]
                {
                "@FantasyName", emitter.FantasyName,
                "@CompanyName", emitter.CompanyName,
                "@Cnpj",emitter.Cnpj.Value,
                "@StateRegistration", emitter.StateRegistration,
                "@MunicipalRegistration", emitter.MunicipalRegistration,
                "@Street", emitter.Address.Street,
                "@Number", emitter.Address.Number,
                "@Neighbourhood", emitter.Address.Neighbourhood,
                "@City", emitter.Address.City,
                "@State", emitter.Address.State.ToString(),
                "@IdEmitter", emitter.Id
                };
            }
            else
            {
                parameters = new object[]
              {
                "@FantasyName", emitter.FantasyName,
                "@CompanyName", emitter.CompanyName,
                "@Cnpj",emitter.Cnpj.Value,
                "@StateRegistration", emitter.StateRegistration,
                "@MunicipalRegistration", emitter.MunicipalRegistration,
                "@Street", emitter.Address.Street,
                "@Number", emitter.Address.Number,
                "@Neighbourhood", emitter.Address.Neighbourhood,
                "@City", emitter.Address.City,
                "@State", emitter.Address.State.ToString(),
              };
            }

            return parameters;
        }
    }
}
