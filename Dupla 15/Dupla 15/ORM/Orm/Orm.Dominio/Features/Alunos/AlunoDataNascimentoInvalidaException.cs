using Orm.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Orm.Dominio.Features.Alunos
{
    [ExcludeFromCodeCoverage]
    public class AlunoDataNascimentoInvalidaException : BusinessException
    {
        public AlunoDataNascimentoInvalidaException() : base("Data de Nascimento não pode ser maior que a data atual")
        {
        }
    }
}
