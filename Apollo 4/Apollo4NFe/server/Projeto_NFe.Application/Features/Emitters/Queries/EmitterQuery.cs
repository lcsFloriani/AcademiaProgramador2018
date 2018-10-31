using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Emitters.Queries
{
    public class EmitterQuery
    {
        public virtual int Size { get; set; }

        public EmitterQuery(int size)
        {
            Size = size;
        }
    }
}
