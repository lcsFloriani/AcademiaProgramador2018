using Orm.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Orm.Dominio.Features.Enderecos
{
    [ExcludeFromCodeCoverage]
    public class EnderecoCidadeEmBrancoException : BusinessException
    {
        public EnderecoCidadeEmBrancoException() : base("Cidade não pode ser em branco")
        {
        }
    }
}
