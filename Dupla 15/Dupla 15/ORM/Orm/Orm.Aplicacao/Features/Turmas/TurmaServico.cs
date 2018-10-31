using Orm.Dominio.Exceptions;
using Orm.Dominio.Features.Turmas;
using System.Collections.Generic;

namespace Orm.Aplicacao.Features.Turmas
{
    public class TurmaServico
    {
        private ITurmaRepositorio _turmaRepositorio;

        public TurmaServico(ITurmaRepositorio repositorio)
        {
            _turmaRepositorio = repositorio;
        }

        public Turma Salvar(Turma turma)
        {
            turma.Validar();
            return _turmaRepositorio.Salvar(turma);
        }

        public Turma Atualizar(Turma turma)
        {
            if (turma.Id <= 0) throw new IdentifierUndefinedException();

            turma.Validar();

            return _turmaRepositorio.Atualizar(turma);
        }

        public IList<Turma> PegarTodos() => _turmaRepositorio.PegarTodos();

        public Turma PegarPorId(int id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return _turmaRepositorio.PegarPorId(id);
        }

        public void Deletar(Turma turma)
        {
            if (turma.Id == 0)
                throw new IdentifierUndefinedException();

            _turmaRepositorio.Deletar(turma);
        }
    }
}
