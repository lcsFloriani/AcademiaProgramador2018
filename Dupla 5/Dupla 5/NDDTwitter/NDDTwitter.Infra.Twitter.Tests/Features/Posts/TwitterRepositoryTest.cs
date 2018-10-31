using FluentAssertions;
using Moq;
using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Infra.Twitter.Base;
using NDDTwitter.Infra.Twitter.Features.Posts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace NDDTwitter.Infra.Twitter.Tests.Features.Posts
{
    [TestFixture]
    public class TwitterRepositoryTest
    {
        Mock<ITwitterService> _mockService;
        IPostRepository _repository;
        Mock<ITweet> _tweet;

        [SetUp]
        public void Initialize()
        {
            _mockService = new Mock<ITwitterService>();
            _repository = new PostTwitterRepository(_mockService.Object);
            _tweet = new Mock<ITweet>();
        }

        [Test]
        [Order(1)]
        public void Test_PostTwitterRepository_InsertTweet_ShouldBeOk()
        {
            Post post = new Post()
            {
                Message = "teste add",
                PostDate = DateTime.Now
            };

            _mockService
                .Setup(pr => pr.SendTweet(post.Message))
                .Returns(_tweet.Object);

            Post postado = _repository.Save(post);
            postado.Should().NotBeNull();
        }

        [Test]
        [Order(5)]
        public void Test_PostTwitterRepository_InsertTweetEmptyMessage_ShouldFail()
        {
            Post post = new Post()
            {
                Message = ""
            };

            Action action = () => { _repository.Save(post); };
            action.Should().Throw<PostMessageIsNullOrEmptyException>();
        }

        [Test]
        [Order(6)]
        public void Test_PostTwitterRepository_InsertTweetOverFlowMessage_ShouldFail()
        {
            Post post = new Post()
            {
                Message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
            };

            Action action = () => { _repository.Save(post); };
            action.Should().Throw<PostMessageOverFlowException>();
        }

        [Test]
        [Order(2)]
        public void Test_PostTwitterRepository_GetTweet_ShouldBeOk()
        {
            var fake = new FakeITweet()
            {
                Id = 1,
                FullText = "texto"
            };            

            _mockService
                .Setup(ms => ms.GetTweet(1))
                .Returns(fake);

            Post postado = _repository.Get(1);
            postado.Should().NotBeNull();
            postado.Id.Should().Be(1);
            postado.Message.Should().Be("texto");
        }

        [Test]
        [Order(7)]
        public void Test_PostTwitterRepository_GetTweetUndefinedId_ShouldFail()
        {
            Action action = () => { _repository.Get(-1); };
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(4)]
        public void Test_PostTwitterRepository_GetAllTweet_ShouldBeOk()
        {
            _mockService
                .Setup(ms => ms.ListTweetsOnHomeTimeLine())
                .Returns(new List<ITweet>
                {
                    new FakeITweet { Id = 1, FullText = "teste GetAll 1" },
                    new FakeITweet { Id = 2, FullText = "teste GetAll 2" }
                });

            IEnumerable<Post> list = _repository.GetAll();
            list.Count().Should().BeGreaterThan(0);
        }

        [Test]
        [Order(3)]
        public void Test_PostTwitterRepository_DeleteTweet_ShouldBeOk()
        {
            var post = new Post()
            {
                Id = 1
            };

            _mockService
                .Setup(ms => ms.DeleteTweet(1))
                .Returns(true);
            
            _repository.Delete(post);
            Post deletado = _repository.Get(1);
            deletado.Should().BeNull();
        }

        [Test]
        [Order(8)]
        public void Test_IntegrationTwitter_Update_ShouldBeFail()
        {
            Post post = new Post() { Id = 1 };

            Action action = () => _repository.Update(post);
            action.Should().Throw<UnsupportedOperationException>();
        }
    }
}
