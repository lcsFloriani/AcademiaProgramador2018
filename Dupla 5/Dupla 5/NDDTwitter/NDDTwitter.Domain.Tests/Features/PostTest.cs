using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NDDTwitter.Domain.Exceptions;

namespace NDDTwitter.Domain.Tests.Features
{
    [TestFixture]
    public class PostTest
    {
        [Test]
        public void ShouldMessageBeNull()
        {
            Post p = new Post()
            {
                Message = null,
                PostDate = DateTime.Now
            };
            Action action = p.Validate;
            action.Should().Throw<PostMessageIsNullOrEmptyException>();
        }

        [Test]
        public void ShouldMessageBeEmpty()
        {
            Post p = new Post()
            {
                Message = "",
                PostDate = DateTime.Now
            };

            Action action = p.Validate;
            action.Should().Throw<PostMessageIsNullOrEmptyException>();
        }

        [Test]
        public void ShouldMessageBeLargerThanOneHundredAndFortyChars()
        {
            Post p = new Post()
            {
                Message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                PostDate = DateTime.Now
            };

            Action action = p.Validate;
            action.Should().Throw<PostMessageOverFlowException>();
        }

        [Test]
        public void ShouldPostDateBeAfterToday()
        {
            Post p = new Post()
            {
                Message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                PostDate = DateTime.Now.AddDays(2)
            };

            Action action = p.Validate;
            action.Should().Throw<PostDateBeAfterTodayException>();
        }

        [Test]
        public void DisplayPostDateShouldBe2DaysAgo()
        {
            Post p = new Post()
            {
                Message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                PostDate = DateTime.Now.AddDays(-2)
            };
            string resultado = p.DisplayPostDate;
            resultado.Should().Be("2 dias atrás");
        }

        [Test]
        public void ShouldMessageBeOk()
        {
            Post p = new Post()
            {
                Message = "E ai Guilherme, beleza?",
                PostDate = DateTime.Now
            };
            Action action = p.Validate;
            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void ShouldPostDateBeOk()
        {
            Post p = new Post()
            {
                Message = "E ai Guilherme, beleza?",
                PostDate = DateTime.Now.AddDays(-2)
            };

            Action action = p.Validate;
            action.Should().NotThrow<Exception>();
        }
    }
}
