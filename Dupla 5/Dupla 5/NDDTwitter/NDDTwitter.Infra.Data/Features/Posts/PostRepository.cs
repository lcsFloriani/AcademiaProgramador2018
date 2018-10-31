using NDDTwitter.Domain.Features.Posts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra.Data.Features.Posts
{
    public class PostRepository : IPostRepository
    {
        public void Delete(Post post)
        {
            string sqlDeletePost = @"DELETE FROM Posts WHERE Id = @id";

            Db.Delete(sqlDeletePost, TakeId(post.Id));
        }

        public Post Get(long id)
        {
            string sqlGetPost = "SELECT * FROM Posts WHERE id = @id";

            return Db.Get(sqlGetPost, Make, TakeId(id));
        }

        public IEnumerable<Post> GetAll()
        {
            string sqlGetAllPosts = @"SELECT * FROM Posts";

            return Db.GetAll(sqlGetAllPosts, Make);
        }

        public Post Save(Post post)
        {
            post.Validate();

            string sqlInsertPost = @"INSERT INTO Posts ([Message], [PostDate]) VALUES (@Message, @PostDate)";
            post.Id = Db.Insert(sqlInsertPost, Take(post));

            return post;
        }

        public Post Update(Post post)
        {
            post.Validate();

            string sqlUpdatePost =
                @"UPDATE Posts SET Message = @Message, PostDate = @PostDate
                WHERE Id = @Id";

            Db.Update(sqlUpdatePost, Take(post));

            return post;
        }

        /// <summary>
        /// Cria um objeto Customer baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Post> Make = reader =>
           new Post
           {
               Id = Convert.ToInt64(reader["Id"]),
               Message = reader["Message"].ToString(),
               PostDate = Convert.ToDateTime(reader["PostDate"])
           };

        /// <summary>
        /// Cria a lista de parametros do objeto Post para passar para o comando Sql
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>lista de parametros</returns>
        private object[] Take(Post post)
        {
            return new object[]
            {
                "@Id", post.Id,
                "@Message", post.Message,
                "@PostDate", post.PostDate
            };
        }

        private object[] TakeId(long id)
        {
            return new object[]
            {
                "@Id", id
            };
        }
    }
}
