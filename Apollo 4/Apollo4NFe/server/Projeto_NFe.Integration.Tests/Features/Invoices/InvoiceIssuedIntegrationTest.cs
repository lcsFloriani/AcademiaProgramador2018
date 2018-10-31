//using FluentAssertions;
//using NUnit.Framework;
//using Projeto_NFe.Application.Features.Invoices;
//using Projeto_NFe.Application.Features.Invoices.Commands;
//using Projeto_NFe.Application.Features.Invoices.Queries;
//using Projeto_NFe.Application.Features.Invoices.ViewModels;
//using Projeto_NFe.Application.Mapping;
//using Projeto_NFe.Common.Tests.Base;
//using Projeto_NFe.Domain.Features.Conveyors;
//using Projeto_NFe.Domain.Features.Emitters;
//using Projeto_NFe.Domain.Features.Invoices;
//using Projeto_NFe.Domain.Features.ItemInvoices;
//using Projeto_NFe.Domain.Features.Receivers;
//using Projeto_NFe.Infra.Data.Features.Invoices;
//using Projeto_NFe.Infra.ORM.Context;
//using Projeto_NFe.WebApi.Controllers.Features.Invoices;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;

//namespace Projeto_NFe.Integration.Tests.Features.Invoices
//{
//    [TestFixture]
//    public class InvoiceIssuedIntegrationTest
//    {
//        private IInvoiceIssuedRepository _repository;
//        private IInvoiceIssuedService _service;
//        private InvoicesIssuedController _controller;
//        private ProjetoNFeContext _context;

//        private InvoiceIssuedCommandDelete _invoiceIssuedDelete;
//        private InvoiceIssuedCommandRegister _invoiceIssuedRegister;
//        private InvoiceIssuedCommandUpdate _invoiceIssuedUpdate;
//        private InvoiceIssuedViewModel _invoiceIssuedViewModel;
//        private InvoiceIssuedQuery _invoiceIssuedQuery;
//        private Conveyor _conveyor;
//        private Emitter _emitter;
//        private Receiver _receiver;
//        private List<ItemInvoice> _itens;


//        [SetUp]
//        public void Initialize()
//        {
//            _context = new ProjetoNFeContext();
//            _repository = new InvoiceIssuedRepository(_context);
//            _service = new InvoiceIssuedService(_repository);
//            _invoiceIssuedDelete = new InvoiceIssuedCommandDelete();
//            _invoiceIssuedRegister = new InvoiceIssuedCommandRegister();
//            _invoiceIssuedUpdate = new InvoiceIssuedCommandUpdate();
//            _invoiceIssuedViewModel = new InvoiceIssuedViewModel();
//            _controller = new InvoicesIssuedController(_service);

//            _conveyor = ObjectMother.GetLegalConveyor(ObjectMother.GetAddress());
//            _emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress());
//            _receiver = ObjectMother.GetReceiverLegal(ObjectMother.GetAddress());
//            _itens = new List<ItemInvoice>();

//            Database.SetInitializer(new BaseIntegrationTest());
//            _context.Database.Initialize(true);

//            AutoMapperInitializer.Reset();
//            AutoMapperInitializer.Initialize();
//        }

//        [Test]
//        public void InvoiceIssueds_Integration_Add_ShouldAddWithSuccess()
//        {
//            //Cenário
//            long expectedId = 1;
//            InvoiceIssued recurrence = ObjectMother.GetInvoiceIssued(_conveyor,_emitter,_receiver,_itens);
//            recurrence.Id = expectedId;

//            _invoiceIssuedRegister.Conveyor = recurrence.Conveyor;
//            _invoiceIssuedRegister.ConveyorId = recurrence.Conveyor.Id;
//            _invoiceIssuedRegister.Emitter = recurrence.Emitter;
//            _invoiceIssuedRegister.EmitterId = recurrence.EmitterId;
//            _invoiceIssuedRegister.EntryDate = recurrence.EntryDate;
//            _invoiceIssuedRegister.Items = recurrence.Items;
//            _invoiceIssuedRegister.NatureOperation = recurrence.NatureOperation;
//            _invoiceIssuedRegister.Receiver = recurrence.Receiver;
//            _invoiceIssuedRegister.ReceiverId = recurrence.ReceiverId;
//            _invoiceIssuedRegister.ValueFreight = recurrence.ValueFreight;

//            //Ação
//            var result = _controller.Post(_invoiceIssuedRegister);

//            //Saída
//            result.Should().NotBeNull();
//        }

//        [Test]
//        public void InvoiceIssueds_Integration_Update_ShouldUpdateWithSuccess()
//        {
//            //Cenario

//            long expectedId = 1;
//            string expectedOperation = "Compra";
//            var expectedDate = DateTime.Now;

//            InvoiceIssued invoiceIssued = _service.Get(expectedId);
//            string oldOperation = invoiceIssued.NatureOperation;
//            var oldDate = invoiceIssued.IssuanceDate;
//            invoiceIssued.NatureOperation = expectedOperation;
//            invoiceIssued.EntryDate = expectedDate;
//            //Ação
//            _invoiceIssuedRegister.Conveyor = invoiceIssued.Conveyor;
//            _invoiceIssuedRegister.ConveyorId = invoiceIssued.Conveyor.Id;
//            _invoiceIssuedRegister.Emitter = invoiceIssued.Emitter;
//            _invoiceIssuedRegister.EmitterId = invoiceIssued.EmitterId;
//            _invoiceIssuedRegister.EntryDate = invoiceIssued.EntryDate;
//            _invoiceIssuedRegister.Items = invoiceIssued.Items;
//            _invoiceIssuedRegister.NatureOperation = invoiceIssued.NatureOperation;
//            _invoiceIssuedRegister.Receiver = invoiceIssued.Receiver;
//            _invoiceIssuedRegister.ReceiverId = invoiceIssued.ReceiverId;
//            _invoiceIssuedRegister.ValueFreight = invoiceIssued.ValueFreight;
//            _controller.Update(_invoiceIssuedUpdate);

//            //Saída
//            var result = _service.Get(expectedId);
//            result.Should().NotBeNull();
//            result.EntryDate.Should().NotBe(oldDate);
//            result.NatureOperation.Should().NotBe(oldOperation);
//        }

//        [Test]
//        public void InvoiceIssueds_Integration_Get_ShouldGetWithSuccess()
//        {
//            //Cenário
//            int searchId = 1;
//            InvoiceIssued recurrence = ObjectMother.GetInvoiceIssued(_conveyor, _emitter, _receiver, _itens);
//            recurrence.Id = searchId;

//            //Ação
//            var result = _controller.GetById(searchId);

//            //Saída
//            result.Should().NotBeNull();
//        }

//        [Test]
//        public void InvoiceIssueds_Integration_GetAll_ShouldGetAllWithSuccess()
//        {
//            // Cenário

//            int size = 1;
//            long firstInvoiceIssuedId = 1;
//            int biggerThan = 0;

//            var odata = OdataQueryOptions.GetOdataQueryOptions<InvoiceIssued>(_controller);

//            // Executa
//            var invoiceIssued = _controller.Get(odata);

//            // Saída
//            invoiceIssued.Should().NotBeNull();
//        }

//        [Test]
//        public void InvoiceIssueds_Integration_Delete_ShouldDeleteWithSuccess()
//        {
//            //Cenário
//            long id = 1;
//            var invoiceIds = new long[] { id };
//            InvoiceIssued invoiceIssued = ObjectMother.GetInvoiceIssued(_conveyor, _emitter, _receiver, _itens);
//            invoiceIssued.Id = id;
//            _invoiceIssuedDelete.InvoiceIds = invoiceIds;

//            //Ação
//            _controller.Delete(_invoiceIssuedDelete);

//            //Saída
//            InvoiceIssued result = _repository.Get(id);
//            result.Should().BeNull();
//        }

//    }
//}
