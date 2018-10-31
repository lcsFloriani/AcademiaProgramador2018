using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.Receivers
{
    public class ReceiverSQLRepository : IReceiverRepository
    {
        private readonly string SQL_INSERT = "INSERT INTO TBReceiver(Name_CompanyName,Cpf_Cnpj,StateRegistration,Type,Street,Number,Neighbourhood,City,State) VALUES (@Name_CompanyName,@Cpf_Cnpj,@StateRegistration,@Type,@Street,@Number,@Neighbourhood,@City,@State)";
        private readonly string SQL_UPDATE = "UPDATE TBReceiver SET Name_CompanyName = @Name_CompanyName, Cpf_Cnpj = @Cpf_Cnpj, StateRegistration = @StateRegistration, Type = @Type, Street = @Street, Number = @Number, Neighbourhood = @Neighbourhood, City = @City, State = @State WHERE IdReceiver = @IdReceiver";
        private readonly string SQL_GET = "SELECT * FROM TBReceiver WHERE IdReceiver = @IdReceiver";
        private readonly string SQL_GETALL = "SELECT * FROM TBReceiver";
        private readonly string SQL_DELETE = "DELETE FROM TBReceiver WHERE IdReceiver = @IdReceiver";
        private readonly string SQL_CHECK_DEPENDENCY = "SELECT CAST(CASE WHEN EXISTS(SELECT IdReceiver FROM TBReceiver INNER JOIN TBInvoiceInProcess ON IdReceiver = ReceiverId WHERE IdReceiver = @IdReceiver) THEN 1 ELSE 0 END AS BIT) AS Exist";

        private readonly long _lessThan = 1;
        private readonly int _exist = 1;

        public Receiver Save(Receiver receiver)
        {
            receiver.Validate();
            receiver.Id = Db.Insert(SQL_INSERT, Take(receiver, false));

            return receiver;
        }

        public Receiver Update(Receiver receiver)
        {
            if (receiver.Id < _lessThan)
                throw new IdentifierUndefinedException();

            receiver.Validate();
            Db.Update(SQL_UPDATE, Take(receiver));

            return receiver;
        }

        public Receiver Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();

            return Db.Get(SQL_GET, Make, new object[] { "@IdReceiver", id });
        }

        public IEnumerable<Receiver> GetAll()
        {
            return Db.GetAll(SQL_GETALL, Make);
        }

        public void Delete(Receiver receiver)
        {
            if (receiver.Id < _lessThan)
                throw new IdentifierUndefinedException();

            Db.Delete(SQL_DELETE, new object[] { "@IdReceiver", receiver.Id });
        }

        public bool CheckDependency(Receiver receiver)
        {
            int result = Db.Get(SQL_CHECK_DEPENDENCY, MakeExist, new object[]
                {
                "@IdReceiver", receiver.Id
                }
            );

            return result == _exist;
        }

        private static Func<IDataReader, int> MakeExist = ReadInt;

        private static int ReadInt(IDataReader reader)
        {
            return Convert.ToInt32(reader["Exist"]);
        }

        private static Func<IDataReader, Receiver> Make = reader =>
          new Receiver
          {
              Id = Convert.ToInt64(reader["IdReceiver"]),
              NameCompanyName = Convert.ToString(reader["Name_CompanyName"]),
              StateRegistration = Convert.ToString(reader["StateRegistration"]),
              Type = (PersonType)Enum.Parse(typeof(PersonType), Convert.ToString(reader["Type"])),
              Cnpj = MakeCnpj(reader),
              Cpf = MakeCpf(reader),
              Address = new Address
              {
                  State = (State)Enum.Parse(typeof(State), Convert.ToString(reader["State"])),
                  City = Convert.ToString(reader["City"]),
                  Neighbourhood = Convert.ToString(reader["Neighbourhood"]),
                  Street = Convert.ToString(reader["Street"]),
                  Number = Convert.ToInt32(reader["Number"])
              }

          };

        private static Cpf MakeCpf(IDataReader reader)
        {
            var type = (PersonType)Enum.Parse(typeof(PersonType), Convert.ToString(reader["Type"]));

            if (type == PersonType.PHYSICAL)
            {
                return new Cpf
                {
                    Value = Convert.ToString(reader["Cpf_Cnpj"])
                };
            }

            return null;
        }

        private static Cnpj MakeCnpj(IDataReader reader)
        {
            var type = (PersonType)Enum.Parse(typeof(PersonType), Convert.ToString(reader["Type"]));

            if (type == PersonType.LEGAL)
            {
                return new Cnpj
                {
                    Value = Convert.ToString(reader["Cpf_Cnpj"])
                };
            }

            return null;
        }

        private object[] Take(Receiver receiver, bool hasId = true)
        {
            object[] parametros = null;
            if (hasId)
            {
                parametros = new object[]
                    {
                "@Name_CompanyName", receiver.NameCompanyName,
                "@Cpf_Cnpj", receiver.Type == PersonType.PHYSICAL ? receiver.Cpf.Value : receiver.Cnpj.Value,
                "@StateRegistration", receiver.StateRegistration.ToString(),
                "@Type", receiver.Type.ToString(),
                "@Street", receiver.Address.Street,
                "@Number", receiver.Address.Number,
                "@Neighbourhood", receiver.Address.Neighbourhood,
                "@City", receiver.Address.City,
                "@State", receiver.Address.State.ToString(),
                "@IdReceiver", receiver.Id
                };
            }
            else
            {
                parametros = new object[]
              {
                "@Name_CompanyName", receiver.NameCompanyName,
                "@Cpf_Cnpj", receiver.Type == PersonType.PHYSICAL ? receiver.Cpf.Value : receiver.Cnpj.Value,
                "@StateRegistration", receiver.StateRegistration.ToString(),
                "@Type", receiver.Type.ToString(),
                "@Street", receiver.Address.Street,
                "@Number", receiver.Address.Number,
                "@Neighbourhood", receiver.Address.Neighbourhood,
                "@City", receiver.Address.City,
                "@State", receiver.Address.State.ToString(),
              };
            }

            return parametros;
        }
    }
}
