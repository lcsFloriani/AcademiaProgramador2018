﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using Projeto_NFe.WebApi.Exceptions;

namespace Projeto_NFe.WebApi.Extensions
{
	public static class ExceptionHandlingExtensions
	{
		/// <summary>
		/// Extension Method do HttpActionExecutedContext para manipular o context quando há uma exceção 
		/// e retornar um ExceptionPayload customizado, informando ao client o que houve de errado.
		/// 
		/// </summary>
		/// <param name="context">É o contexto atual da requisição</param>
		/// <returns>HttpResponseMessage contendo a exceção</returns>
		public static HttpResponseMessage HandleExecutedContextException(this HttpActionExecutedContext context)
		{
			// Retorna a resposta para o cliente com o erro 500 e o ExceptionPayload (código de erro de negócio e mensagem)
			return context.Request.CreateResponse( HttpStatusCode.InternalServerError, PayLoadException.New( context.Exception ) );
		}
	}
}