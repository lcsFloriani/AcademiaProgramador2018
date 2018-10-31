using Floriani.ORM.Dominio.Base;
using Floriani.ORM.Dominio.Funcionalidades.Funcionarios;
using System.Collections.Generic;

namespace Floriani.ORM.Dominio.Funcionalidades.Dependentes
{
    public class Dependente : Entidade
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public virtual ICollection<Funcionario> Independentes { get; set; }
        
        public Dependente() => Independentes = new List<Funcionario>();
    }
}
