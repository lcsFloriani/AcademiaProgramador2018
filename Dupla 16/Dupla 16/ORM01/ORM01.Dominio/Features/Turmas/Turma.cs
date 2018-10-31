using ORM01.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM01.Dominio.Features.Turmas
{
    public class Turma
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual void Validar()
        {
            ValidarDescricao();
        }

        private void ValidarDescricao()
        {
            if (String.IsNullOrEmpty(Descricao))
                throw new DescricaoInvalidaException();
        }
    }
}
