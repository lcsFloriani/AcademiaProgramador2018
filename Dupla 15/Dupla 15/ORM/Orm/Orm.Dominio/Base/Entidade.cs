using System.Diagnostics.CodeAnalysis;

namespace Orm.Dominio.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class Entidade
    {
        public long Id { get; set; }

        public abstract void Validar();

    }
}
