﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using Floriani.MF7.API.Excecoes;
using Floriani.MF7.API.Models;
using Floriani.MF7.Dominio.Excecoes;
using Floriani.MF7.Infra.Csvs;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;

namespace Floriani.MF7.API.Controllers.Comum
{
	public class ApiControllerBase : ApiController
    {
		#region Handlers

		protected IHttpActionResult HandleCallback<TSuccess>(Func<TSuccess> func)
		{
			try {
				return Ok( func() );
			} catch (Exception e) {
				return HandleFailure( e );
			}
		}

		protected IHttpActionResult HandleQuery<TQueryOptions, TResult>(IQueryable<TQueryOptions> query, ODataQueryOptions<TQueryOptions> queryOptions)
		{
			if (Request.Headers.Accept.Contains( MediaTypeWithQualityHeaderValue.Parse( MediaTypes.Csv ) ))
				return ResponseMessage( HandleCSVFile<TQueryOptions, TResult>( query, queryOptions ) );

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
			var exceptionPayload = ExceptionPayload.New( exceptionToHandle );
			return exceptionToHandle is ExcecaoDeNegocio ?
				Content( HttpStatusCode.BadRequest, exceptionPayload ) :
				Content( HttpStatusCode.InternalServerError, exceptionPayload );
		}

		protected IHttpActionResult HandleValidationFailure<T>(IList<T> validationFailure) where T : ValidationFailure
		{
			return Content( HttpStatusCode.BadRequest, validationFailure );
		}

		#endregion
		#region csv handler

		private HttpResponseMessage HandleCSVFile<TQueryOptions, TResult>(IQueryable<TQueryOptions> query, ODataQueryOptions<TQueryOptions> queryOptions)
		{
			var queryResults = queryOptions.ApplyTo( query );
			var project = queryResults.ProjectTo<TResult>();

			var csv = project.ToCsv<TResult>( ";" );
			var bytes = Encoding.UTF8.GetBytes( csv );
			var stream = new MemoryStream( bytes, 0, bytes.Length, false, true );

			var result = new HttpResponseMessage( HttpStatusCode.OK ) { Content = new ByteArrayContent( stream.GetBuffer() ) };

			result.Content.Headers.ContentType = new MediaTypeHeaderValue( "application/octet-stream" );
			result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue( "attachment" ) {
				FileName = string.Format( "export{0}.csv", DateTime.UtcNow.ToString( "yyyyMMddhhmmss" ) )
			};

			return result;
		}

		#endregion Handlers CSV	
	}
}
