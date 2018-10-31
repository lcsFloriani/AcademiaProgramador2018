using Orm.Dominio.Exceptions;
using Orm.Dominio.Features.Enderecos;
using System.Collections.Generic;

namespace Orm.Aplicacao.Features.Enderecos
{
    public class EnderecoServico
    {
        private IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoServico(IEnderecoRepositorio repositorio)
        {
            _enderecoRepositorio = repositorio;
        }

        public Endereco Salvar(Endereco endereco)
        {
            endereco.Validar();
            return _enderecoRepositorio.Salvar(endereco);
        }

        public Endereco Atualizar(Endereco endereco)
        {
            if (endereco.Id <= 0) throw new IdentifierUndefinedException();

            endereco.Validar();

            return _enderecoRepositorio.Atualizar(endereco);
        }

        public IList<Endereco> PegarTodos() => _enderecoRepositorio.PegarTodos();

        public Endereco PegarPorId(int id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return _enderecoRepositorio.PegarPorId(id);
        }

        public void Deletar(Endereco endereco)
        {
            if (endereco.Id == 0)
                throw new IdentifierUndefinedException();

            _enderecoRepositorio.Deletar(endereco);
        }
    }
}
