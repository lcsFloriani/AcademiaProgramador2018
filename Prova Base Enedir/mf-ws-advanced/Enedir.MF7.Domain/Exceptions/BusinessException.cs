﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enedir.MF7.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(ErrorCodes errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCodes ErrorCode { get; }
    }
}
