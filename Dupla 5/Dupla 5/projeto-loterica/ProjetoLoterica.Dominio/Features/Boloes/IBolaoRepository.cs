using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Dominio.Features.Boloes
{
    public interface IBolaoRepository
    {
        Bolao Add(Bolao bolao);
        Bolao Update(Bolao bolao);
        Bolao Get(long id);
        IList<Bolao> GetAll();
        void Delete(Bolao bolao);
    }
}
