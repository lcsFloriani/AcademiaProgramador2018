using Projeto_NFe.Domain.Enums;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Features.Conveyors;
using Projeto_NFe.Infra.CNPJ;
using Projeto_NFe.Infra.CPF;
using Projeto_NFe.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Features.Conveyors
{
    public class ConveyorsRepository : IConveyorRepository
    {
        private ProjetoNFeContext _context;
        private long _affectedRows = 0;

        public ConveyorsRepository(ProjetoNFeContext context)
        {
            _context = context;
        }

        public Conveyor Save(Conveyor conveyor)
        {
            conveyor = _context.Conveyors.Add(conveyor);
            _context.SaveChanges();

            return conveyor;
        }

        public bool Update(Conveyor conveyor)
        {
            _context.Entry(conveyor).State = EntityState.Modified;
            return _context.SaveChanges() > _affectedRows;
        }

        public Conveyor Get(long id)
        {
            return _context.Conveyors.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<Conveyor> GetAll()
        {
            return _context.Conveyors;
        }

        public IQueryable<Conveyor> GetAll(int size)
        {
            return _context.Conveyors.Take(size);
        }

        public bool Delete(long conveyorId)
        {
            Conveyor conveyor = _context.Conveyors.FirstOrDefault(e => e.Id == conveyorId);
            if (conveyor == null)
                throw new NotFoundException();
            _context.Entry(conveyor).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }

        public bool CheckDependency(Conveyor conveyor)
        {
            int count = _context.InvoicesInProcess.Where(n => n.ConveyorId == conveyor.Id).Count();

            return count > _affectedRows;
        }
    }
}
