using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM01.Dominio.Features.Turmas;

namespace ORM01.Aplicacao.Features.Turmas
{
    public class TurmaService : ITurmaService
    {
        private ITurmaRepository _repository;

        public TurmaService(ITurmaRepository repository)
        {
            _repository = repository;
        }

        public void Add(Turma turma)
        {
            turma.Validar();
            _repository.Add(turma);
        }

        public void Delete(Turma turma)
        {
            _repository.Delete(turma);
        }

        public List<Turma> GetAll()
        {
            return _repository.GetAll();
        }

        public Turma GetById(long Id)
        {
            return _repository.GetById(Id);
        }

        public void Update(Turma turma)
        {
            turma.Validar();
            _repository.Update(turma);
        }
    }
}
