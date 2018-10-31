using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Infra.Twitter.Base;
using NDDTwitter.Infra.Twitter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace NDDTwitter.Infra.Twitter.Features.Posts
{
    public class PostTwitterRepository : IPostRepository
    {
        private ITwitterService twitterService;

        public PostTwitterRepository(ITwitterService twitterService)
        {
            this.twitterService = twitterService;
        }

        public bool Delete(Post objeto)
        {
            return twitterService.RemoverTwitter(objeto.Id);
        }

        public IEnumerable<Post> GetAll()
        {
            List<Post> lista = new List<Post>();
            foreach (var item in twitterService.ListTweetsOnHomeTimeLine())
            {
                lista.Add(Make(item));
            }

            return lista;
        }

        public Post GetById(long Id)
        {
            return Make(twitterService.GetTweet(Id));
        }

        public Post Save(Post objeto)
        {
            return Make(twitterService.AdicionarTwitter(objeto.Message));

        }

        public Post Update(Post objeto)
        {
            throw new UnsupportedOperationException();
        }

        public Post Make(ITweet tweet)
        {
            if (tweet == null)
                return new Post();
            return new Post()
            {
                Id = tweet.Id,
                PostDate = tweet.CreatedAt,
                Message = tweet.Text,
            };
        }
    }
}
