using Floriani.ORM.Dominio.Funcionalidades.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Comum.Base.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Funcionario FuncionarioValido()
        {
            var funcionario = new Funcionario
            {
                Id = 1,
                Nome = "Lucas",
                Cargo = CargoValido(),
                Departamento = DepartamentoValido(),
                Idade = 22
            };

            //Caso funcionario tenha Dependentes ou Projetos está dando stackoverflowException
            // funcionario.Dependentes.Add(DependenteValido());
            //funcionario.Projetos.Add(ProjetoValido());
            return funcionario;
        }
    }
}
