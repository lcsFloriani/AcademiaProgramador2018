using Floriani.ORM.Dominio.Base;
using Floriani.ORM.Dominio.Funcionalidades.Cargos;
using Floriani.ORM.Dominio.Funcionalidades.Departamentos;
using Floriani.ORM.Dominio.Funcionalidades.Dependentes;
using Floriani.ORM.Dominio.Funcionalidades.Projetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Dominio.Funcionalidades.Funcionarios
{
    public class Funcionario : Entidade
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public virtual Cargo Cargo { get; set; }
        public string CPF { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<Dependente> Dependentes { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
        public Funcionario()
        {
            Dependentes = new List<Dependente>();
            Projetos = new List<Projeto>();
        }
        
    }
}
