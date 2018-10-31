using BancoTabajara.API.Excecoes;
using BancoTabajara.Dominio.Excecoes;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace BancoTabajara.API.Controllers.Comum
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

        /// <summary>
        /// Manuseia o callback. Valida se é necessário retornar erro ou o próprio TSuccess
        /// </summary> 
        /// <typeparam name="TSuccess"></typeparam>
        /// <param name="func">É a função que irá retornar o valor para o payload</param>
        /// <returns></returns>
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

        /// <summary>
        /// Manuseia a query para aplicar as opções do odata.
        ///
        /// Esse método vai montar a resposta HTTP solicitada, conforme headers.
        /// 
        /// </summary>
        /// <typeparam name="TResult">Tipo de retorno </typeparam>
        /// <param name="query">IQueryable(TQueryOptions)</param>
        /// <returns>IHttpActionResult(TResult) com o resultado da operação</returns>
        protected IHttpActionResult HandleQuery<TResult>(IQueryable<TResult> query)
        {
            return Ok(query.ToList());
        }


        protected IHttpActionResult HandleQueryable<TSource>(IQueryable<TSource> query)
        {
            return Ok(query.ToList());
        }

        /// <summary>
        /// Verifica a exceção passada por parametro para passar o StatusCode correto para o frontend.
        /// </summary>
        /// <typeparam name="T">Qualquer classe que herde de Exeption</typeparam>
        /// <param name="exceptionToHandle">obj de exceção</param>
        /// <returns></returns>
        protected IHttpActionResult HandleFailure<T>(T exceptionToHandle) where T : Exception
        {
            var exceptionPayload = PayLoadExcecao.New(exceptionToHandle);
            return exceptionToHandle is NegocioExcecao ?
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
    }
}