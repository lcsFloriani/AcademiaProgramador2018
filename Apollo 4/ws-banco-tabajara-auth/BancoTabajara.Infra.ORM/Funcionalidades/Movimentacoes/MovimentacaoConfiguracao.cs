using BancoTabajara.Dominio.Funcionalidades.Movimentacoes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Infra.ORM.Funcionalidades.Movimentacoes
{
    public class MovimentacaoConfiguracao : EntityTypeConfiguration<Movimentacao>
    {
        public MovimentacaoConfiguracao()
        {
            this.ToTable("TBMovimentacao");

            this.HasOptional(m => m.Conta).WithMany(c => c.Movimentacoes).HasForeignKey(m => m.ContaId).WillCascadeOnDelete(true);
        }
    }
}
