﻿using BancoTabajara.API.Controllers.Comum;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace BancoTabajara.Controller.Tests.Comum
{
    /// <summary>
    /// Fake para tornar acessivel e sem influência os métodos protected de ApiControllerBase
    /// </summary>
    public class ApiControllerBaseFake : ApiControllerBase
    {
        public IHttpActionResult HandleCallback<TSuccess>(Func<TSuccess> func)
        {
            return base.HandleCallback(func);
        }

        public IHttpActionResult HandleQuery<TResult>(IQueryable<TResult> query)
        {
            return base.HandleQuery(query);
        }

        public IHttpActionResult HandleQueryable<TSource>(IQueryable<TSource> query)
        {
            return base.HandleQueryable<TSource>(query);
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
    public class ApiControllerBaseDummyQuery
    {
    }
}
