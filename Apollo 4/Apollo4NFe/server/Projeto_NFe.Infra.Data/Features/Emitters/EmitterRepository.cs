using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Emitters;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.Emitters
{
    public class EmitterRepository : IEmitterRepository
    {
        private ProjetoNFeContext _context;
        private long _affectedRows = 0;

        public EmitterRepository(ProjetoNFeContext context)
        {
            _context = context;
        }

        public Emitter Save(Emitter emitter)
        {
            emitter = _context.Emitters.Add(emitter);
            _context.SaveChanges();

            return emitter;
        }

        public bool Update(Emitter emitter)
        {
            _context.Entry(emitter).State = EntityState.Modified;
            return _context.SaveChanges() > _affectedRows;
        }

        public Emitter Get(long id)
        {
            return _context.Emitters.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<Emitter> GetAll()
        {
            return _context.Emitters;
        }

        public IQueryable<Emitter> GetAll(int size)
        {
            return _context.Emitters.Take(size);
        }

        public bool Delete(long emitterId)
        {
            Emitter emitter = _context.Emitters.FirstOrDefault(e => e.Id == emitterId);
            if (emitter == null)
                throw new NotFoundException();
            _context.Entry(emitter).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }

        public bool CheckDependency(Emitter emitter)
        {
            int count = _context.InvoicesInProcess.Where(n => n.EmitterId == emitter.Id).Count();

            return count > _affectedRows;
        }
    }
}
