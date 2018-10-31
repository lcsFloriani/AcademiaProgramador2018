using FluentAssertions;
using Moq;
using NDDTwitter.Application.Features.Posts;
using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Infra.Data.Features;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Application.Tests.Features
{
    [TestFixture]
    public class PostServiceTest
    {
        private IPostService _service;
        private Mock<IPostRepository> _mockRepository;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostRepository>();
            _service = new PostService(_mockRepository.Object);
        }

        [Test]
        public void Test_PostService_Add_ShouldBeOk()
        {
            Post post = new Post()
            {
                Message = "teste add",
                PostDate = DateTime.Now
            }; 

            _mockRepository
                .Setup(pr => pr.Save(post))
                .Returns(new Post { Id = 1 });

            Post p = _service.Add(post);

            _mockRepository.Verify(pr => pr.Save(post));
            p.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_PostService_Add_ShouldFailBecause_MessageIsEmpty()
        {
            Post post = new Post()
            {
                Message = "",
                //PostDate = DateTime.Now
            };
            _mockRepository
                .Setup(pr => pr.Save(post))
                .Returns(new Post { Id = 1 });
            Assert.That(() => _service.Add(post), Throws.TypeOf<PostMessageIsNullOrEmptyException>());
        }

        [Test]
        public void Test_PostService_Add_ShouldFailBecause_MessageCharsExceded()
        {
            Post post = new Post()
            {
                Message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                //PostDate = DateTime.Now
            };
            _mockRepository
                .Setup(pr => pr.Save(post))
                .Returns(new Post { Id = 1 });
            Assert.That(() => _service.Add(post), Throws.TypeOf<PostMessageOverFlowException>());
        }

        [Test]
        public void Test_PostService_Add_ShouldFailBecause_PostDateIsAfterToday()
        {
            Post post = new Post()
            {
                Message = "a",
                PostDate = DateTime.Now.AddDays(2)
            };
            
            Action action = () => { _service.Add(post); };
            action.Should().Throw<PostDateBeAfterTodayException>();
        }

        [Test]
        public void Test_PostService_Update_ShouldBeOk()
        {
            Post post = new Post()
            {
                Id = 4,
                Message = "teste update",
                PostDate = DateTime.Now
            };
            _mockRepository
                .Setup(pr => pr.Update(post))
                .Returns(new Post { Id = 1 });

            Post p = _service.Update(post);

            _mockRepository.Verify(pr => pr.Update(post));
            p.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_PostService_Update_ShouldBeFail_BecauseIdIsUndefined()
        {
            Post post = new Post()
            {
                Id = 0,
                Message = "teste update",
                PostDate = DateTime.Now
            };
            
            Action action = () => { _service.Update(post); };
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_PostService_Delete_ShouldBeOk()
        {
            Post post = new Post()
            {
                Id = 3,
                Message = "teste delete",
                PostDate = DateTime.Now
            };

            _mockRepository
                .Setup(pr => pr.Delete(post));

            _service.Delete(post);

            _mockRepository.Verify(pr => pr.Delete(post));
        }

        [Test]
        public void Test_PostService_Delete_ShouldBeFail_BecauseIdIsUndefined()
        {
            Post post = new Post()
            {
                Id = 0,
                Message = "teste update",
                PostDate = DateTime.Now
            };

            Action action = () => { _service.Delete(post); };
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_PostService_Get_ShouldBeOk()
        {
            long Id = 5;

            _mockRepository
                .Setup(pr => pr.Get(Id))
                .Returns(new Post { Id = 5 });

            Post p = _service.Get(Id);

            _mockRepository.Verify(pr => pr.Get(Id));
            p.Id.Should().Be(5);
        }

        [Test]
        public void Test_PostService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(pr => pr.GetAll())
                .Returns(new List<Post> { new Post { Id = 1 },  new Post { Id = 2 } });

            IEnumerable<Post> list = _service.GetAll();

            _mockRepository.Verify(pr => pr.GetAll());
            list.Count<Post>().Should().Be(2);
        }
    }
}
