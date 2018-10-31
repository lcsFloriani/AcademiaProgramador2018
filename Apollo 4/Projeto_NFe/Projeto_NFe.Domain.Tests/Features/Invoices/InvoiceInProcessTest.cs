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
using Projeto_NFe.Infra.CNPJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceInProcessTest
    {

        private Mock<Conveyor> _fakeConveyor;
        private Mock<Emitter> _fakeEmitter;
        private Mock<Receiver> _fakeReceiver;
        private Mock<ItemInvoice> _fakeFirstItemInvoice;
        private Mock<ItemInvoice> _fakeSecondItemInvoice;

        private Mock<Cnpj> _fakeFirstCnpj;
        private Mock<Cnpj> _fakeSecondCnpj;

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

            _fakeFirstCnpj = new Mock<Cnpj>();
            _fakeFirstCnpj.Object.Value = "67479559000117";
            _fakeSecondCnpj = new Mock<Cnpj>();
            _fakeSecondCnpj.Object.Value = "89644496000140";
        }

        [Test]
        public void Invoices_Domain_InvoiceInProcess_Validate_ShouldValidateWithSucess()
        {
            //Cenário
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(_fakeConveyor.Object,_fakeEmitter.Object,_fakeReceiver.Object, items);

            //Ação
            Action action = invoice.Validate;

            //Saída
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Invoices_Domain_InvoiceInProcess_Validate_WithOutConveyor_ShouldValidateWithSucess()
        {
            //Cenário
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithOutConveyor(_fakeEmitter.Object, _fakeReceiver.Object, items);

            //Ação
            Action action = invoice.Validate;

            //Saída
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Invoices_Domain_InvoiceInProcess_Validate_ReceiverWithOutCnpj_ShouldValidateWithSucess()
        {
            //Cenário
            _fakeReceiver.Object.Cnpj = null;
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithOutConveyor(_fakeEmitter.Object, _fakeReceiver.Object, items);

            //Ação
            Action action = invoice.Validate;

            //Saída
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Invoices_Domain_InvoiceInProcess_Validate_ReceiverWithCnpj_ShouldValidateWithSucess()
        {
            //Cenário
            _fakeReceiver.Object.Cnpj = _fakeFirstCnpj.Object;
            _fakeEmitter.Object.Cnpj = _fakeSecondCnpj.Object;

            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithOutConveyor(_fakeEmitter.Object, _fakeReceiver.Object, items);

            //Ação
            Action action = invoice.Validate;

            //Saída
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Invoices_Domain_InvoiceInProcess_Validate_ShouldBeThrowInvoiceInProcessEmitterEqualReceiverException()
        {
            //Cenário
            _fakeReceiver.Object.Cnpj = _fakeFirstCnpj.Object;
            _fakeEmitter.Object.Cnpj = _fakeFirstCnpj.Object;

            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(_fakeConveyor.Object, _fakeEmitter.Object, _fakeReceiver.Object, items);

            //Ação
            Action action = invoice.Validate;

            //Saída
            action.Should().Throw<InvoiceInProcessEmitterEqualReceiverException>();
        }

        [Test]
        public void Invoices_Domain_InvoiceInProcess_Validate_ShouldBeThrowInvoiceInProcessNatureOperationNullOrEmptyException()
        {
            //Cenário
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithOutNatureOperation();

            //Ação
            Action action = invoice.Validate;

            //Saída
            action.Should().Throw<InvoiceInProcessNatureOperationNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Domain_InvoiceInProcess_Validate_ShouldBeThrowInvoiceInProcessValueFreightLessThanZeroException()
        {
            //Cenário
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithValueFreightInvalid();

            //Ação
            Action action = invoice.Validate;

            //Saída
            action.Should().Throw<InvoiceInProcessValueFreightLessThanZeroException>();
        }

        [Test]
        public void Invoices_Domain_InvoiceInProcess_Validate_ShouldThrowInvoiceInProcessEmitterNullException()
        {
            //Cenário
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithNullEmitter(_fakeConveyor.Object, _fakeReceiver.Object, items);

            //Ação
            Action action = invoice.Validate;

            //Saída
            action.Should().Throw<InvoiceInProcessEmitterNullException>();
        }

        [Test]
        public void Invoices_Domain_InvoiceInProcess_Validate_ShouldThrowInvoiceInProcessReceiverNullException()
        {
            //Cenário
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithNullReceiver(_fakeConveyor.Object, _fakeEmitter.Object,items);

            //Ação
            Action action = invoice.Validate;

            //Saída
            action.Should().Throw<InvoiceInProcessReceiverNullException>();
        }

        [Test]
        public void Invoices_Domain_InvoiceInProcess_Validate_ShouldThrowInvoiceInProcessItemsCountLessThanOneException()
        {
            //Cenário
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithNullItems(_fakeConveyor.Object, _fakeEmitter.Object, _fakeReceiver.Object);

            //Ação
            Action action = invoice.Validate;

            //Saída
            action.Should().Throw<InvoiceInProcessItemsCountLessThanOneException>();
        }

        //[Test]
        //public void Invoices_Domain_InvoiceInProcess_CloseIssue_ShouldCloseIssueWithSucess()
        //{
        //    //Cenário
        //    InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(_fakeConveyor.Object, _fakeEmitter.Object, _fakeReceiver.Object, items);
        //    double valueFreight = 10;
        //    //Ação
        //    var result = invoice.IssueNote(valueFreight);

        //    //Saída
        //    result.Should().NotBeNull();
        //    result.Key.Should().NotBeNull();
        //}

        //[Test]
        //public void Invoices_Domain_InvoiceInProcess_CloseIssue_ShouldThrowInvoiceInProcessNatureOperationNullOrEmptyException()
        //{
        //    //Cenário
        //    InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithOutNatureOperation(_fakeConveyor.Object, _fakeEmitter.Object, _fakeReceiver.Object, items);
        //    double valueFreight = 10;
        //    //Ação
        //    Action action = () =>invoice.IssueNote(valueFreight);

        //    //Saída
        //    action.Should().Throw<InvoiceInProcessNatureOperationNullOrEmptyException>();
        //}
    }
}
