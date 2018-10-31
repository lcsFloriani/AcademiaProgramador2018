using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Infra.Data.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Application.Features.Posts
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post Add(Post post)
        {
            post.Validate();

            return _postRepository.Save(post);
        }

        public void Delete(Post post)
        {

            if (post.Id <= 0)
            {
                throw new IdentifierUndefinedException();
            }

            _postRepository.Delete(post);

        }

        public Post Get(long id)
        {
            try
            {
                return _postRepository.Get(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Post Update(Post post)
        {
            if (post.Id <= 0)
            {
                 throw new IdentifierUndefinedException();
            }
            post.Validate();
            return _postRepository.Update(post);
        }
    }
}
