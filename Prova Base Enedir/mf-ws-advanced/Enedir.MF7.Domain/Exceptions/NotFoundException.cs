using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enedir.MF7.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(ErrorCodes errorCode, string message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCodes ErrorCode { get; }
    }
}
