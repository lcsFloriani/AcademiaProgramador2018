using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BancoTabajara.API.Extensoes
{
    public static class ValidationFailureExtensions
    {
        public static string ListandoErros<T>(this IList<T> validationFailures) where T : ValidationFailure
        {
            StringBuilder sb = new StringBuilder();

            foreach (var erro in validationFailures)
                sb.Append(erro.ErrorMessage + "; ");

            return sb.ToString();
        }
    }
}