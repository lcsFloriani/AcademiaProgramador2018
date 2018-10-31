using Enedir.MF7.Controller.Tests.Initializer;
using Moq;
using NUnit.Framework;
using FluentValidation.Results;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using FluentAssertions;
using System.Collections.Generic;
using Enedir.MF7.Common.Tests.Features;
using System.Linq;
using Enedir.MF7.API.Controllers.Functionaries;
using Enedir.MF7.Application.Features.Functionaries;
using Enedir.MF7.Domain.Features.Functionaries;
using Enedir.MF7.Application.Features.Functionaries.Commands;
using Enedir.MF7.Application.Features.Functionaries.ViewModels;
using Enedir.MF7.Application.Features.Functionaries.Querys;

namespace Enedir.MF7.Controller.Tests.Features.Functionaries
{
    [TestFixture]
    public class FunctionaryControllerTest : TestControllerBase
    {
        private FunctionariesController _customerController;
        private Mock<IFunctionaryService> _customerServiceMock;
        private Mock<ValidationResult> _validator;

        private Mock<Functionary> _customer;
        private Mock<FunctionaryRegisterCommand> _registerCommand;
        private Mock<FunctionaryUpdateCommand> _updateCommand;
        private Mock<FunctionaryDeleteCommand> _deleteCommand;
        private Mock<FunctionaryViewModel> _customerViewModel;
        private Mock<FunctionaryQuery> _customerQuery;

        private bool _isValid = true;
        private List<Functionary> customers;

        public object ErrorCodes { get; private set; }

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _customerServiceMock = new Mock<IFunctionaryService>();
            _customerController = new FunctionariesController(_customerServiceMock.Object)
            {
                Request = request
            };

            _customer = new Mock<Functionary>();
            _registerCommand = new Mock<FunctionaryRegisterCommand>();
            _updateCommand = new Mock<FunctionaryUpdateCommand>();
            _deleteCommand = new Mock<FunctionaryDeleteCommand>();
            _customerViewModel = new Mock<FunctionaryViewModel>();
            _customerQuery = new Mock<FunctionaryQuery>();

            _validator = new Mock<ValidationResult>();
            _isValid = true;
            _validator.Setup(v => v.IsValid).Returns(_isValid);

            customers = new List<Functionary>()
            {
                new Functionary() { Id = 1 },
                new Functionary() { Id = 2 },
                new Functionary() { Id = 3 }
            };
        }

        #region Adicionar

        [Test]
        public void Functionarys_Controller_PostAdd_ShouldBeOk()
        {
            // Arrange
            long expectedId = 1;

            _registerCommand.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _customerServiceMock.Setup(c => c.Add(_registerCommand.Object)).Returns(expectedId);

            // Act
            IHttpActionResult callback = _customerController.PostAdd(_registerCommand.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<long>>().Subject;
            httpResponse.Content.Should().Be(expectedId);
            _customerServiceMock.Verify(c => c.Add(_registerCommand.Object), Times.Once);
        }

        [Test]
        public void Functionarys_Controller_PostAdd_ShouldBeFail()
        {
            // Arrange
            _isValid = false;
            _validator.Setup(v => v.IsValid).Returns(_isValid);
            _registerCommand.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _customerServiceMock.Setup(c => c.Add(_registerCommand.Object));

            // Act
            IHttpActionResult callback = _customerController.PostAdd(_registerCommand.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            _customerServiceMock.VerifyNoOtherCalls();
        }

        #endregion Adicionar


        #region Atualizar

        [Test]
        public void Functionarys_Controller_PutUpdate_ShouldBeOk()
        {
            // Arrange
            Functionary customer = ObjectMother.GetFunctionarySeed();
            bool recurrence = true;

            _updateCommand.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _customerServiceMock.Setup(c => c.Update(_updateCommand.Object)).Returns(recurrence);

            // Act
            IHttpActionResult callback = _customerController.PutUpdate(_updateCommand.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _customerServiceMock.Verify(c => c.Update(_updateCommand.Object), Times.Once);

        }

        [Test]
        public void Functionarys_Controller_PutUpdate_ShouldBeFail()
        {
            // Arrange
            _isValid = false;
            _validator.Setup(v => v.IsValid).Returns(_isValid);
            _updateCommand.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _customerServiceMock.Setup(c => c.Update(_updateCommand.Object));

            // Act
            IHttpActionResult callback = _customerController.PutUpdate(_updateCommand.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            _customerServiceMock.VerifyNoOtherCalls();

        }

        #endregion


        #region Listagem

        [Test]
        public void Functionarys_Controller_GetAll_ShouldBeOk()
        {
            // Arrange
            string uri = "http://localhost:57701/api/functionaries?quantity=3";

            FunctionaryQuery query = ObjectMother.GetFunctionaryQuery();

            _customerServiceMock.Setup(c => c.GetAll(It.IsAny<FunctionaryQuery>())).Returns(customers.AsQueryable());

            _customerController.Request = GetUri(uri);

            // Act
            var callback = _customerController.GetAll();

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<List<FunctionaryViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();

            _customerServiceMock.Verify(c => c.GetAll(It.IsAny<FunctionaryQuery>()), Times.Once);
        }

        [Test]
        public void Functionarys_Controller_GetById_ShouldByOk()
        {
            // Arrange
            Functionary customer = ObjectMother.GetFunctionarySeed();
            long searchId = 1;

            _customerServiceMock.Setup(c => c.GetById(It.IsAny<long>())).Returns(customer);

            // Act
            var callback = _customerController.GetById(searchId);

            // Assert
            _customerServiceMock.Verify(c => c.GetById(It.IsAny<long>()), Times.Once);

            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<FunctionaryViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
           // httpResponse.Content.Id.Should().Be(customer.Id);

            _customerServiceMock.Verify(c => c.GetById(It.IsAny<long>()), Times.Once);
        }

        #endregion

        #region Excluir

        [Test]
        public void Functionarys_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            Functionary customer = ObjectMother.GetFunctionarySeed();
            bool recurrence = true;

            _deleteCommand.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _customerServiceMock.Setup(c => c.Remove(_deleteCommand.Object)).Returns(recurrence);

            // Act
            IHttpActionResult callback = _customerController.Remove(_deleteCommand.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _customerServiceMock.Verify(c => c.Remove(_deleteCommand.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Functionarys_Controller_Delete_ShouldFail()
        {
            // Arrange
            _isValid = false;
            _validator.Setup(v => v.IsValid).Returns(_isValid);
            _deleteCommand.Setup(cmd => cmd.Validate()).Returns(_validator.Object);
            _customerServiceMock.Setup(c => c.Remove(_deleteCommand.Object));

            // Act
            IHttpActionResult callback = _customerController.Remove(_deleteCommand.Object);

            // Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            _customerServiceMock.VerifyNoOtherCalls();
        }

        #endregion
    }
}
