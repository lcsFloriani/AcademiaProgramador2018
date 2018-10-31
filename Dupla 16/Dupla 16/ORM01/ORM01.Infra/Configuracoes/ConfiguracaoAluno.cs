using ORM01.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Infra.Configuracoes
{
    public class ConfiguracaoAluno : EntityTypeConfiguration<Aluno>
    {
        public ConfiguracaoAluno()
        {

            ToTable("TBAluno")
           .Property(p => p.Nome)
             .HasColumnType("varchar")
             .HasMaxLength(150)
             .IsRequired();

            Property(p => p.Aniversario)
            .HasColumnName("Aniversario")
              .HasColumnType("datetime")
              .IsRequired();

            Property(p => p.Aniversario)
                .HasColumnName("Aniversario")
                 .HasColumnType("datetime")
                 .IsRequired();

            HasRequired(a => a.Turma);
            HasRequired(a => a.Endereco);
        }
    }
}
