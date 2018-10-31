using Floriani.ORM.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floriani.ORM.Dominio.Funcionalidades.Funcionarios
{
    public interface IFuncionarioRepositorio : IRepositorio<Funcionario>
    {
        ICollection<Funcionario> BuscarPorNome(string nome);
    }
}
