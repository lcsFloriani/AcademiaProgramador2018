using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Domain.Features.Taxes;
using Projeto_NFe.Infra.AccessKeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceIssuedTest
    {
        private Mock<Conveyor> _fakeConveyor;
        private Mock<Emitter> _fakeEmitter;
        private Mock<Receiver> _fakeReceiver;
        private Mock<ItemInvoice> _fakeFirstItemInvoice;
        private Mock<ItemInvoice> _fakeSecondItemInvoice;
        private Mock<Tax> _fakeTax;
        private Mock<AccessKey> _fakeKey;

        private List<ItemInvoice> items;

        [SetUp]
        public void Initialize()
        {
            _fakeConveyor = new Mock<Conveyor>();
            _fakeEmitter = new Mock<Emitter>();
            _fakeReceiver = new Mock<Receiver>();

            _fakeFirstItemInvoice = new Mock<ItemInvoice>();
            _fakeFirstItemInvoice.Object.Product = ObjectMother.GetProduct();
            _fakeSecondItemInvoice = new Mock<ItemInvoice>();
            _fakeSecondItemInvoice.Object.Product = ObjectMother.GetProduct();

            _fakeConveyor.Setup(x => x.Validate());
            _fakeEmitter.Setup(x => x.Validate());
            _fakeReceiver.Setup(x => x.Validate());

            items = new List<ItemInvoice>();
            items.Add(_fakeFirstItemInvoice.Object);
            items.Add(_fakeSecondItemInvoice.Object);

            _fakeTax = new Mock<Tax>();
            _fakeKey = new Mock<AccessKey>();
        }

        [Test]
        public void Invoices_Domain_InvoiceIssued_Validate_ShouldValidateWithSucess()
        {
            //Cenário
            InvoiceIssued invoice = ObjectMother.GetInvoiceIssued(_fakeConveyor.Object, _fakeEmitter.Object, _fakeReceiver.Object, items, _fakeTax.Object, _fakeKey.Object);

            //Ação
            Action action = invoice.Validate;

            //Saída
            action.Should().NotThrow<Exception>();
        }

      
        [Test]
        public void Invoices_Domain_InvoiceIssued_Validate_ShouldThrowInvoiceIssuedDateSmallerThanEntryDateException()
        {
            //Cenário
            InvoiceIssued invoice = ObjectMother.GetInvoiceIssuedWithInvalidIssuanceDate(_fakeConveyor.Object, _fakeEmitter.Object, _fakeReceiver.Object, items, _fakeTax.Object, _fakeKey.Object);

            //Ação
            Action action = invoice.Validate;

            //Saída
            action.Should().Throw<InvoiceIssuedDateSmallerThanEntryDateException>();
        }

        [Test]
        public void Invoices_Domain_InvoiceIssued_GenereteAccessKey_ShouldGenereteAccessKeyWithSuccess()
        {
            //Cenário
            int sizeNumberAccessKey = 44;
            InvoiceIssued invoice = ObjectMother.GetInvoiceIssuedWithoutAccessKey(_fakeConveyor.Object, _fakeEmitter.Object, _fakeReceiver.Object, items, _fakeTax.Object);

            //Ação
            invoice.GenereteAccessKey();

            //Saída
            invoice.Key.Should().NotBeNull();
            invoice.Key.NumberAccessKey.Should().NotBeEmpty();
            invoice.Key.NumberAccessKey.Length.Should().Be(sizeNumberAccessKey);
        }
    }
}
