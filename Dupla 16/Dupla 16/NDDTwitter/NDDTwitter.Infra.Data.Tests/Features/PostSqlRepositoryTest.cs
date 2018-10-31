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

namespace NDDTwitter.Infra.Data.Tests.Features
{
    [TestFixture]
    class PostSqlRepositoryTest
    {
        PostSqlRepository _postSqlRepository;
        Post _post;
 
        
        [SetUp]
        public void PostRepository_Set()
        {
            _postSqlRepository = new PostSqlRepository();
            _post = new Post()
            {
                Message = "Oi, eu sou o Goku!",
                PostDate = DateTime.Now
            };
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void PostRepository_Save_Should_BeOk()
        {
            _postSqlRepository.Save(_post);
            _post.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void PostRepository_Save_Should_BeFail()
        {
            _postSqlRepository.Save(_post);
            _post.Id.Should().BeGreaterThan(0);
        }
        
        [Test]
        public void PostRepository_Update_Should_BeOk()
        {
            _post.Message = "Oi, eu sou o Goku!!!!!!!!!!!!";
            _post.Id = 1;
            _postSqlRepository.Update(_post);
            var postUpdated = _postSqlRepository.GetById(_post.Id);
            postUpdated.Message.Should().Be(_post.Message);
        }

        [Test]
        public void PostRepository_GetAll_ShouldBeOk()
        {
            var teste = _postSqlRepository.GetAll();
            teste.Count().Should().BeGreaterThan(0);
        }
        [Test]
        public void PostRepository_GetById_ShouldBeOk()
        {
            _post.Id = 1;
            var teste = _postSqlRepository.GetById(_post.Id);
            teste.Message.Should().Be("Post de Teste");
        }
        [Test]
        public void PostRepository_Delete_ShouldBeOk()
        {
            _post.Id = 1;
            _postSqlRepository.Delete(_post);
        }



    }
}
