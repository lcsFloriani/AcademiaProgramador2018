using Floriani.ORM.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Dominio.Funcionalidades.Departamentos
{
    public interface IDepartamentoRepositorio : IRepositorio<Departamento>
    {
        ICollection<Departamento> BuscarPorDescricao(string descricao);
    }
}
