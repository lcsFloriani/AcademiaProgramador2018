using Floriani.ORM.Dominio.Base;
using Floriani.ORM.Dominio.Funcionalidades.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Dominio.Funcionalidades.Projetos
{
    public class Projeto : Entidade
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }


        public Projeto() => Funcionarios = new List<Funcionario>();
    }
}
