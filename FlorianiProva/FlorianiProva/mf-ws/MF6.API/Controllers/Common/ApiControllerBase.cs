using FluentValidation.Results;
using MF6.API.Exceptions;
using MF6.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MF6.API.Controllers.Common
{
    public class ApiControllerBase : ApiController
    {
        protected IHttpActionResult HandleCallback<TSuccess>(Func<TSuccess> func)
        {
            try
            {
                return Ok(func());
            }
            catch (Exception e)
            {
                return HandleFailure(e);
            }
        }

        protected IHttpActionResult HandleQuery<TResult>(IQueryable<TResult> query)
        {
            return Ok(query.ToList());
        }

        protected IHttpActionResult HandleQueryable<TSource>(IQueryable<TSource> query)
        {
            return Ok(query.ToList());
        }

        protected IHttpActionResult HandleFailure<T>(T exceptionToHandle) where T : Exception
        {
            var exceptionPayload = ExceptionPayload.New(exceptionToHandle);
            return exceptionToHandle is ExcecaoDeNegocio ?
                Content(HttpStatusCode.BadRequest, exceptionPayload) :
                Content(HttpStatusCode.InternalServerError, exceptionPayload);
        }

        protected IHttpActionResult HandleValidationFailure<T>(IList<T> validationFailure) where T : ValidationFailure
        {
            return Content(HttpStatusCode.BadRequest, validationFailure);
        }
    }
}