using Floriani.Orm.Infra.Dados.Contexto;
using Floriani.ORM.Dominio.Funcionalidades.Projetos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.Orm.Infra.Dados.Funcionalidades.Projetos
{
    public class ProjetoRepositorio : IProjetoRepositorio
    {
        private FlorianiOrmContexto _contexto;
        public ProjetoRepositorio(FlorianiOrmContexto contexto)
        {
            _contexto = contexto;
        }
        public Projeto Atualizar(Projeto entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Projetos.Attach(entidade);

            _contexto.SaveChanges();

            return entidade;
        }

        public ICollection<Projeto> BuscarPorNome(string nome) =>
            _contexto.Projetos.Where(p => p.Nome.Contains(nome)).ToList();

        public void Deletar(Projeto entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Projetos.Attach(entidade);

            _contexto.Projetos.Remove(entidade);

            _contexto.SaveChanges();
        }

        public Projeto Inserir(Projeto entidade)
        {
            entidade = _contexto.Projetos.Add(entidade);
            _contexto.SaveChanges();

            return entidade;
        }

        public Projeto PegarPorId(long id) => _contexto.Projetos.Find(id);

        public ICollection<Projeto> PegarTodos() => _contexto.Projetos.ToList();
    }
}
