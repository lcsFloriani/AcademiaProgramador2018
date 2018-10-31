using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Infra.AccessKeys;
using Projeto_NFe.Infra.XML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.Invoices
{
    public class InvoiceIssuedSQLRepository : IInvoiceIssuedRepository
    {
        private readonly string SQL_INSERT = "INSERT INTO TBInvoiceIssued(AccessKey,TotalValue,ConveyorCpf_Cnpj,EmitterCnpj,ReceiverCpf_Cnpj) VALUES(@AccessKey,@TotalValue,@ConveyorCpf_Cnpj,@EmitterCnpj,@ReceiverCpf_Cnpj)";
        private readonly string SQL_UPDATE = "UPDATE TBInvoiceIssued SET Xml = @Xml WHERE IdInvoiceIssued = @IdInvoiceIssued";
        private readonly string SQL_DELETE = "DELETE FROM TBInvoiceIssued WHERE IdInvoiceIssued = @IdInvoiceIssued";
        private readonly string SQL_GETALL = "SELECT * FROM TBInvoiceIssued";
        private readonly string SQL_GET = "SELECT Xml FROM TBInvoiceIssued WHERE IdInvoiceIssued = @IdInvoiceIssued";
        private readonly string SQL_GET_BY_ACESSKEY = "SELECT Xml FROM TBInvoiceIssued WHERE AccessKey = @AccessKey";

        private readonly string SQL_ACCESSKEY_EXIST = "SELECT CAST(CASE WHEN EXISTS(SELECT * FROM TBInvoiceIssued WHERE AccessKey LIKE @AccessKey AND IdInvoiceIssued <> @IdInvoiceIssued) THEN 1 ELSE 0 END AS BIT) AS Exist";

        private readonly long _lessThan = 1;
        private readonly int _exist = 1;

        private readonly XMLHelper<InvoiceIssued> _xmlHelper = new XMLHelper<InvoiceIssued>();

        public InvoiceIssued Save(InvoiceIssued invoiceIssued)
        {
            invoiceIssued.Validate();

            invoiceIssued.Id = Db.Insert(SQL_INSERT, Take(invoiceIssued, false));

            Db.Update(SQL_UPDATE, Take(invoiceIssued));

            return invoiceIssued;
        }

        public InvoiceIssued Update(InvoiceIssued invoiceIssued)
        {
            throw new UnsupportedOperationException();
        }

        public string Get(long id)
        {
            if (id < _lessThan)
                throw new IdentifierUndefinedException();
            return Db.Get(SQL_GET, Make, new object[] { "@IdInvoiceIssued", id });
        }

        public IEnumerable<string> GetAll()
        {
            return Db.GetAll(SQL_GETALL, Make);
        }

        public string GetByAccessKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new InvoiceIssuedAccessKeyNumberAccessKeyNullOrEmptyException();

            return Db.Get(SQL_GET_BY_ACESSKEY, Make, new object[] { "@AccessKey", key });
        }
        
        public void Delete(InvoiceIssued invoiceIssued)
        {
            if (invoiceIssued.Id < _lessThan)
                throw new IdentifierUndefinedException();

            Db.Delete(SQL_DELETE, new object[] { "@IdInvoiceIssued", invoiceIssued.Id });
        }

        public bool CheckAccessKeyIsRepeat(InvoiceIssued invoiceIssued)
        {
            int result = Db.Get(SQL_ACCESSKEY_EXIST, MakeExist, new object[]
                {
                "@AccessKey", invoiceIssued.Key.NumberAccessKey,
                "@IdInvoiceIssued", invoiceIssued.Id
                });

            return result == _exist;
        }

        private static Func<IDataReader, string> Make = StringXml;

        private static string StringXml(IDataReader reader)
        {
            return Convert.ToString(reader["Xml"]);
        }

        private static Func<IDataReader, int> MakeExist = ReadInt;

        private static int ReadInt(IDataReader reader)
        {
            return Convert.ToInt32(reader["Exist"]);
        }

        private object[] Take(InvoiceIssued invoiceIssued, bool hasId = true)
        {
            object[] parameters = null;

            if (hasId)
            {
                parameters = new object[]
                {
                "@Xml", _xmlHelper.Serialize(invoiceIssued),
                "@IdInvoiceIssued", invoiceIssued.Id
                };
            }
            else { 
                parameters = new object[]
                  {
                "@AccessKey", invoiceIssued.Key.NumberAccessKey,
                "@TotalValue", invoiceIssued.Tax.TotalInvoice,
                "@ConveyorCpf_Cnpj", TakeConveyor(invoiceIssued.Conveyor),
                "@EmitterCnpj", invoiceIssued.Emitter.Cnpj.Value,
                "@ReceiverCpf_Cnpj", invoiceIssued.Receiver.Type == PersonType.PHYSICAL ? invoiceIssued.Receiver.Cpf.Value : invoiceIssued.Receiver.Cnpj.Value,
                  };
        }

            return parameters;
        }

        private Object TakeConveyor(Conveyor conveyor)
        {
            if (conveyor == null)
                return null;

            return conveyor.Type == PersonType.PHYSICAL ? conveyor.Cpf.Value : conveyor.Cnpj.Value;
        }
    }
}
