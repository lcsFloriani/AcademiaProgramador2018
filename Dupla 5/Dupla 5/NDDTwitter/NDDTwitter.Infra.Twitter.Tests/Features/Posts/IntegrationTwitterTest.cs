using FluentAssertions;
using Moq;
using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Infra.Twitter.Base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi.Models;

namespace NDDTwitter.Infra.Twitter.Tests.Features.Posts
{
    [TestFixture]
    public class IntegrationTwitterTest
    {
        private TwitterService _twitterService;
        private Mock<IPostRepository> _mockRepository;
        private long _id;
        private ITweet _tw;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostRepository>();
            _twitterService = new TwitterService();
        }

        [Test]
        [Order(1)]
        public void Test_TweetPost_SendTweet_ShouldBeOk()
        {
            Post post = new Post()
            {
                Message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                PostDate = DateTime.Now,
            };

            _id = _twitterService.SendTweet(post.Message).Id;

            _id.Should().NotBe(0);
        }

        [Test]
        [Order(2)]
        public void Test_TweetPost_GetTweet_ShouldBeOk()
        {            
            _tw =  _twitterService.GetTweet(_id);
            
            _tw.Id.Should().Be(_id);
        }

        [Test]
        [Order(4)]
        public void Test_TweetPost_ListTweetsOnHomeTimeline_ShouldBeOk()
        {
            List<ITweet> tweets = _twitterService.ListTweetsOnHomeTimeLine().ToList<ITweet>();
            tweets.Should().NotBeNull();
        }

        [Test]
        [Order(3)]
        public void Test_TweetPost_DeleteTweet_ShouldBeOk()
        {            
            bool deletedTweet = _twitterService.DeleteTweet(_tw.Id);
            deletedTweet.Should().BeTrue();
        }

        [Test]
        [Order(5)]
        public void Test_TweetPost_SendTweetEmptyMessage_ShouldFail()
        {
            Action action = () => { _twitterService.SendTweet(""); };
            action.Should().Throw<PostMessageIsNullOrEmptyException>();
        }

        [Test]
        [Order(6)]
        public void Test_TweetPost_SendTweetOverFlowMessage_ShouldFail()
        {
            Post post = new Post()
            {
                Message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            };

            Action action = () => { _twitterService.SendTweet(post.Message); };
            action.Should().Throw<PostMessageOverFlowException>();
        }

        [Test]
        [Order(7)]
        public void Test_TweetPost_GetTweetUndefinedId_ShouldFail()
        {
            Action action = () => { _twitterService.GetTweet(-1); };
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(8)]
        public void Test_TweetPost_DeleteTweetUndefinedId_ShouldBeOk()
        {
            Action action = () => { _twitterService.DeleteTweet(-1); };
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
