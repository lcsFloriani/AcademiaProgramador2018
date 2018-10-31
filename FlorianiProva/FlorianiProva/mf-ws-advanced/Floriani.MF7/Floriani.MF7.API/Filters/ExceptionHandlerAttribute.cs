using System.Web.Http.Filters;
using Floriani.MF7.API.Extensions;

namespace Floriani.MF7.API.Filters
{
	public class ExceptionHandlerAttribute : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext context)
		{
			context.Response = context.HandleExecutedContextException();
		}
	}
}