using Orm.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Orm.Dominio.Features.Alunos
{
    [ExcludeFromCodeCoverage]
    public class AlunoNomeEmBrancoException : BusinessException
    {
        public AlunoNomeEmBrancoException() : base("Aluno não pode ter nome em branco")
        {
        }
    }
}
