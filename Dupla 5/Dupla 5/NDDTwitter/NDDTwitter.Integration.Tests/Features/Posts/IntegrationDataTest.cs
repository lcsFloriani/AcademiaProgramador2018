using FluentAssertions;
using NDDTwitter.Application.Features.Posts;
using NDDTwitter.Common.Tests.Base;
using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Infra.Data.Features.Posts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Integration.Tests.Features.Posts
{
    [TestFixture]
    public class IntegrationDataTest
    {
        PostRepository _postRepository;
        PostService _postService;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _postRepository = new PostRepository();
            _postService = new PostService(_postRepository);
        }

        [Test]
        public void Test_PostIntegrationData_InsertPost_ShouldBeOk()
        {
            Post post = new Post()
            {
                Message = "asdasd",
                PostDate = DateTime.Now
            };

            _postService.Add(post);

            IList<Post> allPosts = _postService.GetAll().ToList<Post>();
            allPosts[1].Should().NotBeNull();
            allPosts[1].Message.Should().Be(post.Message);
        }

        [Test]
        public void Test_PostIntegrationData_InsertPostEmptyMessage_ShouldFail()
        {
            Post post = new Post()
            {
                PostDate = DateTime.Now
            };

            Action action = () => _postService.Add(post);
            action.Should().Throw<PostMessageIsNullOrEmptyException>();
            IList<Post> allPosts = _postService.GetAll().ToList<Post>();
            allPosts.Last<Post>().Should().NotBe(post);
        }

        [Test]
        public void Test_PostIntegrationData_InsertPostOverFlowMessage_ShouldFail()
        {
            Post post = new Post()
            {
                Message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                PostDate = DateTime.Now
            };

            Action action = () => _postService.Add(post);
            action.Should().Throw<PostMessageOverFlowException>();
            IList<Post> allPosts = _postService.GetAll().ToList<Post>();
            allPosts.Last<Post>().Should().NotBe(post);
            
        }

        [Test]
        public void Test_IntegrationDatabasePost_InsertPostDateBeLaterThanToday_ShouldFail()
        {
            Post post = new Post()
            {
                Message = "teste",
                PostDate = DateTime.Now.AddDays(2)
            };

            Action action = () => _postService.Add(post);
            action.Should().Throw<PostDateBeAfterTodayException>();
            IList<Post> allPosts = _postService.GetAll().ToList<Post>();
            allPosts.Last<Post>().Should().NotBe(post);
        }

        [Test]
        public void Test_IntegrationDatabasePost_InsertPostDisplayPostDate_ShouldBeOk()
        {
            Post post = new Post()
            {
                Message = "teste",
                PostDate = DateTime.Now.AddDays(-2)
            };

            _postService.Add(post);
            post.DisplayPostDate.Should().Be("2 dias atrás");
        }

        [Test]
        public void Test_PostIntegrationDate_UpdatePost_ShouldBeOk()
        {
            Post p = new Post()
            {
                Id = 1,
                Message = "att",
                PostDate = DateTime.Now
            };

            _postService.Update(p);

            IList<Post> allPosts = _postService.GetAll().ToList<Post>();
            allPosts[0].Should().NotBeNull();
            allPosts[0].Message.Should().Be(p.Message);
        }

        [Test]
        public void Test_PostIntegrationDate_DeletePost_ShouldBeOk()
        {
            Post post = new Post()
            {
                Id = 1
            };

            _postService.Delete(post);

            Post postDeletado = _postService.Get(1);
            postDeletado.Should().BeNull();
        }

        [Test]
        public void Test_PostIntegrationDate_DeletePostUndefinedId_ShouldFail()
        {
            Post post = new Post()
            {
                Id = -1
            };

            Action action = () => _postService.Delete(post);
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_PostIntegrationDate_GetPost_ShouldBeOk()
        {
            Post post = _postService.Get(1);
            post.Should().NotBeNull();
            post.Id.Should().Be(1);
            post.Message.Should().Be("Post de Teste");
        }

        [Test]
        public void Test_PostIntegrationDate_GetPostUndefinedId_ShouldFail()
        {
            Post post = _postService.Get(-1);
            post.Should().BeNull();
        }

        [Test]
        public void Test_PostIntegrationDate_GetAllPost_ShouldBeOk()
        {
            IEnumerable<Post> posts = _postService.GetAll();
            posts.Should().NotBeNull();
            posts.Count().Should().BeGreaterThan(0);
        }
    }
}
