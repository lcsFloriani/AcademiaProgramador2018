using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.WebApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Projeto_NFe.WebApi.Controllers.Common
{
    /// <summary>
    /// Controlador Base do BancoTabajara.API
    /// 
    /// Essa classe é responsável por prover propriedades e métodos úteis nos demais controllers 
    /// que vão possuir essa classe como pai (herança).
    /// 
    /// Ela também herda da classe ApiController, com isso, suas implementações já se tornam controllers da API.
    /// </summary>
    public class ApiControllerBase : ApiController
	{
			#region Handlers

			protected IHttpActionResult HandleCallback<TSuccess>(TSuccess data)
			{
				return Ok( data );
			}
			protected IHttpActionResult HandleQuery<TSource, TResult>(TSource result)
			{
				return Ok( Mapper.Map<TSource, TResult>( result ) );
			}

			protected IHttpActionResult HandleQueryable<TQueryOptions, TResult>(IQueryable<TQueryOptions> query, ODataQueryOptions<TQueryOptions> queryOptions)
			{
				return Ok( HandlePageResult<TQueryOptions, TResult>( query, queryOptions ) );
			}

			protected PageResult<RetType> HandlePageResult<OriginType, RetType>(IQueryable<OriginType> query, ODataQueryOptions<OriginType> queryOptions)
			{
				var queryResults = queryOptions.ApplyTo( query ).Cast<OriginType>().ToList().AsQueryable();
				var pageResult = new PageResult<RetType>( queryResults.ProjectTo<RetType>(),
														Request.ODataProperties().NextLink,
														Request.ODataProperties().TotalCount );

				return pageResult;
			}

			protected IHttpActionResult HandleFailure<T>(T exceptionToHandle) where T : Exception
			{
				var exceptionPayload = PayLoadException.New( exceptionToHandle );
				return exceptionToHandle is BusinessException ?
					Content( HttpStatusCode.BadRequest, exceptionPayload ) :
					Content( HttpStatusCode.InternalServerError, exceptionPayload );
			}

			protected IHttpActionResult HandleValidationFailure<T>(IList<T> validationFailure) where T : ValidationFailure
			{
				return Content( HttpStatusCode.BadRequest, validationFailure );
			}

			#endregion

		}
	}