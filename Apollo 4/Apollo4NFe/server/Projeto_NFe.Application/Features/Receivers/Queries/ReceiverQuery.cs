using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Receivers.Queries
{
    public class ReceiverQuery
    {
        public virtual int Size { get; set; }

        public ReceiverQuery(int _size)
        {
            Size = _size;
        }
    }
}
