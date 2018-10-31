using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Infra.Data.Features.ItemInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Tests.Features.ItemInvoices
{
    [TestFixture]
    public class ItemInvoiceSQLRepositoryTest
    {
        private IItemInvoiceRepository _repository;
        private InvoiceInProcess _invoice;
        private Product _product;

        [SetUp]
        public void Initialize()
        {
            _invoice = new InvoiceInProcess(){ Id = 1 };
            _product = ObjectMother.GetProduct();
            _product.Id = 1;

            _repository = new ItemInvoiceSQLRepository();
        }

        [Test]
        public void ItemInvoices_InfraData_Save_ShouldSaveWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithoutItemInvoice();

            ItemInvoice itemInvoice = ObjectMother.GetItemInvoice(_product, _invoice);

            int expectedId = 1;

            //Ação
            ItemInvoice result = _repository.Save(itemInvoice);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(expectedId);
        }

        [Test]
        public void ItemInvoices_InfraData_Save_ShouldThrowNullProductException()
        {
            //Cenário
            ItemInvoice itemInvoice = ObjectMother.GetItemInvoiceInvalidProduct(_invoice);

            //Ação
            Action action = () => _repository.Save(itemInvoice);

            //Saída
            action.Should().Throw<ItemInvoiceNullProductException>();
        }

        [Test]
        public void ItemInvoices_InfraData_Update_ShouldUpdateWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithItemInvoice();

            ItemInvoice itemInvoice = ObjectMother.GetItemInvoice(_product, _invoice);
            itemInvoice.Id = 1;
            int newQuantity = 9;
            itemInvoice.Quantity = newQuantity;
            //Ação
            ItemInvoice result = _repository.Update(itemInvoice);

            //Saída
            result.Should().NotBeNull();
            result.Quantity.Should().Be(newQuantity);
        }

        [Test]
        public void ItemInvoices_InfraData_Update_ShouldThrowQuantityLessThanOneException()
        {
            //Cenário

            ItemInvoice itemInvoice = ObjectMother.GetItemInvoiceInvalidQuantity(_product, _invoice);
            itemInvoice.Id = 1;

            //Ação
            Action action = () => _repository.Update(itemInvoice);

            //Saída
            action.Should().Throw<ItemInvoiceQuantityLessThanOneException>();
        }

        [Test]
        public void ItemInvoices_InfraData_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            ItemInvoice itemInvoice = ObjectMother.GetItemInvoice(_product, _invoice);

            //Ação
            Action action = () => _repository.Update(itemInvoice);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void ItemInvoices_InfraData_Get_ShouldGetWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithItemInvoice();
            long searchId = 1;

            //Ação
            ItemInvoice result = _repository.Get(searchId);

            //Saída
            result.Should().NotBeNull();
            result.Id.Should().Be(searchId);
        }

        [Test]
        public void ItemInvoices_InfraData_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long id = 0;

            //Execução
            Action action = () => _repository.Get(id);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }


        [Test]
        public void ItemInvoices_InfraData_GetByInvoice_ShouldGetByInvoiceWithSuccess()
        {
            //Cenário
            BaseSqlTest.SeedDatabaseWithItemInvoice();

            ItemInvoice itemInvoice = ObjectMother.GetItemInvoice(_product, _invoice);
            itemInvoice.Id = 1;
            
            int idInvoiceExpected = 1;
            int size = 1;

            //Ação
            IEnumerable <ItemInvoice> items = _repository.GetByInvoice(itemInvoice.Invoice);

            //Saída
            items.Should().NotBeNull();
            items.Count().Should().Be(size);
            items.First().Invoice.Id.Should().Be(idInvoiceExpected);
        }

        [Test]
        public void ItemInvoices_InfraData_Delete_ShouldDeleteWithSuccess()
        {
            //Cenario
            BaseSqlTest.SeedDatabaseWithItemInvoice();

            int searchId = 1;
            ItemInvoice itemInvoice = _repository.Get(searchId);

            //Ação
            _repository.Delete(itemInvoice);

            //Saída
            ItemInvoice result = _repository.Get(searchId);
            result.Should().BeNull();
        }

        [Test]
        public void ItemInvoices_InfraData_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            ItemInvoice itemInvoice = ObjectMother.GetItemInvoice(_product, _invoice);

            //Ação
            Action action = () => _repository.Delete(itemInvoice);

            //Saída
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
