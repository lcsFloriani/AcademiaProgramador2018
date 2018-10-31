using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Receivers;
using Projeto_NFe.Application.Features.Receivers.Commands;
using Projeto_NFe.Application.Features.Receivers.Queries;
using Projeto_NFe.Application.Features.Receivers.ViewModels;
using Projeto_NFe.Application.Mapping;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Controller.Tests.Common;
using Projeto_NFe.Domain.Features.Receivers;
using Projeto_NFe.WebApi.Controllers.Receivers;

namespace Projeto_NFe.Controller.Tests.Features.Receivers
{
	[TestFixture]
	public class ReceiversControllerTest : ApiControllerBaseTests
	{
		private ReceiversController _controller;
		private Mock<IReceiverService> _service;
		private Mock<ValidationResult> _validationResult;
		private Mock<Receiver> _receiver;

		private Mock<ReceiverRegisterCommand> _registerCommand;
		private Mock<ReceiverUpdateCommand> _updateCommand;
		private Mock<ReceiverDeleteCommand> _deleteCommand;
		private Mock<ReceiverViewModel> _viewModel;
		private ReceiverQuery _query;

		private bool _isValid;
		private int _limit = 1;

		[SetUp]
		public void SetUp()
		{
			HttpRequestMessage request = new HttpRequestMessage();
			request.SetConfiguration(new HttpConfiguration());
			_service = new Mock<IReceiverService>();
			_controller = new ReceiversController(_service.Object) {
				Request = request
			};

			_validationResult = new Mock<ValidationResult>();
			_isValid = true;
			_validationResult.Setup(v => v.IsValid).Returns(_isValid);

			_receiver = new Mock<Receiver>();

			_registerCommand = new Mock<ReceiverRegisterCommand>();
			_updateCommand = new Mock<ReceiverUpdateCommand>();
			_deleteCommand = new Mock<ReceiverDeleteCommand>();
			_viewModel = new Mock<ReceiverViewModel>();
			_query = new ReceiverQuery(_limit);

			AutoMapperInitializer.Reset();
			AutoMapperInitializer.Initialize();
		}

		#region POST
		[Test]
		public void Receivers_Controller_Add_ShouldWithSuccess()
		{
			Receiver receiver = ObjectMother.GetReceiverPhysical(ObjectMother.GetAddress());
	
			receiver.Id = 1;

			_registerCommand.Setup(cmd => cmd.Validate()).Returns(_validationResult.Object);
			_service.Setup(c => c.Add(_registerCommand.Object)).Returns(receiver.Id);

			IHttpActionResult callback = _controller.Add(_registerCommand.Object);

			_service.Verify(s => s.Add(_registerCommand.Object), Times.Once);
		}

		[Test]
		public void Receivers_Controller_Add_ShouldWithValidationFailure()
		{
			Receiver receiver = ObjectMother.GetReceiverPhysical(ObjectMother.GetAddress());
			receiver.Id = 1;

			_isValid = false;
			_validationResult.Setup(v => v.IsValid).Returns(_isValid);
			_registerCommand.Setup(cmd => cmd.Validate()).Returns(_validationResult.Object);
			_service.Setup(c => c.Add(_registerCommand.Object)).Returns(receiver.Id);

			IHttpActionResult callback = _controller.Add(_registerCommand.Object);

			var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
			_service.VerifyNoOtherCalls();
		}
		#endregion

		#region PUT
		[Test]
		public void Receivers_Controller_Update_ShouldWithSuccess()
		{
			Receiver receiver = ObjectMother.GetReceiverPhysical(ObjectMother.GetAddress());
			receiver.Id = 1;

			bool isUpdated = true;
			_updateCommand.Setup(cmd => cmd.Validate()).Returns(_validationResult.Object);
			_service.Setup(c => c.Update(_updateCommand.Object)).Returns(isUpdated);

			IHttpActionResult callback = _controller.Update(_updateCommand.Object);

			var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
			httpResponse.Content.Should().BeTrue();
			_service.Verify(s => s.Update(_updateCommand.Object), Times.Once);
		}

		[Test]
		public void Receivers_Controller_Update_ShouldWithValidationFailure()
		{
			Receiver receiver = ObjectMother.GetReceiverPhysical(ObjectMother.GetAddress());
			receiver.Id = 1;

			bool isUpdated = true;
			_isValid = false;
			_validationResult.Setup(v => v.IsValid).Returns(_isValid);
			_updateCommand.Setup(cmd => cmd.Validate()).Returns(_validationResult.Object);
			_service.Setup(c => c.Update(_updateCommand.Object)).Returns(isUpdated);

			IHttpActionResult callback = _controller.Update(_updateCommand.Object);

			var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
			_service.VerifyNoOtherCalls();
		}
		#endregion

		#region GET
		[Test]
		public void Receivers_Controller_GetById_ShouldWithSuccess()
		{
			int id = 1;
			_service.Setup(cmd => cmd.Get(id)).Returns(_receiver.Object);

			IHttpActionResult callback = _controller.GetById(id);

			var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ReceiverViewModel>>().Subject;
			httpResponse.Content.Should().NotBeNull();
			_service.Verify(s => s.Get(id), Times.Once);
		}

		[Test]
		public void Receivers_Controller_Get_ShouldWithSuccess()
		{
			Receiver receiver = ObjectMother.GetReceiverPhysical(ObjectMother.GetAddress());
			receiver.Id = 1;
			var response = new List<Receiver>() { receiver }.AsQueryable();

			_service.Setup(cmd => cmd.GetAll()).Returns(response);
			var odataOptions = GetOdataQueryOptions<Receiver>(_controller);

			IHttpActionResult result = _controller.GetAll(odataOptions);
			_service.Verify(s => s.GetAll());

			var httpResponse = result.Should().BeOfType<OkNegotiatedContentResult<PageResult<ReceiverViewModel>>>().Subject;
			httpResponse.Content.Should().NotBeNullOrEmpty();
			httpResponse.Content.First().Id.Should().Be(receiver.Id);
		}
		#endregion

		#region Delete
		[Test]
		public void Receivers_Controller_Delete_ShouldWithSuccess()
		{
			bool isDeleted = true;
			_deleteCommand.Setup(cmd => cmd.Validate()).Returns(_validationResult.Object);
			_service.Setup(c => c.Delete(_deleteCommand.Object)).Returns(isDeleted);

			IHttpActionResult callback = _controller.Delete(_deleteCommand.Object);

			var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
			_service.Verify(s => s.Delete(_deleteCommand.Object), Times.Once);
			httpResponse.Content.Should().BeTrue();
		}

		[Test]
		public void Receivers_Controller_Delete_ShouldWithValidationFailure()
		{
			bool isDeleted = true;
			_isValid = false;
			_validationResult.Setup(v => v.IsValid).Returns(_isValid);
			_deleteCommand.Setup(cmd => cmd.Validate()).Returns(_validationResult.Object);
			_service.Setup(c => c.Delete(_deleteCommand.Object)).Returns(isDeleted);

			IHttpActionResult callback = _controller.Delete(_deleteCommand.Object);

			var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
			_service.VerifyNoOtherCalls();
		}
		#endregion
	}
}
