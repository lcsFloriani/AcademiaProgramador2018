//using FluentAssertions;
//using NUnit.Framework;
//using Projeto_NFe.Common.Tests.Base;
//using Projeto_NFe.Domain.Exceptions;
//using Projeto_NFe.Domain.Features.Invoices;
//using Projeto_NFe.Domain.Features.ItemInvoices;
//using Projeto_NFe.Domain.Features.Products;
//using Projeto_NFe.Infra.ORM.Features.ItemInvoices;
//using Projeto_NFe.Infra.ORM.Tests.Inicialize;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Projeto_NFe.Infra.ORM.Tests.Features.ItemInvoices
//{
//    [TestFixture]
//    public class ItemInvoiceRepositoryTest : EffortBaseTest
//	{
//        private IItemInvoiceRepository _repository;
//        private InvoiceInProcess _invoice;
//        private Product _product;

//        [SetUp]
//        public void Initialize()
//        {
//            _invoice = new InvoiceInProcess(){ Id = 1 };
//            _product = ObjectMother.GetProduct();
//            _product.Id = 1;

//            _repository = new ItemInvoiceRepository(this.context);
//        }

      
//        //[Test]
//        //public void ItemInvoices_InfraData_Delete_ShouldDeleteWithSuccess()
//        //{
//        //    //Cenario
//        //    BaseSqlTest.SeedDatabaseWithItemInvoice();

//        //    int searchId = 1;
//        //    ItemInvoice itemInvoice = _repository.Get(searchId);

//        //    //Ação
//        //    _repository.Delete(itemInvoice);

//        //    //Saída
//        //    ItemInvoice result = _repository.Get(searchId);
//        //    result.Should().BeNull();
//        //}

//        [Test]
//        public void ItemInvoices_InfraData_Delete_ShouldThrowIdentifierUndefinedException()
//        {
//            //Cenario
//            ItemInvoice itemInvoice = ObjectMother.GetItemInvoice(_product, _invoice);

//            //Ação
//            Action action = () => _repository.Delete(itemInvoice);

//            //Saída
//            action.Should().Throw<IdentifierUndefinedException>();
//        }
//    }
//}
