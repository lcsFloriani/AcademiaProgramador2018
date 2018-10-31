using Orm.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Orm.Dominio.Features.Turmas
{
    [ExcludeFromCodeCoverage]
    public class TurmaDescricaoVaziaException : BusinessException
    {
        public TurmaDescricaoVaziaException() : base("A descrição não deve ser vazia")
        {
        }
    }
}