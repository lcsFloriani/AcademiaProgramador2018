using Floriani.ORM.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Dominio.Funcionalidades.Dependentes
{
    public interface IDependenteRepositorio : IRepositorio<Dependente>
    {
        ICollection<Dependente> BuscarPorNome(string nome);
    }
}
