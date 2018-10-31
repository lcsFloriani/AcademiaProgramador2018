using Floriani.ORM.Dominio.Funcionalidades.Projetos;
using System;

namespace Floriani.ORM.Comum.Base.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Projeto ProjetoValido()
        {
            var projeto = new Projeto
            {
                Nome = "Academia do Programador",
                DataInicio = DateTime.Now.AddMonths(-4)
            };
            projeto.Funcionarios.Add(FuncionarioValido());
            return projeto;
        }
    }
}
