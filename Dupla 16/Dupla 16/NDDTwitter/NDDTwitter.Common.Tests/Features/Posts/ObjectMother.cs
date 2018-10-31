using NDDTwitter.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Common.Tests.Features.Posts
{
    public static class ObjectMother
    {
        static Random random = new Random();
        public static Post postValido {
            get
            {
                return new Post()
                {
                    Message = "Teste de integração" + random.Next(),
                    PostDate = DateTime.Now,
                };
            }
        }

        public static Post postComIdValido
        {
            get
            {
                return new Post()
                {
                    Message = "teste",
                    PostDate = DateTime.Now,
                    Id = 10,
                };
            }
        }

        public static Post postInvalido
        {
            get
            {
                return new Post()
                {
                    Message = "",
                    PostDate = DateTime.Now,
                };
            }
        }

        public static Post postValidoParaEditar
        {
            get
            {
                return new Post()
                {
                    Message = "Oi, Eu sou o Goku!!!!!!!!!!!!!" + random.Next(),
                    PostDate = DateTime.Now,
                    Id = 1
                };
            }
        }

    }
}
