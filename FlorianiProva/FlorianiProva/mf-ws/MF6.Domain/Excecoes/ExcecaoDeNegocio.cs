using System;

namespace MF6.Domain.Exceptions
{
    public class ExcecaoDeNegocio : Exception
    {
        public ExcecaoDeNegocio(CodigoErros errorCode, string message) : base(message) => ErrorCode = errorCode;

        public CodigoErros ErrorCode { get; }
    }
}