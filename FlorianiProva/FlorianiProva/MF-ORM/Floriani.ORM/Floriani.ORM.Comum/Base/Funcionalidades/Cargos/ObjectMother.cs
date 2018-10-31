using Floriani.ORM.Dominio.Funcionalidades.Cargos;

namespace Floriani.ORM.Comum.Base.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Cargo CargoValido() => new Cargo
        {
            Id = 1,
            Descricao = "Estagiário"
        };
    }
}
