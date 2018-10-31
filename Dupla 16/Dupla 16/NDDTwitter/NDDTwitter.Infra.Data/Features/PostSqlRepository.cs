using NDDTwitter.Domain.Features;
using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra.Data.Features
{
    public class PostSqlRepository : IPostRepository
    {
        #region readOnly

        private readonly string SaveSql = @"INSERT INTO Posts
                        (Message,
                         PostDate                               
                        )
                         VALUES
                        (@Message,
                        @PostDate
                        )";

        private readonly string UpdateSql = @"UPDATE Posts
                                SET Message =  @Message,
                                 PostDate = @PostDate
                                 WHERE Id = @Id";

        readonly string getAllSQL = @"SELECT Id,
                                             Message,
                                             PostDate                                             
                                    FROM Posts";

        readonly string getByIDSQL = @"SELECT Id,
                                              Message,
                                              PostDate
                                FROM Posts
                                WHERE Id = @Id";
        readonly string DeletesSQL = @"DELETE FROM Posts
                                  WHERE Id = @Id";

        #endregion
        public Post Save(Post objeto)
        {
            objeto.Id = Db.Insert(SaveSql, Take(objeto));
            return objeto;
        }

        public IEnumerable<Post> GetAll()
        {
            return Db.GetAll(getAllSQL, Make);
        }

        public Post GetById(long Id)
        {
            return Db.Get(getByIDSQL, Make, TakePostId(Id));
        }

        public Post Update(Post objeto)
        {
            Db.Update(UpdateSql, Take(objeto));
            return objeto;
        }

        public bool Delete(Post objeto)
        {
            try
            {
                Db.Delete(DeletesSQL, TakePostId(objeto.Id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static Func<IDataReader, Post> Make = reader => new Post
        {
            Id = Convert.ToInt64(reader["Id"]),
            Message = reader["Message"].ToString(),
            PostDate = Convert.ToDateTime(reader["PostDate"])
        };

        private object[] Take(Post post)
        {
            return new object[]
            {
                "@Id", post.Id,
                "@Message", post.Message,
                "@PostDate", post.PostDate
            };
        }

        private object[] TakePostId(long Id)
        {

            return new object[]
            {
                "@Id", Id
            };
        }
    }
}
