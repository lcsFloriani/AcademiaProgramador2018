using FluentValidation.Results;

using System.Collections.Generic;
using System.Text;

namespace Enedir.MF7.API.Extensions
{
    public static class ValidationFailureExtensions
    {
        public static string Errors<T>(this IList<T> validationFailures) where T : ValidationFailure
        {
            StringBuilder sb = new StringBuilder();

            foreach (var erro in validationFailures)
                sb.Append(erro.ErrorMessage + "; ");

            return sb.ToString();
        }
    }
}