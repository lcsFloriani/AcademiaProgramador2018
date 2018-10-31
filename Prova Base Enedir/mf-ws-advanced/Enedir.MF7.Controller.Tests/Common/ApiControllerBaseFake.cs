using Enedir.MF7.API.Controllers.Common;
using FluentValidation.Results;

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Enedir.MF7.Controller.Tests.Common
{
    public class ApiControllerBaseFake : ApiControllerBase
    {
        public IHttpActionResult HandleCallback<TSuccess>(TSuccess data)
        {
            return base.HandleCallback(() => data);
        }

        public IHttpActionResult HandleQuery<TSource, TResult>(TSource query)
        {
            return base.HandleQuery<TSource, TResult>(query);
        }

        public IHttpActionResult HandleQueryable<TSource, TResult>(IQueryable<TSource> query)
        {
            return base.HandleQueryable<TSource, TResult>(query);
        }

        public IHttpActionResult HandleValidationFailure<T>(IList<T> validationFailure) where T : ValidationFailure
        {
            return base.HandleValidationFailure<T>(validationFailure);
        }
    }

    /// <summary>
    /// Dummy usado para preencher valores: um tipo vazio
    /// </summary>
    public class ApiControllerBaseDummy
    {
    }

    /// <summary>
    /// Dummy usado para conversões de mapeamento
    /// </summary>
    public class ApiControllerBaseDummyViewModel
    {
    }
}

