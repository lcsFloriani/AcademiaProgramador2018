using System.Collections.Generic;

namespace BancoTabajara.Dominio.Funcionalidades.Usuarios
{
    public static class BaseUsuarios
    {
        public static IEnumerable<Usuario> Usuarios()
        {
            return new List<Usuario>
        {
            new Usuario { Nome = "Fulano", Senha = "1234" },
            new Usuario { Nome = "Beltrano", Senha = "5678" },
            new Usuario { Nome = "Sicrano", Senha = "0912" }
        };
        }
    }
}
