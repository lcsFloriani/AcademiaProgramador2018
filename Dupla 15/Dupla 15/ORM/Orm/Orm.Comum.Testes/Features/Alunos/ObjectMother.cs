using Orm.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.Comum.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Aluno AlunoValido() => new Aluno
        {
            Id = 1,
            Nome = "Luis",
            DataNascimento = DateTime.Now.AddYears(-22),
            Endereco = EnderecoValido(),
            Turma = TurmaValida()
        };
        public static Aluno AlunoNomeEmBranco() => new Aluno
        {
            Id = 1,
            Nome = "",
            DataNascimento = DateTime.Now.AddYears(-22),
            Endereco = EnderecoValido(),
            Turma = TurmaValida()
        };
        public static Aluno AlunoDataDeNascimentoInvalida() => new Aluno
        {
            Id = 1,
            Nome = "Luis",
            DataNascimento = DateTime.Now.AddDays(+1),
            Endereco = EnderecoValido(),
            Turma = TurmaValida()
        };
    }
}
