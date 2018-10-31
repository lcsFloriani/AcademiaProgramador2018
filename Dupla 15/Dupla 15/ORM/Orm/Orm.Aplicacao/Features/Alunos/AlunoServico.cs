using Orm.Dominio.Exceptions;
using Orm.Dominio.Features.Alunos;
using System.Collections.Generic;

namespace Orm.Aplicacao.Features.Alunos
{
    public class AlunoServico
    {
        private IAlunoRepositorio _alunoRepositorio;

        public AlunoServico(IAlunoRepositorio repositorio)
        {
            _alunoRepositorio = repositorio;
        }

        public Aluno Salvar(Aluno aluno)
        {
            aluno.Validar();
            return _alunoRepositorio.Salvar(aluno);
        }

        public Aluno Atualizar(Aluno aluno)
        {
            if (aluno.Id <= 0) throw new IdentifierUndefinedException();

            aluno.Validar();

            return _alunoRepositorio.Atualizar(aluno);
        }

        public IList<Aluno> PegarTodos() => _alunoRepositorio.PegarTodos();

        public Aluno PegarPorId(int id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return _alunoRepositorio.PegarPorId(id);
        }

        public void Deletar(Aluno aluno)
        {
            if (aluno.Id == 0)
                throw new IdentifierUndefinedException();

            _alunoRepositorio.Deletar(aluno);
        }
    }
}
