using Floriani.Orm.Infra.Dados.Contexto;
using Floriani.ORM.Dominio.Funcionalidades.Funcionarios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.Orm.Infra.Dados.Funcionalidades.Funcionarios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private FlorianiOrmContexto _contexto;
        public FuncionarioRepositorio(FlorianiOrmContexto contexto)
        {
            _contexto = contexto;
        }
        public Funcionario Atualizar(Funcionario funcionario)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(funcionario);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Funcionarios.Attach(funcionario);

            _contexto.SaveChanges();

            return funcionario;
        }

        public ICollection<Funcionario> BuscarPorNome(string nome) =>
            _contexto.Funcionarios.Where(c => c.Nome.Contains(nome)).ToList();

        public void Deletar(Funcionario funcionario)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(funcionario);

            if (dbEntityEntry.State == EntityState.Detached)
                _contexto.Funcionarios.Attach(funcionario);

            _contexto.Funcionarios.Remove(funcionario);

            _contexto.SaveChanges();
        }

        public Funcionario Inserir(Funcionario funcionario)
        {
            funcionario = _contexto.Funcionarios.Add(funcionario);
            _contexto.SaveChanges();
            return funcionario;
        }

        public Funcionario PegarPorId(long id) => _contexto.Funcionarios.Find(id);

        public ICollection<Funcionario> PegarTodos() => _contexto.Funcionarios.ToList();
    }
}
