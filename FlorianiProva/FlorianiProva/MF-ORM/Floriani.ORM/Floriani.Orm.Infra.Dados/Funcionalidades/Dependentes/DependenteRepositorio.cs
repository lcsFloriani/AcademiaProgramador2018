using Floriani.Orm.Infra.Dados.Contexto;
using Floriani.ORM.Dominio.Funcionalidades.Dependentes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.Orm.Infra.Dados.Funcionalidades.Dependentes
{
    public class DependenteRepositorio : IDependenteRepositorio
    {
        private FlorianiOrmContexto _contexto;
        public DependenteRepositorio(FlorianiOrmContexto contexto)
        {
            _contexto = contexto;
        }
        public Dependente Atualizar(Dependente dependente)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(dependente);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Dependentes.Attach(dependente);

            _contexto.SaveChanges();

            return dependente;
        }

        public ICollection<Dependente> BuscarPorNome(string nome) =>
            _contexto.Dependentes.Where(c => c.Nome.Contains(nome)).ToList();

        public void Deletar(Dependente dependente)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(dependente);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Dependentes.Attach(dependente);

            _contexto.Dependentes.Remove(dependente);

            _contexto.SaveChanges();
        }

        public Dependente Inserir(Dependente dependente)
        {
            dependente = _contexto.Dependentes.Add(dependente);
            _contexto.SaveChanges();
            return dependente;
        }

        public Dependente PegarPorId(long id) => _contexto.Dependentes.Find(id);
        public ICollection<Dependente> PegarTodos() => _contexto.Dependentes.ToList();
    }
}
