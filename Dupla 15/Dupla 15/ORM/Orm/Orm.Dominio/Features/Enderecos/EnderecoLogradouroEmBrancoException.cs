using Orm.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Orm.Dominio.Features.Enderecos
{
    [ExcludeFromCodeCoverage]
    public class EnderecoLogradouroEmBrancoException : BusinessException
    {
        public EnderecoLogradouroEmBrancoException() : base("Logradouro não pode estar em branco")
        {
        }
    }
}
