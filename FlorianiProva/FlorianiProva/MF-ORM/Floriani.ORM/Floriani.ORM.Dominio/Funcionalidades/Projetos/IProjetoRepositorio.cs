using Floriani.ORM.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Dominio.Funcionalidades.Projetos
{
    public interface IProjetoRepositorio : IRepositorio<Projeto>
    {
        ICollection<Projeto> BuscarPorNome(string nome);
    }
}
