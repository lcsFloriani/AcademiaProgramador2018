using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.Invoices.Queries;
using Projeto_NFe.Application.Features.Invoices.ViewModels;
using Projeto_NFe.Application.Mapping;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Infra.Data.Features.Conveyors;
using Projeto_NFe.Infra.Data.Features.Emitters;
using Projeto_NFe.Infra.Data.Features.Invoices;
using Projeto_NFe.Infra.Data.Features.Products;
using Projeto_NFe.Infra.Data.Features.Receivers;
using Projeto_NFe.Infra.ORM.Context;
using Projeto_NFe.WebApi.Controllers.Invoices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceInProgressIntegrationTest
    {
        private IInvoiceInProcessRepository _repository;
        private IInvoiceInProcessService _service;
        private InvoicesController _controller;
        private ProjetoNFeContextTest _context;
        private InvoiceInProcessCommandDelete _invoiceInProgressDelete;
        private InvoiceProcessCommandRegister _invoiceInProgressRegister;
        private InvoiceProcessCommandUpdate _invoiceInProgressUpdate;
        private InvoiceInProcessViewModel _invoiceInProgressViewModel;
        private InvoiceIInProcessQuery _invoiceInProgressQuery;
        private IProductRepository _product;
        private IReceiverRepository _receiver;
        private IEmitterRepository _emitter;
        private IConveyorRepository _conveyor;
        private List<ItemInvoice> _itens;
        private InvoiceInProcess _invoice;
        private ItemInvoice _item;

        [SetUp]
        public void Initialize()
        {
            Database.SetInitializer(new DbInitializer());
            _context = new ProjetoNFeContextTest();

            _product = new ProductRepository(_context);
            _emitter = new EmitterRepository(_context);
            _receiver = new ReceiverRepository(_context);
            _conveyor = new ConveyorsRepository(_context);
            _repository = new InvoiceInProcessRepository(_context);
            _service = new InvoiceInProcessService(_repository, _product, _conveyor, _emitter , _receiver);
            _controller = new InvoicesController(_service);

            _invoiceInProgressDelete = new InvoiceInProcessCommandDelete();
            _invoiceInProgressRegister = new InvoiceProcessCommandRegister();
            _invoiceInProgressUpdate = new InvoiceProcessCommandUpdate();
            _invoiceInProgressViewModel = new InvoiceInProcessViewModel();

            _invoice = CriaCenarios(_context);
            _invoice.Id = 1;

            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
        }

        [Test]
        [Order(1)]
        public void InvoiceInProgress_Integration_Add_ShouldAddWithSuccess()
        {
            //Cenário
            int expectedId = 1;
            var conveyor = _conveyor.Get(expectedId);
            conveyor.Id = 1;
            var receiver = _receiver.Get(expectedId);
            receiver.Id = 1;
            var emitter = _emitter.Get(expectedId);
            emitter.Id = 1;
            InvoiceInProcess recurrence = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, _itens);
            recurrence.Id = expectedId;

            //Demais propiedades
            _invoiceInProgressRegister.ConveyorId = recurrence.Conveyor.Id;
            _invoiceInProgressRegister.ReceiverId = recurrence.Receiver.Id;
            _invoiceInProgressRegister.EmitterId = recurrence.Emitter.Id;
            _invoiceInProgressRegister.EntryDate = recurrence.EntryDate;
            _invoiceInProgressRegister.NatureOperation = recurrence.NatureOperation;
            _invoiceInProgressRegister.ValueFreight = recurrence.ValueFreight;
            //Ação
            var result = _controller.Post(_invoiceInProgressRegister);
            //Saída
            result.Should().NotBeNull();
        }

        [Test]
        [Order(2)]
        public void InvoiceInProgress_Integration_Update_ShouldUpdateWithSuccess()
        {
            //Cenario

            long expectedId = 1;
            string expectedNaturezeOperation = "Venda";

            string oldNameCompany = _invoice.NatureOperation;
            _invoice.NatureOperation = expectedNaturezeOperation;
            
            //Ação

            _invoiceInProgressUpdate.ConveyorId = _invoice.Conveyor.Id;
            _invoiceInProgressUpdate.EmitterId = _invoice.Emitter.Id;
            _invoiceInProgressUpdate.EntryDate = _invoice.EntryDate;
            _invoiceInProgressUpdate.NatureOperation = _invoice.NatureOperation;
            _invoiceInProgressUpdate.ReceiverId = _invoice.Receiver.Id;
            _invoiceInProgressUpdate.ValueFreight = _invoice.ValueFreight;
            _invoiceInProgressUpdate.Id = expectedId;
            _item = ObjectMother.GetItemInvoice(_product.Get(1), _invoice);
            _itens.Add(_item);
            _invoiceInProgressUpdate.Items = _itens;
            _context.InvoicesInProcess.Add(_invoice);
            _context.SaveChanges();
            _controller.Update(_invoiceInProgressUpdate);

            //Saída
            var result = _service.Get(_invoice.Id);
            result.Should().NotBeNull();
        }

        [Test]
        [Order(3)]
        public void InvoiceInProgress_Integration_Get_ShouldGetWithSuccess()
        {
            //Cenário
            int searchId = 1;
            var conveyor = ObjectMother.GetLegalConveyor(ObjectMother.GetAddress());
            conveyor.Id = 1;
            var receiver = ObjectMother.GetReceiverLegal(ObjectMother.GetAddress());
            receiver.Id = 1;
            var emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress());
            emitter.Id = 1;
            InvoiceInProcess recurrence = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, _itens);

            recurrence.Id = searchId;

            //Ação
            var result = _controller.GetById(searchId);

            //Saída
            result.Should().NotBeNull();
        }



        [Test]
        [Order(4)]
        public void InvoiceInProgress_Integration_GetAll_ShouldGetAllWithSuccess()
        {
            // Cenário

            int size = 1;
            long firstEmitterId = 1;
            int biggerThan = 0;

            var odata = OdataQueryOptions.GetOdataQueryOptions<InvoiceInProcess>(_controller);

            // Executa
            var invoice = _controller.Get(odata);

            // Saída
            invoice.Should().NotBeNull();
        }

        [Test]
        [Order(5)]
        public void InvoiceInProgress_Integration_Delete_ShouldDeleteWithSuccess()
        {
            //Cenário
            long id = 1;
            var invoiceIds = new long[] { id };
            _invoiceInProgressDelete.InvoiceIds = invoiceIds;

            //Ação
            var result =  _controller.Delete(_invoiceInProgressDelete);

            //Saída
            result.Should().NotBeNull();
            _context.Database.Delete();
        }

        public InvoiceInProcess CriaCenarios(ProjetoNFeContextTest _context)
        {
            InvoiceInProcess Invoice;
            var conveyor = ObjectMother.GetLegalConveyor(ObjectMother.GetAddress());
            _context.Conveyors.Add(conveyor);
            var receiver = ObjectMother.GetReceiverLegal(ObjectMother.GetAddress());
            _context.Receivers.Add(receiver);
            var emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress());
            _context.Emitters.Add(emitter);
            var product = ObjectMother.GetProduct();
            _context.Products.Add(product);
            _context.SaveChanges();
            _itens = new List<ItemInvoice>();
            _item = new ItemInvoice();

            return Invoice = ObjectMother.GetInvoiceInProcess(conveyor, emitter, receiver, _itens);
        }
    }
}
