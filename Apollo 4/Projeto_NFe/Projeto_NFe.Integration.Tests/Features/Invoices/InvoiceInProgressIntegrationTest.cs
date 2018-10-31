using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using Projeto_NFe.Infra.Data.Features.Invoices;
using Projeto_NFe.Infra.Data.Features.ItemInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceInProgressIntegrationTest
    {
        private IInvoiceInProcessRepository _InvoiceInProcessSQLRepository;
        private IItemInvoiceRepository _ItemInvoiceSQLRepository;

        private IInvoiceInProcessService _invoiceInProcessService;

        [SetUp]
        public void Initialize()
        {
            _InvoiceInProcessSQLRepository = new InvoiceInProcessSQLRepository();
            _ItemInvoiceSQLRepository = new ItemInvoiceSQLRepository();

            _invoiceInProcessService = new InvoiceInProcessService(_InvoiceInProcessSQLRepository, _ItemInvoiceSQLRepository);
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Add_ShouldAddWithSucess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            long ExpectedId = 1;

            //Ação
            var result = _invoiceInProcessService.Add(invoice);

            //Saída
            result.Id.Should().Be(ExpectedId);
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Add_ShouldThrowInvoiceInProcessNatureOperationNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcess();
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithOutNatureOperation();

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<InvoiceInProcessNatureOperationNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Add_ShouldThrowInvoiceInProcessValueFreightLessThanZeroException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcess();
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithValueFreightInvalid();

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<InvoiceInProcessValueFreightLessThanZeroException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Add_ShouldThrowInvoiceInProcessEmitterNullException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcess();
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithNullEmitter(
                ObjectMother.GetConveyor(ObjectMother.GetAddress()),
                ObjectMother.GetReceiver(ObjectMother.GetAddress()), list);

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<InvoiceInProcessEmitterNullException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Add_ShouldThrowInvoiceInProcessReceiverNullException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcess();
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithNullReceiver(
                ObjectMother.GetConveyor(ObjectMother.GetAddress()),
                ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj()), list);

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<InvoiceInProcessReceiverNullException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Add_ShouldThrowInvoiceInProcessItemsCountLessThanOneException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithNullItems(conveyor, emitter, receiver);


            //Ação
            Action Add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            Add.Should().Throw<InvoiceInProcessItemsCountLessThanOneException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Add_ShouldThrowInvoiceInProcessEmitterEqualReceiverException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverLegalWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<InvoiceInProcessEmitterEqualReceiverException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Add_ShouldThrowEmitterCompanyNameNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.getEmitterInvalidCompanyName(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<EmitterCompanyNameNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Add_ShouldThrowConveyorCompanyNameNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCompanyNameNullOrEmpty(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<ConveyorCompanyNameNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Add_ShouldThrowReceiverNameNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithNameEmpty(ObjectMother.GetAddress());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<ReceiverNameNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Add_ShouldThrowItemInvoiceQuantityLessThanOneException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice>();
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceInvalidQuantity(product, invoice);
            Item.Id = 1;
            invoice.Items.Add(Item);

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<ItemInvoiceQuantityLessThanOneException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Conveyor_Add_ShouldThrowAddressCityNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddressInvalidCity(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<AddressCityNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Emitter_Add_ShouldThrowAddressCityNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddressInvalidCity(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<AddressCityNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Receiver_Add_ShouldThrowAddressCityNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddressInvalidCity(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<AddressCityNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Conveyor_Add_ShouldThrowCnpjInvalidValueException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpjInvalidValue());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<CnpjInvalidValueException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Emitter_Add_ShouldThrowCnpjInvalidValueException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpjInvalidValue());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<CnpjInvalidValueException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Receiver_Add_ShouldThrowCpfIncorrectValueException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpfIncorrectValue());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);

            //Ação
            Action add = () => _invoiceInProcessService.Add(invoice);

            //Saída
            add.Should().Throw<CpfIncorrectValueException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Update_ShouldUpdateWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            Product product2 = ObjectMother.GetProduct();
            product2.Id = 2;
            List<ItemInvoice> list = new List<ItemInvoice> { };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            invoice.Id = 1;
            ItemInvoice item1 = ObjectMother.GetItemInvoice(product,invoice);
            item1.Id = 1;
            ItemInvoice item2 = ObjectMother.GetItemInvoiceWithoutInvoice(product2);
            invoice.Items.Add(item1);
            invoice.Items.Add(item2);

            //Ação
            var result = _invoiceInProcessService.Update(invoice);

            //Saída
            result.ValueFreight.Should().Be(invoice.ValueFreight);
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Update_ShouldThrowNatureOperationNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcess();
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithOutNatureOperation();
            invoice.Id = 1;

            //Ação
            Action Update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            Update.Should().Throw<InvoiceInProcessNatureOperationNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Update_ShouldThrowValueFreightLessThanZeroException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcess();
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithValueFreightInvalid();
            invoice.Id = 1;

            //Ação
            Action Update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            Update.Should().Throw<InvoiceInProcessValueFreightLessThanZeroException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Update_ShouldThrowEmitterNullException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcess();
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithNullEmitter(
                ObjectMother.GetConveyor(ObjectMother.GetAddress()),
                ObjectMother.GetReceiver(ObjectMother.GetAddress()), list);
            invoice.Id = 1;

            //Ação
            Action Update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            Update.Should().Throw<InvoiceInProcessEmitterNullException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Update_ShouldThrowReceiverNullException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcess();
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithNullReceiver(
                ObjectMother.GetConveyor(ObjectMother.GetAddress()),
                ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj()), list);
            invoice.Id = 1;

            //Ação
            Action Update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            Update.Should().Throw<InvoiceInProcessReceiverNullException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Update_ShouldThrowItemsCountLessThanOneException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithNullItems(conveyor, emitter, receiver);
            invoice.Id = 1;

            //Ação
            Action Update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            Update.Should().Throw<InvoiceInProcessItemsCountLessThanOneException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Update_ShouldThrowEmitterEqualReceiverException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverLegalWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            invoice.Id = 1;

            //Ação
            Action Update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            Update.Should().Throw<InvoiceInProcessEmitterEqualReceiverException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcess();
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithValueFreightInvalid();

            //Ação
            Action Update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            Update.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Get_ShouldGetWithSucess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();
            long GetId = 1;

            //Ação
            var GetInvoice = _invoiceInProcessService.Get(GetId);

            //Saída
            GetInvoice.Id.Should().Be(GetId);
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();
            long GetId = 0;

            //Ação
            Action Get = () => _invoiceInProcessService.Get(GetId);

            //Saída
            Get.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();
            int ExpectedCount = 1;

            //Ação
            var list = _invoiceInProcessService.GetAll();

            //Saída
            list.Count().Should().BeGreaterOrEqualTo(ExpectedCount);
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Update_ShouldThrowEmitterCompanyNameNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.getEmitterInvalidCompanyName(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            invoice.Id = 1;

            //Ação
            Action update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            update.Should().Throw<EmitterCompanyNameNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Update_ShouldThrowConveyorCompanyNameNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCompanyNameNullOrEmpty(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            invoice.Id = 1;

            //Ação
            Action update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            update.Should().Throw<ConveyorCompanyNameNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Update_ShouldThrowReceiverNameNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithNameEmpty(ObjectMother.GetAddress());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            invoice.Id = 1;

            //Ação
            Action update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            update.Should().Throw<ReceiverNameNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Update_ShouldThrowItemInvoiceQuantityLessThanOneException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice>();
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceInvalidQuantity(product, invoice);
            Item.Id = 1;
            invoice.Items.Add(Item);
            invoice.Id = 1;

            //Ação
            Action update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            update.Should().Throw<ItemInvoiceQuantityLessThanOneException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Conveyor_Update_ShouldThrowAddressCityNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddressInvalidCity(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            invoice.Id = 1;

            //Ação
            Action update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            update.Should().Throw<AddressCityNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Emitter_Update_ShouldThrowAddressCityNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddressInvalidCity(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            invoice.Id = 1;

            //Ação
            Action update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            update.Should().Throw<AddressCityNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Receiver_Update_ShouldThrowAddressCityNullOrEmptyException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddressInvalidCity(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            invoice.Id = 1;

            //Ação
            Action update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            update.Should().Throw<AddressCityNullOrEmptyException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Conveyor_Update_ShouldThrowCnpjInvalidValueException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpjInvalidValue());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            invoice.Id = 1;

            //Ação
            Action update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            update.Should().Throw<CnpjInvalidValueException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Emitter_Update_ShouldThrowCnpjInvalidValueException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpjInvalidValue());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            invoice.Id = 1;

            //Ação
            Action update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            update.Should().Throw<CnpjInvalidValueException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Receiver_Update_ShouldThrowCpfIncorrectValueException()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpfIncorrectValue());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { Item };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            invoice.Id = 1;

            //Ação
            Action update = () => _invoiceInProcessService.Update(invoice);

            //Saída
            update.Should().Throw<CpfIncorrectValueException>();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_WithoutInvoiceInProcess_Update_ShouldUpdateWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcessWithItemInvoice();
            Conveyor conveyor = ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            conveyor.Id = 1;
            Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj());
            emitter.Id = 1;
            Receiver receiver = ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf());
            receiver.Id = 1;
            Product product = ObjectMother.GetProduct();
            product.Id = 1;
            List<ItemInvoice> list = new List<ItemInvoice> { };
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, list);
            invoice.Id = 1;
            ItemInvoice Item = ObjectMother.GetItemInvoiceWithoutInvoice(product);
            Item.Id = 1;
            Item.Invoice = invoice;
            invoice.Items.Add(Item);

            //Ação
            var result = _invoiceInProcessService.Update(invoice);

            //Saída
            result.ValueFreight.Should().Be(invoice.ValueFreight);
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            long searchId = 1;

            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();
            InvoiceInProcess invoice = _invoiceInProcessService.Get(searchId);

            //Ação 
            _invoiceInProcessService.Delete(invoice);
            var result = _invoiceInProcessService.Get(searchId);

            //Saída
            result.Should().BeNull();
        }

        [Test]
        public void Invoices_Integration_InvoiceInProcess_Delete_ShouldDeleteThrowIdentifierUndefinedException()
        {
            //Cenário
            InvoiceInProcess invoice = new InvoiceInProcess();

            //Ação 
            Action delete = () =>_invoiceInProcessService.Delete(invoice);

            //Saída
            delete.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
