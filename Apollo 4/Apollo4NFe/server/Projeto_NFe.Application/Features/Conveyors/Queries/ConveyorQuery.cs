using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Conveyors.Queries
{
    public class ConveyorQuery
    {
        public virtual int Size { get; set; }

        public ConveyorQuery(int size)
        {
            Size = size;
        }
    }
}
