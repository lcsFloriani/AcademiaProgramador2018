using NDDTwitter.Domain.Features;
using NDDTwitter.Infra.Data.Features;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NDDTwitter.Common.Tests.Base;
using NDDTwitter.Application.Features;
using NDDTwitter.Common.Tests.Features.Posts;

namespace NDDTwitter.Integration.Tests.Features.Posts
{
    [TestFixture]
    class PostSqlRepositoryAndServiceTest
    {
        PostSqlRepository _postSqlRepository;
        Post _post;
        PostService _service;

        [SetUp]
        public void PostRepository_Set()
        {
            _postSqlRepository = new PostSqlRepository();
            BaseSqlTest.SeedDatabase();
            _service = new PostService(_postSqlRepository);
            _post = ObjectMother.postValido;
            
        }
        [Test]
        public void PostServiceIntegradeWithSqlRepository_add_Should_BeOk()
        {
            _service.Add(_post);
            _post.Id.Should().BeGreaterThan(0);
            var post = _service.GetById(_post.Id);
            post.Id.Should().Be(_post.Id);
            var posts = _service.GetAll();
            posts.Last().Id.Should().Be(_post.Id);
        }

        [Test]
        public void PostServiceIntegradeWithSqlRepository_Add_Should_BeFail()
        {
            _postSqlRepository.Save(_post);
            _post.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void PostServiceIntegradeWithSqlRepository_Update_Should_BeOk()
        {
            _post = ObjectMother.postValidoParaEditar;
            _service.Update(_post);
            var teste = _service.GetById(_post.Id);
            teste.Message.Should().Be(_post.Message);
        }

        [Test]
        public void PostServiceIntegradeWithSqlRepository_GetAll_ShouldBeOk()
        {
            var teste = _service.GetAll();
            teste.Count().Should().BeGreaterThan(0);
        }
        [Test]
        public void PostServiceIntegradeWithSqlRepository_GetById_ShouldBeOk()
        {
            _post.Id = 1;
            var teste = _service.GetById(_post.Id);
            teste.Message.Should().Be("Post de Teste");
        }
        [Test]
        public void PostServiceIntegradeWithSqlRepository_Delete_ShouldBeOk()
        {
            _post.Id = 1;
            _service.Delete(_post);
        }


    }
}
