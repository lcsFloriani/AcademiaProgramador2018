//using FluentAssertions;
//using FluentValidation.Results;
//using Microsoft.AspNet.OData;
//using Moq;
//using NUnit.Framework;
//using Projeto_NFe.Application.Features.Invoices;
//using Projeto_NFe.Application.Features.Invoices.Commands;
//using Projeto_NFe.Application.Features.Invoices.Queries;
//using Projeto_NFe.Application.Features.Invoices.ViewModels;
//using Projeto_NFe.Application.Mapping;
//using Projeto_NFe.Common.Tests.Base;
//using Projeto_NFe.Controller.Tests.Common;
//using Projeto_NFe.Domain.Features.Conveyors;
//using Projeto_NFe.Domain.Features.Emitters;
//using Projeto_NFe.Domain.Features.Invoices;
//using Projeto_NFe.Domain.Features.ItemInvoices;
//using Projeto_NFe.Domain.Features.Receivers;
//using Projeto_NFe.WebApi.Controllers.Features.Invoices;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Results;

//namespace Projeto_NFe.Controller.Tests.Features.Invoices
//{
//    [TestFixture]
//    public class InvoiceControllerTest : ApiControllerBaseTests
//    {
//        private InvoicesIssuedController _invoiceIssuedController;
//        private Mock<IInvoiceIssuedService> _invoiceIssuedService;
//        private Mock<InvoiceIssued> _invoiceIssued;

//        private Mock<InvoiceProcessCommandRegister> _invoiceIssuedRegisterCmd;
//        private Mock<InvoiceProcessCommandUpdate> _invoiceIssuedUpdateCmd;
//        private Mock<InvoiceInProcessCommandDelete> _invoiceIssuedDeleteCmd;
//        private InvoiceIInProcessQuery _invoiceIssuedQuery;
//        private Mock<ValidationResult> _validator;

//        private Conveyor _conveyor;
//        private Emitter _emitter;
//        private Receiver _receiver;
//        private List<ItemInvoice> _itens;

//        private bool _isValid = true;
//        private int limit = 1;

//        [SetUp]
//        public void SetUp()
//        {
//            HttpRequestMessage request = new HttpRequestMessage();
//            request.SetConfiguration(new HttpConfiguration());
//            _invoiceIssuedService = new Mock<IInvoiceIssuedService>();
//            _invoiceIssuedController = new InvoicesIssuedController(_invoiceIssuedService.Object)
//            {
//                Request = request
//            };
//            _invoiceIssued = new Mock<InvoiceIssued>();

//            _invoiceIssuedRegisterCmd = new Mock<InvoiceProcessCommandRegister>();
//            _invoiceIssuedUpdateCmd = new Mock<InvoiceProcessCommandUpdate>();
//            _invoiceIssuedDeleteCmd = new Mock<InvoiceInProcessCommandDelete>();
//            _invoiceIssuedQuery = new InvoiceIInProcessQuery(limit);

//            _conveyor = ObjectMother.GetLegalConveyor(ObjectMother.GetAddress());
//            _emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress());
//            _receiver = ObjectMother.GetReceiverLegal(ObjectMother.GetAddress());
//            _itens = new List<ItemInvoice>();
//            _itens.Add(ObjectMother.GetItemInvoice(ObjectMother.GetProduct(), ObjectMother.GetInvoiceIssued(_conveyor, _emitter, _receiver, _itens)));

//            _validator = new Mock<ValidationResult>();
//            _isValid = true;
//            _validator.Setup(v => v.IsValid).Returns(_isValid);

//            AutoMapperInitializer.Reset();
//            AutoMapperInitializer.Initialize();
//        }
//        #region POST
//        [Test]
//        public void InvoicesIssued_Controller_Add_ShouldWithSuccess()
//        {
    
//            InvoiceIssued invoiceIssued = ObjectMother.GetInvoiceIssued(_conveyor, _emitter, _receiver, _itens);
//            invoiceIssued.Id = 1;

//            _invoiceIssuedRegisterCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
//            _invoiceIssuedService.Setup(c => c.Add(_invoiceIssuedRegisterCmd.Object)).Returns(invoiceIssued);

//            IHttpActionResult callback = _invoiceIssuedController.Post(_invoiceIssuedRegisterCmd.Object);

//            _invoiceIssuedService.Verify(s => s.Add(_invoiceIssuedRegisterCmd.Object), Times.Once);
//        }

//        [Test]
//        public void InvoiceIssued_Controller_Add_ShouldWithValidationFailure()
//        {
//            InvoiceIssued invoiceIssued = ObjectMother.GetInvoiceIssued(_conveyor, _emitter, _receiver, _itens);
//            invoiceIssued.Id = 1;

//            _isValid = false;
//            _validator.Setup(v => v.IsValid).Returns(_isValid);
//            _invoiceIssuedRegisterCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
//            _invoiceIssuedService.Setup(c => c.Add(_invoiceIssuedRegisterCmd.Object)).Returns(invoiceIssued);

//            IHttpActionResult callback = _invoiceIssuedController.Post(_invoiceIssuedRegisterCmd.Object);

//            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
//            _invoiceIssuedService.VerifyNoOtherCalls();
//        }
//        #endregion

//        #region PUT
//        [Test]
//        public void InvoiceIssued_Controller_Update_ShouldWithSuccess()
//        {
//            InvoiceIssued invoiceIssued = ObjectMother.GetInvoiceIssued(_conveyor, _emitter, _receiver, _itens);
//            invoiceIssued.Id = 1;

//            bool isUpdated = true;
//            _invoiceIssuedUpdateCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
//            _invoiceIssuedService.Setup(c => c.Update(_invoiceIssuedUpdateCmd.Object)).Returns(isUpdated);

//            IHttpActionResult callback = _invoiceIssuedController.Update(_invoiceIssuedUpdateCmd.Object);

//            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
//            httpResponse.Content.Should().BeTrue();
//            _invoiceIssuedService.Verify(s => s.Update(_invoiceIssuedUpdateCmd.Object), Times.Once);
//        }

//        [Test]
//        public void InvoiceIssued_Controller_Update_ShouldWithValidationFailure()
//        {
//            InvoiceIssued invoiceIssued = ObjectMother.GetInvoiceIssued(_conveyor, _emitter, _receiver, _itens);
//            invoiceIssued.Id = 1;

//            bool isUpdated = true;
//            _isValid = false;
//            _validator.Setup(v => v.IsValid).Returns(_isValid);
//            _invoiceIssuedUpdateCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
//            _invoiceIssuedService.Setup(c => c.Update(_invoiceIssuedUpdateCmd.Object)).Returns(isUpdated);

//            IHttpActionResult callback = _invoiceIssuedController.Update(_invoiceIssuedUpdateCmd.Object);

//            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
//            _invoiceIssuedService.VerifyNoOtherCalls();
//        }
//        #endregion

//        #region GET
//        [Test]
//        public void InvoiceIssued_Controller_GetById_ShouldWithSuccess()
//        {
//            int id = 1;
//            _invoiceIssuedService.Setup(cmd => cmd.Get(id)).Returns(_invoiceIssued.Object);

//            IHttpActionResult callback = _invoiceIssuedController.GetById(id);

//            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<InvoiceInProcessViewModel>>().Subject;
//            httpResponse.Content.Should().NotBeNull();
//            _invoiceIssuedService.Verify(s => s.Get(id), Times.Once);
//        }

//        [Test]
//        public void InvoiceIssued_Controller_Get_ShouldWithSuccess()
//        {
//            InvoiceIssued invoiceIssued = ObjectMother.GetInvoiceIssued(_conveyor, _emitter, _receiver, _itens);
//            invoiceIssued.Id = 1;
//            var response = new List<InvoiceIssued>() { invoiceIssued }.AsQueryable();

//            _invoiceIssuedService.Setup(cmd => cmd.GetAll()).Returns(response);
//            var odataOptions = GetOdataQueryOptions<InvoiceIssued>(_invoiceIssuedController);

//            IHttpActionResult result = _invoiceIssuedController.Get(odataOptions);
//            _invoiceIssuedService.Verify(s => s.GetAll());

//            var httpResponse = result.Should().BeOfType<OkNegotiatedContentResult<PageResult<InvoiceInProcessViewModel>>>().Subject;
//            httpResponse.Content.Should().NotBeNullOrEmpty();
//            httpResponse.Content.First().Id.Should().Be(invoiceIssued.Id);
//        }
//        #endregion

//        #region Delete
//        [Test]
//        public void InvoiceIssued_Controller_Delete_ShouldWithSuccess()
//        {
//            bool isDeleted = true;
//            _invoiceIssuedDeleteCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
//            _invoiceIssuedService.Setup(c => c.Delete(_invoiceIssuedDeleteCmd.Object)).Returns(isDeleted);

//            IHttpActionResult callback = _invoiceIssuedController.Delete(_invoiceIssuedDeleteCmd.Object);

//            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
//            _invoiceIssuedService.Verify(s => s.Delete(_invoiceIssuedDeleteCmd.Object), Times.Once);
//            httpResponse.Content.Should().BeTrue();
//        }

//        [Test]
//        public void InvoiceIssued_Controller_Delete_ShouldWithValidationFailure()
//        {
//            bool isDeleted = true;
//            _isValid = false;
//            _validator.Setup(v => v.IsValid).Returns(_isValid);
//            _invoiceIssuedDeleteCmd.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
//            _invoiceIssuedService.Setup(c => c.Delete(_invoiceIssuedDeleteCmd.Object)).Returns(isDeleted);

//            IHttpActionResult callback = _invoiceIssuedController.Delete(_invoiceIssuedDeleteCmd.Object);

//            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
//            _invoiceIssuedService.VerifyNoOtherCalls();
//        }
//        #endregion
//    }
//}
