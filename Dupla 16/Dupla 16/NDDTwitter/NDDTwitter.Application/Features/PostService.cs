using NDDTwitter.Application.Interfaces;
using NDDTwitter.Domain.Features;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Application.Features
{
    public class PostService : IPostService
    {
        IPostRepository _postRepository;


        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public Post Add(Post objeto)
        {
            try
            {
                objeto.Validate();
                return _postRepository.Save(objeto);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Delete(Post objeto)
        {
            try
            {
                Validador.ValidateId(objeto.Id);
                _postRepository.Delete(objeto);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<Post> GetAll()
        {
            try
            {
                var  list = _postRepository.GetAll(); 
                foreach (var item in list)
                {
                    Validador.ValidateId(item.Id);
                }
                return list; 
            }
            catch (Exception)
            {

                throw;
            }

           
        }

        public Post GetById(long Id)
        {
            try
            {
                Validador.ValidateId(Id);
                Post post = _postRepository.GetById(Id);
                Validador.ValidateId(post.Id);               
                return post;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Post Update(Post objeto)
        {
            try
            {
                Validador.ValidateId(objeto.Id);
                objeto.Validate();
                return _postRepository.Update(objeto);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
