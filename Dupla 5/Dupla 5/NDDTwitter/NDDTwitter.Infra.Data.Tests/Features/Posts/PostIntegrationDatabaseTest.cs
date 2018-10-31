using FluentAssertions;
using NDDTwitter.Common.Tests.Base;
using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Infra.Data.Features.Posts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDDTwitter.Integration.Tests.Features.Posts
{
    [TestFixture]
    public class PostIntegrationDatabaseTest
    {
        private IPostRepository _repository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new PostRepository();
        }

        [Test]
        public void Test_IntegrationDatabasePost_Insert_ShouldBeOk()
        {
            Post post = new Post()
            {
                Message = "teste insert",
                PostDate = DateTime.Now
            };

            post = _repository.Save(post);
            post.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_IntegrationDatabasePost_InsertEmptyMessage_ShouldFail()
        {
            Post post = new Post()
            {
                PostDate = DateTime.Now
            };

            Action saveAction = () => _repository.Save(post);
            saveAction.Should().Throw<PostMessageIsNullOrEmptyException>();
        }

        [Test]
        public void Test_IntegrationDatabasePost_InsertOverFlowMessage_ShouldFail()
        {
            Post post = new Post()
            {
                Message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                PostDate = DateTime.Now
            };

            Action saveAction = () => _repository.Save(post);
            saveAction.Should().Throw<PostMessageOverFlowException>();
        }

        [Test]
        public void Test_IntegrationDatabasePost_InsertPostDate_ShouldFail()
        {
            Post post = new Post()
            {
                Message = "teste",
                PostDate = DateTime.Now.AddDays(2)
            };

            Action saveAction = () => _repository.Save(post);
            saveAction.Should().Throw<PostDateBeAfterTodayException>();
        }

        [Test]
        public void Test_IntegrationDatabasePost_Get_ShouldBeOk()
        {
            Post post = _repository.Get(1);
            post.Should().NotBeNull();
            post.Id.Should().Be(1);
        }

        [Test]
        public void Test_IntegrationDatabasePost_GetUndefinedId_ShouldFail()
        {
            Post post = _repository.Get(666);
            post.Should().BeNull();
        }

        [Test]
        public void Test_IntegrationDatabasePost_Update_ShouldBeOk()
        {
            Post post = new Post()
            {
                Id = 1,
                Message = "mensagem atualizada!",
                PostDate = DateTime.Now
            };

            _repository.Update(post);

            Post postAtualizado = _repository.Get(post.Id);
            postAtualizado.Message.Should().Be(post.Message);
        }

        [Test]
        public void Test_IntegrationDatabasePost_Delete_ShouldBeOk()
        {
            Post post = _repository.Get(1);
            _repository.Delete(post);

            post = _repository.Get(1);
            post.Should().Be(null);
        }

        [Test]
        public void Test_IntegrationDatabasePost_GetAll_ShouldBeOk()
        {
            IEnumerable<Post> p = _repository.GetAll();
            p.Count().Should().Be(1);
            p.First().Id.Should().Be(1);
        }
    }
}
