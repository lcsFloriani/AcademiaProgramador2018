using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Test.Features.Invoices
{
    [TestFixture]
    public class InvoiceInProcessApplicationTest
    {
        private Mock<IInvoiceInProcessRepository> _mockInvoiceInProcessRepository;
        private Mock<IItemInvoiceRepository> _mockItemInvoiceRepository;
        private IInvoiceInProcessService _service;
        InvoiceInProcess invoice;

        [SetUp]
        public void Initialize()
        {
            _mockInvoiceInProcessRepository = new Mock<IInvoiceInProcessRepository>();
            _mockItemInvoiceRepository = new Mock<IItemInvoiceRepository>();

            List<ItemInvoice> itens = new List<ItemInvoice>()
            {
                ObjectMother.GetItemInvoiceWithoutInvoice(ObjectMother.GetProduct())
            };

            invoice = ObjectMother.GetInvoiceInProcess(ObjectMother.GetLegalConveyorWithCnpj(ObjectMother.GetAddress(), ObjectMother.GetCnpj()),
                ObjectMother.GetEmitter(ObjectMother.GetAddress(), ObjectMother.GetCnpj()),
                ObjectMother.GetReceiverPhysicalWithCpf(ObjectMother.GetAddress(), ObjectMother.GetCpf()), itens);

            _service = new InvoiceInProcessService(_mockInvoiceInProcessRepository.Object, _mockItemInvoiceRepository.Object);
        }

        [Test]
        public void Invoices_Servive_InvoiceInProcess_Add_ShouldAddWithSuccess()
        {
            //Cenario
            InvoiceInProcess response = invoice;
            response.Id = 1;
            _mockInvoiceInProcessRepository.Setup(x => x.Save(It.IsAny<InvoiceInProcess>())).Returns(response);
            _mockItemInvoiceRepository.Setup(x => x.Save(It.IsAny<ItemInvoice>())).Returns(new ItemInvoice());

            long ExpectedId = 1; 

            //Ação
            var result =_service.Add(invoice);

            //Saída
            result.Id.Should().Be(ExpectedId);
            _mockInvoiceInProcessRepository.Verify(x => x.Save(It.IsAny<InvoiceInProcess>()));
            _mockItemInvoiceRepository.Verify(x => x.Save(It.IsAny<ItemInvoice>()));
        }

        [Test]
        public void Invoices_Servive_InvoiceInProcess_Add_ShouldThrowInvoiceInProcessValueFreightLessThanZeroException()
        {
            //Cenario
            InvoiceInProcess response = invoice;
            response.ValueFreight = -1;

            //Ação
            Action Add = () =>  _service.Add(invoice);

            //Saída
            Add.Should().Throw<InvoiceInProcessValueFreightLessThanZeroException>();
            _mockInvoiceInProcessRepository.VerifyNoOtherCalls();
            _mockItemInvoiceRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Invoices_Servive_InvoiceInProcess_Update_ShouldUpdateWithSuccess()
        {
            //Cenario
            double ExpectedValue = 3;
            invoice.ValueFreight = ExpectedValue;
            invoice.Id = 1;
            InvoiceInProcess response = invoice;
            ItemInvoice item = ObjectMother.GetItemInvoiceWithoutInvoice(ObjectMother.GetProduct());
            item.Id = 1;
            invoice.Items.Add(item);

            _mockInvoiceInProcessRepository.Setup(x => x.Update(It.IsAny<InvoiceInProcess>())).Returns(response);
            _mockItemInvoiceRepository.Setup(x => x.Update(It.IsAny<ItemInvoice>())).Returns(new ItemInvoice());


            //Ação
            var result = _service.Update(invoice);

            //Saída
            result.ValueFreight.Should().Be(ExpectedValue);
            _mockInvoiceInProcessRepository.Verify(x => x.Update(It.IsAny<InvoiceInProcess>()));
            _mockItemInvoiceRepository.Verify(x => x.Update(It.IsAny<ItemInvoice>()));
        }

        [Test]
        public void Invoices_Servive_InvoiceInProcess_Update_ShouldThrowInvoiceInProcessValueFreightLessThanZeroException()
        {
            //Cenario
            InvoiceInProcess response = invoice;
            response.ValueFreight = -1;
            response.Id = 1;

            //Ação
            Action Update = () => _service.Update(invoice);

            //Saída
            Update.Should().Throw<InvoiceInProcessValueFreightLessThanZeroException>();
            _mockInvoiceInProcessRepository.VerifyNoOtherCalls();
            _mockItemInvoiceRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Invoices_Servive_InvoiceInProcess_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            InvoiceInProcess response = invoice;
            response.ValueFreight = -1;

            //Ação
            Action Update = () => _service.Update(invoice);

            //Saída
            Update.Should().Throw<IdentifierUndefinedException>();
            _mockInvoiceInProcessRepository.VerifyNoOtherCalls();
            _mockItemInvoiceRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Invoices_Servive_InvoiceInProcess_Get_ShouldGetWithSuccess()
        {
            //Cenario
            long GetId = 1;
            invoice.Id = 1;
            _mockInvoiceInProcessRepository.Setup(x => x.Get(GetId)).Returns(invoice);
            _mockItemInvoiceRepository.Setup(x => x.GetByInvoice(invoice)).Returns(new List<ItemInvoice>());

            //Ação
            var result = _service.Get(GetId);

            //Saída
            result.Id.Should().Be(GetId);
            _mockInvoiceInProcessRepository.Verify(x => x.Get(GetId));
            _mockItemInvoiceRepository.Verify(x => x.GetByInvoice(invoice));
        }

        [Test]
        public void Invoices_Servive_InvoiceInProcess_Get_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            long GetId = 0;           

            //Ação
            Action Get = () => _service.Get(GetId);

            //Saída
            Get.Should().Throw<IdentifierUndefinedException>();
            _mockInvoiceInProcessRepository.VerifyNoOtherCalls();
            _mockItemInvoiceRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Invoices_Servive_InvoiceInProcess_GetAll_ShouldGetAllWithSuccess()
        {
            //Cenario
            int GreaterThan = 0;
            List<InvoiceInProcess> list = new List<InvoiceInProcess>();
            list.Add(invoice);

            _mockInvoiceInProcessRepository.Setup(x => x.GetAll()).Returns(list);
            _mockItemInvoiceRepository.Setup(x => x.GetByInvoice(It.IsAny<InvoiceInProcess>())).Returns(new List<ItemInvoice>());

            //Ação
            var result = _service.GetAll();

            //Saída
            result.Count().Should().BeGreaterThan(GreaterThan);
            _mockInvoiceInProcessRepository.Verify(x => x.GetAll());
            _mockItemInvoiceRepository.Verify(x => x.GetByInvoice(It.IsAny<InvoiceInProcess>()));
        }
        
        [Test]
        public void Invoices_Servive_InvoiceInProcess_Delete_ShouldDeleteWithSuccess()
        {
            //Cenario
            invoice.Id = 1;
            
            //Ação
            _service.Delete(invoice);
            //Saída
            _mockInvoiceInProcessRepository.Verify(x => x.Delete(invoice));
        }

        [Test]
        public void Invoices_Servive_InvoiceInProcess_Delete_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            invoice.Id = 0;

            //Ação
            Action Delete = () =>_service.Delete(invoice);
            //Saída
            Delete.Should().Throw<IdentifierUndefinedException>();
            _mockInvoiceInProcessRepository.VerifyNoOtherCalls();
        }
    }
}
