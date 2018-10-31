using Floriani.Orm.Infra.Dados.Contexto;
using Floriani.ORM.Dominio.Funcionalidades.Departamentos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.Orm.Infra.Dados.Funcionalidades.Departamentos
{
    public class DepartamentoRepositorio : IDepartamentoRepositorio
    {
        private FlorianiOrmContexto _contexto;

        public DepartamentoRepositorio(FlorianiOrmContexto contexto)
        {
            _contexto = contexto;
        }
        public Departamento Atualizar(Departamento departamento)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(departamento);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Departamentos.Attach(departamento);

            _contexto.SaveChanges();

            return departamento;
        }

        public ICollection<Departamento> BuscarPorDescricao(string descricao) =>
            _contexto.Departamentos.Where(c => c.Descricao.Contains(descricao)).ToList();

        public void Deletar(Departamento departamento)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(departamento);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Departamentos.Attach(departamento);

            _contexto.Departamentos.Remove(departamento);

            _contexto.SaveChanges();
        }

        public Departamento Inserir(Departamento departamento)
        {
            departamento = _contexto.Departamentos.Add(departamento);
            _contexto.SaveChanges();
            return departamento;
        }

        public Departamento PegarPorId(long id) => _contexto.Departamentos.Find(id);

        public ICollection<Departamento> PegarTodos() => _contexto.Departamentos.ToList();
    }
}
