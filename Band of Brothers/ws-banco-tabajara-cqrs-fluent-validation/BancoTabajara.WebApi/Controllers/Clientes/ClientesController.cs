﻿using BancoTabajara.Aplicacao;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Commands;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using BancoTabajara.Infra.Contexto;
using BancoTabajara.Infra.ORM.Funcionalidade.Clientes;
using BancoTabajara.WebApi.Controllers.Common;
using BancoTabajara.WebApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace BancoTabajara.WebApi.Controllers
{
    [RoutePrefix("api/clientes")]
    public class ClientesController : ApiControllerBase
    {
        public IClienteServico _clienteServico;

        public ClientesController(IClienteServico clienteServico) : base()
        {
            _clienteServico = clienteServico;
        }

        #region HttpGet
		 
       [HttpGet]
        public IHttpActionResult Get()
        {
			var chaveValor = this.Request.GetQueryNameValuePairs();

			IQueryable<Cliente> query = HttpGetAllExtensions<Cliente>.GeraQueryParaGetAllCliente( _clienteServico, chaveValor );

			return HandleQuery<Cliente>( query );
		}

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => _clienteServico.PegarPorId(id));
        }
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(ClienteRegistroCommand clienteCmd)
        {
            var validador = clienteCmd.Validate();
            if(!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _clienteServico.Inserir(clienteCmd));
        }

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(ClienteAtualizarCommand clienteCmd)
        {           

            var validador = clienteCmd.Validate();
            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _clienteServico.Atualizar(clienteCmd));
        }

        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(ClienteRemoveCommand clienteCmd)
        {
            return HandleCallback(() => _clienteServico.Deletar(clienteCmd));
        }

        #endregion HttpDelete
    }
}
