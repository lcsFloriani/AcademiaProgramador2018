using ORM01.Dominio.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Infra.Data.Features.Enderecos
{
    public class EnderecoDataRepository : IEnderecoRepository
    {
        ContextORM _ContextORM;
        public EnderecoDataRepository(ContextORM contextORM)
        {
            _ContextORM = contextORM;
        }
        public void Add(Endereco endereco)
        {
            _ContextORM.EnderecoContext.Add(endereco);

            _ContextORM.SaveChanges();
        }

        public void Delete(Endereco endereco)
        {
            DbEntityEntry dbEntityEntry = _ContextORM.Entry(endereco);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _ContextORM.EnderecoContext.Attach(endereco);
            }

            _ContextORM.EnderecoContext.Remove(endereco);

            _ContextORM.SaveChanges();
        }

        public List<Endereco> GetAll()
        {
            return _ContextORM.EnderecoContext.ToList();
        }

        public Endereco GetById(long Id)
        {
            return _ContextORM.EnderecoContext.Find(Id);
        }

        public void Update(Endereco endereco)
        {
            DbEntityEntry dbEntityEntry = _ContextORM.Entry(endereco);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _ContextORM.EnderecoContext.Attach(endereco);
            }

            _ContextORM.SaveChanges();
        }
    }
}
