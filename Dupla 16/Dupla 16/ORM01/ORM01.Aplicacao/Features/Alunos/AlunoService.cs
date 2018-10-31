using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM01.Dominio.Features.Alunos;

namespace ORM01.Aplicacao.Features.Alunos
{
    public class AlunoService : IAlunoService
    {
        private IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public void Add(Aluno aluno)
        {
            aluno.Validar();
             _repository.Add(aluno);
        }

        public void Delete(Aluno aluno)
        {
            _repository.Delete(aluno);
        }

        public List<Aluno> GetAll()
        {
            return _repository.GetAll();
        }

        public Aluno GetById(long Id)
        {
            return _repository.GetById(Id);
        }

        public void Update(Aluno aluno)
        {
            aluno.Validar();
             _repository.Update(aluno);
        }
    }
}
