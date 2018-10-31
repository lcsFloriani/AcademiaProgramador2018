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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceInProcessSQLRepositoryTest
    {
        private IInvoiceInProcessRepository _repository;
        private Conveyor _conveyor;
        private Emitter _emitter;
        private Receiver _receiver;
        private List<ItemInvoice> _itens;

        [SetUp]
        public void Initialize()
        {
            _repository = new InvoiceInProcessSQLRepository();

            Address address = ObjectMother.GetAddress();
            Cnpj cnpj = ObjectMother.GetCnpj();
            Cpf cpf = ObjectMother.GetCpf();

            _conveyor = ObjectMother.GetPhysicalConveyor(address, cpf);
            _conveyor.Id = 1;
            _emitter = ObjectMother.GetEmitter(address, cnpj);
            _emitter.Id = 1;
            _receiver = ObjectMother.GetReceiverPhysicalWithCpf(address, cpf);
            _receiver.Id = 1;
            _itens = new List<ItemInvoice>();


            _itens.Add(new ItemInvoice { Product = ObjectMother.GetProduct(), Quantity =3 });

        }

        [Test]
        public void Invoices_InfraData_InvoiceInProcess_Save_ShouldAddWithSuccess()
        {
            //Cenario
            //BaseSqlTest.SeedDatabaseWithoutInvoiceInProcess();
            BaseSqlTest.SeedDatabaseWithoutInvoiceInProcess();

            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(_conveyor, _emitter, _receiver, _itens);

            long expectId = 1;
            //Ação
            invoice = _repository.Save(invoice);
            //Saída
            invoice.Id.Should().Be(expectId);
        }

        [Test]
        public void Invoices_InfraData_InvoiceInProcess_Save_ShouldThrowEmitterNullException()
        {
            //Cenario
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcessWithNullEmitter(_conveyor,_receiver, _itens);
            invoice.Id = 1;
            //Ação
            Action action = () => _repository.Save(invoice);
            //Saída
            action.Should().Throw<InvoiceInProcessEmitterNullException>();
        }

        [Test]
        public void Invoices_InfraData_InvoiceInProcess_Get_ShouldGetWithSucess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();
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
        public void Invoices_InfraData_InvoiceInProcess_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long searchId = 0;

            //Ação
            Action action = () => _repository.Get(searchId);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Invoices_InfraData_InvoiceInProcess_Update_ShouldUpdateWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();

            long searchId = 1;
            string newNatureOperation = "Teste 123";
            InvoiceInProcess invoice = _repository.Get(searchId);
            invoice.NatureOperation = newNatureOperation;
            invoice.Items = _itens;
            //Ação
            _repository.Update(invoice);
            //Saída
            InvoiceInProcess result = _repository.Get(searchId);
            result.NatureOperation.Should().Be(newNatureOperation);
        }

        [Test]
        public void Invoices_InfraData_InvoiceInProcess_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(_conveyor, _emitter, _receiver, _itens);

            //Ação
            Action action = () => _repository.Update(invoice);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Invoices_InfraData_InvoiceInProcess_GetAll_ShouldGetAllWtihSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();
            int size = 1;
            //Ação
            var result = _repository.GetAll();
            //Saída
            result.Should().NotBeNull();
            result.Count().Should().Be(size);

        }

        [Test]
        public void Invoices_InfraData_InvoiceInProcess_Delete_ShouldDeleteWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithInvoiceInProcess();

            long searchId = 1;
            InvoiceInProcess invoice = _repository.Get(searchId);
            //Ação
            _repository.Delete(invoice);
            //Saída
            InvoiceInProcess result = _repository.Get(searchId);
            result.Should().BeNull();
        }

        [Test]
        public void Invoices_InfraData_InvoiceInProcess_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            InvoiceInProcess invoice = ObjectMother.GetInvoiceInProcess(_conveyor, _emitter, _receiver, _itens);
            
            //Ação
            Action action = () => _repository.Delete(invoice);
            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
