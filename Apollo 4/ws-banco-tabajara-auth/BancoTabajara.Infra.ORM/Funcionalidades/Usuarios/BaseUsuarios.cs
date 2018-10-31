using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTabajara.Infra.ORM.Funcionalidades.Usuarios
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
