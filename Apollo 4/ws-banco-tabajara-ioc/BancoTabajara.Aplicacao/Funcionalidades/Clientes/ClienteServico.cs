using System.Collections.Generic;
using BancoTabajara.Dominio.Excecoes;
using BancoTabajara.Dominio.Funcionalidades.Clientes;
using System.Linq;

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

        public long Adicionar(Cliente cliente)
        {
            cliente.Validar();

            var novoClinte = _repositorio.Adicionar(cliente);

            return novoClinte.Id;
        }

        public bool Atualizar(Cliente entidade)
        {
            if (entidade.Id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            entidade.Validar();

            return _repositorio.Atualizar(entidade);
        }

        public ClienteDTO BuscarPorId(long id)
        {
            if (id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            return _repositorio.BuscarPorId(id).ConverterParaDTO();
        }

        public IQueryable<ClienteDTO> Listagem(int quantidade)
        {
            return _repositorio.Listagem(quantidade).ConverterParaListaDTO();
        }

        public bool Excluir(long id)
        {
            if (id < _menorQue)
                throw new IdentificadorIndefinidoExcecao();

            Cliente cliente = _repositorio.BuscarPorId(id);

            return _repositorio.Excluir(cliente);
        }
    }
}
