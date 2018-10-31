using ORM01.Dominio.Features.Alunos;
using ORM01.Dominio.Features.Enderecos;
using ORM01.Dominio.Features.Turmas;
using ORM01.Infra.Configuracoes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Infra
{
    public class ContextORM : DbContext
    {
        public DbSet<Aluno> AlunoContext { get; set; }

        public DbSet<Endereco> EnderecoContext { get; set; }

        public DbSet<Turma> TurmaContext { get; set; }
        public ContextORM() : base("ORM01")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            
            modelBuilder.Entity<Turma>()
                .ToTable("TBTurma")
                .Property(p => p.Descricao)
                  .HasColumnName("Descricao")
                  .HasColumnType("varchar")
                  .HasMaxLength(150)
                  .IsRequired();

            modelBuilder.Entity<Endereco>()
               .ToTable("TBEndereco");

            modelBuilder.Configurations.Add(new ConfiguracaoAluno());
        }
    }
}
