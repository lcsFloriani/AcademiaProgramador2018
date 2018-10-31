using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.Invoices
{
    public class InvoiceInProcessSQLRepository : IInvoiceInProcessRepository
    {
        private readonly string SQL_INSERT = "INSERT INTO TBInvoiceInProcess(EntryDate,NatureOperation,ConveyorId,EmitterId,ReceiverId,ValueFreight) VALUES(@EntryDate,@NatureOperation,@ConveyorId,@EmitterId,@ReceiverId, @ValueFreight)";
        private readonly string SQL_UPDATE = "UPDATE TBInvoiceInProcess SET EntryDate = @EntryDate, NatureOperation = @NatureOperation, ConveyorId = @ConveyorId, EmitterId = @EmitterId, ReceiverId = @ReceiverId, ValueFreight = @ValueFreight WHERE IdInvoiceInProcess = @IdInvoiceInProcess";
        private readonly string SQL_DELETE = "DELETE FROM TBInvoiceInProcess WHERE IdInvoiceInProcess = @IdInvoiceInProcess";
        private readonly string SQL_GETALL =
             "SELECT ip.*, " +
             "e.FantasyName AS EmitterFantasyName, " +
             "e.CompanyName AS EmitterCompanyName, " +
             "e.Cnpj AS EmitterCnpj, " +
             "e.StateRegistration AS EmitterStateRegistration, " +
             "e.MunicipalRegistration AS EmitterMunicipalRegistration, " +
             "e.Street AS EmitterStreet, " +
             "e.Number AS EmitterNumber, " +
             "e.Neighbourhood AS EmitterNeighbourhood, " +
             "e.City AS EmitterCity, " +
             "e.State AS EmitterState, " +
             "r.Name_CompanyName AS ReceiverName_CompanyName, " +
             "r.Cpf_Cnpj AS ReceiveCpf_Cnpj, " +
             "r.StateRegistration AS ReceiverStateRegistration, " +
             "r.Type AS ReceiverType, " +
             "r.Street AS ReceiverStreet, " +
             "r.Number AS ReceiverNumber, " +
             "r.Neighbourhood AS ReceiverNeighbourhood, " +
             "r.City AS ReceiverCity, " +
             "r.State AS ReceiverState, " +
             "c.Name_CompanyName AS ConveyorName_CompanyName, " +
             "c.Cpf_Cnpj AS ConveyorCpf_Cnpj, " +
             "c.FreightResponsibility AS ConveyorFreightResponsibility, " +
             "c.Type AS ConveyorType, " +
             "c.Street AS ConveyorStreet, " +
             "c.Number AS ConveyorNumber, " +
             "c.Neighbourhood AS ConveyorNeighbourhood, " +
             "c.City AS ConveyorCity, " +
             "c.State AS ConveyorState " +
             "FROM TBInvoiceInProcess AS ip " +
             "INNER JOIN TBEmitter AS e ON ip.EmitterId = e.IdEmitter " +
             "INNER JOIN TBReceiver AS r ON ip.ReceiverId = r.IdReceiver " +
             "LEFT JOIN TBConveyor AS c ON ip.ConveyorId = c.IdConveyor";

        private readonly string SQL_GET = 
            "SELECT ip.*, " +
            "e.FantasyName AS EmitterFantasyName, " +
            "e.CompanyName AS EmitterCompanyName, " +
            "e.Cnpj AS EmitterCnpj, " +
            "e.StateRegistration AS EmitterStateRegistration, " +
            "e.MunicipalRegistration AS EmitterMunicipalRegistration, " +
            "e.Street AS EmitterStreet, " +
            "e.Number AS EmitterNumber, " +
            "e.Neighbourhood AS EmitterNeighbourhood, " +
            "e.City AS EmitterCity, " +
            "e.State AS EmitterState, " +
            "r.Name_CompanyName AS ReceiverName_CompanyName, " +
            "r.Cpf_Cnpj AS ReceiveCpf_Cnpj, " +
            "r.StateRegistration AS ReceiverStateRegistration, " +
            "r.Type AS ReceiverType, " +
            "r.Street AS ReceiverStreet, " +
            "r.Number AS ReceiverNumber, " +
            "r.Neighbourhood AS ReceiverNeighbourhood, " +
            "r.City AS ReceiverCity, " +
            "r.State AS ReceiverState, " +
            "c.Name_CompanyName AS ConveyorName_CompanyName, " +
            "c.Cpf_Cnpj AS ConveyorCpf_Cnpj, " +
            "c.FreightResponsibility AS ConveyorFreightResponsibility, " +
            "c.Type AS ConveyorType, " +
            "c.Street AS ConveyorStreet, " +
            "c.Number AS ConveyorNumber, " +
            "c.Neighbourhood AS ConveyorNeighbourhood, " +
            "c.City AS ConveyorCity, " +
            "c.State AS ConveyorState " +
            "FROM TBInvoiceInProcess AS ip " +
            "INNER JOIN TBEmitter AS e ON ip.EmitterId = e.IdEmitter " +
            "INNER JOIN TBReceiver AS r ON ip.ReceiverId = r.IdReceiver " +
            "LEFT JOIN TBConveyor AS c ON ip.ConveyorId = c.IdConveyor " +
            "WHERE ip.IdInvoiceInProcess = @IdInvoiceInProcess";

        private readonly long _lessThan = 1;

        public InvoiceInProcess Save(InvoiceInProcess invoiceInProcess)
        {
            invoiceInProcess.Validate();
            invoiceInProcess.Id = Db.Insert(SQL_INSERT, Take(invoiceInProcess, false));

            return invoiceInProcess;
        }

        public InvoiceInProcess Update(InvoiceInProcess invoiceInProcess)
        {
            if (invoiceInProcess.Id < _lessThan)
                throw new IdentifierUndefinedException();

            invoiceInProcess.Validate();
            Db.Update(SQL_UPDATE, Take(invoiceInProcess));

            return invoiceInProcess;
        }

        public InvoiceInProcess Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();

            return Db.Get(SQL_GET, Make,new object[] { "@IdInvoiceInProcess", id });
        }

        public IEnumerable<InvoiceInProcess> GetAll()
        {
            return Db.GetAll(SQL_GETALL, Make);
        }

        public void Delete(InvoiceInProcess invoiceInProcess)
        {
            if (invoiceInProcess.Id < _lessThan)
                throw new IdentifierUndefinedException();

            Db.Delete(SQL_DELETE, new object[] { "@IdInvoiceInProcess", invoiceInProcess.Id });
        }

        private static Func<IDataReader, InvoiceInProcess> Make = reader =>
        new InvoiceInProcess
        {
            Id = Convert.ToInt64(reader["IdInvoiceInProcess"]),
            EntryDate = Convert.ToDateTime(reader["EntryDate"]),
            NatureOperation = Convert.ToString(reader["NatureOperation"]),
            ValueFreight = Convert.ToDouble(reader["ValueFreight"]),
            Emitter = new Emitter
            {
                Id = Convert.ToInt64(reader["EmitterId"]),
                Cnpj = new Cnpj
                {
                    Value = Convert.ToString(reader["EmitterCnpj"])
                },
                CompanyName = Convert.ToString(reader["EmitterFantasyName"]),
                FantasyName = Convert.ToString(reader["EmitterCompanyName"]),
                StateRegistration = Convert.ToString(reader["EmitterStateRegistration"]),
                MunicipalRegistration = Convert.ToString(reader["EmitterMunicipalRegistration"]),
                Address = new Address
                {
                    State = (State)Enum.Parse(typeof(State), Convert.ToString(reader["EmitterState"])),
                    City = Convert.ToString(reader["EmitterCity"]),
                    Neighbourhood = Convert.ToString(reader["EmitterNeighbourhood"]),
                    Street = Convert.ToString(reader["EmitterStreet"]),
                    Number = Convert.ToInt32(reader["EmitterNumber"])
                }
                },
            Receiver = new Receiver
            {
                Id = Convert.ToInt64(reader["ReceiverId"]),
                NameCompanyName = Convert.ToString(reader["ReceiverName_CompanyName"]),
                StateRegistration = Convert.ToString(reader["ReceiverStateRegistration"]),
                Type = (PersonType)Enum.Parse(typeof(PersonType), Convert.ToString(reader["ReceiverType"])),
                Cnpj = MakeCnpj(reader, "ReceiveCpf_Cnpj", "ReceiverType"),
                Cpf = MakeCpf(reader, "ReceiveCpf_Cnpj", "ReceiverType"),
                Address = new Address
                {
                    State = (State)Enum.Parse(typeof(State), Convert.ToString(reader["ReceiverState"])),
                    City = Convert.ToString(reader["ReceiverCity"]),
                    Neighbourhood = Convert.ToString(reader["ReceiverNeighbourhood"]),
                    Street = Convert.ToString(reader["ReceiverStreet"]),
                    Number = Convert.ToInt32(reader["ReceiverNumber"])
                }
            },
            Conveyor = MakeConveyor(reader)

        };

        private static Conveyor MakeConveyor(IDataReader reader)
        {
            if (reader["ConveyorId"] == DBNull.Value)
                return null;

            return new Conveyor
            {
                Id = Convert.ToInt64(reader["ConveyorId"]),
                NameCompanyName = Convert.ToString(reader["ConveyorName_CompanyName"]),
                FreightResponsibility = (FreightResponsibility)Enum.Parse(typeof(FreightResponsibility), Convert.ToString(reader["ConveyorFreightResponsibility"])),
                Type = (PersonType)Enum.Parse(typeof(PersonType), Convert.ToString(reader["ConveyorType"])),
                Cnpj = MakeCnpj(reader, "ConveyorCpf_Cnpj", "ConveyorType"),
                Cpf = MakeCpf(reader, "ConveyorCpf_Cnpj", "ConveyorType"),
                Address = new Address
                {
                    State = (State)Enum.Parse(typeof(State), Convert.ToString(reader["ConveyorState"])),
                    City = Convert.ToString(reader["ConveyorCity"]),
                    Neighbourhood = Convert.ToString(reader["ConveyorNeighbourhood"]),
                    Street = Convert.ToString(reader["ConveyorStreet"]),
                    Number = Convert.ToInt32(reader["ConveyorNumber"]),
                }
            };
        }

        private static Cpf MakeCpf(IDataReader reader, string columnCpf, string columnType)
        {
            var type = (PersonType)Enum.Parse(typeof(PersonType), Convert.ToString(reader[columnType]));

            if (type == PersonType.PHYSICAL)
            {
                return new Cpf
                {
                    Value = Convert.ToString(reader[columnCpf])
                };
            }

            return null;
        }

        private static Cnpj MakeCnpj(IDataReader reader, string columnCnpj, string columnType)
        {
            var type = (PersonType)Enum.Parse(typeof(PersonType), Convert.ToString(reader[columnType]));

            if (type == PersonType.LEGAL)
            {
                return new Cnpj
                {
                    Value = Convert.ToString(reader[columnCnpj])
                };
            }

            return null;
        }

        private object[] Take(InvoiceInProcess invoiceInProcess, bool hasId = true)
        {
            object[] parameters = null;

            if (hasId)
            {
                parameters = new object[]
                {
                "@EntryDate", invoiceInProcess.EntryDate,
                "@NatureOperation", invoiceInProcess.NatureOperation,
                "@ConveyorId", invoiceInProcess.Conveyor?.Id,
                "@EmitterId",invoiceInProcess.Emitter.Id,
                "@ReceiverId", invoiceInProcess.Receiver.Id,
                "@ValueFreight", invoiceInProcess.ValueFreight,
                "@IdInvoiceInProcess", invoiceInProcess.Id
                };
            }
            else
            {
                parameters = new object[]
              {
                "@EntryDate", invoiceInProcess.EntryDate,
                "@NatureOperation", invoiceInProcess.NatureOperation,
                "@ConveyorId", invoiceInProcess.Conveyor?.Id,
                "@EmitterId",invoiceInProcess.Emitter.Id,
                "@ReceiverId", invoiceInProcess.Receiver.Id,
                "@ValueFreight", invoiceInProcess.ValueFreight
              };
            }

            return parameters;
        }
    }
}
