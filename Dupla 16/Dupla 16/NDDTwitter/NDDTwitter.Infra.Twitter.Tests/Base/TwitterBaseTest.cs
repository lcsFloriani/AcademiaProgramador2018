using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NDDTwitter.Common.Tests.Base;
using NDDTwitter.Domain.Features;
using NDDTwitter.Infra.Data.Features;
using NDDTwitter.Infra.Twitter.Base;
using NDDTwitter.Infra.Twitter.Exceptions;
using NDDTwitter.Infra.Twitter.Features.Posts;
using NUnit;
using NUnit.Framework;

namespace NDDTwitter.Infra.Twitter.Tests.Base
{
    [TestFixture]
    class TwitterBaseTest
    {
        TwitterService _twitterService;
        string _post;
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
            Random r = new Random();
            _post = r.Next() + "";
        }

        [Test]
        public void TwitterRepository_Save_Should_BeOk()
        {
            var tweet = _twitterService.AdicionarTwitter(_post);
            ids.Add(tweet.Id);
            tweet.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void TwitterRepositoryTest_Send_Tweets_BeEmpty()
        {
            Action comparison = () => {_twitterService.ValidadorMessage(""); };
            comparison.Should().Throw<TwitterExceptionMessageNull>();
        }

        [Test]
        public void TwitterRepositoryTest_Send_Tweets_BeRepeat()
        {
            var tweet = _twitterService.AdicionarTwitter(_post);
            Action comparison = () => { _twitterService.AdicionarTwitter(_post); };
            ids.Add(tweet.Id);
            comparison.Should().Throw<TwitterExceptionMessageRepetida>();
        }

        [Test]
        public void TwitterRepository_Delete_ShouldBeOk()
        {
            var tweet = _twitterService.AdicionarTwitter(_post);
            var resultado = _twitterService.RemoverTwitter(tweet.Id);
            resultado.Should().BeTrue();
        }
        [Test]
        public void TwitterRepository_Delete_ShouldBeFailID()
        {
            Action comparison = () => { _twitterService.RemoverTwitter(0); };

            comparison.Should().Throw<TwitterExceptionIdNull>();
        }
        [Test]
        public void TwitterRepository_Get_ShouldBeOk()
        {
            var tweet = _twitterService.AdicionarTwitter(_post);
            var resultado = _twitterService.GetTweet(tweet.Id);
            resultado.Should().NotBeNull();
            resultado.Text.Should().Be(_post);
            ids.Add(tweet.Id);
        }
        [Test]
        public void TwitterRepository_Get_ShouldBeFailID()
        {
            Action comparison = () => { _twitterService.GetTweet(0); };

            comparison.Should().Throw<TwitterExceptionIdNull>();
        }
        [Test]
        public void TwitterRepository_ListTimeLine_ShouldBeOk()
        {
            var tweet = _twitterService.AdicionarTwitter(_post);
            var tweets = _twitterService.ListTweetsOnHomeTimeLine();
            tweets.Count().Should().BeGreaterThan(0);
            tweets.First().Text.Should().Be(_post);
            ids.Add(tweet.Id);
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
