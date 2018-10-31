using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Clientes;

namespace Pizzaria.Application.Features.Clientes
{
    public class ClienteServico : IClienteServico
    {
        private IClienteRepositorio _repositorio;
        private int menorQue = 1;

        public ClienteServico(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Cliente Adicionar(Cliente entidade)
        {
            entidade.Validar();

            return _repositorio.Salvar(entidade);
        }

        public Cliente Atualizar(Cliente entidade)
        {
            if (entidade.Id < menorQue)
                throw new IdentificadorIndefinidoExcecao();

            entidade.Validar();

            return _repositorio.Atualizar(entidade);
        }

        public Cliente BuscarPorId(long id)
        {
            if (id < menorQue)
                throw new IdentificadorIndefinidoExcecao();

            return _repositorio.BuscarPorId(id);
        }

        public Cliente BuscarPorTelefone(string telefone)
        {
            if (string.IsNullOrEmpty(telefone))
                throw new ClienteTelefoneNuloOuVazioExcecao();

            return _repositorio.BuscarPorTelefone(telefone);
        }

        public List<Cliente> Listagem()
        {
            return _repositorio.Listagem() as List<Cliente>;
        }

        public void Excluir(Cliente entidade)
        {
            if (entidade.Id < menorQue)
                throw new IdentificadorIndefinidoExcecao();

            _repositorio.Excluir(entidade);
        }

        public bool VerificarClienteComTelefoneRepetido(Cliente cliente)
        {
            return _repositorio.VerificarClienteComTelefoneRepetido(cliente);
        }
    }
}
