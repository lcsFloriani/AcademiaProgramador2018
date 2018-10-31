using Floriani.ORM.Dominio.Funcionalidades.Departamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Comum.Base.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Departamento DepartamentoValido() => new Departamento
        {
            Id = 1,
            Descricao = "Administração"
        };
    }
}
