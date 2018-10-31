using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Infra.Data.Features.Invoices;
using Projeto_NFe.Infra.Data.Features.ItemInvoices;
using Projeto_NFe.Infra.XML.Features.Invoices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceIssuedIntegrationTest
    {
        private IInvoiceInProcessRepository _invoiceInProcessRepository;
        private IInvoiceIssuedRepository _invoiceIssuedRepository;
        private IInvoiceIssuedXMLRepository _invoiceIssuedXMLRepository;

        private InvoiceIssued _invoiceIssued;
        private InvoiceInProcess _invoiceInProcess;
        private IInvoiceIssuedService _service;
        private List<ItemInvoice> itens;
        
        private IInvoiceInProcessService _invoiceInProcessService;
        private IItemInvoiceRepository _itemInvoiceRepository;

        [SetUp]
        public void Initialize()
        {
            _invoiceInProcessRepository = new InvoiceInProcessSQLRepository();
            _invoiceIssuedRepository = new InvoiceIssuedSQLRepository();
            _invoiceIssuedXMLRepository = new InvoiceIssuedXMLRepository();
            _itemInvoiceRepository = new ItemInvoiceSQLRepository();
            _invoiceInProcessService = new InvoiceInProcessService(_invoiceInProcessRepository, _itemInvoiceRepository);

            itens = new List<ItemInvoice>()
            {
                ObjectMother.GetItemInvoiceWithoutInvoice(ObjectMother.GetProduct())
            };

            _invoiceIssued = ObjectMother.GetInvoiceIssued(ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress(), ObjectMother.GetCpf()),
                ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj()), ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf()),
                itens, ObjectMother.GetTax(_invoiceIssued), ObjectMother.GetAccessKey());

            _invoiceInProcess = ObjectMother.GetInvoiceInProcess(ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress(), ObjectMother.GetCpf()),
                ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj()), ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf()),
                itens);

            _service = new InvoiceIssuedService(_invoiceIssuedRepository, _invoiceInProcessRepository, _invoiceIssuedXMLRepository);
        }

        [Test, Order(1)]
        public void Invoices_Integration_InvoiceIssued_IssuedNote_ShouldIssuedNoteWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();

            long idInvoiceInProcess = 1;
            InvoiceInProcess invoiceInProcess = _invoiceInProcessService.Get(idInvoiceInProcess);

            long idExpected = 1;
            int size = 1;

            //Ação
            InvoiceIssued invoiceIssued = _service.IssuedNote(invoiceInProcess);

            //Saída
            invoiceIssued.Should().NotBeNull();
            invoiceIssued.Id.Should().Be(idExpected);
            invoiceIssued.Receiver.Should().NotBeNull();
            invoiceIssued.Emitter.Should().NotBeNull();
            invoiceIssued.Conveyor.Should().NotBeNull();
            invoiceIssued.Items.Should().NotBeNull();
            invoiceIssued.Items.Count().Should().Be(size);
        }

        [Test, Order(12)]
        public void Invoices_Integration_InvoiceIssued_IssuedNote_ShouldThrowInvoiceInProcessValueFreightLessThanZeroException()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();
            
            InvoiceInProcess invoiceInProcess = ObjectMother.GetInvoiceInProcessWithValueFreightInvalid();

            //Ação
            Action action = () => _service.IssuedNote(invoiceInProcess);

            //Saída
            action.Should().Throw<InvoiceInProcessValueFreightLessThanZeroException>();
        }

        [Test, Order(13)]
        public void Invoices_Integration_InvoiceIssued_IssuedNote_ShouldThrowInvoiceInProcessNatureOperationNullOrEmptyException()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();

            InvoiceInProcess invoiceInProcess = ObjectMother.GetInvoiceInProcessWithOutNatureOperation();
            
            //Ação
            Action action = () => _service.IssuedNote(invoiceInProcess);

            //Saída
            action.Should().Throw<InvoiceInProcessNatureOperationNullOrEmptyException>();
        }

        [Test, Order(14)]
        public void Invoices_Integration_InvoiceIssued_IssuedNote_ShouldThrowInvoiceInProcessEmitterNullException()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();

            InvoiceInProcess invoiceInProcess = ObjectMother.GetInvoiceInProcessWithNullEmitter(
                ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress(), ObjectMother.GetCpf()),
               ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf()),
                itens);

            //Ação
            Action action = () => _service.IssuedNote(invoiceInProcess);

            //Saída
            action.Should().Throw<InvoiceInProcessEmitterNullException>();
        }

        [Test, Order(15)]
        public void Invoices_Integration_InvoiceIssued_IssuedNote_ShouldThrowInvoiceInProcessReceiverNullException()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();

            InvoiceInProcess invoiceInProcess = ObjectMother.GetInvoiceInProcessWithNullReceiver(
                ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress(), ObjectMother.GetCpf()),
                ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj()), itens);

            //Ação
            Action action = () => _service.IssuedNote(invoiceInProcess);

            //Saída
            action.Should().Throw<InvoiceInProcessReceiverNullException>();
        }

        [Test, Order(16)]
        public void Invoices_Integration_InvoiceIssued_IssuedNote_ShouldThrowInvoiceInProcessItemsCountLessThanOneException()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();

            InvoiceInProcess invoiceInProcess = ObjectMother.GetInvoiceInProcessWithNullItems(
                ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress(), ObjectMother.GetCpf()),
                ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj()), 
                ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf()));

            //Ação
            Action action = () => _service.IssuedNote(invoiceInProcess);

            //Saída
            action.Should().Throw<InvoiceInProcessItemsCountLessThanOneException>();
        }

        [Test, Order(17)]
        public void Invoices_Integration_InvoiceIssued_IssuedNote_ShouldThrowInvoiceInProcessEmitterEqualReceiverException()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();

            InvoiceInProcess invoiceInProcess = ObjectMother.GetInvoiceInProcess(
                ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress(), ObjectMother.GetCpf()),
                ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj()),
                ObjectMother.GetReceiverLegalWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj()), itens);

            //Ação
            Action action = () => _service.IssuedNote(invoiceInProcess);

            //Saída
            action.Should().Throw<InvoiceInProcessEmitterEqualReceiverException>();
        }

        [Test, Order(2)]
        public void Invoices_Integration_InvoiceIssued_Get_ShouldGetWithSuccess()
        {
            //Cenário
            long searchId = 1;
            int size = 1;

            //Ação
            InvoiceIssued invoiceIssued = _service.Get(searchId);

            //Saída
            invoiceIssued.Should().NotBeNull();
            invoiceIssued.Id.Should().Be(searchId);
            invoiceIssued.Receiver.Should().NotBeNull();
            invoiceIssued.Emitter.Should().NotBeNull();
            invoiceIssued.Conveyor.Should().NotBeNull();
            invoiceIssued.Items.Should().NotBeNull();
            invoiceIssued.Items.Count().Should().Be(size);
        }

        [Test, Order(3)]
        public void Invoices_Integration_InvoiceIssued_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            long searchId = 0;

            //Ação
            Action action = () => _service.Get(searchId);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test, Order(18)]
        public void Invoices_Integration_InvoiceIssued_Get_ShouldGetWithNullXml()
        {
            //Cenário
            long searchId = 3;

            //Ação
            var result = _service.Get(searchId);

            //Saída
            result.Should().BeNull();
        }

        [Test, Order(4)]
        public void Invoices_Integration_InvoiceIssued_GetByAccessKey_ShouldGetByAccessKeyWithSuccess()
        {
            //Cenário
            int size = 1;
            long searchId = 1;
            InvoiceIssued invoiceIssued = _service.Get(searchId);

            //Ação
            InvoiceIssued result = _service.GetByAccessKey(invoiceIssued.Key.NumberAccessKey);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(searchId);
            result.Receiver.Should().NotBeNull();
            result.Emitter.Should().NotBeNull();
            result.Conveyor.Should().NotBeNull();
            result.Items.Should().NotBeNull();
            result.Items.Count().Should().Be(size);
        }

        [Test, Order(5)]
        public void Invoices_Integration_InvoiceIssued_GetByAccessKey_ShouldThrowAccessKeyNumberAccessKeyNullOrEmptyException()
        {
            //Cenário
            string key = "";

            //Ação
            Action action = () => _service.GetByAccessKey(key);

            //Saída
            action.Should().Throw<InvoiceIssuedAccessKeyNumberAccessKeyNullOrEmptyException>();
        }

        [Test, Order(19)]
        public void Invoices_Integration_InvoiceIssued_GetByAccessKey_ShouldGetByAccessKeyWithNullXml()
        {
            //Cenário
            string nonExistentKey = "5685645645456456456";

            //Ação
            var result = _service.GetByAccessKey(nonExistentKey);

            //Saída
            result.Should().BeNull();
        }

        [Test, Order(6)]
        public void Invoices_Integration_InvoiceIssued_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenário
            int size = 1;

            //Ação
            IEnumerable<InvoiceIssued> result = _service.GetAll();

            //Saída
            result.Should().NotBeNull();
            result.Count().Should().Be(size);
        }

        [Test, Order(7)]
        public void Invoices_Integration_InvoiceIssued_ExportToXML_ShouldExportToXMLWithSuccess()
        {
            //Cenário
            long searchId = 1;
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktop, "TesteDeNotaFiscalIntegracao(destinatario Fisico).xml");
            InvoiceIssued invoiceIssued = _service.Get(searchId);

            //Ação
            _service.ExportToXML(invoiceIssued.Key.NumberAccessKey, path);

            //Saída
            bool exist = File.Exists(path);
            exist.Should().BeTrue();
        }

        [Test, Order(8)]
        public void Invoices_Integration_InvoiceIssued_ExportToXML_ShouldThrowInvalidPathException()
        {
            //Cenário
            long searchId = 1;
            string path = "";
            InvoiceIssued invoiceIssued = _service.Get(searchId);

            //Ação
            Action action = () =>  _service.ExportToXML(invoiceIssued.Key.NumberAccessKey, path);

            //Saída
            action.Should().Throw<InvalidPathException>();
        }

        [Test, Order(9)]
        public void Invoices_Integration_InvoiceIssued_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            long searchId = 1;
            InvoiceIssued invoiceIssued = _service.Get(searchId);

            //Ação
            _service.Delete(invoiceIssued);

            //Saída
            InvoiceIssued result = _service.Get(searchId);
            result.Should().BeNull();
        }

        [Test, Order(10)]
        public void Invoices_Integration_InvoiceIssued_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            InvoiceIssued invoiceIssued = _invoiceIssued;

            //Ação
            Action action = () => _service.Delete(invoiceIssued);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test, Order(11)]
        public void Invoices_Integration_InvoiceIssued_ExportToPDF_ShouldExportToPDFWithSuccess()
        {
            //Cenário
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktop, "TesteDeNotaFiscal(destinatario Fisico).xml");
            string key = "12344567891010987654321054128976126798341634";

            //Ação
            Action action = () => _service.ExportToPDF(key, path);

            //Saída
            action.Should().Throw<UnsupportedOperationException>();
        }

    }
}
