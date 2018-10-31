using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enedir.MF7.Domain.Features.Functionaries;

namespace Enedir.MF7.Domain.Features.Outgoing
{
   public class Outgo
    {
        public long Id { set; get; }
        public string Description { set; get; }
        public DateTime Date { set; get; }
        public Double Price { set; get; }
        public OutgoTypeEnum OutgoType { set; get; }

        public long FunctionaryId { set; get; }
        public virtual Functionary Functionary { set; get; }
    }
}
