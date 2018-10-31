using Orm.Dominio.Features.Turmas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.Comum.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Turma TurmaComDescricaoEmBranco() => new Turma
        {
            Descricao = "",
            Id = 1
        };
        public static Turma TurmaValida() => new Turma
        {
            Id = 1,
            Descricao = "desc"
        };
    }
}
