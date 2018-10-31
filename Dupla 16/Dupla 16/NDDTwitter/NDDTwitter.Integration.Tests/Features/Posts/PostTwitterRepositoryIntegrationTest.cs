using FluentAssertions;
using NDDTwitter.Application.Features;
using NDDTwitter.Common.Tests.Features.Posts;
using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features;
using NDDTwitter.Infra.Twitter.Base;
using NDDTwitter.Infra.Twitter.Exceptions;
using NDDTwitter.Infra.Twitter.Features.Posts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Integration.Tests.Features.Posts
{
    [TestFixture]
    public class PostTwitterRepositoryIntegrationTest
    {

        PostTwitterRepository _postTwitterRepository;
        Post _post;
        PostService _service;
        TwitterService _twitterService;
        List<long> ids;

        [OneTimeSetUp]
        public void listIds()
        {
            ids = new List<long>();
        }

        [SetUp]
        public void PostRepository_Set()
        {
            _twitterService = new TwitterService();
            _postTwitterRepository = new PostTwitterRepository(_twitterService);
            _service = new PostService(_postTwitterRepository);
            _post = ObjectMother.postValido;

        }

        [Test]
        public void PostTwitterRepositoryAndServiceTest_Send_BeOk()
        {
            _post = _service.Add(_post);
            _post.Id.Should().BeGreaterThan(0);
            var tweets = _service.GetAll();
            tweets.First().Id.Should().Be(_post.Id);
        }

        [Test]
        public void PostTwitterRepositoryIntegrationTest_Send_BeEmpty()
        {
            Action comparison = () => { _service.Add(ObjectMother.postInvalido); };
            comparison.Should().Throw<MessageNulaOuVaziaException>();
        }

        [Test]
        public void PostTwitterRepositoryIntegrationTest_Send_BeRepeat()
        {
            var tweet = _service.Add(_post);
            Action comparison = () => { _service.Add(_post); };
            ids.Add(tweet.Id);
            comparison.Should().Throw<TwitterExceptionMessageRepetida>();
        }


        [Test]
        public void PostTwitterRepositoryIntegrationTest_GetAll_BeOk()
        {
            var tweet = _service.GetAll();
            tweet.Count().Should().BeGreaterThan(0);
        }

        
        [Test]
        public void PostTwitterRepositoryIntegrationTest_GetById_BeOk()
        {
            var tweet = _service.Add(_post);
            var resultado = _service.GetById(tweet.Id);
            resultado.Id.Should().Be(tweet.Id);
            ids.Add(tweet.Id);
        }

        [Test]
        public void PostTwitterRepositoryIntegrationTest_Update_BeOk()
        {
           
            Action comparison = () => { _service.Update(ObjectMother.postComIdValido); };

            comparison.Should().Throw<UnsupportedOperationException>();
        }


        [Test]
        public void PostTwitterRepositoryIntegrationTest_Delete_BeOk()
        {
            _post = _service.Add(_post);
            _service.Delete(_post);
            var tweets = _service.GetAll();
            tweets.Last().Should().NotBe(_post);

        }


        [TearDown]
        public void limpaTests()
        {
            foreach (var item in ids)
            {
                var resultado = _twitterService.RemoverTwitter(item);
            }
        }
    }
}