using Floriani.ORM.Dominio.Funcionalidades.Cargos;
using Floriani.ORM.Dominio.Funcionalidades.Departamentos;
using Floriani.ORM.Dominio.Funcionalidades.Dependentes;
using Floriani.ORM.Dominio.Funcionalidades.Funcionarios;
using Floriani.ORM.Dominio.Funcionalidades.Projetos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.Orm.Infra.Dados.Contexto
{
    public class FlorianiOrmContexto : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        public FlorianiOrmContexto() : base("MF_ORM_Floriani")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Projeto>().HasMany(f => f.Funcionarios)
                .WithMany(p => p.Projetos)
                .Map(aa => aa.MapLeftKey("FuncionarioId")
                .MapRightKey("ProjetoId")
                .ToTable("TBProjetosFuncionarios"));

            modelBuilder.Entity<Funcionario>().HasMany(f => f.Dependentes)
                .WithMany(d => d.Independentes)
                .Map(bb => bb.MapLeftKey("DependenteId")
                .MapRightKey("FuncionarioId")
                .ToTable("TBFuncionariosDependentes"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
