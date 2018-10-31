using ORM01.Dominio.Features.Turmas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Infra.Data.Features.Turmas
{
    public class TurmaDataRepository : ITurmaRepository
    {
        ContextORM _contextORM;
        public TurmaDataRepository(ContextORM contextORM)
        {
            _contextORM = contextORM;
        }
        public void Add(Turma turma)
        {
            _contextORM.TurmaContext.Add(turma);

            _contextORM.SaveChanges();
        }

        public void Delete(Turma turma)
        {
            DbEntityEntry dbEntityEntry = _contextORM.Entry(turma);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contextORM.TurmaContext.Attach(turma);
            }

            _contextORM.TurmaContext.Remove(turma);

            _contextORM.SaveChanges();
        }

        public List<Turma> GetAll()
        {
            return _contextORM.TurmaContext.ToList();
        }

        public Turma GetById(long Id)
        {
            return _contextORM.TurmaContext.Find(Id);
        }

        public void Update(Turma turma)
        {
            DbEntityEntry dbEntityEntry = _contextORM.Entry(turma);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contextORM.TurmaContext.Attach(turma);
            }

            _contextORM.SaveChanges();
        }
    }
}
