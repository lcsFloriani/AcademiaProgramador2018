using Floriani.Orm.Infra.Dados.Contexto;
using Floriani.ORM.Dominio.Funcionalidades.Cargos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.Orm.Infra.Dados.Funcionalidades.Cargos
{
    public class CargoRepositorio : ICargoRepositorio
    {
        private FlorianiOrmContexto _contexto;
        public CargoRepositorio(FlorianiOrmContexto contexto)
        {
            _contexto = contexto;
        }
        public Cargo Atualizar(Cargo cargo)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(cargo);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Cargos.Attach(cargo);

            _contexto.SaveChanges();

            return cargo;
        }

        public ICollection<Cargo> BuscarPorDescricao(string descricao) =>      
            _contexto.Cargos.Where(c => c.Descricao.Contains(descricao)).ToList();        

        public void Deletar(Cargo cargo)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(cargo);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Cargos.Attach(cargo);

            _contexto.Cargos.Remove(cargo);

            _contexto.SaveChanges();
        }

        public Cargo Inserir(Cargo cargo)
        {
            cargo = _contexto.Cargos.Add(cargo);

            _contexto.SaveChanges();
            return cargo;
        }

        public Cargo PegarPorId(long id) => _contexto.Cargos.Find(id);

        public ICollection<Cargo> PegarTodos() => _contexto.Cargos.ToList();
    }
}
