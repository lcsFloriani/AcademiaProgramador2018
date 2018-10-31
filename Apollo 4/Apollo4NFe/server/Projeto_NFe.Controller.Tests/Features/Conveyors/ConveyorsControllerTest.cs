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
using Projeto_NFe.Application.Features.Conveyors;
using Projeto_NFe.Application.Features.Conveyors.Commands;
using Projeto_NFe.Application.Features.Conveyors.Queries;
using Projeto_NFe.Application.Features.Conveyors.ViewModels;
using Projeto_NFe.Application.Mapping;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Controller.Tests.Common;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.WebApi.Controllers.Conveyors;

namespace Projeto_NFe.Controller.Tests.Features.Conveyors
{
	[TestFixture]
	public class ConveyorsControllerTest : ApiControllerBaseTests
	{
		private ConveyorsController _controller;
		private Mock<IConveyorService> _service;
		private Mock<ValidationResult> _validationResult;
		private Mock<Conveyor> _conveyor;

		private Mock<ConveyorRegisterCommand> _registerCommand;
		private Mock<ConveyorUpdateCommand> _updateCommand;
		private Mock<ConveyorDeleteCommand> _deleteCommand;
		private Mock<ConveyorViewModel> _viewModel;
		private ConveyorQuery _query;

		private bool _isValid;
		private int _limit = 1;

		[SetUp]
		public void SetUp()
		{
			HttpRequestMessage request = new HttpRequestMessage();
			request.SetConfiguration(new HttpConfiguration());
			_service = new Mock<IConveyorService>();
			_controller = new ConveyorsController(_service.Object) {
				Request = request
			};

			_validationResult = new Mock<ValidationResult>();
			_isValid = true;
			_validationResult.Setup(v => v.IsValid).Returns(_isValid);

			_conveyor = new Mock<Conveyor>();

			_registerCommand = new Mock<ConveyorRegisterCommand>();
			_updateCommand = new Mock<ConveyorUpdateCommand>();
			_deleteCommand = new Mock<ConveyorDeleteCommand>();
			_viewModel = new Mock<ConveyorViewModel>();
			_query = new ConveyorQuery(_limit);

			AutoMapperInitializer.Reset();
			AutoMapperInitializer.Initialize();
		}

		#region POST
		[Test]
		public void Conveyors_Controller_Add_ShouldWithSuccess()
		{
			Conveyor conveyor = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress());
			conveyor.Id = 1;

			_registerCommand.Setup(cmd => cmd.Validate()).Returns(_validationResult.Object);
			_service.Setup(c => c.Add(_registerCommand.Object)).Returns(conveyor.Id);

			IHttpActionResult callback = _controller.Add(_registerCommand.Object);

			_service.Verify(s => s.Add(_registerCommand.Object), Times.Once);
		}

		[Test]
		public void Conveyors_Controller_Add_ShouldWithValidationFailure()
		{
			Conveyor conveyor = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress());
			conveyor.Id = 1;

			_isValid = false;
			_validationResult.Setup(v => v.IsValid).Returns(_isValid);
			_registerCommand.Setup(cmd => cmd.Validate()).Returns(_validationResult.Object);
			_service.Setup(c => c.Add(_registerCommand.Object)).Returns(conveyor.Id);

			IHttpActionResult callback = _controller.Add(_registerCommand.Object);

			var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
			_service.VerifyNoOtherCalls();
		}
		#endregion

		#region PUT
		[Test]
		public void Conveyors_Controller_Update_ShouldWithSuccess()
		{
			Conveyor conveyor = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress());
			conveyor.Id = 1;

			bool isUpdated = true;
			_updateCommand.Setup(cmd => cmd.Validate()).Returns(_validationResult.Object);
			_service.Setup(c => c.Update(_updateCommand.Object)).Returns(isUpdated);

			IHttpActionResult callback = _controller.Update(_updateCommand.Object);

			var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
			httpResponse.Content.Should().BeTrue();
			_service.Verify(s => s.Update(_updateCommand.Object), Times.Once);
		}

		[Test]
		public void Conveyors_Controller_Update_ShouldWithValidationFailure()
		{
			Conveyor conveyor = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress());
			conveyor.Id = 1;

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
		public void Conveyors_Controller_GetById_ShouldWithSuccess()
		{
			int id = 1;
			_service.Setup(cmd => cmd.Get(id)).Returns(_conveyor.Object);

			IHttpActionResult callback = _controller.GetById(id);

			var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ConveyorViewModel>>().Subject;
			httpResponse.Content.Should().NotBeNull();
			_service.Verify(s => s.Get(id), Times.Once);
		}

		[Test]
		public void Conveyors_Controller_Get_ShouldWithSuccess()
		{
			Conveyor conveyor = ObjectMother.GetPhysicalConveyor(ObjectMother.GetAddress());
			conveyor.Id = 1;
			var response = new List<Conveyor>() { conveyor }.AsQueryable();

			_service.Setup(cmd => cmd.GetAll()).Returns(response);
			var odataOptions = GetOdataQueryOptions<Conveyor>(_controller);

			IHttpActionResult result = _controller.Get(odataOptions);
			_service.Verify(s => s.GetAll());

			var httpResponse = result.Should().BeOfType<OkNegotiatedContentResult<PageResult<ConveyorViewModel>>>().Subject;
			httpResponse.Content.Should().NotBeNullOrEmpty();
			httpResponse.Content.First().Id.Should().Be(conveyor.Id);
		}
		#endregion

		#region Delete
		[Test]
		public void Conveyors_Controller_Delete_ShouldWithSuccess()
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
		public void Conveyors_Controller_Delete_ShouldWithValidationFailure()
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
