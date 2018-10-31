using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Receivers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Test.Features.Invoices
{
    [TestFixture]
    public class InvoiceIssuedApplicationTest
    {
        private Mock<IInvoiceInProcessRepository> _mockInvoiceInProcessRepository;
        private Mock<IInvoiceIssuedRepository> _mockInvoiceIssuedRepository;
        private Mock<IInvoiceIssuedXMLRepository> _mockInvoiceIssuedXMLRepository;
        private InvoiceIssued _invoiceIssued;
        private InvoiceInProcess _invoiceInProcess;
        private InvoiceIssuedService _service;
        private string _xml = "<InvoiceIssued> <Id>1</Id> <EntryDate>2018-06-13T09:29:42.8568007-03:00</EntryDate> <NatureOperation>Teste</NatureOperation><Conveyor><Id>1</Id><Type>PHYSICAL</Type><NameCompanyName>José da Silva</NameCompanyName><FreightResponsibility>EMITTER</FreightResponsibility><Cpf><Value>32999959010</Value></Cpf><Address><Street>ABC</Street><Number>12</Number><Neighbourhood>Coral</Neighbourhood><City>Lages</City><State>SC</State></Address></Conveyor><Emitter><Id>1</Id><FantasyName>asd</FantasyName><CompanyName>Jequiti</CompanyName><Cnpj><Value>08671696000190</Value></Cnpj><StateRegistration>3123123</StateRegistration><MunicipalRegistration>2039102</MunicipalRegistration><Address><Street>ABC</Street><Number>12</Number><Neighbourhood>Coral</Neighbourhood><City>Lages</City><State>SC</State></Address></Emitter><Receiver><Id>1</Id><Type>PHYSICAL</Type><NameCompanyName>Test</NameCompanyName><Cpf><Value>32999959010</Value></Cpf><StateRegistration>Test</StateRegistration><Address><Street>ABC</Street><Number>12</Number><Neighbourhood>Coral</Neighbourhood><City>Lages</City><State>SC</State></Address></Receiver><Items><ItemInvoice><Id>0</Id><Product><Id>0</Id><Description>Tenis</Description><UnitaryValue>12.32</UnitaryValue></Product><Quantity>2</Quantity></ItemInvoice></Items><Tax><ValueFreight>2</ValueFreight></Tax><Key><NumberAccessKey>12344567891010987654321054128976126798341634</NumberAccessKey></Key><IssuanceDate>2018-06-14T09:29:42.8578002-03:00</IssuanceDate></InvoiceIssued>";
        private List<ItemInvoice> itens;

        [SetUp]
        public void Initialize()
        {
            _mockInvoiceInProcessRepository = new Mock<IInvoiceInProcessRepository>();
            _mockInvoiceIssuedRepository = new Mock<IInvoiceIssuedRepository>();
            _mockInvoiceIssuedXMLRepository = new Mock<IInvoiceIssuedXMLRepository>();

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

            _service = new InvoiceIssuedService(_mockInvoiceIssuedRepository.Object, _mockInvoiceInProcessRepository.Object, _mockInvoiceIssuedXMLRepository.Object);
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_ExportToPDF_ShouldExportToPDFWithSuccess()
        {
            //Cenário
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktop, "TesteDeNotaFiscal(destinatario Fisico).xml");
            string key = "12344567891010987654321054128976126798341634";

            //Ação
            Action action = () => _service.ExportToPDF(key, path);

            //Saída
            action.Should().Throw<UnsupportedOperationException>();
            _mockInvoiceIssuedRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_ExportToXML_ShouldExportToXMLWithSuccess()
        {
            //Cenário
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktop, "TesteDeNotaFiscal(destinatario Fisico).xml");
            string key = "12344567891010987654321054128976126798341634";

            _mockInvoiceIssuedRepository.Setup(x => x.GetByAccessKey(key)).Returns(_xml);
            InvoiceIssued invoiceIssued = _service.GetByAccessKey(key);
            _mockInvoiceIssuedXMLRepository.Setup(x => x.Export(It.IsAny<InvoiceIssued>(), path));

            //Ação
            _service.ExportToXML(key, path);

            //Saída
            _mockInvoiceIssuedXMLRepository.Verify(x => x.Export(It.IsAny<InvoiceIssued>(), path));
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_ExportToXML_ShouldThrowInvalidPathException()
        {
            //Cenário
            string path = "";
            string key = "12344567891010987654321054128976126798341634";

            //Ação
            Action action = () => _service.ExportToXML(key, path);

            //Saída
            action.Should().Throw<InvalidPathException>();
            _mockInvoiceIssuedRepository.VerifyNoOtherCalls();
            _mockInvoiceIssuedXMLRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_Get_ShouldGetWithSuccess()
        {
            //Cenário
            int searchId = 1;

            _mockInvoiceIssuedRepository.Setup(x => x.Get(searchId)).Returns(_xml);

            //Ação
            InvoiceIssued result = _service.Get(searchId);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(searchId);
            _mockInvoiceIssuedRepository.Verify(x => x.Get(searchId));
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            long searchId = 0;

            //Ação
            Action action = () => _service.Get(searchId);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
            _mockInvoiceIssuedRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenário
            int size = 1;

            IEnumerable<string> listaXml = new List<string>() { _xml };

            _mockInvoiceIssuedRepository.Setup(x => x.GetAll()).Returns(listaXml);

            //Ação
            IEnumerable<InvoiceIssued> result = _service.GetAll();

            //Saída
            result.Should().NotBeNull();
            result.Count().Should().Be(size);
            _mockInvoiceIssuedRepository.Verify(x => x.GetAll());
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_GetByAccessKey_ShouldGetByAccessKeyWithSuccess()
        {
            //Cenário
            int idExpected = 1;
            string key = "12344567891010987654321054128976126798341634";

            _mockInvoiceIssuedRepository.Setup(x => x.GetByAccessKey(key)).Returns(_xml);

            //Ação
           InvoiceIssued result = _service.GetByAccessKey(key);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(idExpected);
            _mockInvoiceIssuedRepository.Verify(x => x.GetByAccessKey(key));
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_GetByAccessKey_ShouldThrowAccessKeyNumberAccessKeyNullOrEmptyException()
        {
            //Cenário
            string key = "";

            //Ação
            Action action = () => _service.GetByAccessKey(key);

            //Saída
            action.Should().Throw<InvoiceIssuedAccessKeyNumberAccessKeyNullOrEmptyException>();
            _mockInvoiceIssuedRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_IssuedNote_ShouldInvoiceIssuedWithSuccess()
        {
            //Cenário
            long biggerThan = 0;
            InvoiceIssued invoiceIssued = _invoiceIssued;
            InvoiceInProcess invoiceInProcess = _invoiceInProcess;

            _mockInvoiceIssuedRepository.Setup(x => x.CheckAccessKeyIsRepeat(It.IsAny<InvoiceIssued>())).Returns(false);
            _mockInvoiceIssuedRepository.Setup(x => x.Save(It.IsAny<InvoiceIssued>())).Returns(new InvoiceIssued { Id = 1});
            _mockInvoiceInProcessRepository.Setup(x => x.Delete(invoiceInProcess));

            //Ação
            InvoiceIssued result = _service.IssuedNote(invoiceInProcess);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(biggerThan);
            _mockInvoiceIssuedRepository.Verify(x => x.CheckAccessKeyIsRepeat(It.IsAny<InvoiceIssued>()));
            _mockInvoiceIssuedRepository.Verify(x => x.Save(It.IsAny<InvoiceIssued>()));
            _mockInvoiceInProcessRepository.Verify(x => x.Delete(invoiceInProcess));
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_IssuedNote_ShouldThrowAccessKeyIsRepeatException()
        {
            //Cenário
            InvoiceIssued invoiceIssued = _invoiceIssued;
            InvoiceInProcess invoiceInProcess = _invoiceInProcess;

            bool exist = true;
            _mockInvoiceIssuedRepository.Setup(x => x.CheckAccessKeyIsRepeat(It.IsAny<InvoiceIssued>())).Returns(exist);

            //Ação
            Action action = () => _service.IssuedNote(invoiceInProcess);

            //Saída
            action.Should().Throw<InvoiceIssuedAccessKeyIsRepeatException>();
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_IssuedNote_ShouldThrowInvoiceInProcessEmitterNullException()
        {
            //Cenário
            InvoiceIssued invoiceIssued = _invoiceIssued;
            InvoiceInProcess invoiceInProcess = ObjectMother.GetInvoiceInProcessWithNullEmitter(ObjectMother.GetConveyor(ObjectMother.GetAddress()), 
                ObjectMother.GetReceiver(ObjectMother.GetAddress()), itens);

            //Ação
            Action action = () => _service.IssuedNote(invoiceInProcess);

            //Saída
            action.Should().Throw<InvoiceInProcessEmitterNullException>();
            _mockInvoiceIssuedRepository.VerifyNoOtherCalls();
            _mockInvoiceInProcessRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            InvoiceIssued invoiceIssued = _invoiceIssued;
            invoiceIssued.Id = 1;

            _mockInvoiceIssuedRepository.Setup(x => x.Delete(invoiceIssued));

            //Ação
            _service.Delete(invoiceIssued);

            //Saída
            _mockInvoiceIssuedRepository.Verify(x => x.Delete(invoiceIssued));
        }

        [Test]
        public void Invoices_Service_InvoiceIssued_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            InvoiceIssued invoiceIssued = _invoiceIssued;

            //Ação
            Action action = () =>_service.Delete(invoiceIssued);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
            _mockInvoiceIssuedRepository.VerifyNoOtherCalls();
        }
    }
}
