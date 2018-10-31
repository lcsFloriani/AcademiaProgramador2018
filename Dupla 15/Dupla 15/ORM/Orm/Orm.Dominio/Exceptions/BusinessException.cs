using System;
using System.Diagnostics.CodeAnalysis;

namespace Orm.Dominio.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}
