using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Floriani.MF7.Dominio.Excecoes;
using Newtonsoft.Json;

namespace Floriani.MF7.API.Excecoes
{
	public class ExceptionPayload
	{
		public int ErrorCode { get; set; }

		[JsonIgnore]
		public Exception Exception { get; set; }

		public string ErrorMessage { get; set; }

		public static ExceptionPayload New<T>(T exception) where T : Exception
		{
			int errorCode;
			if (exception is ExcecaoDeNegocio)
				errorCode = ( exception as ExcecaoDeNegocio ).CodigoErro.GetHashCode();
			else
				errorCode = CodigosDeErros.Unhandled.GetHashCode();
			return new ExceptionPayload {
				ErrorCode = errorCode,
				ErrorMessage = exception.Message,
				Exception = exception
			};
		}
	}
}