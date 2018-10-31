using Floriani.ORM.Dominio.Funcionalidades.Dependentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Comum.Base.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Dependente DependenteValido()
        {
            var dependente = new Dependente
            {
                Id = 1,
                Nome = "Zé",
                Idade = 21,
            };
            return dependente;
        }
    }
}
