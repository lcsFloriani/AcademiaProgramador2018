using Orm.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Orm.Dominio.Features.Enderecos
{
    [ExcludeFromCodeCoverage]
    public class EnderecoBairroEmBrancoException : BusinessException
    {
        public EnderecoBairroEmBrancoException() : base("Bairro não pode ser em branco")
        {
        }
    }
}
