using NDDResearch.API.Exceptions;
using NDDResearch.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Extensions;
using System.Web.OData.Query;
using FluentValidation.Results;
using AutoMapper.QueryableExtensions;
using NDDResearch.API.Filters;
using NDDResearch.Infra.Structs;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using NDDResearch.Infra.Csv;

namespace NDDResearch.API.Controllers.Common
{
    /// <summary>
    /// Controlador Base do NDDResearch.API
    /// 
    /// Essa classe é responsável por prover propriedades e métodos úteis nos demais controllers 
    /// que vão possuir essa classe como pai (herança).
    /// 
    /// Ela também herda da classe ApiController, com isso, suas implementações já se tornam controllers da API.
    /// </summary>
    [CustomAuthorize]
    public class ApiControllerBase : ApiController
    {
        /// <summary>
        /// Retorna o Id do usário que está fazendo a chamada.
        /// </summary>
        protected int UserId
        {
            get
            {
                return Convert.ToInt32(GetClaimValue("UserId"));
            }
        }

        #region Handlers

        /// <summary>
        /// Manuseia o callback. Valida se é necessário retornar erro ou o próprio TSuccess
        /// </summary> 
        /// <typeparam name="TFailure"></typeparam>
        /// <typeparam name="TSuccess"></typeparam>
        /// <param name="callback">Objeto Try utilizado nas chamadas.</param>
        /// <returns></returns>
        protected IHttpActionResult HandleCallback<TFailure, TSuccess>(Try<TFailure, TSuccess> callback) where TFailure : Exception
        {
            return callback.IsFailure ? HandleFailure(callback.Failure) : Ok(callback.Result);
        }

        /// <summary>
        /// Manuseia a query para aplicar as opções do odata.
        ///
        /// Esse método vai gerar o PageResult associando os dados (query) com as opções do odata (queryOptions) 
        /// após isso ele monta a resposta HTTP solicitada, conforme headers.
        /// 
        /// </summary>
        /// <typeparam name="TQueryOptions">Tipo do obj de origem (domínio)</typeparam>
        /// <typeparam name="TResult">Tipo de retorno </typeparam>
        /// <param name="query">IQueryable(TQueryOptions)</param>
        /// <param name="queryOptions">OdataQueryOptions(TQueryOptions)</param>
        /// <returns>IHttpActionResult(TResult) com o resultado da operação</returns>
        protected IHttpActionResult HandleQuery<TQueryOptions, TResult>(IQueryable<TQueryOptions> query, ODataQueryOptions<TQueryOptions> queryOptions)
        {
            if (Request.Headers.Accept.Contains(MediaTypeWithQualityHeaderValue.Parse("text/csv")))
                return ResponseMessage(HandleCSVFile<TQueryOptions, TResult>(query, queryOptions));

            return Ok(HandlePageResult<TQueryOptions, TResult>(query, queryOptions));
        }

        /// <summary>
        /// Aplica o filtro (odata) a query e retora um pageresult criado através do project da TQueryOptions para TResult. 
        /// </summary>
        /// <typeparam name="TQueryOptions">Tipo do obj de origem (domínio)</typeparam>
        /// <typeparam name="TResult">Tipo de retorno objQuery</typeparam>
        /// <param name="query">IQueryable(TQueryOptions)</param>
        /// <param name="queryOptions">OdataQueryOptions</param>
        /// <returns>PageResult(TResult)</returns>
        protected PageResult<TResult> HandlePageResult<TQueryOptions, TResult>(IQueryable<TQueryOptions> query, ODataQueryOptions<TQueryOptions> queryOptions)
        {
            var queryResults = queryOptions.ApplyTo(query);
            var pageResult = new PageResult<TResult>(queryResults.ProjectTo<TResult>(),
                                                    Request.ODataProperties().NextLink, 
                                                    Request.ODataProperties().TotalCount);
            return pageResult;
        }

        /// <summary>
        /// Verifica a exceção passada por parametro para passar o StatusCode correto para o frontend.
        /// </summary>
        /// <typeparam name="T">Qualquer classe que herde de Exeption</typeparam>
        /// <param name="exceptionToHandle">obj de exceção</param>
        /// <returns></returns>
        protected IHttpActionResult HandleFailure<T>(T exceptionToHandle) where T : Exception
        {
            var exceptionPayload = ExceptionPayload.New(exceptionToHandle);
            return exceptionToHandle is BusinessException ?
                Content(HttpStatusCode.BadRequest, exceptionPayload) :
                Content(HttpStatusCode.InternalServerError, exceptionPayload);
        }

        /// <summary>
        /// Retorna IHttpStatusCode de erro + erros da validação.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationFailure">Erros de validação (ValidationFailure)</param>
        /// <returns>IHttpActionResult com os erros e status code padrão</returns>
        protected IHttpActionResult HandleValidationFailure<T>(IList<T> validationFailure) where T : ValidationFailure
        {
            return Content(HttpStatusCode.BadRequest, validationFailure);
        }

        #endregion

        #region Utils

        /// <summary>
        /// Método responsável por ler do token, no contexto da requisição, as claims codificadas.
        /// </summary>
        /// <param name="type">É o nome da claim (atributo) desejada para leitura no token</param>
        /// <returns>O valor correspondente a claim</returns>
        private string GetClaimValue(string type)
        {
            return ((ClaimsIdentity)RequestContext.Principal.Identity).FindFirst(type).Value;

        }

        /// <summary>
        /// Aplica o filtro (odata) a query, monta um HttpResultMessage com o arquivo CSV
        /// </summary>
        /// <typeparam name="TQueryOptions">Tipo do obj de origem (domínio)</typeparam>
        /// <typeparam name="TResult">Tipo de retorno objQuery</typeparam>
        /// <param name="query">IQueryable(TQueryOptions)</param>
        /// <param name="queryOptions">OdataQueryOptions</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage HandleCSVFile<TQueryOptions, TResult>(IQueryable<TQueryOptions> query, ODataQueryOptions<TQueryOptions> queryOptions)
        {
            var queryResults = queryOptions.ApplyTo(query);
            var project = queryResults.ProjectTo<TResult>();

            var csv = project.ToCsv<TResult>(";");
            var bytes = Encoding.UTF8.GetBytes(csv ?? "");
            var stream = new MemoryStream(bytes, 0, bytes.Length, false, true);

            var result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(stream.GetBuffer()) };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = string.Format("export{0}.csv", DateTime.UtcNow.ToString("yyyyMMddhhmmss"))
            };

            return result;
        }

        #endregion
    }
}