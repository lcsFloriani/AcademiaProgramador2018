using FluentAssertions;
using NUnit.Framework;
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
using Projeto_NFe.Infra.ORM.Tests.Inicialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceInProcessRepositoryTest : EffortBaseTest
    {
        private IInvoiceInProcessRepository _repository;
        private Conveyor _conveyor;
        private Emitter _emitter;
        private Receiver _receiver;
        private List<ItemInvoice> _itens;
        private Product _product;

        [SetUp]
        public void Initialize()
        {
            _repository = new InvoiceInProcessRepository(this.context);

            Address address = ObjectMother.GetAddress();

            _conveyor = ObjectMother.GetPhysicalConveyor(address);
            _conveyor.Id = 1;
            _emitter = ObjectMother.GetEmitter(address);
            _emitter.Id = 1;
            _receiver = ObjectMother.GetReceiverPhysical(address);
            _receiver.Id = 1;
            _itens = new List<ItemInvoice>();
            _product = ObjectMother.GetProduct();
            _product.Id = 2;

            _itens.Add(new ItemInvoice { Product = _product, Quantity = 3 });

        }

        [Test]
        public void Invoices_InfraORM_InvoiceInProcess_Save_ShouldAddWithSuccess()
        {
            //Cenario
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(_conveyor, _emitter, _receiver, null);

            long expectId = 2;
            //Ação
            invoice = _repository.Save(invoice);
            //Saída
            invoice.Id.Should().Be(expectId);
        }

        [Test]
        public void Invoices_InfraORM_InvoiceInProcess_Get_ShouldGetWithSucess()
        {
            //Cenario

            long searchId = 1;
            long conveyorId = 1;
            long emitterId = 1;
            long receiverId = 1;
            //Ação
            InvoiceInProcess result = _repository.Get(searchId);
            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(searchId);
            result.Conveyor.Should().NotBeNull();
            result.Conveyor.Id.Should().Be(conveyorId);
            result.Conveyor.Address.Should().NotBeNull();
            result.Emitter.Should().NotBeNull();
            result.Emitter.Id.Should().Be(emitterId);
            result.Emitter.Address.Should().NotBeNull();
            result.Receiver.Should().NotBeNull();
            result.Receiver.Id.Should().Be(receiverId);
            result.Receiver.Address.Should().NotBeNull();
        }

        [Test]
        public void Invoices_InfraORM_InvoiceInProcess_Update_ShouldUpdateWithSuccess()
        {
            //Cenario
            long searchId = 1;
            string newNatureOperation = "Teste 123";
            InvoiceInProcess invoice = _repository.Get(searchId);
            invoice.NatureOperation = newNatureOperation;
     
            //Ação
            _repository.Update(invoice);
            //Saída
            InvoiceInProcess result = _repository.Get(searchId);
            result.NatureOperation.Should().Be(newNatureOperation);
        }

        [Test]
        public void Invoices_InfraORM_InvoiceInProcess_GetAll_ShouldGetAllWtihSuccess()
        {
            //Cenario
            int size = 1;
            //Ação
            var result = _repository.GetAll();
            //Saída
            result.Should().NotBeNull();
            result.Count().Should().Be(size);

        }

        [Test]
        public void Invoices_InfraORM_InvoiceInProcess_GetAllWithSize_ShouldGetAllWtihSuccess()
        {
            //Cenario
            int size = 1;
            //Ação
            var result = _repository.GetAll(size);
            //Saída
            result.Should().NotBeNull();
            result.Count().Should().Be(size);

        }

        [Test]
        public void Invoices_InfraORM_InvoiceInProcess_Delete_ShouldDeleteWithSuccess()
        {
            //Cenario
            long searchId = 1;
            //Ação
            bool deleted = _repository.Delete(searchId);
            //Saída
            deleted.Should().BeTrue();
            InvoiceInProcess result = _repository.Get(searchId);
            result.Should().BeNull();
        }
    }
}
