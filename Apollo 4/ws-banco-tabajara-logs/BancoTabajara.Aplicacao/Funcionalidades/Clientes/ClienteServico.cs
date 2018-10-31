using System.Collections.Generic;
using BancoTabajara.Dominio.Excecoes;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using System.Linq;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Commands;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.Querys;
using System;
using BancoTabajara.Aplicacao.Funcionalidades.Clientes.ViewModels;

namespace BancoTabajara.Aplicacao.Funcionalidades.Clientes
{
    public class ClienteServico : IClienteServico
    {
        private IClienteRepositorio _repositorio;
        private int _menorQue = 1;

        public ClienteServico(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public long Adicionar(ClienteRegistraCommand command)
        {
            Cliente cliente = command.ConverterParaObjeto();

            //cliente.Validar();

            var novoClinte = _repositorio.Adicionar(cliente);

            return novoClinte.Id;
        }

        public bool Atualizar(ClienteAtualizaCommand command)
        {
            //if (entidade.Id < _menorQue)
            //    throw new IdentificadorIndefinidoExcecao();

            //entidade.Validar();

            var cliente = command.ConverterParaObjeto();

            return _repositorio.Atualizar(cliente);
        }

        public Cliente BuscarPorId(long id)
        {
            if (id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            return _repositorio.BuscarPorId(id);
        }

        public IQueryable<Cliente> Listagem(ClienteQuery query)
        {
            return _repositorio.Listagem(query.Quantidade);
        }

        public bool Excluir(ClienteDeletaCommand command)
        {
            Cliente cliente = command.ConverterParaObjeto();

            var deletado = _repositorio.BuscarPorId(cliente.Id);

            return _repositorio.Excluir(deletado);
        }
    }
}