using Floriani.ORM.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Dominio.Funcionalidades.Cargos
{
    public interface ICargoRepositorio : IRepositorio<Cargo>
    {
        ICollection<Cargo> BuscarPorDescricao(string descricao);
    }
}
