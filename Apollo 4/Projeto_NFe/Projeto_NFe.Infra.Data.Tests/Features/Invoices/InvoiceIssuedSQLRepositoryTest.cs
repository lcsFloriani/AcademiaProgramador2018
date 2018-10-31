using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.Domain.Features.Taxes;
using Projeto_NFe.Infra.AccessKeys;
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
    public class InvoiceIssuedSQLRepositoryTest
    {
        private IInvoiceIssuedRepository _repository;
        private Conveyor _conveyor;
        private Emitter _emitter;
        private Receiver _receiver;
        private List<ItemInvoice> _itens;
        private AccessKey _key;
        private Tax _tax;

        [SetUp]
        public void Initialize()
        {
            _repository = new InvoiceIssuedSQLRepository();

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
            _itens.Add(new ItemInvoice { Product = ObjectMother.GetProduct(), Quantity = 2, Invoice = new InvoiceInProcess { Id = 2} });
            _key = ObjectMother.GetAccessKey();
            _tax = ObjectMother.GetTaxWithOutInvoice();
        }

        [Test, Order(1)]
        public void Invoices_InfraData_InvoiceIssued_Save_ShouldAddWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithoutInvoiceIssued();

            InvoiceIssued invoice = ObjectMother.GetInvoiceIssued(_conveyor, _emitter, _receiver, _itens, _tax,_key);
            invoice.Tax.invoice = invoice;

            long expectId = 1;

            //Ação
            invoice = _repository.Save(invoice);

            //Saída
            invoice.Id.Should().Be(expectId);
        }

        [Test, Order(2)]
        public void Invoices_InfraData_InvoiceIssued_Get_ShouldGetWithSuccess()
        {
            //Cenario
            long searchId = 1;

            //Ação
            string xml = _repository.Get(searchId);

            //Saída
            xml.Should().NotBeNull();
        }

        [Test, Order(3)]
        public void Invoices_InfraData_InvoiceIssued_CheckAccessKeyIsRepeat_AccessKeyIsNotRepeat_ShouldValidateAccessKeyWithSuccess()
        {
            //Cenario
            long id = 1;
            InvoiceIssued invoice = new InvoiceIssued { Id = id, Key = _key};

            //Ação
            var result = _repository.CheckAccessKeyIsRepeat(invoice);

            //Saída
            result.Should().BeFalse();
        }

        [Test, Order(4)]
        public void Invoices_InfraData_InvoiceIssued_CheckAccessKeyIsRepeat_AccessKeyIsRepeat_ShouldValidateAccessKeyWithSuccess()
        {
            //Cenario
            long id = 3;
            InvoiceIssued invoice = new InvoiceIssued { Id = id, Key = _key };

            //Ação
            var result = _repository.CheckAccessKeyIsRepeat(invoice);

            //Saída
            result.Should().BeTrue();
        }

        [Test, Order(5)]
        public void Invoices_InfraData_InvoiceIssued_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenario
            int size = 1;

            //Ação
            var invoices = _repository.GetAll();

            //Saída
            invoices.Should().NotBeNull();
            invoices.Count().Should().Be(size);
        }

        [Test, Order(6)]
        public void Invoices_InfraData_InvoiceIssued_GetByAccessKey_ShouldGetByAccessKeyWithSuccess()
        {
            //Cenario
            string key = "12344567891010987654321054128976126798341634";

            //Ação
            var xml = _repository.GetByAccessKey(key);

            //Saída
            xml.Should().NotBeNull(xml);
        }


        [Test, Order(7)]
        public void Invoices_InfraData_InvoiceIssued_Delete_ShouldDeleteWithSuccess()
        {
            //Cenario
            long id = 1;
            InvoiceIssued invoice = new InvoiceIssued { Id = id };

            //Ação
             _repository.Delete(invoice);

            //Saída
            var result = _repository.Get(id);
            result.Should().BeNull();
        }

        [Test, Order(8)]
        public void Invoices_InfraData_InvoiceIssued_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long searchId = 0;

            //Ação
            Action action = () => _repository.Get(searchId);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test, Order(9)]
        public void Invoices_InfraData_InvoiceIssued_Update_ShouldThrowUnsupportedOperationException()
        {
            //Cenario
            InvoiceIssued invoice = ObjectMother.GetInvoiceIssuedWithInvalidId();

            //Ação
            Action action = () => _repository.Update(invoice);

            //Saída
            action.Should().Throw<UnsupportedOperationException>();
        }

        [Test, Order(10)]
        public void Invoices_InfraData_InvoiceIssued_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            InvoiceIssued invoice = ObjectMother.GetInvoiceIssuedWithInvalidId();

            //Ação
            Action action = () => _repository.Delete(invoice);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
