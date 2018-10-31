using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Emitters;
using Projeto_NFe.Application.Features.Emitters.Commands;
using Projeto_NFe.Application.Features.Emitters.Queries;
using Projeto_NFe.Application.Features.Emitters.ViewModels;
using Projeto_NFe.Application.Mapping;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Controller.Tests.Common;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.WebApi.Controllers.Emitters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controller.Tests.Features.Emitters
{
	[TestFixture]
	public class EmittersControllerTest : ApiControllerBaseTests
	{
		private EmittersController _controller;
		private Mock<IEmitterService> _service;
		private Mock<ValidationResult> _validationResult;
		private Mock<Emitter> _emitter;

		private Mock<EmitterRegisterCommand> _registerCommand;
		private Mock<EmitterUpdateCommand> _updateCommand;
		private Mock<EmitterDeleteCommand> _deleteCommand;
		private Mock<EmitterViewModel> _viewModel;
		private EmitterQuery _query;

		private bool _isValid;
		private int _limit = 1;

		[SetUp]
		public void SetUp()
		{
			HttpRequestMessage request = new HttpRequestMessage();
			request.SetConfiguration(new HttpConfiguration());
			_service = new Mock<IEmitterService>();
			_controller = new EmittersController(_service.Object) {
				Request = request
			};

			_validationResult = new Mock<ValidationResult>();
			_isValid = true;
			_validationResult.Setup(v => v.IsValid).Returns(_isValid);

			_emitter = new Mock<Emitter>();

			_registerCommand = new Mock<EmitterRegisterCommand>();
			_updateCommand = new Mock<EmitterUpdateCommand>();
			_deleteCommand = new Mock<EmitterDeleteCommand>();
			_viewModel = new Mock<EmitterViewModel>();
			_query = new EmitterQuery(_limit);

			AutoMapperInitializer.Reset();
			AutoMapperInitializer.Initialize();
		}

		#region POST
		[Test]
		public void Emitters_Controller_Add_ShouldWithSuccess()
		{
			Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress());
			emitter.Id = 1;

			_registerCommand.Setup(cmd => cmd.Validate()).Returns(_validationResult.Object);
			_service.Setup(c => c.Add(_registerCommand.Object)).Returns(emitter.Id);

			IHttpActionResult callback = _controller.Add(_registerCommand.Object);

			_service.Verify(s => s.Add(_registerCommand.Object), Times.Once);
		}

		[Test]
		public void Emitters_Controller_Add_ShouldWithValidationFailure()
		{
			Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress());
			emitter.Id = 1;

			_isValid = false;
			_validationResult.Setup(v => v.IsValid).Returns(_isValid);
			_registerCommand.Setup(cmd => cmd.Validate()).Returns(_validationResult.Object);
			_service.Setup(c => c.Add(_registerCommand.Object)).Returns(emitter.Id);

			IHttpActionResult callback = _controller.Add(_registerCommand.Object);
			
			var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
			_service.VerifyNoOtherCalls();
		}
		#endregion

		#region PUT
		[Test]
		public void Emitters_Controller_Update_ShouldWithSuccess()
		{
			Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress());
			emitter.Id = 1;
			
			bool isUpdated = true;
			_updateCommand.Setup(cmd => cmd.Validate()).Returns(_validationResult.Object);
			_service.Setup(c => c.Update(_updateCommand.Object)).Returns(isUpdated);

			IHttpActionResult callback = _controller.Update(_updateCommand.Object);

			var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
			httpResponse.Content.Should().BeTrue();
			_service.Verify(s => s.Update(_updateCommand.Object), Times.Once);
		}

		[Test]
		public void Emitters_Controller_Update_ShouldWithValidationFailure()
		{
			Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress());
			emitter.Id = 1;

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
		public void Emitters_Controller_GetById_ShouldWithSuccess()
		{
			int id = 1;
			_service.Setup(cmd => cmd.Get(id)).Returns(_emitter.Object);

			IHttpActionResult callback = _controller.GetById(id);

			var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<EmitterViewModel>>().Subject;
			httpResponse.Content.Should().NotBeNull();
			_service.Verify(s => s.Get(id), Times.Once);
		}
		
		[Test]
		public void Emitters_Controller_Get_ShouldWithSuccess()
		{
			Emitter emitter = ObjectMother.GetEmitter(ObjectMother.GetAddress());
			emitter.Id = 1;
			var response = new List<Emitter>() { emitter }.AsQueryable();
			
			_service.Setup(cmd => cmd.GetAll()).Returns(response);
			var odataOptions = GetOdataQueryOptions<Emitter>(_controller);

			IHttpActionResult result = _controller.Get(odataOptions);
			_service.Verify(s => s.GetAll());

			var httpResponse = result.Should().BeOfType<OkNegotiatedContentResult<PageResult<EmitterViewModel>>>().Subject;
			httpResponse.Content.Should().NotBeNullOrEmpty();
			httpResponse.Content.First().Id.Should().Be(emitter.Id);
		}
		#endregion

		#region Delete
		[Test]
		public void Emitters_Controller_Delete_ShouldWithSuccess()
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
		public void Emitters_Controller_Delete_ShouldWithValidationFailure()
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
