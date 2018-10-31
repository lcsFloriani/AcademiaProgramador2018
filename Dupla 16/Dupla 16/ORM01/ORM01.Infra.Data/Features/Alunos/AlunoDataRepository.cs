using ORM01.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Infra.Data.Features.Alunos
{
    public class AlunoDataRepository : IAlunoRepository
    {
        ContextORM _ContextORM;
        public AlunoDataRepository(ContextORM contextORM)
        {
            _ContextORM = contextORM;
        }
        public void Add(Aluno aluno)
        {
            _ContextORM.AlunoContext.Add(aluno);

            _ContextORM.SaveChanges();
        }

        public void Delete(Aluno aluno)
        {
            DbEntityEntry dbEntityEntry = _ContextORM.Entry(aluno);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _ContextORM.AlunoContext.Attach(aluno);
            }

            _ContextORM.AlunoContext.Remove(aluno);

            _ContextORM.SaveChanges();
        }

        public List<Aluno> GetAll()
        {
            return _ContextORM.AlunoContext.ToList();
        }

        public Aluno GetById(long Id)
        {
            return _ContextORM.AlunoContext.Find(Id);
        }

        public void Update(Aluno aluno)
        {
            DbEntityEntry dbEntityEntry = _ContextORM.Entry(aluno);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _ContextORM.AlunoContext.Attach(aluno);
            }

            _ContextORM.SaveChanges();
        }
    }
}
