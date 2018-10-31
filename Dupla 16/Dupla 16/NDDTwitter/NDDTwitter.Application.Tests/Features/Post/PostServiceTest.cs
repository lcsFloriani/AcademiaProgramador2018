using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NDDTwitter.Application.Features;
using NDDTwitter.Application.Interfaces;
using NDDTwitter.Domain.Features;
using NDDTwitter.Domain.Features.Posts;
using NUnit.Framework;
using FluentAssertions;
using NDDTwitter.Domain.Exceptions;

namespace NDDTwitter.Application.Tests.Features
{
    [TestFixture]
    class PostServiceTest
    {
        private PostService Alvo;

        private Mock<IPostRepository> _mock;

        Post _post;

        [SetUp]
        public void PostService_Set()
        {
            _mock = new Mock<IPostRepository>();
            Alvo = new PostService(_mock.Object);
            _post = new Post()
            {
                Id = 1,
                Message = "Oi, eu sou o Goku",
                PostDate = DateTime.Now
            };
        }

        [Test]
        public void PostService_AddTest_ShouldBeOK()
        {

            _mock.Setup(x => x.Save(_post)).Returns(new Post() { Id = 1 });

            var obtido = Alvo.Add(_post);

            _mock.Verify(x => x.Save(_post));
            obtido.Id.Should().BeGreaterThan(0);
        }
        [Test]
        public void PostService_AddTest_ShouldShow_MessageNulaOuVaziaException()
        {
            _post.Message = "";

            Action action = () => { Alvo.Add(_post); };
            action.Should().Throw<MessageNulaOuVaziaException>();
            _mock.VerifyNoOtherCalls();
        }
        [Test]
        public void PostService_AddTest_ShouldShow_MessageMoreThan140CharacterException()
        {
            _post.Message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            Action action = () => { Alvo.Add(_post); };
            action.Should().Throw<MessageMoreThan140CharacterException>();
            _mock.VerifyNoOtherCalls();
        }
        [Test]
        public void PostService_AddTest_ShouldShow_DateTimeException()
        {
            _post.PostDate = DateTime.Now.AddDays(100);

            Action action = () => { Alvo.Add(_post); };
            action.Should().Throw<DateTimeException>();
            _mock.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_DeleteTest_ShouldBeOK()
        {
            _mock.Setup(x => x.Delete(_post));

            Alvo.Delete(_post);

            _mock.Verify(x => x.Delete(_post));
        }

        [Test]
        public void PostService_DeleteTest_ShouldBeFail()
        {
            _post.Id = 0;
            _mock.Setup(x => x.Delete(_post));

            Action action = () => { Alvo.Delete(_post); };
            action.Should().Throw<IdentifierUndefinedException>();
            _mock.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_GetAllTest_ShouldBeOK()
        {

            _mock.Setup(x => x.GetAll()).Returns(new List<Post>() {
               _post
            });

            var obtido = Alvo.GetAll();
            _mock.Verify(x => x.GetAll());
            obtido.First().Should().Be(_post);
        }

        [Test]
        public void PostService_GetAllTest_ShouldBeFail()
        {
            List<Post> list = new List<Post>();
            list.Add(new Post { Id = 0});
            _mock.Setup(x => x.GetAll()).Returns(list);


            Action action = () => { Alvo.GetAll(); };
            action.Should().Throw<IdentifierUndefinedException>();
            
        }

        [Test]
        public void PostService_GetById_ShouldBeOK()
        {
            _mock.Setup(x => x.GetById(_post.Id)).Returns(_post);

            var obtido = Alvo.GetById(_post.Id);

            _mock.Verify(x => x.GetById(_post.Id));
            _post.Should().Be(obtido);
        }

        [Test]
        public void PostService_GetByIdPastId0_ShouldBeFail()
        {
            _post.Id = 0;
            _mock.Setup(x => x.GetById(_post.Id)).Returns(_post);


            Action action = () => { Alvo.GetById(_post.Id); };
            action.Should().Throw<IdentifierUndefinedException>();
            _mock.VerifyNoOtherCalls();

        }
        [Test]
        public void PostService_GetByIdTakeId0_ShouldBeFail()
        {
            _mock.Setup(x => x.GetById(_post.Id)).Returns(new Post {Id = 0});


            Action action = () => { Alvo.GetById(_post.Id); };
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void PostService_UpdateTest_ShouldBeOK()
        {
            _mock.Setup(x => x.Update(_post)).Returns(new Post() { Id = 1 });

            var obtido = Alvo.Update(_post);

            _mock.Verify(x => x.Update(_post));
            obtido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void PostService_UpdateTest_ShouldBeFail()
        {
            _post.Id = 0;
            _mock.Setup(x => x.Update(_post)).Returns(new Post() { Id = 1 });

            Action action = () => { Alvo.Update(_post); };
            action.Should().Throw<IdentifierUndefinedException>();
            _mock.VerifyNoOtherCalls();
        }

    }
}
