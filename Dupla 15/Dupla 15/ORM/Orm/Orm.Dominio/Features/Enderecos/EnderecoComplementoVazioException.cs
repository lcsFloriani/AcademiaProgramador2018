using Orm.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Orm.Dominio.Features.Enderecos
{
    [ExcludeFromCodeCoverage]
    public class EnderecoComplementoVazioException : BusinessException
    {
        public EnderecoComplementoVazioException() : base("O complemento não pode ser vazio")
        {
        }
    }
}