using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Floriani.MF7.API.Excecoes;

namespace Floriani.MF7.API.Extensions
{
	public static class ExceptionHandlingExtensions
	{
		public static HttpResponseMessage HandleExecutedContextException(this HttpActionExecutedContext context)
		{
			return context.Request.CreateResponse( HttpStatusCode.InternalServerError, ExceptionPayload.New( context.Exception ) );
		}
	}
}