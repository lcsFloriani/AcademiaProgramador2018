using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.Conveyors
{
    public class ConveyorSQLRepository : IConveyorRepository
    {

        private readonly string SQL_INSERT = "INSERT INTO TBConveyor(Name_CompanyName,Cpf_Cnpj,FreightResponsibility,Type,Street,Number,Neighbourhood,City,State) VALUES (@Name_CompanyName,@Cpf_Cnpj,@FreightResponsibility,@Type,@Street,@Number,@Neighbourhood,@City,@State)";
        private readonly string SQL_UPDATE = "UPDATE TBConveyor SET Name_CompanyName = @Name_CompanyName, Cpf_Cnpj = @Cpf_Cnpj, FreightResponsibility = @FreightResponsibility, Type = @Type, Street = @Street, Number = @Number, Neighbourhood = @Neighbourhood, City = @City, State = @State WHERE IdConveyor = @IdConveyor";
        private readonly string SQL_GET = "SELECT * FROM TBConveyor WHERE IdConveyor = @IdConveyor";
        private readonly string SQL_GETALL = "SELECT * FROM TBConveyor";
        private readonly string SQL_DELETE = "DELETE FROM TBConveyor WHERE IdConveyor = @IdConveyor";
        private readonly string SQL_CHECK_DEPENDENCY = "SELECT CAST(CASE WHEN EXISTS(SELECT IdConveyor FROM TBConveyor INNER JOIN TBInvoiceInProcess ON IdConveyor = ConveyorId WHERE IdConveyor =	@IdConveyor) THEN 1 ELSE 0 END AS BIT) AS Exist";

        private readonly long _lessThan = 1;
        private readonly int _exist = 1;

        public Conveyor Save(Conveyor conveyor)
        {
            conveyor.Validate();
            conveyor.Id = Db.Insert(SQL_INSERT, Take(conveyor, false));

            return conveyor;
        }

        public Conveyor Update(Conveyor conveyor)
        {
            if (conveyor.Id < _lessThan)
                throw new IdentifierUndefinedException();

            conveyor.Validate();
            Db.Update(SQL_UPDATE, Take(conveyor));

            return conveyor;
        }

        public Conveyor Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();

            return Db.Get(SQL_GET, Make, new object[] { "@IdConveyor", id });
        }

        public IEnumerable<Conveyor> GetAll()
        {
            return Db.GetAll(SQL_GETALL, Make);
        }

        public void Delete(Conveyor conveyor)
        {
            if (conveyor.Id < _lessThan)
                throw new IdentifierUndefinedException();

            Db.Delete(SQL_DELETE, new object[] { "@IdConveyor", conveyor.Id });
        }

        public bool CheckDependency(Conveyor conveyor)
        {
            int result = Db.Get(SQL_CHECK_DEPENDENCY, MakeExist, new object[] 
                { "@IdConveyor", conveyor.Id
                }
            );

            return result == _exist;
        }

        private static Func<IDataReader, int> MakeExist = ReadInt;

        private static int ReadInt(IDataReader reader)
        {
            return Convert.ToInt32(reader["Exist"]);
        }

        /// <summary>
        /// Cria um objeto Customer baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Conveyor> Make = reader =>
          new Conveyor
          {
              Id = Convert.ToInt64(reader["IdConveyor"]),
              NameCompanyName = Convert.ToString(reader["Name_CompanyName"]),
              FreightResponsibility = (FreightResponsibility)Enum.Parse(typeof(FreightResponsibility), Convert.ToString(reader["FreightResponsibility"])),
              Type = (PersonType)Enum.Parse(typeof(PersonType), Convert.ToString(reader["Type"])),
              Cnpj = MakeCnpj(reader),
              Cpf = MakeCpf(reader),
              Address = new Address
              {
                  State = (State)Enum.Parse(typeof(State), Convert.ToString(reader["State"])),
                  City = Convert.ToString(reader["City"]),
                  Neighbourhood = Convert.ToString(reader["Neighbourhood"]),
                  Street = Convert.ToString(reader["Street"]),
                  Number = Convert.ToInt32(reader["Number"]),
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

        private object[] Take(Conveyor conveyor, bool hasId = true)
        {
            object[] parametros = null;
            if (hasId)
            {
                parametros = new object[]
                    {
                "@Name_CompanyName", conveyor.NameCompanyName,
                "@Cpf_Cnpj", conveyor.Type == PersonType.PHYSICAL ? conveyor.Cpf.Value : conveyor.Cnpj.Value,
                "@FreightResponsibility", conveyor.FreightResponsibility.ToString(),
                "@Type", conveyor.Type.ToString(),
                "@Street", conveyor.Address.Street,
                "@Number", conveyor.Address.Number,
                "@Neighbourhood", conveyor.Address.Neighbourhood,
                "@City", conveyor.Address.City,
                "@State", conveyor.Address.State.ToString(),
                "@IdConveyor", conveyor.Id
                };
            }
            else
            {
                parametros = new object[]
              {
                "@Name_CompanyName", conveyor.NameCompanyName,
                "@Cpf_Cnpj", conveyor.Type == PersonType.PHYSICAL ? conveyor.Cpf.Value : conveyor.Cnpj.Value,
                "@FreightResponsibility", conveyor.FreightResponsibility.ToString(),
                "@Type", conveyor.Type.ToString(),
                "@Street", conveyor.Address.Street,
                "@Number", conveyor.Address.Number,
                "@Neighbourhood", conveyor.Address.Neighbourhood,
                "@City", conveyor.Address.City,
                "@State", conveyor.Address.State.ToString(),
              };
            }

            return parametros;
        }

    }


}
