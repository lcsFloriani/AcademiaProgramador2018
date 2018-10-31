using BancoTabajara.API.Extensoes;
using System;
using System.Web.Http.Filters;

namespace BancoTabajara.API.Filtros
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Método invocado quando ocorre uma exceção no controller
        /// </summary>
        /// <param name="context">É o contexto atual da requisição</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.HandleExecutedContextException();
        }
    }
}