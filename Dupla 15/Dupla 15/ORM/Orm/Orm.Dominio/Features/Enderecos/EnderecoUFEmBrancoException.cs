using Orm.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Orm.Dominio.Features.Enderecos
{
    [ExcludeFromCodeCoverage]
    public class EnderecoUFEmBrancoException : BusinessException
    {
        public EnderecoUFEmBrancoException() : base("UF não pode estar em branco")
        {
        }
    }
}
