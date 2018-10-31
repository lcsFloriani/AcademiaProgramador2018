﻿using BancoTabajara.API.Controllers.Comum;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Commands;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Querys;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.ViewModels;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace BancoTabajara.API.Controllers.Clientes
{
    [Authorize]
    [RoutePrefix("api/clientes")]
    public class ClientesController : ApiControllerBase
    {
        public IClienteServico servico;

        public ClientesController(IClienteServico servico) : base()
        {
            this.servico = servico;
        }

        #region POST
 
        [HttpPost]
        public IHttpActionResult Adicionar(ClienteRegistraCommand command)
        {
            ValidationResult resultadoValidacao = command.Validar();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);

            return HandleCallback(() => servico.Adicionar(command));
        }

        #endregion

        #region PUT

        [HttpPut]
        public IHttpActionResult Atualizar(ClienteAtualizaCommand command)
        {
            ValidationResult resultadoValidacao = command.Validar();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);

            return HandleCallback(() => servico.Atualizar(command));
        }

        #endregion

        #region GET

        [HttpGet]
        public IHttpActionResult Listagem()
        {
            var keyValuePairs = this.Request.GetQueryNameValuePairs();
            KeyValuePair<string, string> quantidadePares = keyValuePairs.First(x => x.Key.Equals("quantidade"));
            int quantidade = int.Parse(quantidadePares.Value);

            ClienteQuery clienteQuery = new ClienteQuery(quantidade);

            var query = servico.Listagem(clienteQuery);

            return HandleQueryable<Cliente, ClienteViewModel>(query); ;
        }

        [HttpGet]
        [Route("{id:long}")]
        public IHttpActionResult BuscarPorId(long id)
        {
            return HandleQuery<Cliente, ClienteViewModel>(servico.BuscarPorId(id));
        }

        #endregion

        #region DELETE

        [HttpDelete]
        public IHttpActionResult Excluir(ClienteDeletaCommand command)
        {
            ValidationResult resultadoValidacao = command.Validar();

            if (!resultadoValidacao.IsValid)
                return HandleValidationFailure(resultadoValidacao.Errors);

            return HandleCallback(() => servico.Excluir(command));
        }

        #endregion
    }
}