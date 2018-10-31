using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NDDTwitter.Infra.Twitter.Base;
using NDDTwitter.Infra.Twitter.Features.Posts;
using NDDTwitter.Domain.Features;
using Tweetinvi.Models;
using Tweetinvi;
using FluentAssertions;
using NDDTwitter.Infra.Twitter.Interfaces;
using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Common.Tests.Features.Posts;

namespace NDDTwitter.Infra.Twitter.Tests.Features
{
    [TestFixture]
    public class TwitterRepositoryTest
    {
        private PostTwitterRepository Alvo;
        private Mock<ITwitterService> _mock;
        Post _post;

        [SetUp]
        public void TwitterService_Set()
        {
            _mock = new Mock<ITwitterService>();
            Alvo = new PostTwitterRepository(_mock.Object);
            _post = ObjectMother.postValido;
        }

        [Test]
        public void TwitterRepositoryTest_Send_Tweets_BeOK()
        {
            _mock.Setup(x => x.AdicionarTwitter(_post.Message)).Returns(It.IsAny<ITweet>());

            var obtido = Alvo.Save(_post);
            _mock.Verify(x => x.AdicionarTwitter(_post.Message));
            obtido.Should().NotBeNull();
        }

        [Test]
        public void TwitterRepositoryTest_Delete_Tweets_BeOK()
        {
            _mock.Setup(x => x.RemoverTwitter(_post.Id));

            Alvo.Delete(_post);

            _mock.Verify(x => x.RemoverTwitter(_post.Id));
        }

        [Test]
        public void TwitterRepositoryTest_TimeLine_Tweets_BeOK()
        {
            List<ITweet> list = new List<ITweet>();
            list.Add(It.IsAny<ITweet>());
            _mock.Setup(x => x.ListTweetsOnHomeTimeLine()).Returns(list);

            var obtido = Alvo.GetAll();
            _mock.Verify(x => x.ListTweetsOnHomeTimeLine());
            obtido.Should().NotBeNull();

        }

        [Test]
        public void TwitterRepositoryTest_GetById_Tweets_BeOK()
        {
            _mock.Setup(x => x.GetTweet(_post.Id)).Returns(It.IsAny<ITweet>());

            var obtido = Alvo.GetById(_post.Id);

            _mock.Verify(x => x.GetTweet(_post.Id));
            obtido.Should().NotBeNull();
        }

        [Test]
        public void TwitterRepositoryTest_Update_Tweets_BeFail()
        {
            Action comparison = () => { Alvo.Update(_post); };
            comparison.Should().Throw<UnsupportedOperationException>();
        }
    }
}
