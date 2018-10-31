using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Infra.Twitter.Base;
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
        ITwitterService _twitterService;

        public PostTwitterRepository(ITwitterService twitterService)
        {
            _twitterService = twitterService;
        }

        public void Delete(Post post)
        {
            _twitterService.DeleteTweet(post.Id);
        }

        public Post Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();

            if (_twitterService.GetTweet(id) != null)
                return MakePost(_twitterService.GetTweet(id));

            return null;
        }

        public IEnumerable<Post> GetAll()
        {
            List<Post> posts = new List<Post>();
            foreach (var item in _twitterService.ListTweetsOnHomeTimeLine())
            {
                posts.Add(MakePost(item));
            }

            return posts;
        }

        public Post Save(Post post)
        {
            post.Validate();
            return MakePost(_twitterService.SendTweet(post.Message));
        }

        public Post Update(Post post)
        {
            throw new UnsupportedOperationException();
        }

        private Post MakePost(ITweet tw)
        {
            Post p;
            return p = new Post()
            {
                Id = tw.Id,
                Message = tw.FullText,
                PostDate = tw.CreatedAt
            };        
        }
    }
}
