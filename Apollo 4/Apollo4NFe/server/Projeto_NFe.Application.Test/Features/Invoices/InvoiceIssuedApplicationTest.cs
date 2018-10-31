//using FluentAssertions;
//using Moq;
//using NUnit.Framework;
//using Projeto_NFe.Application.Features.Invoices;
//using Projeto_NFe.Application.Features.Invoices.Commands;
//using Projeto_NFe.Application.Mapping;
//using Projeto_NFe.Common.Tests.Base;
//using Projeto_NFe.Domain.Exceptions;
//using Projeto_NFe.Domain.Features.Conveyors;
//using Projeto_NFe.Domain.Features.Emitters;
//using Projeto_NFe.Domain.Features.Invoices;
//using Projeto_NFe.Domain.Features.ItemInvoices;
//using Projeto_NFe.Domain.Features.Receivers;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Projeto_NFe.Application.Test.Features.Invoices
//{
//    [TestFixture]
//    public class InvoiceIssuedApplicationTest
//    {
//        private Mock<IInvoiceIssuedRepository> _mockInvoiceIssuedRepository;
//        private InvoiceIssued _invoiceIssued;
//        private InvoiceIssuedCommandDelete _mockCommandDelete;
//        private Mock<InvoiceIssuedCommandRegister> _mockCommandRegister;
//        private Mock<InvoiceIssuedCommandUpdate> _mockCommandUpdate;
//        private InvoiceIssuedService _service;
//        private List<ItemInvoice> itens;

//        [SetUp]
//        public void Initialize()
//        {
//            _mockInvoiceIssuedRepository = new Mock<IInvoiceIssuedRepository>();

//            itens = new List<ItemInvoice>()
//            {
//                ObjectMother.GetItemInvoiceWithoutInvoice(ObjectMother.GetProduct())
//            };

//            _mockCommandUpdate = new Mock<InvoiceIssuedCommandUpdate>();
//            _mockCommandRegister = new Mock<InvoiceIssuedCommandRegister>();
//            _mockCommandDelete = new InvoiceIssuedCommandDelete();

//            _invoiceIssued = new InvoiceIssued { Id = 1 };

//            _service = new InvoiceIssuedService(_mockInvoiceIssuedRepository.Object);
//            AutoMapperInitializer.Reset();
//            AutoMapperInitializer.Initialize();

//        }

        
//        [Test]
//        public void InvoiceIssued_Service_Get_ShouldGetWithSuccess()
//        {
//            //Cenário
//            int searchId = 1;

//            _mockInvoiceIssuedRepository.Setup(x => x.Get(searchId)).Returns(_invoiceIssued);

//            //Ação
//            InvoiceIssued result = _service.Get(searchId);

//            //Saída
//            result.Should().NotBeNull();
//            result.Id.Should().Be(searchId);
//            _mockInvoiceIssuedRepository.Verify(x => x.Get(searchId));
//        }

//        [Test]
//        public void InvoiceIssued_Service_GetAll_ShouldGetAllWithSuccess()
//        {
//            //Cenário
//            int size = 1;
//            List<InvoiceIssued> Invoices = new List<InvoiceIssued>();
//            Invoices.Add(_invoiceIssued);

//            _mockInvoiceIssuedRepository.Setup(x => x.GetAll()).Returns(Invoices.AsQueryable);

//            //Ação
//            IQueryable<InvoiceIssued> result = _service.GetAll();

//            //Saída
//            result.Should().NotBeNull();
//            result.Count().Should().Be(size);
//            _mockInvoiceIssuedRepository.Verify(x => x.GetAll());
//        }

//        [Test]
//        public void InvoiceIssued_Service_GetByAccessKey_ShouldGetByAccessKeyWithSuccess()
//        {
//            //Cenário
//            int idExpected = 1;
//            string key = "12344567891010987654321054128976126798341634";
//            _invoiceIssued.Key.NumberAccessKey = key;

//            _mockInvoiceIssuedRepository.Setup(x => x.GetByAccessKey(key)).Returns(_invoiceIssued);

//            //Ação
//            InvoiceIssued result = _service.GetByAccessKey(key);

//            //Saída
//            result.Should().NotBeNull();
//            result.Id.Should().Be(idExpected);
//            _mockInvoiceIssuedRepository.Verify(x => x.GetByAccessKey(key));
//        }

        

//        [Test]
//        public void InvoiceIssued_Service_Add_ShouldAddWithSuccess()
//        {
//            //Cenário
//            long biggerThan = 0;
//            long expectedId = 1;

//            _mockInvoiceIssuedRepository.Setup(m => m.Save(It.IsAny<InvoiceIssued>())).Returns(_invoiceIssued);
            
//            //Ação
//            InvoiceIssued result = _service.Add(_mockCommandRegister.Object);

//            //Saída

//            result.Id.Should().BeGreaterThan(biggerThan);
//            result.Id.Should().Be(expectedId);
//            _mockInvoiceIssuedRepository.Verify(m => m.Save(It.IsAny<InvoiceIssued>()));

//        }

//        [Test]
//        public void InvoiceIssued_Service_Delete_ShouldDeleteWithSuccess()
//        {
//            //Cenário
//            long id = 1;
//            var invoiceIds = new long[] { id };
//            InvoiceIssued invoiceIssued = _invoiceIssued;
//            invoiceIssued.Id = id;

//            _mockInvoiceIssuedRepository.Setup(x => x.Delete(It.IsAny<long>())).Returns(true);

//            _mockCommandDelete.InvoiceIds = invoiceIds;

//            //Ação
//            bool result = _service.Delete(_mockCommandDelete);

//            //Saída
//            result.Should().BeTrue();
//            _mockInvoiceIssuedRepository.Verify(x => x.Delete(It.IsAny<long>()));
//        }
//    }
//}
