//using FluentAssertions;
//using NUnit.Framework;
//using Projeto_NFe.Common.Tests.Base;
//using Projeto_NFe.Domain.Exceptions;
//using Projeto_NFe.Domain.Features.Addresses;
//using Projeto_NFe.Domain.Features.Conveyors;
//using Projeto_NFe.Domain.Features.Emitters;
//using Projeto_NFe.Domain.Features.Invoices;
//using Projeto_NFe.Domain.Features.ItemInvoices;
//using Projeto_NFe.Domain.Features.Receivers;
//using Projeto_NFe.Domain.Features.Taxes;
//using Projeto_NFe.Infra.AccessKeys;
//using Projeto_NFe.Infra.Data.Features.Invoices;
//using Projeto_NFe.Infra.ORM.Tests.Inicialize;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Projeto_NFe.Infra.ORM.Tests.Features.Invoices
//{
//    [TestFixture]
//    public class InvoiceIssuedSQLRepositoryTest : EffortBaseTest
//    {
//        private IInvoiceIssuedRepository _repository;
//        private Conveyor _conveyor;
//        private Emitter _emitter;
//        private Receiver _receiver;
//        private InvoiceIssued _invoice;
//        private List<ItemInvoice> _itens;
//        private AccessKey _key;
//        private Tax _tax;

//        [SetUp]
//        public void Initialize()
//        {
//            _repository = new InvoiceIssuedRepository(context);

//            Address address = ObjectMother.GetAddress();

//            _conveyor = ObjectMother.GetPhysicalConveyor(address);
//            _conveyor.Id = 1;
//            _emitter = ObjectMother.GetEmitter(address);
//            _emitter.Id = 1;
//            _receiver = ObjectMother.GetReceiverPhysical(address);
//            _receiver.Id = 1;
//            _itens = new List<ItemInvoice>();
//            _invoice = ObjectMother.GetInvoiceIssued(_conveyor, _emitter, _receiver, _itens);
//            _invoice.Id = 1;
//            _itens.Add(new ItemInvoice { Product = ObjectMother.GetProduct(), Quantity = 2, Invoice = _invoice });
//            _key = ObjectMother.GetAccessKey();
//            _tax = ObjectMother.GetTaxWithOutInvoice();
//        }

//        [Test]
//        public void InvoicesIssued_InfraORM_InvoiceIssued_Save_ShouldAddWithSuccess()
//        {
//            //Cenario

//            long expectId = 1;

//            //Ação
//            _invoice = _repository.Save(_invoice);

//            //Saída
//            _invoice.Id.Should().Be(expectId);
//        }

//        [Test]
//        public void InvoicesIssued_InfraORM_Get_ShouldGetWithSuccess()
//        {
//            //Cenario
//            long searchId = 1;

//            //Ação
//            var Invoice = _repository.Get(searchId);

//            //Saída
//            Invoice.Should().NotBeNull();
//        }

//        [Test]
//        public void InvoicesIssued_InfraORM_GetAll_ShouldGetAllWithSuccess()
//        {
//            //Cenario
//            int size = 1;

//            //Ação
//            var invoices = _repository.GetAll();

//            //Saída
//            invoices.Should().NotBeNull();
//            invoices.Count().Should().Be(size);
//        }

//        [Test]
//        public void InvoicesIssued_InfraORM_InvoiceIssued_Delete_ShouldDeleteWithSuccess()
//        {
//            //Cenario
//            long searchId = 1;
//            //Ação
//            _repository.Delete(searchId);

//            //Saída
//            var result = _repository.Get(searchId);
//            result.Should().BeNull();
//        }


//        [Test]
//        public void InvoicesIssued_InfraORM_Update_ShouldWhithSucess()
//        {
//            //Cenário
//            long searchId = 1;
//            string newName = "Novo";
//            InvoiceIssued invoice = _repository.Get(searchId);
//            invoice.EntryDate = DateTime.Now;

//            //Executa
//            _repository.Update(invoice);

//            //Saída
//            InvoiceIssued result = _repository.Get(searchId);
//            result.Should().Be(invoice);
//        }

//    }
//}
