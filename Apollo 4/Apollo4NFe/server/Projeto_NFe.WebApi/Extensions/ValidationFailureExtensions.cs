using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using FluentValidation.Results;

namespace Projeto_NFe.WebApi.Extensions
{
	public static class ValidationFailureExtensions
	{
		public static string Errors<T>(this IList<T> validationFailures) where T : ValidationFailure
		{
			StringBuilder sb = new StringBuilder();

			foreach (var erro in validationFailures)
				sb.Append( erro.ErrorMessage + "; " );

			return sb.ToString();
		}
	}
}