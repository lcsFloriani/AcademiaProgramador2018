using FluentAssertions;
using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Infra.Twitter.Base;
using NDDTwitter.Infra.Twitter.Features.Posts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace NDDTwitter.Integration.Tests.Features.Posts
{
    [TestFixture]
    public class IntegrationTwitterTest
    {

        PostTwitterRepository _twitterRepository;
        TwitterService _twitterService;
        private long _id;

        [SetUp]
        public void Initialize()
        {
            _twitterService = new TwitterService();
            _twitterRepository = new PostTwitterRepository(_twitterService);
        }

        [Test]
        [Order(1)]
        public void Test_IntegrationTwitter_Save_ShouldBeOk()
        {
            Random rdn = new Random();

            Post post = new Post()
            {
                Message = rdn.Next().ToString()
            };

            Post postEnviado = _twitterRepository.Save(post);
            _id = postEnviado.Id;
            postEnviado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(5)]
        public void Test_IntegrationTwitter_SaveEmptyMessage_ShouldFail()
        {
            Post post = new Post()
            {
                Message = ""
            };

            Action action = () => _twitterRepository.Save(post);
            action.Should().Throw<PostMessageIsNullOrEmptyException>();
        }

        [Test]
        [Order(6)]
        public void Test_IntegrationTwitter_SaveOverFlowMessage_ShouldFail()
        {
            Post post = new Post()
            {
                Message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            };

            Action action = () => _twitterRepository.Save(post);
            action.Should().Throw<PostMessageOverFlowException>();
        }

        [Test]
        [Order(2)]
        public void Test_IntegrationTwitter_Get_ShouldBeOk()
        {
            Post post = _twitterRepository.Get(_id);
            post.Id.Should().NotBe(0);
            post.Id.Should().Be(_id);
        }

        [Test]
        [Order(7)]
        public void Test_IntegrationTwitter_GetUndefinedId_ShouldFail()
        {
            Action action = () => _twitterRepository.Get(-1);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(3)]
        public void Test_IntegrationTwitter_GetAll_ShouldBeOk()
        {
            List<Post> posts = _twitterRepository.GetAll().ToList<Post>();
            posts.Count.Should().Be(1);
        }

        [Test]
        [Order(4)]
        public void Test_IntegrationTwitter_Delete_ShouldBeOk()
        {
            Post post = new Post() { Id = _id };

            _twitterRepository.Delete(post);

            Post postDeletado = _twitterRepository.Get(_id);
            postDeletado.Should().BeNull();
        }

        [Test]
        [Order(8)]
        public void Test_IntegrationTwitter_DeleteUndefinedId_ShouldBeFail()
        {
            Post post = new Post() { Id = -1 };

            Action action = () => _twitterRepository.Delete(post);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order (9)]
        public void Test_IntegrationTwitter_Update_ShouldBeFail()
        {
            Post post = new Post() { Id = _id };

            Action action = () => _twitterRepository.Update(post);
            action.Should().Throw<UnsupportedOperationException>();
        }
    }
}
