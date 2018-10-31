using System.Web.Http;

namespace Projeto_NFe.WebApi.Controllers.Common
{
    [RoutePrefix("api/public")]
    public class PublicController : ApiController
    {
        [HttpGet]
        [Route("is-alive")]
        public IHttpActionResult IsAlive()
        {
            return Ok(true);
        }
    }
}
