using Projeto_NFe.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
    public static class BaseSqlTest
    {
        private const string RECREATE_TABLES =
            "TRUNCATE TABLE TBInvoiceIssued;" +
            "DELETE FROM TBInvoiceInProcess DBCC CHECKIDENT('TBInvoiceInProcess',RESEED,0);" +
            "DELETE FROM TBItemInvoice DBCC CHECKIDENT('TBItemInvoice',RESEED,0);" +
            "DELETE FROM TBProduct DBCC CHECKIDENT('TBProduct',RESEED,0);" +
            "DELETE FROM TBEmitter DBCC CHECKIDENT('TBEmitter',RESEED,0);" +
            "DELETE FROM TBReceiver DBCC CHECKIDENT('TBReceiver',RESEED,0);" +
            "DELETE FROM TBConveyor DBCC CHECKIDENT('TBConveyor',RESEED,0);";

        private const string INSERT_PHYSICAL_CONVEYOR = "INSERT INTO TBConveyor(Name_CompanyName,Cpf_Cnpj,FreightResponsibility,Type,Street,Number,Neighbourhood,City,State) VALUES ('José Pedro','32999959010','EMITTER','PHYSICAL','Rua XZ',10,'Popular','Lages','SC')";
        private const string INSERT_LEGAL_CONVEYOR = "INSERT INTO TBConveyor(Name_CompanyName,Cpf_Cnpj,FreightResponsibility,Type,Street,Number,Neighbourhood,City,State) VALUES ('Empresa XY','08671696000190','RECEIVER','LEGAL','Rua ZX',11,'SDASDAS','Lages','SP')";
        private const string INSERT_PHYSICAL_RECEIVER = "INSERT INTO TBReceiver(Name_CompanyName,Cpf_Cnpj,StateRegistration,Type,Street,Number,Neighbourhood,City,State) VALUES ('José Pedro','32999959010','54645645645','PHYSICAL','Rua XZ',10,'Popular','Lages','SC')";
        private const string INSERT_LEGAL_RECEIVER = "INSERT INTO TBReceiver(Name_CompanyName,Cpf_Cnpj,StateRegistration,Type,Street,Number,Neighbourhood,City,State) VALUES ('Empresa XY','08671696000190','23423423423','LEGAL','Rua ZX',11,'SDASDAS','Lages','SP')";
        private const string INSERT_EMITTER = "INSERT INTO TBEmitter(FantasyName,CompanyName,Cnpj,StateRegistration,MunicipalRegistration,Street,Number,Neighbourhood,City,State) VALUES ('Boticario','Boticario produto de higiene pessoal','10580271000117','213','123','Rua ZX',11,'SDASDAS','Lages','SP')";
        private const string INSERT_PRODUCT = "INSERT INTO TBProduct(Code,Description, UnitaryValue) VALUES ('0001','Tenis', 15.32)";
        private const string INSERT_PRODUCT2 = "INSERT INTO TBProduct(Code,Description, UnitaryValue) VALUES ('0401','Meia', 15.32)";
        private const string INSERT_INVOICE_IN_PROCESS = "INSERT INTO TBInvoiceInProcess (EntryDate,NatureOperation,ConveyorId,EmitterId,ReceiverId,ValueFreight) VALUES (GETDATE(),'Teste',1,1,1,10)";
        private const string INSERT_ITEMINVOICE = "INSERT INTO TBItemInvoice(InvoiceId, ProductId, Quantity) VALUES (1, 1, '2')";

    

        public static void SeedDatabaseWithoutConveyor()
        {
            Db.Update(RECREATE_TABLES);
        }

        public static void SeedDatabaseWithConveyor()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_PHYSICAL_CONVEYOR);
            Db.Update(INSERT_LEGAL_CONVEYOR);
        }

        public static void SeedDatabaseWithConveyorWithDependency()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_PHYSICAL_CONVEYOR);
            Db.Update(INSERT_LEGAL_CONVEYOR);
            Db.Update(INSERT_EMITTER);
            Db.Update(INSERT_PHYSICAL_RECEIVER);
            Db.Update(INSERT_LEGAL_RECEIVER);
            Db.Update(INSERT_INVOICE_IN_PROCESS);
        }

        public static void SeedDatabaseWithOutReceiver()
        {
            Db.Update(RECREATE_TABLES);
        }

        public static void SeedDatabaseWithReceivers()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_PHYSICAL_RECEIVER);
            Db.Update(INSERT_LEGAL_RECEIVER);
        }

        public static void SeedDatabaseWithoutEmitter()
        {
            Db.Update(RECREATE_TABLES);
        }

        public static void SeedDatabaseWithEmitter()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_EMITTER);
        }

        public static void SeedDatabaseWithoutProduct()
        {
            Db.Update(RECREATE_TABLES);
        }

        public static void SeedDatabaseWithProduct()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_PRODUCT);
        }

        public static void SeedDatabaseWithProductWithDependency()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_PRODUCT);
            Db.Update(INSERT_EMITTER);
            Db.Update(INSERT_LEGAL_RECEIVER);
            Db.Update(INSERT_LEGAL_CONVEYOR);
            Db.Update(INSERT_INVOICE_IN_PROCESS);
            Db.Update(INSERT_ITEMINVOICE);
        }

        public static void SeedDatabaseWithInvoiceInProcessWithDependency()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_EMITTER);
            Db.Update(INSERT_PHYSICAL_RECEIVER);
            Db.Update(INSERT_LEGAL_RECEIVER);
            Db.Update(INSERT_PHYSICAL_CONVEYOR);
            Db.Update(INSERT_LEGAL_CONVEYOR);
            Db.Update(INSERT_INVOICE_IN_PROCESS);
            Db.Update(INSERT_PRODUCT);
            Db.Update(INSERT_ITEMINVOICE);
        }

        public static void SeedDatabaseWithEmitterWithDependency()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_EMITTER);
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_PRODUCT);
            Db.Update(INSERT_EMITTER);
            Db.Update(INSERT_LEGAL_RECEIVER);
            Db.Update(INSERT_LEGAL_CONVEYOR);
            Db.Update(INSERT_INVOICE_IN_PROCESS);
            Db.Update(INSERT_ITEMINVOICE);
        }

        public static void SeedDatabaseWithReceiverWithDependency()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_PRODUCT);
            Db.Update(INSERT_EMITTER);
            Db.Update(INSERT_LEGAL_RECEIVER);
            Db.Update(INSERT_LEGAL_CONVEYOR);
            Db.Update(INSERT_INVOICE_IN_PROCESS);
            Db.Update(INSERT_PHYSICAL_RECEIVER);
            Db.Update(INSERT_LEGAL_RECEIVER);
            Db.Update(INSERT_ITEMINVOICE);
        }

        public static void SeedDatabaseWithoutItemInvoice()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_PRODUCT);
            Db.Update(INSERT_EMITTER);
            Db.Update(INSERT_LEGAL_RECEIVER);
            Db.Update(INSERT_LEGAL_CONVEYOR);
            Db.Update(INSERT_INVOICE_IN_PROCESS);
        }

        public static void SeedDatabaseWithItemInvoice()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_PRODUCT);
            Db.Update(INSERT_EMITTER);
            Db.Update(INSERT_LEGAL_RECEIVER);
            Db.Update(INSERT_LEGAL_CONVEYOR);
            Db.Update(INSERT_INVOICE_IN_PROCESS);
            Db.Update(INSERT_ITEMINVOICE);
        }

        public static void SeedDatabaseWithoutInvoiceInProcess()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_EMITTER);
            Db.Update(INSERT_PHYSICAL_RECEIVER);
            Db.Update(INSERT_LEGAL_RECEIVER);
            Db.Update(INSERT_PHYSICAL_CONVEYOR);
            Db.Update(INSERT_LEGAL_CONVEYOR);
        }

        public static void SeedDatabaseWithoutInvoiceInProcessWithItemInvoice()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_EMITTER);
            Db.Update(INSERT_PHYSICAL_RECEIVER);
            Db.Update(INSERT_LEGAL_RECEIVER);
            Db.Update(INSERT_PHYSICAL_CONVEYOR);
            Db.Update(INSERT_LEGAL_CONVEYOR);
            Db.Update(INSERT_PRODUCT);
            Db.Update(INSERT_PRODUCT2);
        }



        public static void SeedDatabaseWithInvoiceInProcess()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_EMITTER);
            Db.Update(INSERT_PHYSICAL_RECEIVER);
            Db.Update(INSERT_LEGAL_RECEIVER);
            Db.Update(INSERT_PHYSICAL_CONVEYOR);
            Db.Update(INSERT_LEGAL_CONVEYOR);
            Db.Update(INSERT_PRODUCT);
            Db.Update(INSERT_PRODUCT2);
            Db.Update(INSERT_INVOICE_IN_PROCESS);
            Db.Update(INSERT_ITEMINVOICE);

        }

        public static void SeedDatabaseWithoutInvoiceIssued()
        {
            Db.Update(RECREATE_TABLES);
        

        }

    }
}