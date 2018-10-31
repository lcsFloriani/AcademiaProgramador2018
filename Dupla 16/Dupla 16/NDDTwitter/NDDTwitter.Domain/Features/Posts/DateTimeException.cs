using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Domain.Exceptions
{
    public class DateTimeException : BusinessException
    {
        public DateTimeException() : base("A data não pode ser maior que a data atual")
        {
        }
    }
}
