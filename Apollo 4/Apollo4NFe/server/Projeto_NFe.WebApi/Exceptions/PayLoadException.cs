using Projeto_NFe.Domain.Exceptions;
using Newtonsoft.Json;
using System;

namespace Projeto_NFe.WebApi.Exceptions
{
	public class PayLoadException
	{
		[JsonIgnore]
		public Exception Exception { get; set; }
		public int ErrorCode { get; set; }
		public string ErrorMessage { get; set; }

		public static PayLoadException New<T>(T exception) where T : Exception
		{
			int errorCode;
			if (exception is BusinessException)
				errorCode = ( exception as BusinessException ).ErrorCode.GetHashCode();
			else
				errorCode = ErrorCodes.Unhandled.GetHashCode();
			return new PayLoadException {
				ErrorCode = errorCode,
				ErrorMessage = exception.Message,
			};
		}
	}
}